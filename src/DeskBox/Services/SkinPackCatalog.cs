using DeskBox.Models;

namespace DeskBox.Services;

/// <summary>
/// Built-in widget skin packs and helpers to apply or match them against <see cref="AppSettings"/>.
/// </summary>
public static class SkinPackCatalog
{
    public const string DarkGlassId = "DarkGlass";
    public const string LightMinimalId = "LightMinimal";
    public const string HighContrastId = "HighContrast";
    public const string CustomId = "Custom";

    public static IReadOnlyList<SkinPack> BuiltInPacks { get; } =
    [
        CreateDarkGlass(),
        CreateLightMinimal(),
        CreateHighContrast()
    ];

    public static SkinPack? FindBuiltIn(string? id) =>
        BuiltInPacks.FirstOrDefault(pack =>
            string.Equals(pack.Id, id, StringComparison.OrdinalIgnoreCase));

    public static string NormalizeSelectedSkinId(string? id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return CustomId;
        }

        if (string.Equals(id, CustomId, StringComparison.OrdinalIgnoreCase))
        {
            return CustomId;
        }

        return FindBuiltIn(id) is not null ? FindBuiltIn(id)!.Id : CustomId;
    }

    public static void Apply(AppSettings settings, SkinPack pack)
    {
        ArgumentNullException.ThrowIfNull(settings);
        ArgumentNullException.ThrowIfNull(pack);

        settings.Theme = pack.Theme;
        settings.TrayIconStyle = pack.TrayIconStyle;
        settings.AccentColorMode = pack.AccentColorMode;
        if (!string.IsNullOrWhiteSpace(pack.CustomAccentColor))
        {
            settings.CustomAccentColor = pack.CustomAccentColor;
        }

        settings.WidgetMaterialType = pack.WidgetMaterialType;
        settings.WidgetOpacity = pack.WidgetOpacity;
        settings.WidgetMaterialIntensity = pack.WidgetMaterialIntensity;
        settings.WidgetCornerPreference = pack.WidgetCornerPreference;
        settings.WidgetBorderColorMode = pack.WidgetBorderColorMode;
        settings.WidgetBorderStyle = pack.WidgetBorderStyle;
        SettingsService.ApplyLayoutDensityPreset(settings, pack.LayoutDensity);
        settings.DisplayWidgetChromeMode = pack.DisplayWidgetChromeMode;
        settings.InteractiveWidgetChromeMode = pack.InteractiveWidgetChromeMode;
        settings.SelectedSkinId = pack.Id;
    }

    public static string ResolveMatchingSkinId(AppSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        foreach (SkinPack pack in BuiltInPacks)
        {
            if (Matches(settings, pack))
            {
                return pack.Id;
            }
        }

        return CustomId;
    }

    public static bool Matches(AppSettings settings, SkinPack pack)
    {
        ArgumentNullException.ThrowIfNull(settings);
        ArgumentNullException.ThrowIfNull(pack);

        if (!StringEquals(settings.Theme, pack.Theme) ||
            !StringEquals(settings.TrayIconStyle, pack.TrayIconStyle) ||
            !StringEquals(settings.AccentColorMode, pack.AccentColorMode) ||
            !StringEquals(settings.WidgetMaterialType, pack.WidgetMaterialType) ||
            !StringEquals(settings.WidgetCornerPreference, pack.WidgetCornerPreference) ||
            !StringEquals(settings.WidgetBorderColorMode, pack.WidgetBorderColorMode) ||
            !StringEquals(settings.WidgetBorderStyle, pack.WidgetBorderStyle) ||
            !StringEquals(settings.LayoutDensity, pack.LayoutDensity) ||
            !StringEquals(settings.DisplayWidgetChromeMode, pack.DisplayWidgetChromeMode) ||
            !StringEquals(settings.InteractiveWidgetChromeMode, pack.InteractiveWidgetChromeMode))
        {
            return false;
        }

        if (string.Equals(pack.AccentColorMode, "Custom", StringComparison.OrdinalIgnoreCase))
        {
            if (!string.IsNullOrWhiteSpace(pack.CustomAccentColor) &&
                !StringEquals(settings.CustomAccentColor, pack.CustomAccentColor))
            {
                return false;
            }
        }

        if (Math.Abs(settings.WidgetOpacity - pack.WidgetOpacity) > 0.021)
        {
            return false;
        }

        if (Math.Abs(settings.WidgetMaterialIntensity - pack.WidgetMaterialIntensity) > 0.021)
        {
            return false;
        }

        return true;
    }

    private static bool StringEquals(string? left, string? right) =>
        string.Equals(left, right, StringComparison.OrdinalIgnoreCase);

    private static SkinPack CreateDarkGlass() => new()
    {
        Id = DarkGlassId,
        Theme = "Dark",
        TrayIconStyle = "White",
        AccentColorMode = "System",
        WidgetMaterialType = SettingsService.WidgetMaterialTypeAcrylic,
        WidgetOpacity = 0.72,
        WidgetMaterialIntensity = 0.70,
        WidgetCornerPreference = SettingsService.WidgetCornerPreferenceRound,
        WidgetBorderColorMode = SettingsService.WidgetBorderColorModeNeutral,
        WidgetBorderStyle = SettingsService.WidgetBorderStyleThin,
        LayoutDensity = SettingsService.LayoutDensityStandard,
        DisplayWidgetChromeMode = SettingsService.WidgetChromeModeOverlay,
        InteractiveWidgetChromeMode = SettingsService.WidgetChromeModeStandard
    };

    private static SkinPack CreateLightMinimal() => new()
    {
        Id = LightMinimalId,
        Theme = "Light",
        TrayIconStyle = "Black",
        AccentColorMode = "System",
        WidgetMaterialType = SettingsService.WidgetMaterialTypeMica,
        WidgetOpacity = 0.92,
        WidgetMaterialIntensity = 0.45,
        WidgetCornerPreference = SettingsService.WidgetCornerPreferenceSmall,
        WidgetBorderColorMode = SettingsService.WidgetBorderColorModeNeutral,
        WidgetBorderStyle = SettingsService.WidgetBorderStyleThin,
        LayoutDensity = SettingsService.LayoutDensityCompact,
        DisplayWidgetChromeMode = SettingsService.WidgetChromeModeCompact,
        InteractiveWidgetChromeMode = SettingsService.WidgetChromeModeCompact
    };

    private static SkinPack CreateHighContrast() => new()
    {
        Id = HighContrastId,
        Theme = "Dark",
        TrayIconStyle = "Colorful",
        AccentColorMode = "Custom",
        CustomAccentColor = "#FFB900",
        WidgetMaterialType = SettingsService.WidgetMaterialTypeSolid,
        WidgetOpacity = 1.0,
        WidgetMaterialIntensity = 1.0,
        WidgetCornerPreference = SettingsService.WidgetCornerPreferenceSmall,
        WidgetBorderColorMode = SettingsService.WidgetBorderColorModeAccent,
        WidgetBorderStyle = SettingsService.WidgetBorderStyleThick,
        LayoutDensity = SettingsService.LayoutDensityRelaxed,
        DisplayWidgetChromeMode = SettingsService.WidgetChromeModeStandard,
        InteractiveWidgetChromeMode = SettingsService.WidgetChromeModeStandard
    };
}
