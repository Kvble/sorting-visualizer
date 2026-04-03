using System.Drawing;
using System.Threading;

namespace SortingVisualizer.Utility
{
    static class Global
    {
        public const int BarWidth = 5;
        public const int CompareDelayMs = 15;
        public const int SwapDelayMs = 5;

        public static int Width;
        public static int MaxHeight;
        public static int MaxWidth;
        public static Graphics Graphics;
        public static Canvas Canvas;
        public static int MaxEntities;
        public static CancellationTokenSource Cts = new CancellationTokenSource();
    }
}
