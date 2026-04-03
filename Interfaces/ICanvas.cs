using System.Drawing;

namespace SortingVisualizer.Interfaces
{
    internal interface ICanvas
    {
        int BarWidth { get; }
        int MaxHeight { get; }
        int CompareDelayMs { get; }
        int SwapDelayMs { get; }
        void ClearCanvas(int width, int height);
        void DrawRect(Color color, int xAxis, int yAxis);
    }
}
