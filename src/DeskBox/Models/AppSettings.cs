using System.Text.Json.Serialization;

namespace DeskBox.Models;

/// <summary>
/// Root settings object that is serialized to/from the JSON config file.
/// State lives in per-domain <c>*SettingsSlice</c> objects; the flat
/// properties below are the serialization facade and the legacy access
/// surface. Declaration order here defines the on-disk member order.
/// </summary>
public class AppSettings
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

    // NOTE: truncated restore - SEE BLOCKER
}
