namespace BakanlikOturumTakibi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gridOturumlar = new DataGridView();
            txtArama = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)gridOturumlar).BeginInit();
            SuspendLayout();
            // 
            // gridOturumlar
            // 
            gridOturumlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridOturumlar.Location = new Point(2, 46);
            gridOturumlar.Name = "gridOturumlar";
            gridOturumlar.RowHeadersWidth = 45;
            gridOturumlar.Size = new Size(798, 404);
            gridOturumlar.TabIndex = 0;
            gridOturumlar.CellContentClick += gridOturumlar_CellContentClick;
            // 
            // txtArama
            // 
            txtArama.Location = new Point(65, 12);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(685, 25);
            txtArama.TabIndex = 1;
            txtArama.TextChanged += txtArama_TextChanged;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 10000;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtArama);
            Controls.Add(gridOturumlar);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)gridOturumlar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridOturumlar;
        private TextBox txtArama;
        private System.Windows.Forms.Timer timer1;
    }
}
