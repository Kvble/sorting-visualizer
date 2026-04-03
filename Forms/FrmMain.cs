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
        private const int BarWidth = 5;
        private const int ThreadJoinTimeoutMs = 2000;

        private SortElement[] _elements;
        private Thread _currentThread;
        private Canvas _canvas;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public FrmMain()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, pnlCanvas, new object[] { true });
            pnlCanvas.Paint += PnlCanvas_Paint;
        }

        private void PnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            _canvas?.PaintTo(e.Graphics);
        }

        private void InitWindowSettings()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void InitParameters()
        {
            _canvas?.Dispose();
            _canvas = new Canvas(pnlCanvas.Width, pnlCanvas.Height, BarWidth,
                () => { if (!pnlCanvas.IsDisposed) pnlCanvas.BeginInvoke((Action)(() => pnlCanvas.Invalidate())); });
            _elements = new SortElement[pnlCanvas.Width / BarWidth];
        }

        private void EnableSortButtons()
        {
            btnQuickSort.Enabled = true;
            btnMergeSort.Enabled = true;
            btnInsertionSort.Enabled = true;
        }

        private void DisableSortButtons()
        {
            btnQuickSort.Enabled = false;
            btnMergeSort.Enabled = false;
            btnInsertionSort.Enabled = false;
        }

        private void ClearThread()
        {
            _cts.Cancel();
            _currentThread?.Join(ThreadJoinTimeoutMs);
            _cts.Dispose();
            _cts = new CancellationTokenSource();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitWindowSettings();
            DisableSortButtons();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Kvble/sorting-visualizer") { UseShellExecute = true });
        }

        private void linkedInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.linkedin.com/in/kevin-xavier-andrade-125b9b174/") { UseShellExecute = true });
        }

        private void btnGenerateArray_Click(object sender, EventArgs e)
        {
            EnableSortButtons();
            ClearThread();
            InitParameters();

            _canvas.ClearCanvas(pnlCanvas.Width, pnlCanvas.Height);
            var rand = new Random();
            for (int i = 0; i < _elements.Length; i++)
            {
                int randomHeight = rand.Next(0, pnlCanvas.Height);
                _elements[i] = new SortElement(i, randomHeight);
                _canvas.DrawRect(Color.Black, i * BarWidth, pnlCanvas.Height - randomHeight);
            }
        }

        private void StartSort(ISortAlgorithm algorithm)
        {
            DisableSortButtons();
            var token = _cts.Token;
            _currentThread = new Thread(() =>
            {
                algorithm.Sort(_elements, token);
            });
            _currentThread.IsBackground = true;
            _currentThread.Start();
        }

        private void btnMergeSort_Click(object sender, EventArgs e)
        {
            StartSort(new MergeSort(_canvas));
        }

        private void btnQuickSort_Click(object sender, EventArgs e)
        {
            StartSort(new QuickSort(_canvas));
        }

        private void btnInsertionSort_Click(object sender, EventArgs e)
        {
            StartSort(new InsertionSort(_canvas));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cts.Cancel();
            _currentThread?.Join(ThreadJoinTimeoutMs);
            _cts.Dispose();
            _canvas?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
