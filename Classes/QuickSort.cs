using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using SortingVisualizer.Classes.Utility;

namespace SortingVisualizer.Classes
{
    class QuickSort
    {
        public QuickSort() { }

        public void QuickSortHelper(Height[] heights, int low, int high)
        {
            if (low < high)
            {
                int pi = QuickSortPartition(heights, low, high);

                QuickSortHelper(heights, low, pi);
                QuickSortHelper(heights, pi + 1, high);
            }
        }

        void Swap(ref Height a, ref Height b)
        {
            Global.Canvas.drawRect(Color.Red, a.Id * 5, Global.MaxHeight - a.Value);
            Global.Canvas.drawRect(Color.Red, b.Id * 5, Global.MaxHeight - b.Value);
            Thread.Sleep(15);
            Global.Canvas.drawRect(Color.White, a.Id * 5, 0);
            Global.Canvas.drawRect(Color.White, b.Id * 5, 0);
            int t = a.Value;
            a.Value = b.Value;
            b.Value = t;
            Global.Canvas.drawRect(Color.Blue, a.Id * 5, Global.MaxHeight - a.Value);
            Global.Canvas.drawRect(Color.Blue, b.Id * 5, Global.MaxHeight - b.Value);
            Thread.Sleep(5);
            Global.Canvas.drawRect(Color.Black, a.Id * 5, Global.MaxHeight - a.Value);
            Global.Canvas.drawRect(Color.Black, b.Id * 5, Global.MaxHeight - b.Value);
        }

        public int QuickSortPartition(Height[] heights, int low, int high)
        {
            Height pivot = heights[low];
            int i = (low - 1);
            int j = (high + 1);
            do
            {
                do
                {
                    j = j - 1;
                } while (heights[j].Value > pivot.Value);
                do
                {
                    i = i + 1;
                } while (heights[i].Value < pivot.Value);
                if(i < j)
                {
                    Swap(ref heights[i], ref heights[j]);
                }
            } while (i < j);
            return j;
        }

    }
}
