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
        Graphics graphics;

        public Canvas(Panel canvas)
        {
            this.graphics = canvas.CreateGraphics();
        }

        public void clearCanvas(int width, int height)
        {
            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
        }
    }
}
