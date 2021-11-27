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
        private int[] heights;
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
            Random rnd = new Random();
            Canvas canvas = new Canvas();
            this.heights = new int[0];
            canvas.clearCanvas(pnlCanvas);
            canvas.drawAllElements(pnlCanvas, ref this.heights);
        }

        private void btnMergeSort_Click(object sender, EventArgs e)
        {
            Canvas canvas = new Canvas();
            Span<int> unsorted = this.heights;

            MergeSort.MergeSortHelper(ref unsorted, ref unsorted, pnlCanvas);

            
            canvas.clearCanvas(pnlCanvas);
            canvas.redrawAllElements(pnlCanvas, unsorted.ToArray());
            
        }
    }
}
