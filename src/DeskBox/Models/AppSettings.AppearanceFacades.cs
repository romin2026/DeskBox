using System.Text.Json.Serialization;

namespace DeskBox.Models;

public partial class AppSettings
{

    /// <inheritdoc cref="TodoSettingsSlice.TodoLayoutMode"/>
    public string TodoLayoutMode { get => Todo.TodoLayoutMode; set => Todo.TodoLayoutMode = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoAutoSelectFirstInWideLayout"/>
    public bool TodoAutoSelectFirstInWideLayout { get => Todo.TodoAutoSelectFirstInWideLayout; set => Todo.TodoAutoSelectFirstInWideLayout = value; }

    /// <inheritdoc cref="MusicSettingsSlice.MusicUseArtworkBackdrop"/>
    public bool MusicUseArtworkBackdrop { get => Music.MusicUseArtworkBackdrop; set => Music.MusicUseArtworkBackdrop = value; }

    /// <inheritdoc cref="MusicSettingsSlice.MusicEnableCoverHoverMotion"/>
    public bool MusicEnableCoverHoverMotion { get => Music.MusicEnableCoverHoverMotion; set => Music.MusicEnableCoverHoverMotion = value; }

    /// <inheritdoc cref="MusicSettingsSlice.MusicDisplayMode"/>
    public string MusicDisplayMode { get => Music.MusicDisplayMode; set => Music.MusicDisplayMode = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.LastQuickCaptureFileWidgetId"/>
    public string LastQuickCaptureFileWidgetId { get => QuickCapture.LastQuickCaptureFileWidgetId; set => QuickCapture.LastQuickCaptureFileWidgetId = value; }

    /// <inheritdoc cref="CoreSettingsSlice.GlobalHotkeyEnabled"/>
    public bool GlobalHotkeyEnabled { get => Core.GlobalHotkeyEnabled; set => Core.GlobalHotkeyEnabled = value; }

    /// <inheritdoc cref="CoreSettingsSlice.GlobalHotkeyActivationKind"/>
    public HotkeyActivationKind GlobalHotkeyActivationKind { get => Core.GlobalHotkeyActivationKind; set => Core.GlobalHotkeyActivationKind = value; }

    /// <inheritdoc cref="CoreSettingsSlice.GlobalHotkeyModifiers"/>
    public int GlobalHotkeyModifiers { get => Core.GlobalHotkeyModifiers; set => Core.GlobalHotkeyModifiers = value; }

    /// <inheritdoc cref="CoreSettingsSlice.GlobalHotkeyKey"/>
    public int GlobalHotkeyKey { get => Core.GlobalHotkeyKey; set => Core.GlobalHotkeyKey = value; }

    /// <inheritdoc cref="CoreSettingsSlice.DesktopDoubleClickEnabled"/>
    public bool DesktopDoubleClickEnabled { get => Core.DesktopDoubleClickEnabled; set => Core.DesktopDoubleClickEnabled = value; }

    /// <inheritdoc cref="CoreSettingsSlice.HasCompletedOnboarding"/>
    public bool HasCompletedOnboarding { get => Core.HasCompletedOnboarding; set => Core.HasCompletedOnboarding = value; }

    /// <inheritdoc cref="CoreSettingsSlice.OnboardingStepIndex"/>
    public int OnboardingStepIndex { get => Core.OnboardingStepIndex; set => Core.OnboardingStepIndex = value; }

    /// <inheritdoc cref="CoreSettingsSlice.CompletedOnboardingVersion"/>
    public int CompletedOnboardingVersion { get => Core.CompletedOnboardingVersion; set => Core.CompletedOnboardingVersion = value; }

    /// <inheritdoc cref="CoreSettingsSlice.HasResolvedInitialFileWidgetSetup"/>
    public bool HasResolvedInitialFileWidgetSetup { get => Core.HasResolvedInitialFileWidgetSetup; set => Core.HasResolvedInitialFileWidgetSetup = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.DefaultWidgetWidth"/>
    public double DefaultWidgetWidth { get => WidgetShell.DefaultWidgetWidth; set => WidgetShell.DefaultWidgetWidth = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.DefaultWidgetHeight"/>
    public double DefaultWidgetHeight { get => WidgetShell.DefaultWidgetHeight; set => WidgetShell.DefaultWidgetHeight = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetOpacity"/>
    public double WidgetOpacity { get => WidgetShell.WidgetOpacity; set => WidgetShell.WidgetOpacity = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetMaterialType"/>
    public string WidgetMaterialType { get => WidgetShell.WidgetMaterialType; set => WidgetShell.WidgetMaterialType = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetMaterialIntensity"/>
    public double WidgetMaterialIntensity { get => WidgetShell.WidgetMaterialIntensity; set => WidgetShell.WidgetMaterialIntensity = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetForegroundMode"/>
    public string WidgetForegroundMode { get => WidgetShell.WidgetForegroundMode; set => WidgetShell.WidgetForegroundMode = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetForegroundColor"/>
    public string WidgetForegroundColor { get => WidgetShell.WidgetForegroundColor; set => WidgetShell.WidgetForegroundColor = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetBorderColorMode"/>
    public string WidgetBorderColorMode { get => WidgetShell.WidgetBorderColorMode; set => WidgetShell.WidgetBorderColorMode = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetBorderStyle"/>
    public string WidgetBorderStyle { get => WidgetShell.WidgetBorderStyle; set => WidgetShell.WidgetBorderStyle = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCornerPreference"/>
    public string WidgetCornerPreference { get => WidgetShell.WidgetCornerPreference; set => WidgetShell.WidgetCornerPreference = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetAnimationEffect"/>
    public string WidgetAnimationEffect { get => WidgetShell.WidgetAnimationEffect; set => WidgetShell.WidgetAnimationEffect = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetAnimationSpeed"/>
    public string WidgetAnimationSpeed { get => WidgetShell.WidgetAnimationSpeed; set => WidgetShell.WidgetAnimationSpeed = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetAnimationSlideDirection"/>
    public string WidgetAnimationSlideDirection { get => WidgetShell.WidgetAnimationSlideDirection; set => WidgetShell.WidgetAnimationSlideDirection = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetAnimationEasingIntensity"/>
    public string WidgetAnimationEasingIntensity { get => WidgetShell.WidgetAnimationEasingIntensity; set => WidgetShell.WidgetAnimationEasingIntensity = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetLayerMode"/>
    public string WidgetLayerMode { get => WidgetShell.WidgetLayerMode; set => WidgetShell.WidgetLayerMode = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.KeepWidgetsVisibleOnShowDesktop"/>
    public bool KeepWidgetsVisibleOnShowDesktop { get => WidgetShell.KeepWidgetsVisibleOnShowDesktop; set => WidgetShell.KeepWidgetsVisibleOnShowDesktop = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.DisplayWidgetChromeMode"/>
    public string DisplayWidgetChromeMode { get => WidgetShell.DisplayWidgetChromeMode; set => WidgetShell.DisplayWidgetChromeMode = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.InteractiveWidgetChromeMode"/>
    public string InteractiveWidgetChromeMode { get => WidgetShell.InteractiveWidgetChromeMode; set => WidgetShell.InteractiveWidgetChromeMode = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCollapseBehavior"/>
    public string WidgetCollapseBehavior { get => WidgetShell.WidgetCollapseBehavior; set => WidgetShell.WidgetCollapseBehavior = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.LegacyWidgetCapsuleModeEnabled"/>
    [JsonPropertyName("widgetCapsuleModeEnabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LegacyWidgetCapsuleModeEnabled { get => WidgetShell.LegacyWidgetCapsuleModeEnabled; set => WidgetShell.LegacyWidgetCapsuleModeEnabled = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCompactWidthMode"/>
    public string WidgetCompactWidthMode { get => WidgetShell.WidgetCompactWidthMode; set => WidgetShell.WidgetCompactWidthMode = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCompactExpansionDirection"/>
    public string WidgetCompactExpansionDirection { get => WidgetShell.WidgetCompactExpansionDirection; set => WidgetShell.WidgetCompactExpansionDirection = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCapsuleArrangementMode"/>
    public string WidgetCapsuleArrangementMode { get => WidgetShell.WidgetCapsuleArrangementMode; set => WidgetShell.WidgetCapsuleArrangementMode = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCapsuleBarSpacing"/>
    public double WidgetCapsuleBarSpacing { get => WidgetShell.WidgetCapsuleBarSpacing; set => WidgetShell.WidgetCapsuleBarSpacing = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCapsuleBarPlacement"/>
    public string WidgetCapsuleBarPlacement { get => WidgetShell.WidgetCapsuleBarPlacement; set => WidgetShell.WidgetCapsuleBarPlacement = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCapsuleBarDirection"/>
    public string WidgetCapsuleBarDirection { get => WidgetShell.WidgetCapsuleBarDirection; set => WidgetShell.WidgetCapsuleBarDirection = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCapsuleBarOrder"/>
    public List<string> WidgetCapsuleBarOrder { get => WidgetShell.WidgetCapsuleBarOrder; set => WidgetShell.WidgetCapsuleBarOrder = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCapsuleFreePlacements"/>
    public Dictionary<string, WidgetCompactPlacement> WidgetCapsuleFreePlacements { get => WidgetShell.WidgetCapsuleFreePlacements; set => WidgetShell.WidgetCapsuleFreePlacements = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCollapsedStyle"/>
    public string WidgetCollapsedStyle { get => WidgetShell.WidgetCollapsedStyle; set => WidgetShell.WidgetCollapsedStyle = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCompactContentMode"/>
    public string WidgetCompactContentMode { get => WidgetShell.WidgetCompactContentMode; set => WidgetShell.WidgetCompactContentMode = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCompactHideSensitiveContent"/>
    public bool WidgetCompactHideSensitiveContent { get => WidgetShell.WidgetCompactHideSensitiveContent; set => WidgetShell.WidgetCompactHideSensitiveContent = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCompactSettingsVersion"/>
    public int WidgetCompactSettingsVersion { get => WidgetShell.WidgetCompactSettingsVersion; set => WidgetShell.WidgetCompactSettingsVersion = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCompactAnimationEffect"/>
    public string WidgetCompactAnimationEffect { get => WidgetShell.WidgetCompactAnimationEffect; set => WidgetShell.WidgetCompactAnimationEffect = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCompactAnimationDurationMs"/>
    public int WidgetCompactAnimationDurationMs { get => WidgetShell.WidgetCompactAnimationDurationMs; set => WidgetShell.WidgetCompactAnimationDurationMs = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCompactExpandDelayMs"/>
    public int WidgetCompactExpandDelayMs { get => WidgetShell.WidgetCompactExpandDelayMs; set => WidgetShell.WidgetCompactExpandDelayMs = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCompactCollapseDelayMs"/>
    public int WidgetCompactCollapseDelayMs { get => WidgetShell.WidgetCompactCollapseDelayMs; set => WidgetShell.WidgetCompactCollapseDelayMs = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetCompactMediaCornerMode"/>
    public string WidgetCompactMediaCornerMode { get => WidgetShell.WidgetCompactMediaCornerMode; set => WidgetShell.WidgetCompactMediaCornerMode = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetTitleIconMode"/>
    public string WidgetTitleIconMode { get => WidgetShell.WidgetTitleIconMode; set => WidgetShell.WidgetTitleIconMode = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.DoubleClickToOpen"/>
    public bool DoubleClickToOpen { get => FileWidget.DoubleClickToOpen; set => FileWidget.DoubleClickToOpen = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileWidgetFolderOpenBehavior"/>
    public string FileWidgetFolderOpenBehavior { get => FileWidget.FileWidgetFolderOpenBehavior; set => FileWidget.FileWidgetFolderOpenBehavior = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileItemSystemContextMenuEnabled"/>
    public bool FileItemSystemContextMenuEnabled { get => FileWidget.FileItemSystemContextMenuEnabled; set => FileWidget.FileItemSystemContextMenuEnabled = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.HideShortcutArrowOverlay"/>
    public bool HideShortcutArrowOverlay { get => FileWidget.HideShortcutArrowOverlay; set => FileWidget.HideShortcutArrowOverlay = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.ShowImageFilesAsIcons"/>
    public bool ShowImageFilesAsIcons { get => FileWidget.ShowImageFilesAsIcons; set => FileWidget.ShowImageFilesAsIcons = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.ShowHoverButtons"/>
    public bool ShowHoverButtons { get => WidgetShell.ShowHoverButtons; set => WidgetShell.ShowHoverButtons = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetHoverButtonActions"/>
    public string WidgetHoverButtonActions { get => WidgetShell.WidgetHoverButtonActions; set => WidgetShell.WidgetHoverButtonActions = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.ResizeSnapEnabled"/>
    public bool ResizeSnapEnabled { get => WidgetShell.ResizeSnapEnabled; set => WidgetShell.ResizeSnapEnabled = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.WidgetSnapSpacing"/>
    public double WidgetSnapSpacing { get => WidgetShell.WidgetSnapSpacing; set => WidgetShell.WidgetSnapSpacing = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.ShowListItemDetails"/>
    public bool ShowListItemDetails { get => FileWidget.ShowListItemDetails; set => FileWidget.ShowListItemDetails = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.ShowFileItemPathTooltips"/>
    public bool ShowFileItemPathTooltips { get => FileWidget.ShowFileItemPathTooltips; set => FileWidget.ShowFileItemPathTooltips = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileStacksEnabled"/>
    public bool FileStacksEnabled { get => FileWidget.FileStacksEnabled; set => FileWidget.FileStacksEnabled = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileStackAutoStacking"/>
    public bool FileStackAutoStacking { get => FileWidget.FileStackAutoStacking; set => FileWidget.FileStackAutoStacking = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileStackGroupBy"/>
    public string FileStackGroupBy { get => FileWidget.FileStackGroupBy; set => FileWidget.FileStackGroupBy = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileStackThreshold"/>
    public int FileStackThreshold { get => FileWidget.FileStackThreshold; set => FileWidget.FileStackThreshold = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileStackOrderBy"/>
    public string FileStackOrderBy { get => FileWidget.FileStackOrderBy; set => FileWidget.FileStackOrderBy = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileStackOpenMode"/>
    public string FileStackOpenMode { get => FileWidget.FileStackOpenMode; set => FileWidget.FileStackOpenMode = value; }
}
