using DeskBox.Models;
using DeskBox.Services;

namespace DeskBox.Tests;

public sealed class SkinPackCatalogTests
{
    [Fact]
    public void BuiltInPacks_ContainsThreePresets()
    {
        Assert.Equal(3, SkinPackCatalog.BuiltInPacks.Count);
        Assert.Contains(SkinPackCatalog.BuiltInPacks, pack => pack.Id == SkinPackCatalog.DarkGlassId);
        Assert.Contains(SkinPackCatalog.BuiltInPacks, pack => pack.Id == SkinPackCatalog.LightMinimalId);
        Assert.Contains(SkinPackCatalog.BuiltInPacks, pack => pack.Id == SkinPackCatalog.HighContrastId);
    }

    [Theory]
    [InlineData(SkinPackCatalog.DarkGlassId)]
    [InlineData(SkinPackCatalog.LightMinimalId)]
    [InlineData(SkinPackCatalog.HighContrastId)]
    public void Apply_WritesUnderlyingAppearanceSettings_AndMatchesPack(string skinId)
    {
        SkinPack pack = SkinPackCatalog.FindBuiltIn(skinId)!;
        var settings = new AppSettings();

        SkinPackCatalog.Apply(settings, pack);

        Assert.Equal(skinId, settings.SelectedSkinId);
        Assert.Equal(pack.Theme, settings.Theme);
        Assert.Equal(pack.TrayIconStyle, settings.TrayIconStyle);
        Assert.Equal(pack.AccentColorMode, settings.AccentColorMode);
        Assert.Equal(pack.WidgetMaterialType, settings.WidgetMaterialType);
        Assert.Equal(pack.WidgetOpacity, settings.WidgetOpacity, precision: 3);
        Assert.Equal(pack.WidgetMaterialIntensity, settings.WidgetMaterialIntensity, precision: 3);
        Assert.Equal(pack.WidgetCornerPreference, settings.WidgetCornerPreference);
        Assert.Equal(pack.WidgetBorderColorMode, settings.WidgetBorderColorMode);
        Assert.Equal(pack.WidgetBorderStyle, settings.WidgetBorderStyle);
        Assert.Equal(pack.LayoutDensity, settings.LayoutDensity);
        Assert.Equal(pack.DisplayWidgetChromeMode, settings.DisplayWidgetChromeMode);
        Assert.Equal(pack.InteractiveWidgetChromeMode, settings.InteractiveWidgetChromeMode);
        Assert.True(SkinPackCatalog.Matches(settings, pack));
        Assert.Equal(skinId, SkinPackCatalog.ResolveMatchingSkinId(settings));
    }

    [Fact]
    public void ResolveMatchingSkinId_ReturnsCustom_WhenAppearanceDiverges()
    {
        SkinPack pack = SkinPackCatalog.FindBuiltIn(SkinPackCatalog.DarkGlassId)!;
        var settings = new AppSettings();
        SkinPackCatalog.Apply(settings, pack);

        settings.WidgetOpacity = Math.Clamp(pack.WidgetOpacity - 0.2, 0, 1);
        settings.SelectedSkinId = SkinPackCatalog.DarkGlassId;

        Assert.Equal(SkinPackCatalog.CustomId, SkinPackCatalog.ResolveMatchingSkinId(settings));
    }

    [Fact]
    public void NormalizeSelectedSkinId_FallsBackToCustom_ForUnknownValues()
    {
        Assert.Equal(SkinPackCatalog.CustomId, SkinPackCatalog.NormalizeSelectedSkinId(null));
        Assert.Equal(SkinPackCatalog.CustomId, SkinPackCatalog.NormalizeSelectedSkinId(" "));
        Assert.Equal(SkinPackCatalog.CustomId, SkinPackCatalog.NormalizeSelectedSkinId("not-a-skin"));
        Assert.Equal(SkinPackCatalog.DarkGlassId, SkinPackCatalog.NormalizeSelectedSkinId("darkglass"));
    }
}
