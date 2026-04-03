using System.Drawing;

namespace SortingVisualizer.Interfaces
{
    internal interface ICanvas
    {
        void ClearCanvas(int width, int height);
        void DrawRect(Color color, int xAxis, int yAxis);
    }
}
