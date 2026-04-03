using SortingVisualizer.Interfaces;
using SortingVisualizer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace SortingVisualizer.Utility
{
    internal class InsertionSort : ISortAlgorithm
    {
        public void Sort(SortElement[] elements, CancellationToken token)
        {
            for(int i = 1; i < elements.Length; i++)
            {
                if (token.IsCancellationRequested) return;
                int temp = elements[i].Value;
                int j = i - 1;
                while(j >= 0 && elements[j].Value > temp)
                {
                    if (token.IsCancellationRequested) return;
                    Global.Canvas.DrawRect(Color.Red, elements[j + 1].Id * Global.Width, Global.MaxHeight - elements[j + 1].Value);
                    Global.Canvas.DrawRect(Color.Red, elements[j].Id * Global.Width, Global.MaxHeight - elements[j].Value);
                    Thread.Sleep(15);
                    Global.Canvas.DrawRect(Color.White, elements[j + 1].Id * Global.Width, 0);
                    Global.Canvas.DrawRect(Color.White, elements[j].Id * Global.Width, 0);
                    elements[j + 1].Value = elements[j].Value;
                    Global.Canvas.DrawRect(Color.Blue, elements[j + 1].Id * Global.Width, Global.MaxHeight - elements[j + 1].Value);
                    Global.Canvas.DrawRect(Color.Blue, elements[j].Id * Global.Width, Global.MaxHeight - elements[j].Value);
                    Thread.Sleep(15);
                    Global.Canvas.DrawRect(Color.Black, elements[j + 1].Id * Global.Width, Global.MaxHeight - elements[j + 1].Value);
                    Global.Canvas.DrawRect(Color.Black, elements[j].Id * Global.Width, Global.MaxHeight - elements[j].Value);
                    j--;
                }
                elements[j + 1].Value = temp;
            }
        }
    }
}
