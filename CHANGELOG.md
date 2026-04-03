# Changelog

## 2026-04-03

- Replaced `IInsertionSort`, `IMergeSort`, and `IQuickSort` with a single `ISortAlgorithm` interface exposing `Sort(SortElement[], CancellationToken)`
- Updated `InsertionSort`, `MergeSort`, and `QuickSort` to implement `ISortAlgorithm`; made internal helper methods private
- Added `StartSort(ISortAlgorithm)` helper to `FrmMain` and simplified sort button click handlers
- Removed `IInsertionSort.cs`, `IMergeSort.cs`, and `IQuickSort.cs`
- Renamed `Height` class to `SortElement` for clarity across all source files and interfaces
- Removed parameterless constructor from `SortElement`
- Renamed `Models/Height.cs` to `Models/SortElement.cs`
- Updated `SortingVisualizer.csproj` compile reference to `Models\SortElement.cs`
