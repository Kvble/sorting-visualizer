using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using SortingVisualizer.Utility;

namespace SortingVisualizer
{
    class Canvas
    {
        Graphics graphics;

        public Canvas(Panel canvas)
        {
            this.graphics = canvas.CreateGraphics();
        }

        public Canvas(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void clearCanvas(int width, int height)
        {
            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
        }

        public void drawRect(Color color, int xAxis, int yAxis)
        {
            this.graphics.FillRectangle(new SolidBrush(color), xAxis, yAxis, Global.Width, Global.MaxHeight);
            this.graphics.DrawRectangle(new Pen(Color.White, 1), xAxis, yAxis, Global.Width, Global.MaxHeight);
        }

    }
}
