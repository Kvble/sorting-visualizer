using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using SortingVisualizer.Interfaces;
using SortingVisualizer.Models;
using SortingVisualizer.Utility;

namespace SortingVisualizer
{
    public partial class FrmMain : Form
    {
        SortElement[] _heights;
        Thread _currentThread;
        public FrmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initialize general window's settings
        /// </summary>
        public void InitWindowSettings()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        /// <summary>
        /// Initialize global app's parameters
        /// </summary>
        public void InitParameters()
        {
            Global.Graphics?.Dispose();
            Global.Graphics = pnlCanvas.CreateGraphics();
            Global.MaxHeight = pnlCanvas.Height;
            Global.MaxWidth = pnlCanvas.Width;
            Global.Width = Global.BarWidth;
            Global.Canvas = new Canvas();
            Global.MaxEntities = Global.MaxWidth / Global.Width;
            this._heights = new SortElement[Global.MaxEntities];
        }
        /// <summary>
        /// Generates a random number from 0 to the maximum window height
        /// </summary>
        /// <param name="rand">The random number that has been generated</param>
        /// <returns>Returns a random number</returns>
        public int GenRandomNumber(Random rand)
        {
            return rand.Next(0, Global.MaxHeight);
        }
        /// <summary>
        /// Enables all sorting buttons on the window
        /// </summary>
        public void EnableSortButtons()
        {
            btnQuickSort.Enabled = true;
            btnMergeSort.Enabled = true;
            btnInsertionSort.Enabled = true;
        }
        /// <summary>
        /// Disables all sorting buttons on the window
        /// </summary>
        public void DisableSortButtons()
        {
            btnQuickSort.Enabled = false;
            btnMergeSort.Enabled = false;
            btnInsertionSort.Enabled= false;
        }
        /// <summary>
        /// Clears all active threads
        /// </summary>
        public void ClearThread()
        {
            if (Global.Cts != null)
            {
                Global.Cts.Cancel();
                Global.Cts.Dispose();
            }
            Global.Cts = new CancellationTokenSource();
        }
        public void FrmMain_Load(object sender, EventArgs e)
        {
            InitWindowSettings();
        }
        public void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Kvble/sorting-visualizer") { UseShellExecute = true });
        }
        private void linkedInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.linkedin.com/in/kevin-xavier-andrade-125b9b174/") { UseShellExecute = true });
        }
        public void btnGenerateArray_Click(object sender, EventArgs e)
        {
            EnableSortButtons();
            InitParameters();
            ClearThread();

            Global.Canvas.ClearCanvas(Global.MaxWidth, Global.MaxHeight);
            Random rand = new Random();
            for (int i = 0; i < Global.MaxEntities; i++)
            {
                int randomHeight = GenRandomNumber(rand);
                this._heights[i] = new SortElement(i, randomHeight);
                Global.Canvas.DrawRect(Color.Black, i * Global.Width, Global.MaxHeight - randomHeight);
            }
        }
        private void StartSort(ISortAlgorithm algorithm)
        {
            DisableSortButtons();
            var token = Global.Cts.Token;
            _currentThread = new Thread(() =>
            {
                algorithm.Sort(this._heights, token);
            });
            _currentThread.IsBackground = true;
            _currentThread.Start();
        }
        public void btnMergeSort_Click(object sender, EventArgs e)
        {
            StartSort(new MergeSort());
        }
        public void btnQuickSort_Click(object sender, EventArgs e)
        {
            StartSort(new QuickSort());
        }
        public void btnInsertionSort_Click(object sender, EventArgs e)
        {
            StartSort(new InsertionSort());
        }


    }
}
