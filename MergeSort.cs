using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using SortingVisualizer.Utility;

namespace SortingVisualizer
{
    class MergeSort
    {

        public MergeSort()
        {
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
                Global.Canvas.drawRect(Color.Red, left.First().Id * 5, Global.MaxHeight - left.First().Value);
                Global.Canvas.drawRect(Color.Red, right.First().Id * 5, Global.MaxHeight - right.First().Value);
                Thread.Sleep(15);
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
            Global.Canvas.drawRect(Color.White, source.First().Id * 5, 0);
            if (NotEmpty(compared))
            {
                if(isChanging)
                {
                    Global.Canvas.drawRect(Color.White, compared.First().Id * 5, 0);
                    if (isSourceLeft)
                    {
                        for (int i = 1; i < source.Count; i++)
                        {
                            source[i].Id++;
                            Global.Canvas.drawRect(Color.White, source[i].Id * 5, 0);
                            Global.Canvas.drawRect(Color.Black, source[i].Id * 5, Global.MaxHeight - source[i].Value);
                        }
                    }
                    for (int i = 0; i < compared.Count; i++)
                    {
                        compared[i].Id++;
                        Global.Canvas.drawRect(Color.White, compared[i].Id * 5, 0);
                        Global.Canvas.drawRect(Color.Black, compared[i].Id * 5, Global.MaxHeight - compared[i].Value);
                    }
                }
            }
            source.First().Id = index;
            Global.Canvas.drawRect(Color.Blue, source.First().Id * 5, Global.MaxHeight - source.First().Value);
            Thread.Sleep(5);
            Global.Canvas.drawRect(Color.Black, source.First().Id * 5, Global.MaxHeight - source.First().Value);
            result.Add(source.First());
            source.RemoveAt(0);
        }
    }
}
