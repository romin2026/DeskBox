using DeskBox.Helpers;
using DeskBox.Models;
using DeskBox.Services;

namespace DeskBox.ViewModels;

public partial class SettingsViewModel
{
    private string _selectedSkinId = SkinPackCatalog.CustomId;

    private bool _isApplyingSkinPack;

    private bool _skinPackHostHookInstalled;

    public string SelectedSkinId
    {
        get
        {
            EnsureSkinPackHostHook();
            return SkinPackCatalog.NormalizeSelectedSkinId(_settingsService.Settings.SelectedSkinId);
        }
        set
        {
            EnsureSkinPackHostHook();
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
            _appearanceSettings.UpdateSkinPackSelection(normalized);

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

    private void EnsureSkinPackHostHook()
    {
        if (_skinPackHostHookInstalled)
        {
            return;
        }

        _skinPackHostHookInstalled = true;
        _selectedSkinId = SkinPackCatalog.NormalizeSelectedSkinId(_settingsService.Settings.SelectedSkinId);
        _appearanceSettings.UpdateSkinPackSelection(_selectedSkinId);
        // When the appearance editor commits user tweaks, re-match the active pack.
        _appearanceSettings.AppearanceValueCommitted += OnAppearanceCommittedForSkinPack;
    }

    private void OnAppearanceCommittedForSkinPack()
    {
        if (_isApplyingSkinPack || _isRestoringDefaults || _isApplyingSettingsSnapshot)
        {
            return;
        }

        SyncSelectedSkinIdFromCurrentSettings();
    }

    private void OnAppearanceSkinPackUserChanged(string skinId)
    {
        // Editor ComboBox wrote SelectedSkinId on the appearance VM; route through
        // this shell property so ApplySkinPack / Custom persistence still runs.
        SelectedSkinId = skinId;
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
            PushAppearanceThemeSelection();
            PushAppearanceAccentPresentation();
            _appearanceSettings.SyncPresentation();
            _appearanceSettings.UpdateSkinPackSelection(pack.Id);
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
        _appearanceSettings.UpdateSkinPackSelection(matched);
    }

    private void PushAppearanceSkinPackSelection()
    {
        string skinId = SkinPackCatalog.NormalizeSelectedSkinId(_settingsService.Settings.SelectedSkinId);
        _selectedSkinId = skinId;
        _appearanceSettings.UpdateSkinPackSelection(skinId);
    }
}
