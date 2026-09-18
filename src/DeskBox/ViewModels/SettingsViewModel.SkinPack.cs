namespace DeskBox.ViewModels;

public partial class SettingsViewModel
{
    private string _selectedSkinId = SkinPackCatalog.CustomId;

    private bool _isApplyingSkinPack;

    public string SelectedSkinId
    {
        get => _selectedSkinId;
        set
        {
            string normalized = SkinPackCatalog.NormalizeSelectedSkinId(value);
            if (!SetProperty(ref _selectedSkinId, normalized))
            {
                return;
            }

            OnPropertyChanged(nameof(SelectedSkinIdText));

            if (_isRestoringDefaults || _isApplyingSettingsSnapshot)
            {
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
        if (string.Equals(_selectedSkinId, matched, StringComparison.Ordinal))
        {
            if (!string.Equals(_settingsService.Settings.SelectedSkinId, matched, StringComparison.Ordinal))
            {
                _settingsService.Settings.SelectedSkinId = matched;
            }

            return;
        }

        _selectedSkinId = matched;
        _settingsService.Settings.SelectedSkinId = matched;
        OnPropertyChanged(nameof(SelectedSkinId));
        OnPropertyChanged(nameof(SelectedSkinIdText));
    }
}
