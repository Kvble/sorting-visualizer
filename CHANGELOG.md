# Changelog

## 2026-04-03

### Bug Fixes

- Fixed GDI+ resource leak in `Canvas`: `SolidBrush` and `Pen` objects are now wrapped in `using` statements, preventing handle exhaustion and eventual crashes during sorting animations
- Replaced dangerous `Thread.Abort()` in `FrmMain.ClearThread()` with `CancellationTokenSource`/`CancellationToken` pattern; all three sorting algorithms now accept and check `CancellationToken` for cooperative cancellation
- Added `lock` around all GDI+ drawing calls in `Canvas` to prevent cross-thread `Graphics` corruption
- Fixed `Graphics` object never being disposed before recreation — each "Generate New Array" click was leaking the previous `Graphics` handle
- Initialized `CancellationTokenSource` at declaration to prevent `NullReferenceException` if sort triggered before array generation
- Added cancellation checks inside QuickSort's inner `do-while` partition loops, which could run for a long time on pathological input without responding to cancellation
- Fixed MergeSort crash on cancellation: added guards for empty lists in `MergeSortProcess` and array size mismatch in `Sort`
- Fixed `Process.Start` for .NET 8 compatibility — added `UseShellExecute = true` for opening URLs
- Sort buttons are now disabled on startup (previously enabled with no array to sort)
- Sorting thread is now joined with 500ms timeout before disposing the `CancellationTokenSource`, preventing the old thread from drawing after cancellation
- Fixed rendering lost on window overlap: replaced fragile `CreateGraphics()` with double-buffered `Bitmap` approach — Canvas now draws to an in-memory buffer, and the panel repaints from it via `Paint` event
- Enabled `DoubleBuffered` on canvas panel to eliminate flickering during sort animations
- `Canvas` now implements `IDisposable` — `Bitmap` and `Graphics` are properly disposed when generating a new array or closing the form
- Changed `_drawLock` from `static` to instance field — prevents cross-instance lock contention
- `pnlCanvas.Invalidate()` now called via `BeginInvoke` with `IsDisposed` guard to prevent cross-thread and disposed-control issues
- Thread join timeout increased from 500ms to 2000ms for more reliable cancellation
- `CancellationTokenSource` properly cancelled, joined, and disposed on form close via `OnFormClosing`

### Refactoring

- Renamed `Height` model class to `SortElement`; removed unnecessary parameterless constructor
- Consolidated three sorting interfaces (`IInsertionSort`, `IMergeSort`, `IQuickSort`) into a single `ISortAlgorithm` with `Sort(SortElement[], CancellationToken)`; internal helper methods made private
- Added `StartSort(ISortAlgorithm)` helper method in `FrmMain`, reducing three identical button handlers to one-liners
- Applied C# naming conventions: PascalCase for all methods, `_camelCase` for private fields, fixed inconsistent casing on `Global.maxEntities`
- Renamed `height`/`heights` parameters to `elements` in MergeSort and QuickSort internal methods
- Eliminated `Global` static class: Canvas now owns its `Graphics`, `BarWidth`, `MaxHeight`, and animation delay constants; sorting algorithms receive `ICanvas` via constructor injection; `FrmMain` owns `Canvas` and `CancellationTokenSource` as instance fields
- `ICanvas` expanded with `BarWidth`, `MaxHeight`, `CompareDelayMs`, `SwapDelayMs` properties
- All event handlers in `FrmMain` changed from `public` to `private`
- Modernized `using` statements to C# 8+ `using` declarations in `Canvas`
- Removed debug `PrintArray()` method and its `Console.WriteLine` calls
- Simplified MergeSort array split from 25 lines to 2 using C# range syntax
- Replaced `.First()` with `[0]` indexing in MergeSort, removed `System.Linq` dependency
- Added explicit `internal` access modifier to all non-public classes

### Cleanup

- Extracted magic numbers to named constants: `Thread.Sleep(15)` -> `CompareDelayMs`, `Thread.Sleep(5)` -> `SwapDelayMs`, `Width = 5` -> `BarWidth`
- Removed unused `using` directives from `InsertionSort.cs` and `Program.cs`
- Deleted `SortUtil.cs` — replaced `SortUtil.NotEmpty(list)` with inline `list.Count > 0`
- Removed unused self-signed certificate (`Kevin Andrade.pfx`) and its `.csproj` references
- Removed unused NuGet dependencies: `Cake.DocFx`, `docfx.console`, `System.Buffers`, `System.Memory`, `System.Runtime.CompilerServices.Unsafe`
- Deleted `packages.config`
- Fixed typo in XML comment: "oon the window" -> "on the window"

### Translation

- Translated all Italian comments to English in `Program.cs`, `FrmMain.Designer.cs`, `AssemblyInfo.cs`, `Resources.Designer.cs`, `Settings.Designer.cs`, `SortingVisualizer.csproj`

### Migration

- Migrated from .NET Framework 4.8 to .NET 8 with SDK-style project file
- Removed obsolete files: `App.config`, `Properties/AssemblyInfo.cs`, `SortingVisualizer.sln`, `packages.config`
- `.csproj` reduced from 153 lines to 12 lines

## 2022-07-27

- Added `.gitignore`
- Cleaned project directory: removed `bin/`, `obj/`, `.vs/`, `_site/` build artifacts from repository
- Restored `Properties/` files that were accidentally deleted during cleanup

## 2021-12-23

- Added Quick Sort algorithm with Hoare partition scheme and visual animation
- Restructured project: moved source files into `Forms/`, `Classes/` folders
- Added custom application icon (`graph.ico`)
- Added self-signed certificate (`Kevin Andrade.pfx`) for assembly signing
- Added `docfx` NuGet package for documentation generation
- Upgraded target framework from .NET Framework 4.6 to 4.8

## 2021-12-22

- Extracted `Global` static class for shared state (`Graphics`, dimensions, `Canvas`)
- Added `LICENSE.md` (MIT)
- Added Release build configuration

## 2021-11-29

- Added `Height` data model with `Id` and `Value` properties
- Refactored Canvas and MergeSort into separate classes
- Added form UI with menu strip (File > Exit, Help > GitHub)

## 2021-11-27

- Initial project setup: C# WinForms application with Merge Sort visualization
- Color-coded animation: red (comparing), blue (moving), black (sorted)
- Random array generation with configurable bar width
