using System.Drawing;
using SortingVisualizer.Interfaces;

namespace SortingVisualizer.Utility
{
    class Canvas : ICanvas
    {
        public Canvas() {}
        public void clearCanvas(int width, int height)
        {
            Global.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
        }
        public void drawRect(Color color, int xAxis, int yAxis)
        {
            Global.Graphics.FillRectangle(new SolidBrush(color), xAxis, yAxis, Global.Width, Global.MaxHeight);
            Global.Graphics.DrawRectangle(new Pen(Color.White, 1), xAxis, yAxis, Global.Width, Global.MaxHeight);
        }
    }
}
