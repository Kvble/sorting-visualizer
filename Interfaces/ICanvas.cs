using System.Drawing;

namespace SortingVisualizer.Interfaces
{
    internal interface ICanvas
    {
        void clearCanvas(int width, int height);
        void drawRect(Color color, int xAxis, int yAxis);
    }
}
