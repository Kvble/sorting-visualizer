using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SortingVisualizer
{
    public partial class FrmMain : Form
    {
        Height[] heights;
        Graphics graphics;
        int maxHeight;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnGenerateArray_Click(object sender, EventArgs e)
        {
            graphics = pnlCanvas.CreateGraphics();
            int maxEntities = pnlCanvas.Width / 5;
            maxHeight = pnlCanvas.Height;
            this.heights = new Height[maxEntities];

            Canvas canvas = new Canvas(pnlCanvas);
            canvas.clearCanvas(pnlCanvas.Width, pnlCanvas.Height);

            Random rand = new Random();
            for (int i = 0; i < maxEntities; i++)
            {
                int randValue = rand.Next(0, maxHeight);
                this.heights[i] = new Height(i, randValue);
                graphics.FillRectangle(new SolidBrush(Color.Black), i * 5, maxHeight - randValue, 5, maxHeight);
                graphics.DrawRectangle(new Pen(Color.White, 1), i * 5, maxHeight - randValue, 5, maxHeight);
            }
            printValues();
        }

        private void printValues()
        {
            string str = "";
            for (int i = 0; i < heights.Length; i++)
            {
                str += heights[i].Value + " ";
            }
            Console.WriteLine(str);
        }

        private void btnMergeSort_Click(object sender, EventArgs e)
        {
            MergeSort merge = new MergeSort(graphics, maxHeight);
            var thread = new Thread(() =>
            {
                Height[] sorted = new Height[this.heights.Length];
                sorted = merge.MergeSortHelper(this.heights);
                printValues();
            });
            thread.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
