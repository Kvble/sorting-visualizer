using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Documents;

namespace SortingVisualizer
{
    class MergeSort
    {
        public static void MergeSortHelper(ref Span<int> full, ref Span<int> array, Panel canvas)
        {
            int half = array.Length / 2;

            if(array.Length > 1)
            {
                Span<int> leftSide = array.Slice(0, half);
                Span<int> rightSide = array.Slice(half);
                MergeSortHelper(ref full, ref leftSide, canvas);
                MergeSortHelper(ref full, ref rightSide, canvas);
                MergeSortProcess(full, array, half, canvas);
            }
            
        }

        public static void MergeSortProcess(Span<int> full, Span<int> array, int half, Panel canvas)
        {
            Canvas canv = new Canvas();
            int[] unsorted = array.ToArray();
            int indexLeft = 0;
            int indexRight = half;
            int offset = 0;
            canv.clearCanvas(canvas);
            canv.redrawAllElements(canvas, full.ToArray());
            Thread.Sleep(100);
            while (indexLeft < half && indexRight < unsorted.Length)
            {
                if (unsorted[indexLeft] <= unsorted[indexRight])
                {
                    array[offset] = unsorted[indexLeft];
                    indexLeft++;
                }
                else
                {
                    array[offset] = unsorted[indexRight];
                    indexRight++;
                }
                offset++;
            }
            while(indexLeft < half)
            {
                array[offset] = unsorted[indexLeft];
                indexLeft++;
                offset++;
            }
            while (indexRight < unsorted.Length)
            {
                array[offset] = unsorted[indexRight];
                indexRight++;
                offset++;
            }

        }
    }
}
