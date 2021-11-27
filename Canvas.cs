using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SortingVisualizer
{
    class Canvas
    {
        public void clearCanvas(Panel canvas)
        {
            Graphics formGraphics = canvas.CreateGraphics();
            formGraphics.Clear(Color.White);
        }

        public void drawElement(Panel canvas, Rectangle rect)
        {
            SolidBrush brush = new SolidBrush(Color.Gray);
            Pen pen = new Pen(Color.White, 1);
            Graphics formGraphics = canvas.CreateGraphics();
            formGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            formGraphics.FillRectangle(brush, rect);
            formGraphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
            brush.Dispose();
            formGraphics.Dispose();
        }

        public void drawAllElements(Panel canvas, ref int[] heights)
        {
            Random rnd = new Random();
            for (int i = 1; i <= 84; i++) //84
            {
                int height = rnd.Next(10, 400);
                Array.Resize(ref heights, heights.Length + 1);
                heights[heights.GetUpperBound(0)] = height;
                this.drawElement(canvas, new Rectangle(10 * i, 0, 10, height));
            }
        }

        public void redrawAllElements(Panel canvas, int[] heights)
        {
            for (int i = 0; i < heights.Length; i++)
            {
                this.drawElement(canvas, new Rectangle(10 * (i + 1), 0, 10, heights[i]));
            }
        }
    }
}
