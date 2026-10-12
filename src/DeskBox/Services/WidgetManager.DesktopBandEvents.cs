// Copyright (c) DeskBox. All rights reserved.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DeskBox.Platform;

namespace DeskBox.Services;

/// <summary>
/// Event-driven desktop-band bedding repair.
///
/// Resting widgets are owned by SHELLDLL_DefView (DesktopPinned mode, and
/// Dynamic mode with "keep widgets visible on Show Desktop"). When Explorer
/// shows a desktop-owned window — the "Delete folder" / "Empty Recycle Bin"
/// confirmation (#32770), a file-operation dialog, a launch hosted by the
/// desktop — it raises the DefView owner band and the widgets ride along
/// above every application. Nothing in the daily path pulls them back.
///
/// Instead of polling, out-of-context WinEvent hooks observe exactly the
/// moments that can displace the band:
///   * EVENT_SYSTEM_FOREGROUND — a desktop-owned window (or the desktop)
///     gains foreground, or foreground leaves it again;
///   * EVENT_OBJECT_SHOW / HIDE / DESTROY — a window owned by
///     Progman/WorkerW/DefView appears or disappears;
///   * EVENT_OBJECT_REORDER — the shell desktop windows are reordered.
/// Each signal queues one debounced, verified re-bed (the existing
/// VerifyDesktopPinnedBedding predicate: nothing moves unless a foreign
/// application window really sits below a widget). All transactions are
/// SWP_NOACTIVATE, so focus is never stolen.
/// </summary>
public sealed partial class WidgetManager
{
    private const uint EVENT_SYSTEM_FOREGROUND = 0x0003;
    private const uint EVENT_OBJECT_DESTROY = 0x8001;
    private const uint EVENT_OBJECT_SHOW = 0x8002;
    private const uint EVENT_OBJECT_HIDE = 0x8003;
    private const uint EVENT_OBJECT_REORDER = 0x8004;
    private const uint WINEVENT_OUTOFCONTEXT = 0x0000;
    private const uint WINEVENT_SKIPOWNPROCESS = 0x0002;
    private const int OBJID_WINDOW = 0;
    private const int CHILDID_SELF = 0;

    private static readonly TimeSpan DesktopBandRecheckDebounce =
        TimeSpan.FromMilliseconds(150);

    // The native callback is a static UnmanagedCallersOnly entry point
    // (Native AOT safe, no delegate to keep alive); it dispatches to the
    // single live manager.
    private static WidgetManager? s_desktopBandHookOwner;

    private IntPtr _desktopBandForegroundHook;
    private IntPtr _desktopBandObjectHook;
    private bool _desktopBandHooksInstalled;
    private long _desktopBandRecheckGeneration;
    private bool _desktopBandDisturbed;
    private readonly HashSet<IntPtr> _desktopOwnedPopups = new();

    /// <summary>
    /// Installs the hooks once (idempotent). Must run on the UI thread:
    /// out-of-context callbacks are delivered through that thread's message
    /// loop, so every callback already runs on the UI thread.
    /// </summary>
    private void EnsureDesktopBandEventHooksInstalled()
    {
        if (_desktopBandHooksInstalled || App.IsShuttingDown)
        {
            return;
        }

        if (!HasUiThreadAccess())
        {
            UiDispatch.RunOrDefer(EnsureDesktopBandEventHooksInstalled);
            return;
        }

        IntPtr callback = GetDesktopBandWinEventCallback();
        uint flags = WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS;
        _desktopBandForegroundHook = SetWinEventHook(
            EVENT_SYSTEM_FOREGROUND,
            EVENT_SYSTEM_FOREGROUND,
            IntPtr.Zero,
            callback,
            0,
            0,
            flags);
        _desktopBandObjectHook = SetWinEventHook(
            EVENT_OBJECT_DESTROY,
            EVENT_OBJECT_REORDER,
            IntPtr.Zero,
            callback,
            0,
            0,
            flags);
        s_desktopBandHookOwner = this;
        _desktopBandHooksInstalled = true;
        App.Log(
            "[ZOrder] Desktop-band WinEvent hooks installed " +
            $"foreground=0x{_desktopBandForegroundHook.ToInt64():X} " +
            $"object=0x{_desktopBandObjectHook.ToInt64():X}");
    }

    /// <summary>Teardown: unhook before windows close on exit.</summary>
    private void RemoveDesktopBandEventHooks()
    {
        _desktopBandRecheckGeneration++;
        if (_desktopBandForegroundHook != IntPtr.Zero)
        {
            _ = UnhookWinEvent(_desktopBandForegroundHook);
            _desktopBandForegroundHook = IntPtr.Zero;
        }

        if (_desktopBandObjectHook != IntPtr.Zero)
        {
            _ = UnhookWinEvent(_desktopBandObjectHook);
            _desktopBandObjectHook = IntPtr.Zero;
        }

        if (ReferenceEquals(s_desktopBandHookOwner, this))
        {
            s_desktopBandHookOwner = null;
        }

        _desktopOwnedPopups.Clear();
        _desktopBandDisturbed = false;
        _desktopBandHooksInstalled = false;
        ResetBeddingLeakTracking();
    }

    private static unsafe IntPtr GetDesktopBandWinEventCallback() =>
        (IntPtr)(delegate* unmanaged[Stdcall]<IntPtr, uint, IntPtr, int, int, uint, uint, void>)
            &OnDesktopBandWinEvent;

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnDesktopBandWinEvent(
        IntPtr hook,
        uint eventType,
        IntPtr windowHandle,
        int objectId,
        int childId,
        uint eventThread,
        uint eventTime)
    {
        if (windowHandle == IntPtr.Zero ||
            objectId != OBJID_WINDOW ||
            childId != CHILDID_SELF)
        {
            return;
        }

        WidgetManager? owner = s_desktopBandHookOwner;
        if (owner is null || App.IsShuttingDown)
        {
            return;
        }

        try
        {
            owner.HandleDesktopBandWinEvent(eventType, windowHandle);
        }
        catch (Exception ex)
        {
            // An exception must never unwind into user32.
            App.Log($"[ZOrder] Desktop-band WinEvent handler failed: {ex.Message}");
        }
    }

    private void HandleDesktopBandWinEvent(uint eventType, IntPtr windowHandle)
    {
        switch (eventType)
        {
            case EVENT_SYSTEM_FOREGROUND:
                if (IsDesktopOwnedPopup(windowHandle))
                {
                    _desktopOwnedPopups.Add(windowHandle);
                    _desktopBandDisturbed = true;
                    QueueDesktopBandRecheck("desktop-dialog-foreground");
                }
                else if (WidgetLayerService.IsDesktopShellWindowOrOwnedByIt(windowHandle))
                {
                    QueueDesktopBandRecheck("desktop-foreground");
                }
                else if (_desktopBandDisturbed || WidgetLayerService.UsesDesktopPinnedMode())
                {
                    // Foreground left the desktop band: the moment a raised
                    // band would be seen covering the application.
                    QueueDesktopBandRecheck("foreground-left-desktop-band");
                }
                break;

            case EVENT_OBJECT_SHOW:
                if (IsDesktopOwnedPopup(windowHandle))
                {
                    _desktopOwnedPopups.Add(windowHandle);
                    _desktopBandDisturbed = true;
                    QueueDesktopBandRecheck("desktop-dialog-shown");
                }
                break;

            case EVENT_OBJECT_HIDE:
            case EVENT_OBJECT_DESTROY:
                // The window may already be gone; rely on what was seen.
                if (_desktopOwnedPopups.Remove(windowHandle))
                {
                    _desktopBandDisturbed = true;
                    QueueDesktopBandRecheck("desktop-dialog-closed");
                }
                break;

            case EVENT_OBJECT_REORDER:
                if (IsDesktopShellClass(windowHandle))
                {
                    QueueDesktopBandRecheck("desktop-band-reordered");
                }
                break;
        }
    }

    /// <summary>
    /// Debounced (latest request wins) verified re-bed. A one-shot delay,
    /// not a timer: nothing runs unless a hook event fired.
    /// </summary>
    private void QueueDesktopBandRecheck(string reason)
    {
        if (!WidgetLayerService.UsesDesktopBandAttachment() || !HasVisibleWidgets)
        {
            return;
        }

        long generation = ++_desktopBandRecheckGeneration;
        UiDispatch.RunOrDefer(async () =>
        {
            await Task.Delay(DesktopBandRecheckDebounce);
            if (generation != _desktopBandRecheckGeneration || App.IsShuttingDown)
            {
                return;
            }

            // The user is working inside DeskBox (Dynamic-mode raise, a
            // flyout): its own Z-order paths own the group right now.
            IntPtr foregroundRoot = WidgetLayerService.GetForegroundRoot(
                Win32Helper.GetForegroundWindow());
            if (foregroundRoot != IntPtr.Zero &&
                App.Current.IsDeskBoxWindow(foregroundRoot))
            {
                return;
            }

            VerifyDesktopPinnedBedding(reason, requireConfirmation: false);

            // Once every desktop-owned popup is gone and an application holds
            // the foreground, the band disturbance has been repaired.
            _desktopOwnedPopups.RemoveWhere(handle =>
                !Win32Helper.IsWindow(handle) || !Win32Helper.IsWindowVisible(handle));
            if (_desktopOwnedPopups.Count == 0 &&
                foregroundRoot != IntPtr.Zero &&
                !WidgetLayerService.IsDesktopShellWindowOrOwnedByIt(foregroundRoot))
            {
                _desktopBandDisturbed = false;
            }
        });
    }

    /// <summary>
    /// A top-level window (dialog or otherwise) whose owner chain reaches
    /// Progman, WorkerW, or SHELLDLL_DefView, excluding the shell windows
    /// themselves.
    /// </summary>
    private static bool IsDesktopOwnedPopup(IntPtr windowHandle)
    {
        if (!Win32Helper.IsWindow(windowHandle) || IsDesktopShellClass(windowHandle))
        {
            return false;
        }

        IntPtr owner = Win32Helper.GetWindow(windowHandle, Win32Helper.GW_OWNER);
        return owner != IntPtr.Zero &&
               WidgetLayerService.IsDesktopShellWindowOrOwnedByIt(owner);
    }

    private static bool IsDesktopShellClass(IntPtr windowHandle)
    {
        var className = new System.Text.StringBuilder(64);
        int length = Win32Helper.GetClassName(windowHandle, className, className.Capacity);
        if (length <= 0)
        {
            return false;
        }

        string name = className.ToString();
        return name is "Progman" or "WorkerW" or "SHELLDLL_DefView";
    }

    [LibraryImport("user32.dll")]
    private static partial IntPtr SetWinEventHook(
        uint eventMin,
        uint eventMax,
        IntPtr hmodWinEventProc,
        IntPtr pfnWinEventProc,
        uint idProcess,
        uint idThread,
        uint dwFlags);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool UnhookWinEvent(IntPtr hWinEventHook);
}
