namespace DeskBox.Models;

/// <summary>
/// A named bundle of appearance settings that can be applied in one step.
/// </summary>
public sealed class SkinPack
{
    public required string Id { get; init; }

    public required string Theme { get; init; }

    public required string TrayIconStyle { get; init; }

    public required string AccentColorMode { get; init; }

    public string? CustomAccentColor { get; init; }

    public required string WidgetMaterialType { get; init; }

    public required double WidgetOpacity { get; init; }

    public required double WidgetMaterialIntensity { get; init; }

    public required string WidgetCornerPreference { get; init; }

    public required string WidgetBorderColorMode { get; init; }

    public required string WidgetBorderStyle { get; init; }

    public required string LayoutDensity { get; init; }

    public required string DisplayWidgetChromeMode { get; init; }

    public required string InteractiveWidgetChromeMode { get; init; }
}
