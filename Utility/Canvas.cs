using System;
using System.Drawing;
using SortingVisualizer.Interfaces;

namespace SortingVisualizer.Utility
{
    internal class Canvas : ICanvas, IDisposable
    {
        private readonly object _drawLock = new object();
        private readonly Bitmap _buffer;
        private readonly Graphics _graphics;
        private readonly Action _requestRepaint;

        public int BarWidth { get; }
        public int MaxHeight { get; }
        public int CompareDelayMs => 15;
        public int SwapDelayMs => 5;

        public Canvas(int width, int height, int barWidth, Action requestRepaint)
        {
            _buffer = new Bitmap(width, height);
            _graphics = Graphics.FromImage(_buffer);
            _requestRepaint = requestRepaint;
            BarWidth = barWidth;
            MaxHeight = height;
        }

        public void PaintTo(Graphics target)
        {
            lock (_drawLock)
            {
                target.DrawImageUnscaled(_buffer, 0, 0);
            }
        }

        public void ClearCanvas(int width, int height)
        {
            lock (_drawLock)
            {
                using var brush = new SolidBrush(Color.White);
                _graphics.FillRectangle(brush, 0, 0, width, height);
            }
            _requestRepaint();
        }

        public void DrawRect(Color color, int xAxis, int yAxis)
        {
            lock (_drawLock)
            {
                using var brush = new SolidBrush(color);
                _graphics.FillRectangle(brush, xAxis, yAxis, BarWidth, MaxHeight);
                using var pen = new Pen(Color.White, 1);
                _graphics.DrawRectangle(pen, xAxis, yAxis, BarWidth, MaxHeight);
            }
            _requestRepaint();
        }

        public void Dispose()
        {
            _graphics?.Dispose();
            _buffer?.Dispose();
        }
    }
}
