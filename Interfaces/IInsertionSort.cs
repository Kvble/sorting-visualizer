using SortingVisualizer.Models;
using System.Collections.Generic;
using System.Threading;

namespace SortingVisualizer.Interfaces
{
    internal interface IInsertionSort
    {
        void InsertionSortProcess(SortElement[] heights, CancellationToken token);
    }
}
