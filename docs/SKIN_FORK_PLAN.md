# DeskBox Skin Fork Plan (romin2026)

## Goals
- Named **widget skin packs** (presets + light custom): material, opacity, corners, border, accent, density, chrome bundled.
- Optional later: custom UI fonts; file-type icon packs; import/export skin packs (folder or zip).
- Working branch: `feature/skins-fonts-icons`

## Landed (v1 skin packs)

- `SettingsViewModel.SkinPack` apply/sync + Appearance ComboBox; Custom re-resolve on appearance field changes.
- `SkinPack` model + `SkinPackCatalog` built-in registry (`DarkGlass`, `LightMinimal`, `HighContrast`).
- Persisted `AppSettings.SelectedSkinId` (additive; defaults to `Custom`).
- Unit tests in `tests/DeskBox.Tests/SkinPackCatalogTests.cs`.
- Appearance UI selector (ComboBox) wired to `SelectedSkinId` / `AvailableSkinPackOptions`.

## Stubbed for later
- Custom UI fonts (app-wide / widget chrome).
- UI / tray / title icon packs.
- Per-extension file-type icons + cache.
- Skin pack import/export (v1.5).
