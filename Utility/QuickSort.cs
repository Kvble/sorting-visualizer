using System.Drawing;
using System.Threading;
using SortingVisualizer.Models;

namespace SortingVisualizer.Utility
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
            Global.Canvas.drawRect(Color.Red, a.Id * Global.Width, Global.MaxHeight - a.Value);
            Global.Canvas.drawRect(Color.Red, b.Id * Global.Width, Global.MaxHeight - b.Value);
            Thread.Sleep(15);
            Global.Canvas.drawRect(Color.White, a.Id * Global.Width, 0);
            Global.Canvas.drawRect(Color.White, b.Id * Global.Width, 0);
            int t = a.Value;
            a.Value = b.Value;
            b.Value = t;
            Global.Canvas.drawRect(Color.Blue, a.Id * Global.Width, Global.MaxHeight - a.Value);
            Global.Canvas.drawRect(Color.Blue, b.Id * Global.Width, Global.MaxHeight - b.Value);
            Thread.Sleep(5);
            Global.Canvas.drawRect(Color.Black, a.Id * Global.Width, Global.MaxHeight - a.Value);
            Global.Canvas.drawRect(Color.Black, b.Id * Global.Width, Global.MaxHeight - b.Value);
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
