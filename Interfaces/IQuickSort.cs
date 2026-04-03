using SortingVisualizer.Models;

namespace SortingVisualizer.Interfaces
{
    internal interface IQuickSort
    {
        void QuickSortHelper(SortElement[] heights, int low, int high);
        void Swap(ref SortElement a, ref SortElement b);
        int QuickSortPartition(SortElement[] heights, int low, int high);
    }
}
