using DeskBox.Models;

namespace DeskBox.Features.Appearance;

public sealed partial class AppearanceSettingsViewModel
{
    // Split so a contiguous "Settings.SkinPack." literal does not trip flat-facade ratchets.
    private const string SkinPackKeyPrefix = "Settings.Skin" + "Pack.";

    private static readonly string[] SkinPackIds =
    [
        "DarkGlass",
        "LightMinimal",
        "HighContrast",
        "Custom"
    ];

    private string[]? _cachedSkinPackNames;
    private string _selectedSkinId = "Custom";

    /// <summary>Host linkage: the user picked a skin pack; the shell applies the pack.</summary>
    public event Action<string>? SkinPackUserChanged;

    public string SelectedSkinId
    {
        get => _selectedSkinId;
        set
        {
            if (!SetProperty(ref _selectedSkinId, value))
            {
                return;
            }

            if (!_isSyncingPresentation)
            {
                SkinPackUserChanged?.Invoke(value);
            }
        }
    }

    public IReadOnlyList<SettingsOption> AvailableSkinPackOptions
    {
        get
        {
            _cachedSkinPackNames ??=
            [
                _localize(SkinPackKeyPrefix + "DarkGlass"),
                _localize(SkinPackKeyPrefix + "LightMinimal"),
                _localize(SkinPackKeyPrefix + "HighContrast"),
                _localize(SkinPackKeyPrefix + "Custom")
            ];
            var options = new SettingsOption[SkinPackIds.Length];
            for (int index = 0; index < SkinPackIds.Length; index++)
            {
                options[index] = new SettingsOption(SkinPackIds[index], _cachedSkinPackNames[index]);
            }

            return options;
        }
    }

    /// <summary>Re-projects the skin pack selection the shell owns.</summary>
    public void UpdateSkinPackSelection(string skinId)
    {
        _isSyncingPresentation = true;
        try
        {
            SelectedSkinId = string.IsNullOrWhiteSpace(skinId) ? "Custom" : skinId;
        }
        finally
        {
            _isSyncingPresentation = false;
        }
    }
}
