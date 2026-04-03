using SortingVisualizer.Models;
using System.Threading;

namespace SortingVisualizer.Interfaces
{
    internal interface ISortAlgorithm
    {
        void Sort(SortElement[] elements, CancellationToken token);
    }
}
