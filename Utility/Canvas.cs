using System.Drawing;
using SortingVisualizer.Interfaces;

namespace SortingVisualizer.Utility
{
    class Canvas : ICanvas
    {
        private static readonly object _drawLock = new object();
        private readonly Graphics _graphics;

        public int BarWidth { get; }
        public int MaxHeight { get; }
        public int CompareDelayMs => 15;
        public int SwapDelayMs => 5;

        public Canvas(Graphics graphics, int barWidth, int maxHeight)
        {
            _graphics = graphics;
            BarWidth = barWidth;
            MaxHeight = maxHeight;
        }

        public void ClearCanvas(int width, int height)
        {
            lock (_drawLock)
            {
                using var brush = new SolidBrush(Color.White);
                _graphics.FillRectangle(brush, 0, 0, width, height);
            }
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
        }
    }
}
