using System.Text.Json.Serialization;

namespace DeskBox.Models;

/// <summary>
/// Root settings object that is serialized to/from the JSON config file.
/// State lives in per-domain <c>*SettingsSlice</c> objects; the flat
/// properties below are the serialization facade and the legacy access
/// surface. Declaration order here defines the on-disk member order.
/// </summary>
public partial class AppSettings
{
    /// <summary>
    /// Settings schema version for migration purposes.
    /// New or legacy settings without this field begin at version 1 and are
    /// advanced by <see cref="DeskBox.Services.SettingsMigrationPipeline"/>.
    /// </summary>
    public int SchemaVersion { get; set; } = 1;

    // ─── Ownership slices (never serialized directly) ───────────────

    [JsonIgnore]
    public CoreSettingsSlice Core { get; } = new();

    [JsonIgnore]
    public PerformanceSettingsSlice Performance { get; } = new();

    [JsonIgnore]
    public QuickCaptureSettingsSlice QuickCapture { get; } = new();

    [JsonIgnore]
    public TodoSettingsSlice Todo { get; } = new();

    [JsonIgnore]
    public MusicSettingsSlice Music { get; } = new();

    [JsonIgnore]
    public WidgetShellSettingsSlice WidgetShell { get; } = new();

    [JsonIgnore]
    public FileWidgetSettingsSlice FileWidget { get; } = new();

    [JsonIgnore]
    public BackupSettingsSlice Backup { get; } = new();

    [JsonIgnore]
    public DesktopOrganizationSettingsSlice DesktopOrganization { get; } = new();

    [JsonIgnore]
    public WidgetLayoutSettingsSlice WidgetLayout { get; } = new();

    [JsonIgnore]
    public WeatherSettingsSlice Weather { get; } = new();

    [JsonIgnore]
    public SearchSettingsSlice Search { get; } = new();

    // ─── Serialization facade (wire contract, order-significant) ──

    /// <inheritdoc cref="CoreSettingsSlice.Theme"/>
    public string Theme { get => Core.Theme; set => Core.Theme = value; }

    /// <inheritdoc cref="CoreSettingsSlice.TrayIconStyle"/>
    public string TrayIconStyle { get => Core.TrayIconStyle; set => Core.TrayIconStyle = value; }

    /// <inheritdoc cref="CoreSettingsSlice.Language"/>
    public string Language { get => Core.Language; set => Core.Language = value; }

    /// <inheritdoc cref="CoreSettingsSlice.AccentColorMode"/>
    public string AccentColorMode { get => Core.AccentColorMode; set => Core.AccentColorMode = value; }

    /// <inheritdoc cref="CoreSettingsSlice.CustomAccentColor"/>
    public string CustomAccentColor { get => Core.CustomAccentColor; set => Core.CustomAccentColor = value; }

    /// <inheritdoc cref="CoreSettingsSlice.SelectedSkinId"/>
    public string SelectedSkinId { get => Core.SelectedSkinId; set => Core.SelectedSkinId = value; }

    /// <inheritdoc cref="CoreSettingsSlice.AutoStart"/>
    public bool AutoStart { get => Core.AutoStart; set => Core.AutoStart = value; }

    /// <inheritdoc cref="CoreSettingsSlice.AutoStartDefaultApplied"/>
    public bool AutoStartDefaultApplied { get => Core.AutoStartDefaultApplied; set => Core.AutoStartDefaultApplied = value; }

    /// <inheritdoc cref="CoreSettingsSlice.AutoStartMode"/>
    public StartupMode? AutoStartMode { get => Core.AutoStartMode; set => Core.AutoStartMode = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.PerformanceMode"/>
    public string PerformanceMode { get => Performance.PerformanceMode; set => Performance.PerformanceMode = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.HiddenCacheCleanupDelaySeconds"/>
    public int HiddenCacheCleanupDelaySeconds { get => Performance.HiddenCacheCleanupDelaySeconds; set => Performance.HiddenCacheCleanupDelaySeconds = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.HiddenCacheCleanupScope"/>
    public string HiddenCacheCleanupScope { get => Performance.HiddenCacheCleanupScope; set => Performance.HiddenCacheCleanupScope = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.VisibleIdleCacheCleanupDelaySeconds"/>
    public int VisibleIdleCacheCleanupDelaySeconds { get => Performance.VisibleIdleCacheCleanupDelaySeconds; set => Performance.VisibleIdleCacheCleanupDelaySeconds = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.IdleWorkingSetTrimEnabled"/>
    public bool IdleWorkingSetTrimEnabled { get => Performance.IdleWorkingSetTrimEnabled; set => Performance.IdleWorkingSetTrimEnabled = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.ImmediateHiddenWorkingSetTrimEnabled"/>
    public bool ImmediateHiddenWorkingSetTrimEnabled { get => Performance.ImmediateHiddenWorkingSetTrimEnabled; set => Performance.ImmediateHiddenWorkingSetTrimEnabled = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.TransientWindowReleaseDelaySeconds"/>
    public int TransientWindowReleaseDelaySeconds { get => Performance.TransientWindowReleaseDelaySeconds; set => Performance.TransientWindowReleaseDelaySeconds = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.PerformanceCacheBudget"/>
    public string PerformanceCacheBudget { get => Performance.PerformanceCacheBudget; set => Performance.PerformanceCacheBudget = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.EnableContinuousDecorativeAnimations"/>
    public bool EnableContinuousDecorativeAnimations { get => Performance.EnableContinuousDecorativeAnimations; set => Performance.EnableContinuousDecorativeAnimations = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.EnableTextMarqueeAnimations"/>
    public bool EnableTextMarqueeAnimations { get => Performance.EnableTextMarqueeAnimations; set => Performance.EnableTextMarqueeAnimations = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.EnableVinylRotationAnimations"/>
    public bool EnableVinylRotationAnimations { get => Performance.EnableVinylRotationAnimations; set => Performance.EnableVinylRotationAnimations = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.EnableGlanceImageAutoRotation"/>
    public bool EnableGlanceImageAutoRotation { get => Performance.EnableGlanceImageAutoRotation; set => Performance.EnableGlanceImageAutoRotation = value; }

    /// <inheritdoc cref="PerformanceSettingsSlice.EnableCompactAmbientAnimations"/>
    public bool EnableCompactAmbientAnimations { get => Performance.EnableCompactAmbientAnimations; set => Performance.EnableCompactAmbientAnimations = value; }

    /// <inheritdoc cref="CoreSettingsSlice.AutoCheckForUpdates"/>
    public bool AutoCheckForUpdates { get => Core.AutoCheckForUpdates; set => Core.AutoCheckForUpdates = value; }

    /// <inheritdoc cref="CoreSettingsSlice.LastUpdateCheckAt"/>
    public DateTimeOffset? LastUpdateCheckAt { get => Core.LastUpdateCheckAt; set => Core.LastUpdateCheckAt = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureEnabled"/>
    public bool QuickCaptureEnabled { get => QuickCapture.QuickCaptureEnabled; set => QuickCapture.QuickCaptureEnabled = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoEnabled"/>
    public bool TodoEnabled { get => Todo.TodoEnabled; set => Todo.TodoEnabled = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.FeatureWidgetEnabledStates"/>
    public Dictionary<string, bool> FeatureWidgetEnabledStates { get => WidgetLayout.FeatureWidgetEnabledStates; set => WidgetLayout.FeatureWidgetEnabledStates = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureClipboardEnabled"/>
    public bool QuickCaptureClipboardEnabled { get => QuickCapture.QuickCaptureClipboardEnabled; set => QuickCapture.QuickCaptureClipboardEnabled = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureImageClipboardEnabled"/>
    public bool QuickCaptureImageClipboardEnabled { get => QuickCapture.QuickCaptureImageClipboardEnabled; set => QuickCapture.QuickCaptureImageClipboardEnabled = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureRecentLimit"/>
    public int QuickCaptureRecentLimit { get => QuickCapture.QuickCaptureRecentLimit; set => QuickCapture.QuickCaptureRecentLimit = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureShowCreatedTime"/>
    public bool QuickCaptureShowCreatedTime { get => QuickCapture.QuickCaptureShowCreatedTime; set => QuickCapture.QuickCaptureShowCreatedTime = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureItemPreviewLineCount"/>
    public int QuickCaptureItemPreviewLineCount { get => QuickCapture.QuickCaptureItemPreviewLineCount; set => QuickCapture.QuickCaptureItemPreviewLineCount = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureListTextSize"/>
    public double QuickCaptureListTextSize { get => QuickCapture.QuickCaptureListTextSize; set => QuickCapture.QuickCaptureListTextSize = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureContentTextSize"/>
    public double QuickCaptureContentTextSize { get => QuickCapture.QuickCaptureContentTextSize; set => QuickCapture.QuickCaptureContentTextSize = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureEditorEnterBehavior"/>
    public string QuickCaptureEditorEnterBehavior { get => QuickCapture.QuickCaptureEditorEnterBehavior; set => QuickCapture.QuickCaptureEditorEnterBehavior = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureDefaultFormat"/>
    public string QuickCaptureDefaultFormat { get => QuickCapture.QuickCaptureDefaultFormat; set => QuickCapture.QuickCaptureDefaultFormat = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureWideLayout"/>
    public string QuickCaptureWideLayout { get => QuickCapture.QuickCaptureWideLayout; set => QuickCapture.QuickCaptureWideLayout = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureWideOpenMode"/>
    public string QuickCaptureWideOpenMode { get => QuickCapture.QuickCaptureWideOpenMode; set => QuickCapture.QuickCaptureWideOpenMode = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureAllowRemoteImages"/>
    public bool QuickCaptureAllowRemoteImages { get => QuickCapture.QuickCaptureAllowRemoteImages; set => QuickCapture.QuickCaptureAllowRemoteImages = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.AttachmentStorageMode"/>
    public string AttachmentStorageMode { get => QuickCapture.AttachmentStorageMode; set => QuickCapture.AttachmentStorageMode = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureDefaultView"/>
    public string QuickCaptureDefaultView { get => QuickCapture.QuickCaptureDefaultView; set => QuickCapture.QuickCaptureDefaultView = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureTabStyle"/>
    public string QuickCaptureTabStyle { get => QuickCapture.QuickCaptureTabStyle; set => QuickCapture.QuickCaptureTabStyle = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureShowTabBar"/>
    public bool QuickCaptureShowTabBar { get => QuickCapture.QuickCaptureShowTabBar; set => QuickCapture.QuickCaptureShowTabBar = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureShowRecordsTab"/>
    public bool QuickCaptureShowRecordsTab { get => QuickCapture.QuickCaptureShowRecordsTab; set => QuickCapture.QuickCaptureShowRecordsTab = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureShowPinnedTab"/>
    public bool QuickCaptureShowPinnedTab { get => QuickCapture.QuickCaptureShowPinnedTab; set => QuickCapture.QuickCaptureShowPinnedTab = value; }

    /// <inheritdoc cref="QuickCaptureSettingsSlice.QuickCaptureShowRecentTab"/>
    public bool QuickCaptureShowRecentTab { get => QuickCapture.QuickCaptureShowRecentTab; set => QuickCapture.QuickCaptureShowRecentTab = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoNewTaskPosition"/>
    public string TodoNewTaskPosition { get => Todo.TodoNewTaskPosition; set => Todo.TodoNewTaskPosition = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoTabStyle"/>
    public string TodoTabStyle { get => Todo.TodoTabStyle; set => Todo.TodoTabStyle = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowTabBar"/>
    public bool TodoShowTabBar { get => Todo.TodoShowTabBar; set => Todo.TodoShowTabBar = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowAllTab"/>
    public bool TodoShowAllTab { get => Todo.TodoShowAllTab; set => Todo.TodoShowAllTab = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowActiveTab"/>
    public bool TodoShowActiveTab { get => Todo.TodoShowActiveTab; set => Todo.TodoShowActiveTab = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowTodayTab"/>
    public bool TodoShowTodayTab { get => Todo.TodoShowTodayTab; set => Todo.TodoShowTodayTab = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowThisWeekTab"/>
    public bool TodoShowThisWeekTab { get => Todo.TodoShowThisWeekTab; set => Todo.TodoShowThisWeekTab = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowThisMonthTab"/>
    public bool TodoShowThisMonthTab { get => Todo.TodoShowThisMonthTab; set => Todo.TodoShowThisMonthTab = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowImportantTab"/>
    public bool TodoShowImportantTab { get => Todo.TodoShowImportantTab; set => Todo.TodoShowImportantTab = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowCompletedTab"/>
    public bool TodoShowCompletedTab { get => Todo.TodoShowCompletedTab; set => Todo.TodoShowCompletedTab = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoDefaultFilter"/>
    public string TodoDefaultFilter { get => Todo.TodoDefaultFilter; set => Todo.TodoDefaultFilter = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowCompletedTasks"/>
    public bool TodoShowCompletedTasks { get => Todo.TodoShowCompletedTasks; set => Todo.TodoShowCompletedTasks = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoItemPreviewLineCount"/>
    public int TodoItemPreviewLineCount { get => Todo.TodoItemPreviewLineCount; set => Todo.TodoItemPreviewLineCount = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoListTextSize"/>
    public double TodoListTextSize { get => Todo.TodoListTextSize; set => Todo.TodoListTextSize = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoContentTextSize"/>
    public double TodoContentTextSize { get => Todo.TodoContentTextSize; set => Todo.TodoContentTextSize = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoEditorEnterBehavior"/>
    public string TodoEditorEnterBehavior { get => Todo.TodoEditorEnterBehavior; set => Todo.TodoEditorEnterBehavior = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowFooterStats"/>
    public bool TodoShowFooterStats { get => Todo.TodoShowFooterStats; set => Todo.TodoShowFooterStats = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoShowClearCompletedButton"/>
    public bool TodoShowClearCompletedButton { get => Todo.TodoShowClearCompletedButton; set => Todo.TodoShowClearCompletedButton = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoReminderEnabled"/>
    public bool TodoReminderEnabled { get => Todo.TodoReminderEnabled; set => Todo.TodoReminderEnabled = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoDefaultReminderOffsetMinutes"/>
    public int TodoDefaultReminderOffsetMinutes { get => Todo.TodoDefaultReminderOffsetMinutes; set => Todo.TodoDefaultReminderOffsetMinutes = value; }

    /// <inheritdoc cref="TodoSettingsSlice.TodoUseWideDetailPane"/>
    public bool TodoUseWideDetailPane { get => Todo.TodoUseWideDetailPane; set => Todo.TodoUseWideDetailPane = value; }
}
