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

## Next
1. Collect visual references for 2–3 default skins.
2. Map settings model hooks (`AppearanceOptions`, widget chrome, icon cache).
3. After consent: install build tools → compile → side-by-side test with official DeskBox.
