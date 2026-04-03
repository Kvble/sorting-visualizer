using System.Drawing;
using System.Threading;
using SortingVisualizer.Interfaces;
using SortingVisualizer.Models;

namespace SortingVisualizer.Utility
{
    internal class QuickSort : ISortAlgorithm
    {
        private readonly ICanvas _canvas;

        public QuickSort(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public void Sort(SortElement[] elements, CancellationToken token)
        {
            QuickSortHelper(elements, 0, elements.Length - 1, token);
        }

        private void QuickSortHelper(SortElement[] elements, int low, int high, CancellationToken token)
        {
            if (token.IsCancellationRequested) return;
            if (low < high)
            {
                int pi = QuickSortPartition(elements, low, high, token);
                QuickSortHelper(elements, low, pi, token);
                QuickSortHelper(elements, pi + 1, high, token);
            }
        }

        private void Swap(ref SortElement a, ref SortElement b)
        {
            _canvas.DrawRect(Color.Red, a.Id * _canvas.BarWidth, _canvas.MaxHeight - a.Value);
            _canvas.DrawRect(Color.Red, b.Id * _canvas.BarWidth, _canvas.MaxHeight - b.Value);
            Thread.Sleep(_canvas.CompareDelayMs);
            _canvas.DrawRect(Color.White, a.Id * _canvas.BarWidth, 0);
            _canvas.DrawRect(Color.White, b.Id * _canvas.BarWidth, 0);
            int t = a.Value;
            a.Value = b.Value;
            b.Value = t;
            _canvas.DrawRect(Color.Blue, a.Id * _canvas.BarWidth, _canvas.MaxHeight - a.Value);
            _canvas.DrawRect(Color.Blue, b.Id * _canvas.BarWidth, _canvas.MaxHeight - b.Value);
            Thread.Sleep(_canvas.SwapDelayMs);
            _canvas.DrawRect(Color.Black, a.Id * _canvas.BarWidth, _canvas.MaxHeight - a.Value);
            _canvas.DrawRect(Color.Black, b.Id * _canvas.BarWidth, _canvas.MaxHeight - b.Value);
        }

        private int QuickSortPartition(SortElement[] elements, int low, int high, CancellationToken token)
        {
            SortElement pivot = elements[low];
            int i = (low - 1);
            int j = (high + 1);
            do
            {
                if (token.IsCancellationRequested) return j;
                do
                {
                    j = j - 1;
                } while (!token.IsCancellationRequested && elements[j].Value > pivot.Value);
                do
                {
                    i = i + 1;
                } while (!token.IsCancellationRequested && elements[i].Value < pivot.Value);
                if (i < j)
                {
                    Swap(ref elements[i], ref elements[j]);
                }
            } while (i < j);
            return j;
        }
    }
}
