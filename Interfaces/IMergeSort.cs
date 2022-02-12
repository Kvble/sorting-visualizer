using SortingVisualizer.Models;
using System.Collections.Generic;

namespace SortingVisualizer.Interfaces
{
    internal interface IMergeSort
    {
        Height[] MergeSortHelper(Height[] height);
        Height[] MergeSortProcess(List<Height> left, List<Height> right);
        void MoveValueFromSourceToResult(List<Height> source, List<Height> result, int index, List<Height> compared, bool isChanging, bool isSourceLeft);
    }
}
