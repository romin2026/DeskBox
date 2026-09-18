using System.Text.Json.Serialization;

namespace DeskBox.Models;

public partial class AppSettings
{

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileStackPopoverLayout"/>
    public string FileStackPopoverLayout { get => FileWidget.FileStackPopoverLayout; set => FileWidget.FileStackPopoverLayout = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileStackPopoverStyle"/>
    public string FileStackPopoverStyle { get => FileWidget.FileStackPopoverStyle; set => FileWidget.FileStackPopoverStyle = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileStackCustomRules"/>
    public List<FileStackCustomRule> FileStackCustomRules { get => FileWidget.FileStackCustomRules; set => FileWidget.FileStackCustomRules = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileStackUnmatchedBehavior"/>
    public string FileStackUnmatchedBehavior { get => FileWidget.FileStackUnmatchedBehavior; set => FileWidget.FileStackUnmatchedBehavior = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.ManagedDropAction"/>
    public string ManagedDropAction { get => FileWidget.ManagedDropAction; set => FileWidget.ManagedDropAction = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.DefaultManagedStorageRootPath"/>
    public string DefaultManagedStorageRootPath { get => FileWidget.DefaultManagedStorageRootPath; set => FileWidget.DefaultManagedStorageRootPath = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.ManagedStorageDesktopShortcutEnabled"/>
    public bool ManagedStorageDesktopShortcutEnabled { get => FileWidget.ManagedStorageDesktopShortcutEnabled; set => FileWidget.ManagedStorageDesktopShortcutEnabled = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.ManagedStorageDesktopShortcutPath"/>
    public string ManagedStorageDesktopShortcutPath { get => FileWidget.ManagedStorageDesktopShortcutPath; set => FileWidget.ManagedStorageDesktopShortcutPath = value; }

    /// <inheritdoc cref="BackupSettingsSlice.AutomaticBackupEnabled"/>
    public bool AutomaticBackupEnabled { get => Backup.AutomaticBackupEnabled; set => Backup.AutomaticBackupEnabled = value; }

    /// <inheritdoc cref="BackupSettingsSlice.AutomaticBackupIntervalMinutes"/>
    public int AutomaticBackupIntervalMinutes { get => Backup.AutomaticBackupIntervalMinutes; set => Backup.AutomaticBackupIntervalMinutes = value; }

    /// <inheritdoc cref="BackupSettingsSlice.AutomaticBackupRetentionCount"/>
    public int AutomaticBackupRetentionCount { get => Backup.AutomaticBackupRetentionCount; set => Backup.AutomaticBackupRetentionCount = value; }

    /// <inheritdoc cref="BackupSettingsSlice.AutomaticBackupDirectory"/>
    public string AutomaticBackupDirectory { get => Backup.AutomaticBackupDirectory; set => Backup.AutomaticBackupDirectory = value; }

    /// <inheritdoc cref="DesktopOrganizationSettingsSlice.RecentOrganizationHistory"/>
    public List<OrganizationHistoryEntry> RecentOrganizationHistory { get => DesktopOrganization.RecentOrganizationHistory; set => DesktopOrganization.RecentOrganizationHistory = value; }

    /// <inheritdoc cref="DesktopOrganizationSettingsSlice.DesktopOrganizationRules"/>
    public List<DesktopOrganizationRule> DesktopOrganizationRules { get => DesktopOrganization.DesktopOrganizationRules; set => DesktopOrganization.DesktopOrganizationRules = value; }

    /// <inheritdoc cref="DesktopOrganizationSettingsSlice.DesktopAutoOrganizationEnabled"/>
    public bool DesktopAutoOrganizationEnabled { get => DesktopOrganization.DesktopAutoOrganizationEnabled; set => DesktopOrganization.DesktopAutoOrganizationEnabled = value; }

    /// <inheritdoc cref="DesktopOrganizationSettingsSlice.DesktopAutoOrganizationBaselineUtc"/>
    public DateTimeOffset? DesktopAutoOrganizationBaselineUtc { get => DesktopOrganization.DesktopAutoOrganizationBaselineUtc; set => DesktopOrganization.DesktopAutoOrganizationBaselineUtc = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.IconSize"/>
    public double IconSize { get => WidgetShell.IconSize; set => WidgetShell.IconSize = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.TextSize"/>
    public double TextSize { get => WidgetShell.TextSize; set => WidgetShell.TextSize = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.LayoutDensity"/>
    public string LayoutDensity { get => WidgetShell.LayoutDensity; set => WidgetShell.LayoutDensity = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.LayoutDensityScale"/>
    public double LayoutDensityScale { get => WidgetShell.LayoutDensityScale; set => WidgetShell.LayoutDensityScale = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.HorizontalSpacingScale"/>
    public double HorizontalSpacingScale { get => WidgetShell.HorizontalSpacingScale; set => WidgetShell.HorizontalSpacingScale = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.VerticalSpacingScale"/>
    public double VerticalSpacingScale { get => WidgetShell.VerticalSpacingScale; set => WidgetShell.VerticalSpacingScale = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileNameWidthScale"/>
    public double FileNameWidthScale { get => FileWidget.FileNameWidthScale; set => FileWidget.FileNameWidthScale = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.FileNameLineCount"/>
    public int FileNameLineCount { get => FileWidget.FileNameLineCount; set => FileWidget.FileNameLineCount = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.ShowFileExtensions"/>
    public bool ShowFileExtensions { get => FileWidget.ShowFileExtensions; set => FileWidget.ShowFileExtensions = value; }

    /// <inheritdoc cref="FileWidgetSettingsSlice.HideShortcutExtensionWhenShowingFileExtensions"/>
    public bool HideShortcutExtensionWhenShowingFileExtensions { get => FileWidget.HideShortcutExtensionWhenShowingFileExtensions; set => FileWidget.HideShortcutExtensionWhenShowingFileExtensions = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.Widgets"/>
    public List<WidgetConfig> Widgets { get => WidgetLayout.Widgets; set => WidgetLayout.Widgets = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.WidgetGroups"/>
    public List<WidgetGroupConfig> WidgetGroups { get => WidgetLayout.WidgetGroups; set => WidgetLayout.WidgetGroups = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.WidgetTopologyLayouts"/>
    public Dictionary<string, WidgetTopologyLayoutProfile> WidgetTopologyLayouts { get => WidgetLayout.WidgetTopologyLayouts; set => WidgetLayout.WidgetTopologyLayouts = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.ActiveWidgetTopologyKey"/>
    public string? ActiveWidgetTopologyKey { get => WidgetLayout.ActiveWidgetTopologyKey; set => WidgetLayout.ActiveWidgetTopologyKey = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.WidgetGroupsEnabled"/>
    public bool WidgetGroupsEnabled { get => WidgetLayout.WidgetGroupsEnabled; set => WidgetLayout.WidgetGroupsEnabled = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.WidgetGroupDefaultNavigationStyle"/>
    public string WidgetGroupDefaultNavigationStyle { get => WidgetLayout.WidgetGroupDefaultNavigationStyle; set => WidgetLayout.WidgetGroupDefaultNavigationStyle = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.WidgetGroupDefaultTitleDisplayMode"/>
    public string WidgetGroupDefaultTitleDisplayMode { get => WidgetLayout.WidgetGroupDefaultTitleDisplayMode; set => WidgetLayout.WidgetGroupDefaultTitleDisplayMode = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.WidgetGroupWheelSwitchEnabled"/>
    public bool WidgetGroupWheelSwitchEnabled { get => WidgetLayout.WidgetGroupWheelSwitchEnabled; set => WidgetLayout.WidgetGroupWheelSwitchEnabled = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.WidgetGroupHoverSwitchEnabled"/>
    public bool WidgetGroupHoverSwitchEnabled { get => WidgetLayout.WidgetGroupHoverSwitchEnabled; set => WidgetLayout.WidgetGroupHoverSwitchEnabled = value; }

    /// <inheritdoc cref="WidgetShellSettingsSlice.FocusClickedWidgetOnRaise"/>
    public bool FocusClickedWidgetOnRaise { get => WidgetShell.FocusClickedWidgetOnRaise; set => WidgetShell.FocusClickedWidgetOnRaise = value; }

    /// <inheritdoc cref="WidgetLayoutSettingsSlice.DeletedWidgetIds"/>
    public List<string> DeletedWidgetIds { get => WidgetLayout.DeletedWidgetIds; set => WidgetLayout.DeletedWidgetIds = value; }

    // ─── Weather Widget Settings ───────────────────────────────────
    /// <inheritdoc cref="WeatherSettingsSlice.WeatherAutoLocation"/>
    public bool WeatherAutoLocation { get => Weather.WeatherAutoLocation; set => Weather.WeatherAutoLocation = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherCityName"/>
    public string WeatherCityName { get => Weather.WeatherCityName; set => Weather.WeatherCityName = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherLatitude"/>
    public double WeatherLatitude { get => Weather.WeatherLatitude; set => Weather.WeatherLatitude = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherLongitude"/>
    public double WeatherLongitude { get => Weather.WeatherLongitude; set => Weather.WeatherLongitude = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherTemperatureUnit"/>
    public string WeatherTemperatureUnit { get => Weather.WeatherTemperatureUnit; set => Weather.WeatherTemperatureUnit = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherWindSpeedUnit"/>
    public string WeatherWindSpeedUnit { get => Weather.WeatherWindSpeedUnit; set => Weather.WeatherWindSpeedUnit = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherDataSource"/>
    public string WeatherDataSource { get => Weather.WeatherDataSource; set => Weather.WeatherDataSource = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherDefaultView"/>
    public string WeatherDefaultView { get => Weather.WeatherDefaultView; set => Weather.WeatherDefaultView = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherSkin"/>
    public string WeatherSkin { get => Weather.WeatherSkin; set => Weather.WeatherSkin = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherShowForecast"/>
    public bool WeatherShowForecast { get => Weather.WeatherShowForecast; set => Weather.WeatherShowForecast = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherShowSunrise"/>
    public bool WeatherShowSunrise { get => Weather.WeatherShowSunrise; set => Weather.WeatherShowSunrise = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherShowUvIndex"/>
    public bool WeatherShowUvIndex { get => Weather.WeatherShowUvIndex; set => Weather.WeatherShowUvIndex = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherShowPrecipitation"/>
    public bool WeatherShowPrecipitation { get => Weather.WeatherShowPrecipitation; set => Weather.WeatherShowPrecipitation = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherShowHumidity"/>
    public bool WeatherShowHumidity { get => Weather.WeatherShowHumidity; set => Weather.WeatherShowHumidity = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherShowWind"/>
    public bool WeatherShowWind { get => Weather.WeatherShowWind; set => Weather.WeatherShowWind = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherShowPressure"/>
    public bool WeatherShowPressure { get => Weather.WeatherShowPressure; set => Weather.WeatherShowPressure = value; }

    /// <inheritdoc cref="WeatherSettingsSlice.WeatherRefreshIntervalMinutes"/>
    public int WeatherRefreshIntervalMinutes { get => Weather.WeatherRefreshIntervalMinutes; set => Weather.WeatherRefreshIntervalMinutes = value; }

    // ─── Search Settings ───────────────────────────────────────────────
    /// <inheritdoc cref="SearchSettingsSlice.SearchHotkeyEnabled"/>
    public bool SearchHotkeyEnabled { get => Search.SearchHotkeyEnabled; set => Search.SearchHotkeyEnabled = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchHotkeyModifiers"/>
    public int SearchHotkeyModifiers { get => Search.SearchHotkeyModifiers; set => Search.SearchHotkeyModifiers = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchHotkeyKey"/>
    public int SearchHotkeyKey { get => Search.SearchHotkeyKey; set => Search.SearchHotkeyKey = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchDisplayMode"/>
    public string SearchDisplayMode { get => Search.SearchDisplayMode; set => Search.SearchDisplayMode = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchIncludeDeskBoxContent"/>
    public bool SearchIncludeDeskBoxContent { get => Search.SearchIncludeDeskBoxContent; set => Search.SearchIncludeDeskBoxContent = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchEverythingEnabled"/>
    public bool SearchEverythingEnabled { get => Search.SearchEverythingEnabled; set => Search.SearchEverythingEnabled = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchEverythingExecutablePath"/>
    public string SearchEverythingExecutablePath { get => Search.SearchEverythingExecutablePath; set => Search.SearchEverythingExecutablePath = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchEverythingAdvancedSyntaxEnabled"/>
    public bool SearchEverythingAdvancedSyntaxEnabled { get => Search.SearchEverythingAdvancedSyntaxEnabled; set => Search.SearchEverythingAdvancedSyntaxEnabled = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchShowRecommendations"/>
    public bool SearchShowRecommendations { get => Search.SearchShowRecommendations; set => Search.SearchShowRecommendations = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchSaveHistory"/>
    public bool SearchSaveHistory { get => Search.SearchSaveHistory; set => Search.SearchSaveHistory = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchMaxResults"/>
    public int SearchMaxResults { get => Search.SearchMaxResults; set => Search.SearchMaxResults = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchDefaultTab"/>
    public string SearchDefaultTab { get => Search.SearchDefaultTab; set => Search.SearchDefaultTab = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchAppIconAnimation"/>
    public int SearchAppIconAnimation { get => Search.SearchAppIconAnimation; set => Search.SearchAppIconAnimation = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchPopupCustomX"/>
    public int? SearchPopupCustomX { get => Search.SearchPopupCustomX; set => Search.SearchPopupCustomX = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchPopupCustomY"/>
    public int? SearchPopupCustomY { get => Search.SearchPopupCustomY; set => Search.SearchPopupCustomY = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchPopupCustomWidth"/>
    public int? SearchPopupCustomWidth { get => Search.SearchPopupCustomWidth; set => Search.SearchPopupCustomWidth = value; }

    /// <inheritdoc cref="SearchSettingsSlice.SearchPopupCustomHeight"/>
    public int? SearchPopupCustomHeight { get => Search.SearchPopupCustomHeight; set => Search.SearchPopupCustomHeight = value; }
}
