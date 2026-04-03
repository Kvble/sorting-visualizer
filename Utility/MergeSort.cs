using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using SortingVisualizer.Interfaces;
using SortingVisualizer.Models;

namespace SortingVisualizer.Utility
{
    internal class MergeSort : ISortAlgorithm
    {
        private readonly ICanvas _canvas;

        public MergeSort(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public void Sort(SortElement[] elements, CancellationToken token)
        {
            var sorted = MergeSortHelper(elements, token);
            if (token.IsCancellationRequested) return;
            Array.Copy(sorted, elements, elements.Length);
        }

        private SortElement[] MergeSortHelper(SortElement[] elements, CancellationToken token)
        {
            if (elements.Length <= 1) return elements;
            if (token.IsCancellationRequested) return elements;

            int mid = elements.Length - elements.Length / 2;
            var leftSide = elements[..mid];
            var rightSide = elements[mid..];

            leftSide = MergeSortHelper(leftSide, token);
            if (token.IsCancellationRequested) return leftSide;
            rightSide = MergeSortHelper(rightSide, token);
            if (token.IsCancellationRequested) return rightSide;

            return MergeSortProcess(new List<SortElement>(leftSide), new List<SortElement>(rightSide), token);
        }

        private SortElement[] MergeSortProcess(List<SortElement> left, List<SortElement> right, CancellationToken token)
        {
            var result = new List<SortElement>();
            if (left.Count == 0) return right.ToArray();
            if (right.Count == 0) return left.ToArray();
            int index = left[0].Id;
            while (left.Count > 0 && right.Count > 0)
            {
                if (token.IsCancellationRequested) return result.ToArray();
                _canvas.DrawRect(Color.Red, left[0].Id * _canvas.BarWidth, _canvas.MaxHeight - left[0].Value);
                _canvas.DrawRect(Color.Red, right[0].Id * _canvas.BarWidth, _canvas.MaxHeight - right[0].Value);
                Thread.Sleep(_canvas.CompareDelayMs);
                if (left[0].Value <= right[0].Value)
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
            _canvas.DrawRect(Color.White, source[0].Id * _canvas.BarWidth, 0);
            if (compared.Count > 0)
            {
                if (isChanging)
                {
                    _canvas.DrawRect(Color.White, compared[0].Id * _canvas.BarWidth, 0);
                    if (isSourceLeft)
                    {
                        for (int i = 1; i < source.Count; i++)
                        {
                            source[i].Id++;
                            _canvas.DrawRect(Color.White, source[i].Id * _canvas.BarWidth, 0);
                            _canvas.DrawRect(Color.Black, source[i].Id * _canvas.BarWidth, _canvas.MaxHeight - source[i].Value);
                        }
                    }
                    for (int i = 0; i < compared.Count; i++)
                    {
                        compared[i].Id++;
                        _canvas.DrawRect(Color.White, compared[i].Id * _canvas.BarWidth, 0);
                        _canvas.DrawRect(Color.Black, compared[i].Id * _canvas.BarWidth, _canvas.MaxHeight - compared[i].Value);
                    }
                }
            }
            source[0].Id = index;
            _canvas.DrawRect(Color.Blue, source[0].Id * _canvas.BarWidth, _canvas.MaxHeight - source[0].Value);
            Thread.Sleep(_canvas.SwapDelayMs);
            _canvas.DrawRect(Color.Black, source[0].Id * _canvas.BarWidth, _canvas.MaxHeight - source[0].Value);
            result.Add(source[0]);
            source.RemoveAt(0);
        }
    }
}
