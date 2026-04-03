using System.Drawing;
using System.Threading;

namespace SortingVisualizer.Utility
{
    static class Global
    {
        public static int Width;
        public static int MaxHeight;
        public static int MaxWidth;
        public static Graphics Graphics;
        public static Canvas Canvas;
        public static int maxEntities;
        public static CancellationTokenSource Cts;
    }
}
