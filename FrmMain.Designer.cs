
namespace SortingVisualizer
{
    partial class FrmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnGenerateArray = new System.Windows.Forms.Button();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.btnMergeSort = new System.Windows.Forms.Button();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.pnlControl.Controls.Add(this.btnMergeSort);
            this.pnlControl.Controls.Add(this.btnGenerateArray);
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(884, 70);
            this.pnlControl.TabIndex = 1;
            // 
            // btnGenerateArray
            // 
            this.btnGenerateArray.FlatAppearance.BorderSize = 0;
            this.btnGenerateArray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateArray.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateArray.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGenerateArray.Location = new System.Drawing.Point(0, 0);
            this.btnGenerateArray.Name = "btnGenerateArray";
            this.btnGenerateArray.Size = new System.Drawing.Size(150, 70);
            this.btnGenerateArray.TabIndex = 0;
            this.btnGenerateArray.Text = "Generate New Array";
            this.btnGenerateArray.UseVisualStyleBackColor = true;
            this.btnGenerateArray.Click += new System.EventHandler(this.btnGenerateArray_Click);
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCanvas.BackColor = System.Drawing.Color.White;
            this.pnlCanvas.Location = new System.Drawing.Point(12, 76);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(860, 473);
            this.pnlCanvas.TabIndex = 2;
            // 
            // btnMergeSort
            // 
            this.btnMergeSort.FlatAppearance.BorderSize = 0;
            this.btnMergeSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMergeSort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMergeSort.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMergeSort.Location = new System.Drawing.Point(147, 0);
            this.btnMergeSort.Name = "btnMergeSort";
            this.btnMergeSort.Size = new System.Drawing.Size(157, 70);
            this.btnMergeSort.TabIndex = 1;
            this.btnMergeSort.Text = "Merge Sort";
            this.btnMergeSort.UseVisualStyleBackColor = true;
            this.btnMergeSort.Click += new System.EventHandler(this.btnMergeSort_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.pnlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.Text = "Sorting Visualizer";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnGenerateArray;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.Button btnMergeSort;
    }
}

