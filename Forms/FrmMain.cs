using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using SortingVisualizer.Classes.Utility;
using SortingVisualizer.Classes;

namespace SortingVisualizer
{
    public partial class FrmMain : Form
    {
        Height[] heights;

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
            setSortButtons(true);
            Global.Graphics = pnlCanvas.CreateGraphics();
            Global.MaxHeight = pnlCanvas.Height;
            Global.MaxWidth = pnlCanvas.Width;
            Global.Width = 5;
            Global.Canvas = new Canvas();
            int maxEntities = Global.MaxWidth / Global.Width;
            this.heights = new Height[maxEntities];

            Global.Canvas.clearCanvas(Global.MaxWidth, Global.MaxHeight);

            Random rand = new Random();
            for (int i = 0; i < maxEntities; i++)
            {
                int randValue = rand.Next(0, Global.MaxHeight);
                this.heights[i] = new Height(i, randValue);
                Global.Canvas.drawRect(Color.Black, i * 5, Global.MaxHeight - randValue);
            }
        }

        private void btnMergeSort_Click(object sender, EventArgs e)
        {
            setSortButtons(false);
            MergeSort merge = new MergeSort();
            var mergeThread = new Thread(() =>
            {
                this.heights = merge.MergeSortHelper(this.heights);
            });
            mergeThread.IsBackground = true;
            mergeThread.Start();
        }

        private void btnQuickSort_Click(object sender, EventArgs e)
        {
            setSortButtons(false);
            QuickSort quick = new QuickSort();
            var quickThread = new Thread(() =>
            {
                quick.QuickSortHelper(this.heights, 0, this.heights.Length - 1);
            });
            quickThread.IsBackground = true;
            quickThread.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setSortButtons(bool value)
        {
            btnQuickSort.Enabled = value;
            btnMergeSort.Enabled = value;
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

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Kvble/sorting-visualizer");
        }
    }
}
