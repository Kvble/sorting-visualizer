using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using SortingVisualizer.Models;
using SortingVisualizer.Utility;

namespace SortingVisualizer
{
    public partial class FrmMain : Form
    {
        Height[] heights;
        Thread currentThread;
        public FrmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initialize general window's settings
        /// </summary>
        public void initWindowSettings()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        /// <summary>
        /// Initialize global app's parameters
        /// </summary>
        public void initParameters()
        {
            Global.Graphics = pnlCanvas.CreateGraphics();
            Global.MaxHeight = pnlCanvas.Height;
            Global.MaxWidth = pnlCanvas.Width;
            Global.Width = 5;
            Global.Canvas = new Canvas();
            Global.maxEntities = Global.MaxWidth / Global.Width;
            this.heights = new Height[Global.maxEntities];
        }
        /// <summary>
        /// Generates a random number from 0 to the maximum window height
        /// </summary>
        /// <param name="rand">The random number that has been generated</param>
        /// <returns>Returns a random number</returns>
        public int genRandomNumber(Random rand)
        {
            return rand.Next(0, Global.MaxHeight);
        }
        /// <summary>
        /// Enables all sorting buttons on the window
        /// </summary>
        public void enableSortButtons()
        {
            btnQuickSort.Enabled = true;
            btnMergeSort.Enabled = true;
            btnInsertionSort.Enabled = true;
        }
        /// <summary>
        /// Disables all sorting buttons oon the window
        /// </summary>
        public void disableSortButtons()
        {
            btnQuickSort.Enabled = false;
            btnMergeSort.Enabled = false;
            btnInsertionSort.Enabled= false;
        }
        /// <summary>
        /// Clears all active threads
        /// </summary>
        public void clearThread()
        {
            if (currentThread != null)
            {
                currentThread.Abort();
            }
        }
        public void FrmMain_Load(object sender, EventArgs e)
        {
            initWindowSettings();
        }
        public void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Kvble/sorting-visualizer");
        }
        private void linkedInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/kevin-xavier-andrade-125b9b174/");
        }
        public void btnGenerateArray_Click(object sender, EventArgs e)
        {
            enableSortButtons();
            initParameters();
            clearThread();

            Global.Canvas.clearCanvas(Global.MaxWidth, Global.MaxHeight);
            Random rand = new Random();
            for (int i = 0; i < Global.maxEntities; i++)
            {
                int randomHeight = genRandomNumber(rand);
                this.heights[i] = new Height(i, randomHeight);
                Global.Canvas.drawRect(Color.Black, i * Global.Width, Global.MaxHeight - randomHeight);
            }
        }
        public void btnMergeSort_Click(object sender, EventArgs e)
        {
            disableSortButtons();
            MergeSort merge = new MergeSort();
            currentThread = new Thread(() =>
            {
                this.heights = merge.MergeSortHelper(this.heights);
            });
            currentThread.IsBackground = true;
            currentThread.Start();
        }
        public void btnQuickSort_Click(object sender, EventArgs e)
        {
            disableSortButtons();
            QuickSort quick = new QuickSort();
            currentThread = new Thread(() =>
            {
                quick.QuickSortHelper(this.heights, 0, this.heights.Length - 1);
            });
            currentThread.IsBackground = true;
            currentThread.Start();
        }
        public void btnInsertionSort_Click(object sender, EventArgs e)
        {
            printArray();
            disableSortButtons();
            InsertionSort insertion = new InsertionSort();
            currentThread = new Thread(() =>
            {
                insertion.InsertionSortProcess(this.heights);
                printArray();
            });
            currentThread.IsBackground = true;
            currentThread.Start();
        }
        /// <summary>
        /// Iterates every element of the array and prints the element's Id and Value 
        /// </summary>
        public void printArray()
        {
            foreach (var item in this.heights)
            {
                Console.WriteLine($"Id: {item.Id} | Value: {item.Value}\n");
            }
        }

        
    }
}
