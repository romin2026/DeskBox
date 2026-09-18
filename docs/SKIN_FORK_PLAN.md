# DeskBox Skin Fork Plan (romin2026)

Private fork goals relative to upstream `Tianyu199509/DeskBox` (GPL-3.0).
Official DeskBox remains the daily driver until a fork build is ready.

## Scope

### v1 — ship first
- Named **widget skin packs** (presets + light custom): material, opacity, corners, border, accent, density, chrome bundled as one selectable skin.
- **Custom UI fonts**: pick installed system fonts for body/title; keep existing size controls.
- **UI/tray/title icons**: replace resource icons for chrome (not file-type icons yet).

### v1.5 — longer track
- **Per-extension file icon packs** with disk cache and fallback to Shell icons.
- Import/export skin packs (folder or zip).

## Non-goals (for now)
- Merging back to upstream (upstream is not accepting external PRs).
- Replacing Windows desktop shell.
- Installing build tooling on Wolf-Win10 without explicit user consent.

## Branch
- Working branch: `feature/skins-fonts-icons`
- Base: `main` @ fork creation

## Build note
Compiling WinUI 3 / .NET 10 Native AOT requires Visual Studio workloads on Windows.
Do **not** install those until the user explicitly approves a tool list.

## Landed (v1 skin packs)
- `SkinPack` model + `SkinPackCatalog` built-in registry (`DarkGlass`, `LightMinimal`, `HighContrast`).
- Persisted `AppSettings.SelectedSkinId` (additive; defaults to `Custom`).
- Appearance settings UI combo (zh-CN + en-US strings) applies a pack by writing existing appearance fields (theme, tray icon, accent, material, opacity, intensity, corners, border, density, chrome).
- Editing any covered appearance field re-resolves the selection; mismatched bundles become `Custom`.
- Unit tests in `tests/DeskBox.Tests/SkinPackCatalogTests.cs`.

### Built-in packs
| Id | Intent |
| --- | --- |
| `DarkGlass` | Dark theme, acrylic, translucent, round corners |
| `LightMinimal` | Light theme, mica, thin border, compact density |
| `HighContrast` | Solid material, thick accent border, relaxed density, strong custom accent |

## Still stubbed
- Custom UI fonts (system font picker for body/title).
- UI / tray / title icon resource packs.
- Per-extension file-type icon packs + cache (v1.5).
- Skin pack import/export (v1.5).

## Next
1. Side-by-side visual QA once a Windows build toolchain is approved.
2. Font picker + chrome icon pack hooks.
3. File-type icon pack pipeline after icon cache design.
