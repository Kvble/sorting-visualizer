using SortingVisualizer.Models;
using System.Collections.Generic;
using System.Threading;

namespace SortingVisualizer.Interfaces
{
    internal interface IMergeSort
    {
        Height[] MergeSortHelper(Height[] height, CancellationToken token);
        Height[] MergeSortProcess(List<Height> left, List<Height> right, CancellationToken token);
        void MoveValueFromSourceToResult(List<Height> source, List<Height> result, int index, List<Height> compared, bool isChanging, bool isSourceLeft);
    }
}
