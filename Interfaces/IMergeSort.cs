using SortingVisualizer.Models;
using System.Collections.Generic;
using System.Threading;

namespace SortingVisualizer.Interfaces
{
    internal interface IMergeSort
    {
        SortElement[] MergeSortHelper(SortElement[] height, CancellationToken token);
        SortElement[] MergeSortProcess(List<SortElement> left, List<SortElement> right, CancellationToken token);
        void MoveValueFromSourceToResult(List<SortElement> source, List<SortElement> result, int index, List<SortElement> compared, bool isChanging, bool isSourceLeft);
    }
}
