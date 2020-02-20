namespace EASY_Summary_Evaluation.Forms
{
    partial class TMForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Calc = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CosSimilarity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CosineSimilarity2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_compare = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthBaseline = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // Calc
            // 
            this.Calc.Location = new System.Drawing.Point(508, 97);
            this.Calc.Name = "Calc";
            this.Calc.Size = new System.Drawing.Size(117, 59);
            this.Calc.TabIndex = 0;
            this.Calc.Text = "Calculate Similarity";
            this.Calc.UseVisualStyleBackColor = true;
            this.Calc.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.CosSimilarity,
            this.CosineSimilarity2});
            this.dataGridView1.Location = new System.Drawing.Point(63, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(393, 105);
            this.dataGridView1.TabIndex = 1;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            // 
            // CosSimilarity
            // 
            this.CosSimilarity.HeaderText = "Cosine Similarity   original-summary";
            this.CosSimilarity.Name = "CosSimilarity";
            this.CosSimilarity.Width = 150;
            // 
            // CosineSimilarity2
            // 
            this.CosineSimilarity2.HeaderText = "Cosine Similarity   original-referencies";
            this.CosineSimilarity2.Name = "CosineSimilarity2";
            // 
            // btn_compare
            // 
            this.btn_compare.Location = new System.Drawing.Point(512, 328);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Size = new System.Drawing.Size(113, 63);
            this.btn_compare.TabIndex = 37;
            this.btn_compare.Text = "compare to baselines";
            this.btn_compare.UseVisualStyleBackColor = true;
            this.btn_compare.Visible = false;
            this.btn_compare.Click += new System.EventHandler(this.btn_compare_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView2.Location = new System.Drawing.Point(63, 311);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(393, 105);
            this.dataGridView2.TabIndex = 38;
            this.dataGridView2.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "File Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Cosine Similarity   original-summary";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Cosine Similarity   original-referencies";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // lengthBaseline
            // 
            this.lengthBaseline.AutoSize = true;
            this.lengthBaseline.Location = new System.Drawing.Point(60, 272);
            this.lengthBaseline.Name = "lengthBaseline";
            this.lengthBaseline.Size = new System.Drawing.Size(118, 13);
            this.lengthBaseline.TabIndex = 45;
            this.lengthBaseline.Text = "The length of baseline -";
            this.lengthBaseline.Visible = false;
            // 
            // TMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 603);
            this.Controls.Add(this.lengthBaseline);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btn_compare);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Calc);
            this.Name = "TMForm";
            this.Text = "Topic Modeling";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Calc;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CosSimilarity;
        private System.Windows.Forms.DataGridViewTextBoxColumn CosineSimilarity2;
        private System.Windows.Forms.Button btn_compare;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label lengthBaseline;
    }
}