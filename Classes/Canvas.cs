using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using SortingVisualizer.Classes.Utility;

namespace SortingVisualizer.Classes
{
    class Canvas
    {

        public Canvas()
        {
        }

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
