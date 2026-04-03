using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;
using SortingVisualizer.Interfaces;
using System;
using SortingVisualizer.Models;

namespace SortingVisualizer.Utility
{
    class MergeSort : ISortAlgorithm
    {
        public MergeSort(){}

        public void Sort(SortElement[] elements, CancellationToken token)
        {
            var sorted = MergeSortHelper(elements, token);
            if (token.IsCancellationRequested) return;
            System.Array.Copy(sorted, elements, elements.Length);
        }

        private SortElement[] MergeSortHelper(SortElement[] elements, CancellationToken token)
        {
            int half = elements.Length / 2;

            if (elements.Length <= 1) return elements;
            if (token.IsCancellationRequested) return elements;

            SortElement[] leftSide;
            SortElement[] rightSide;

            if (elements.Length % 2 == 0)
            {
                leftSide = new SortElement[half];
                rightSide = new SortElement[half];
                int index = half;
                for (int i = 0; i < half;  i++)
                {
                    leftSide[i] = elements[i];
                    rightSide[i] = elements[index];
                    index++;
                }
            }
            else
            {
                leftSide = new SortElement[half + 1];
                rightSide = new SortElement[half];
                for (int i = 0; i < half + 1; i++)
               {
                    leftSide[i] = elements[i];
                }
                int index = half + 1;
                for (int i = 0; i < half; i++)
                {
                    rightSide[i] = elements[index];
                    index++;
                }
            }

            leftSide = MergeSortHelper(leftSide, token);
            if (token.IsCancellationRequested) return leftSide;
            rightSide = MergeSortHelper(rightSide, token);
            if (token.IsCancellationRequested) return rightSide;

            return this.MergeSortProcess(leftSide.ToList(), rightSide.ToList(), token);
        }

        private SortElement[] MergeSortProcess(List<SortElement> left, List<SortElement> right, CancellationToken token)
        {
            var result = new List<SortElement>();
            if (left.Count == 0) return right.ToArray();
            if (right.Count == 0) return left.ToArray();
            int index = left.First().Id;
            while (left.Count > 0 && right.Count > 0)
            {
                if (token.IsCancellationRequested) return result.ToArray();
                Global.Canvas.DrawRect(Color.Red, left.First().Id * Global.Width, Global.MaxHeight - left.First().Value);
                Global.Canvas.DrawRect(Color.Red, right.First().Id * Global.Width, Global.MaxHeight - right.First().Value);
                Thread.Sleep(Global.CompareDelayMs);
                if (left.First().Value <= right.First().Value)
                    MoveValueFromSourceToResult(left, result, index, right, false, true);
                else
                    MoveValueFromSourceToResult(right, result, index, left, true, false);

                index++;
            }

            while (left.Count > 0)
            {
                if (token.IsCancellationRequested) return result.ToArray();
                MoveValueFromSourceToResult(left, result, index, right, false, true);
                index++;
            }

            while (right.Count > 0)
            {
                if (token.IsCancellationRequested) return result.ToArray();
                MoveValueFromSourceToResult(right, result, index, left, false, false);
                index++;
            }
            return result.ToArray();
        }

        private void MoveValueFromSourceToResult(List<SortElement> source, List<SortElement> result, int index, List<SortElement> compared, bool isChanging, bool isSourceLeft)
        {
            Global.Canvas.DrawRect(Color.White, source.First().Id * Global.Width, 0);
            if (compared.Count > 0)
            {
                if(isChanging)
                {
                    Global.Canvas.DrawRect(Color.White, compared.First().Id * Global.Width, 0);
                    if (isSourceLeft)
                    {
                        for (int i = 1; i < source.Count; i++)
                        {
                            source[i].Id++;
                            Global.Canvas.DrawRect(Color.White, source[i].Id * Global.Width, 0);
                            Global.Canvas.DrawRect(Color.Black, source[i].Id * Global.Width, Global.MaxHeight - source[i].Value);
                        }
                    }
                    for (int i = 0; i < compared.Count; i++)
                    {
                        compared[i].Id++;
                        Global.Canvas.DrawRect(Color.White, compared[i].Id * Global.Width, 0);
                        Global.Canvas.DrawRect(Color.Black, compared[i].Id * Global.Width, Global.MaxHeight - compared[i].Value);
                    }
                }
            }
            source.First().Id = index;
            Global.Canvas.DrawRect(Color.Blue, source.First().Id * Global.Width, Global.MaxHeight - source.First().Value);
            Thread.Sleep(Global.SwapDelayMs);
            Global.Canvas.DrawRect(Color.Black, source.First().Id * Global.Width, Global.MaxHeight - source.First().Value);
            result.Add(source.First());
            source.RemoveAt(0);
        }
    }
}
