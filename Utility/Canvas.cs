using System.Drawing;
using SortingVisualizer.Interfaces;

namespace SortingVisualizer.Utility
{
    class Canvas : ICanvas
    {
        private static readonly object _drawLock = new object();

        public Canvas() {}
        public void clearCanvas(int width, int height)
        {
            lock (_drawLock)
            {
                using (var brush = new SolidBrush(Color.White))
                {
                    Global.Graphics.FillRectangle(brush, 0, 0, width, height);
                }
            }
        }
        public void drawRect(Color color, int xAxis, int yAxis)
        {
            lock (_drawLock)
            {
                using (var brush = new SolidBrush(color))
                {
                    Global.Graphics.FillRectangle(brush, xAxis, yAxis, Global.Width, Global.MaxHeight);
                }
                using (var pen = new Pen(Color.White, 1))
                {
                    Global.Graphics.DrawRectangle(pen, xAxis, yAxis, Global.Width, Global.MaxHeight);
                }
            }
        }
    }
}
