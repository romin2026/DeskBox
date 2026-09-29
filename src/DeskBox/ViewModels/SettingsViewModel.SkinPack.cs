using DeskBox.Helpers;
using DeskBox.Models;
using DeskBox.Services;

namespace DeskBox.ViewModels;

public partial class SettingsViewModel
{
    private string _selectedSkinId = SkinPackCatalog.CustomId;

    private bool _isApplyingSkinPack;

    private bool _skinPackSaveHookInstalled;

    public string SelectedSkinId
    {
        get
        {
            EnsureSkinPackSaveHook();
            return SkinPackCatalog.NormalizeSelectedSkinId(_settingsService.Settings.SelectedSkinId);
        }
        set
        {
            EnsureSkinPackSaveHook();
            string normalized = SkinPackCatalog.NormalizeSelectedSkinId(value);
            string current = SkinPackCatalog.NormalizeSelectedSkinId(_settingsService.Settings.SelectedSkinId);
            if (string.Equals(current, normalized, StringComparison.Ordinal) &&
                string.Equals(_selectedSkinId, normalized, StringComparison.Ordinal))
            {
                return;
            }

            _selectedSkinId = normalized;
            OnPropertyChanged(nameof(SelectedSkinId));
            OnPropertyChanged(nameof(SelectedSkinIdText));

            if (_isRestoringDefaults || _isApplyingSettingsSnapshot)
            {
                _settingsService.Settings.SelectedSkinId = normalized;
                return;
            }

            if (string.Equals(normalized, SkinPackCatalog.CustomId, StringComparison.Ordinal))
            {
                _settingsService.Settings.SelectedSkinId = SkinPackCatalog.CustomId;
                SaveAppearanceChange();
                return;
            }

            ApplySkinPack(normalized);
        }
    }

    public string SelectedSkinIdText => GetSkinPackDisplayName(SelectedSkinId);

    private void EnsureSkinPackSaveHook()
    {
        if (_skinPackSaveHookInstalled)
        {
            return;
        }

        _skinPackSaveHookInstalled = true;
        _selectedSkinId = SkinPackCatalog.NormalizeSelectedSkinId(_settingsService.Settings.SelectedSkinId);
        PropertyChanged += OnSkinPackHostPropertyChanged;
    }

    private void OnSkinPackHostPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (_isApplyingSkinPack || _isRestoringDefaults || _isApplyingSettingsSnapshot)
        {
            return;
        }

        string? name = e.PropertyName;
        if (string.IsNullOrEmpty(name) ||
            name is nameof(SelectedSkinId) or nameof(SelectedSkinIdText) or nameof(AvailableSkinPackOptions))
        {
            return;
        }

        if (name is nameof(SelectedTheme)
            or nameof(SelectedTrayIconStyle)
            or nameof(SelectedWidgetMaterialType)
            or nameof(WidgetOpacity)
            or nameof(WidgetMaterialIntensity)
            or nameof(SelectedWidgetCornerPreference)
            or nameof(SelectedWidgetBorderColorMode)
            or nameof(SelectedWidgetBorderStyle)
            or nameof(SelectedLayoutDensity)
            or nameof(SelectedDisplayWidgetChromeMode)
            or nameof(SelectedInteractiveWidgetChromeMode)
            or nameof(UseSystemAccentColor)
            or nameof(SelectedAccentColor)
            or nameof(SelectedAccentColorSource))
        {
            SyncSelectedSkinIdFromCurrentSettings();
        }
    }

    private void ApplySkinPack(string skinId)
    {
        SkinPack? pack = SkinPackCatalog.FindBuiltIn(skinId);
        if (pack is null)
        {
            return;
        }

        _isApplyingSkinPack = true;
        try
        {
            SkinPackCatalog.Apply(_settingsService.Settings, pack);
            _selectedSkinId = pack.Id;
            ApplySettingsSnapshot();

            _themeService.SetTheme(pack.Theme);
            if (string.Equals(pack.AccentColorMode, ThemeService.AccentModeCustom, StringComparison.OrdinalIgnoreCase))
            {
                if (!string.IsNullOrWhiteSpace(pack.CustomAccentColor) &&
                    AccentColorHelper.TryParseHex(pack.CustomAccentColor, out var color))
                {
                    _themeService.SetCustomAccentColor(color);
                }
                else
                {
                    _themeService.SetAccentMode(ThemeService.AccentModeCustom);
                }
            }
            else
            {
                _themeService.SetAccentMode(ThemeService.AccentModeSystem);
            }

            App.Current?.UpdateTrayIcon();
            SaveAppearanceChange();
            OnPropertyChanged(nameof(SelectedSkinId));
            OnPropertyChanged(nameof(SelectedSkinIdText));
        }
        finally
        {
            _isApplyingSkinPack = false;
        }
    }

    private void SyncSelectedSkinIdFromCurrentSettings()
    {
        string matched = SkinPackCatalog.ResolveMatchingSkinId(_settingsService.Settings);
        string current = SkinPackCatalog.NormalizeSelectedSkinId(_settingsService.Settings.SelectedSkinId);
        if (string.Equals(current, matched, StringComparison.Ordinal) &&
            string.Equals(_selectedSkinId, matched, StringComparison.Ordinal))
        {
            return;
        }

        _selectedSkinId = matched;
        _settingsService.Settings.SelectedSkinId = matched;
        OnPropertyChanged(nameof(SelectedSkinId));
        OnPropertyChanged(nameof(SelectedSkinIdText));
    }
}
