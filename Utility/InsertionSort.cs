using SortingVisualizer.Interfaces;
using SortingVisualizer.Models;
using System.Drawing;
using System.Threading;

namespace SortingVisualizer.Utility
{
    internal class InsertionSort : ISortAlgorithm
    {
        private readonly ICanvas _canvas;

        public InsertionSort(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public void Sort(SortElement[] elements, CancellationToken token)
        {
            for (int i = 1; i < elements.Length; i++)
            {
                if (token.IsCancellationRequested) return;
                int temp = elements[i].Value;
                int j = i - 1;
                while (j >= 0 && elements[j].Value > temp)
                {
                    if (token.IsCancellationRequested) return;
                    _canvas.DrawRect(Color.Red, elements[j + 1].Id * _canvas.BarWidth, _canvas.MaxHeight - elements[j + 1].Value);
                    _canvas.DrawRect(Color.Red, elements[j].Id * _canvas.BarWidth, _canvas.MaxHeight - elements[j].Value);
                    Thread.Sleep(_canvas.CompareDelayMs);
                    _canvas.DrawRect(Color.White, elements[j + 1].Id * _canvas.BarWidth, 0);
                    _canvas.DrawRect(Color.White, elements[j].Id * _canvas.BarWidth, 0);
                    elements[j + 1].Value = elements[j].Value;
                    _canvas.DrawRect(Color.Blue, elements[j + 1].Id * _canvas.BarWidth, _canvas.MaxHeight - elements[j + 1].Value);
                    _canvas.DrawRect(Color.Blue, elements[j].Id * _canvas.BarWidth, _canvas.MaxHeight - elements[j].Value);
                    Thread.Sleep(_canvas.CompareDelayMs);
                    _canvas.DrawRect(Color.Black, elements[j + 1].Id * _canvas.BarWidth, _canvas.MaxHeight - elements[j + 1].Value);
                    _canvas.DrawRect(Color.Black, elements[j].Id * _canvas.BarWidth, _canvas.MaxHeight - elements[j].Value);
                    j--;
                }
                elements[j + 1].Value = temp;
            }
        }
    }
}
