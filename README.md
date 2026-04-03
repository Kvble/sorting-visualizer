# Sorting Visualizer

A Windows desktop app that lets you see how different sorting algorithms work in real time. Watch bars get compared, swapped, and sorted with color-coded animations.

## Download

Grab the latest release from the [Releases page](https://github.com/Kvble/sorting-visualizer/releases) and run it. No installation needed.

## How to Use

1. Click **Generate New Array** to create a random set of bars
2. Click **Merge Sort**, **Quick Sort**, or **Insertion Sort** to start
3. Watch the algorithm work — red means comparing, blue means moving, black means done
4. Click **Generate New Array** again at any time to stop and start over

## Developing

Clone the repository and open it in [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/vs/community/). Requires the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
git clone https://github.com/Kvble/sorting-visualizer.git
cd sorting-visualizer
dotnet build
dotnet run
```

Press **F5** in VS Code to launch with the debugger attached.

## Patch Notes

### v2.0.0 (2026-04-03)

- Upgraded to .NET 8 — better performance and modern tooling
- App no longer loses its drawing when another window covers it
- Smoother animations with no flickering
- Stopping a sort mid-way is now clean and instant (no more force-killing threads)
- Fixed a memory leak that could crash the app after generating many arrays
- Cleaner codebase with dependency injection and a single unified sorting interface

### v1.0.0 (2022-02-12)

- Added Insertion Sort
- Improved thread management — sorting can be interrupted by generating a new array
- Refactored project structure with interfaces and models

### v0.2.0 (2021-12-23)

- Added Quick Sort with animated visualization
- Buttons are disabled while sorting is running
- Added GitHub link in the Help menu
- Added application icon
- Reorganized project folder structure

### v0.1.1 (2021-12-22)

- Improved code modularity
- Adjusted sorting animation speed

### v0.1.0 (2021-11-27)

- Initial release
- Merge Sort with real-time visualization
- Random array generation

## Contributing

If you'd like to contribute, please fork the repository and use a feature branch. Pull requests are welcome.

## License

[MIT](https://github.com/Kvble/sorting-visualizer/blob/main/LICENSE.md)
