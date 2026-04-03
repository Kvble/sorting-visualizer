using SortingVisualizer.Models;
using System.Collections.Generic;
using System.Threading;

namespace SortingVisualizer.Interfaces
{
    internal interface IInsertionSort
    {
        void InsertionSortProcess(Height[] heights, CancellationToken token);
    }
}
