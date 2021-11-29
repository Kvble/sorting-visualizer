using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace SortingVisualizer
{
    class MergeSort
    {
        Graphics graphics;
        int maxHeight;

        public MergeSort(Graphics graphics, int maxHeight)
        {
            this.graphics = graphics;
            this.maxHeight = maxHeight;
        }
        public Height[] MergeSortHelper(Height[] height)
        {
            int half = height.Length / 2;
            
            if (height.Length <= 1) return height;

            Height[] leftSide;
            Height[] rightSide;

            if (height.Length % 2 == 0)
            {
                leftSide = new Height[half];
                rightSide = new Height[half];
                int index = half;
                for (int i = 0; i < half;  i++)
                {
                    leftSide[i] = height[i];
                    rightSide[i] = height[index];
                    index++;
                }
            }
            else
            {
                leftSide = new Height[half + 1];
                rightSide = new Height[half];
                for (int i = 0; i < half + 1; i++)
               {
                    leftSide[i] = height[i];
                }
                int index = half + 1;
                for (int i = 0; i < half; i++)
                {
                    rightSide[i] = height[index];
                    index++;
                }
            }

            leftSide = MergeSortHelper(leftSide);
            rightSide = MergeSortHelper(rightSide);

            return this.MergeSortProcess(leftSide.ToList(), rightSide.ToList());
        }

        public Height[] MergeSortProcess(List<Height> left, List<Height> right)
        {
            var result = new List<Height>();
            int index = left.First().Id;
            while (NotEmpty(left) && NotEmpty(right))
            {
                graphics.FillRectangle(new SolidBrush(Color.Red), left.First().Id * 5, maxHeight - left.First().Value, 5, maxHeight);
                graphics.DrawRectangle(new Pen(Color.White, 1), left.First().Id * 5, maxHeight - left.First().Value, 5, maxHeight);
                graphics.FillRectangle(new SolidBrush(Color.Red), right.First().Id * 5, maxHeight - right.First().Value, 5, maxHeight);
                graphics.DrawRectangle(new Pen(Color.White, 1), right.First().Id * 5, maxHeight - right.First().Value, 5, maxHeight);
                Thread.Sleep(50);
                if (left.First().Value <= right.First().Value)
                    MoveValueFromSourceToResult(left, result, index, right, false, true);
                else
                    MoveValueFromSourceToResult(right, result, index, left, true, false);

                index++;
            }

            while (NotEmpty(left))
            {
                MoveValueFromSourceToResult(left, result, index, right, false, true);
                index++;
            }

            while (NotEmpty(right))
            {
                MoveValueFromSourceToResult(right, result, index, left, false, false);
                index++;
            }
            return result.ToArray();
        }

        private static bool NotEmpty(List<Height> list)
        {
            return list.Count > 0;
        }

        private void MoveValueFromSourceToResult(List<Height> source, List<Height> result, int index, List<Height> compared, bool isChanging, bool isSourceLeft)
        {
            graphics.FillRectangle(new SolidBrush(Color.White), source.First().Id * 5, 0, 5, maxHeight);
            if (NotEmpty(compared))
            {
                if(isChanging)
                {
                    graphics.FillRectangle(new SolidBrush(Color.White), compared.First().Id * 5, 0, 5, maxHeight);
                    if (isSourceLeft)
                    {
                        for (int i = 1; i < source.Count; i++)
                        {
                            source[i].Id++;
                            graphics.FillRectangle(new SolidBrush(Color.White), source[i].Id * 5, 0, 5, maxHeight);
                            graphics.FillRectangle(new SolidBrush(Color.Black), source[i].Id * 5, maxHeight - source[i].Value, 5, maxHeight);
                            graphics.DrawRectangle(new Pen(Color.White, 1), source[i].Id * 5, maxHeight - source[i].Value, 5, maxHeight);
                        }
                    }
                    for (int i = 0; i < compared.Count; i++)
                    {
                        compared[i].Id++;
                        graphics.FillRectangle(new SolidBrush(Color.White), compared[i].Id * 5, 0, 5, maxHeight);
                        graphics.FillRectangle(new SolidBrush(Color.Black), compared[i].Id * 5, maxHeight - compared[i].Value, 5, maxHeight);
                        graphics.DrawRectangle(new Pen(Color.White, 1), compared[i].Id * 5, maxHeight - compared[i].Value, 5, maxHeight);
                    }
                }
            }
            source.First().Id = index;
            graphics.FillRectangle(new SolidBrush(Color.Blue), source.First().Id * 5, maxHeight - source.First().Value, 5, maxHeight);
            graphics.DrawRectangle(new Pen(Color.White, 1), source.First().Id * 5, maxHeight - source.First().Value, 5, maxHeight);
            Thread.Sleep(10);
            graphics.FillRectangle(new SolidBrush(Color.Black), source.First().Id * 5, maxHeight - source.First().Value, 5, maxHeight);
            graphics.DrawRectangle(new Pen(Color.White, 1), source.First().Id * 5, maxHeight - source.First().Value, 5, maxHeight);
            result.Add(source.First());
            source.RemoveAt(0);
            print(result);
        }

        private static void print(List<Height> source)
        {
            string str = "";
            foreach (var item in source)
            {
                str += item.Value + " ";
            }
            Console.WriteLine(str);
        }
    }
}
