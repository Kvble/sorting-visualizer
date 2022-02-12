using SortingVisualizer.Models;

namespace SortingVisualizer.Interfaces
{
    internal interface IQuickSort
    {
        void QuickSortHelper(Height[] heights, int low, int high);
        void Swap(ref Height a, ref Height b);
        int QuickSortPartition(Height[] heights, int low, int high);
    }
}
