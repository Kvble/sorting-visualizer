using SortingVisualizer.Interfaces;
using SortingVisualizer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace SortingVisualizer.Utility
{
    internal class InsertionSort : IInsertionSort
    {
        public void InsertionSortProcess(Height[] heights)
        {
            for(int i = 1; i < heights.Length; i++) 
            {
                int temp = heights[i].Value;
                int j = i - 1;
                while(j >= 0 && heights[j].Value > temp)
                {
                    Global.Canvas.drawRect(Color.Red, heights[j + 1].Id * Global.Width, Global.MaxHeight - heights[j + 1].Value);
                    Global.Canvas.drawRect(Color.Red, heights[j].Id * Global.Width, Global.MaxHeight - heights[j].Value);
                    Thread.Sleep(15);
                    Global.Canvas.drawRect(Color.White, heights[j + 1].Id * Global.Width, 0);
                    Global.Canvas.drawRect(Color.White, heights[j].Id * Global.Width, 0);
                    heights[j + 1].Value = heights[j].Value;
                    Global.Canvas.drawRect(Color.Blue, heights[j + 1].Id * Global.Width, Global.MaxHeight - heights[j + 1].Value);
                    Global.Canvas.drawRect(Color.Blue, heights[j].Id * Global.Width, Global.MaxHeight - heights[j].Value);
                    Thread.Sleep(15);
                    Global.Canvas.drawRect(Color.Black, heights[j + 1].Id * Global.Width, Global.MaxHeight - heights[j + 1].Value);
                    Global.Canvas.drawRect(Color.Black, heights[j].Id * Global.Width, Global.MaxHeight - heights[j].Value);
                    j--;
                }
                heights[j + 1].Value = temp;
            }
        }
    }
}
