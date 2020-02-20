namespace SummaryEvaluation
{
    partial class ReadabilityMetricsForm
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
            this.lbl_result = new System.Windows.Forms.Label();
            this.btn_calc = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NNP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AWL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flesch_Reading_Ease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flesch_Kincaid_Grade_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthBaseline = new System.Windows.Forms.Label();
            this.btn_compare = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_result.Location = new System.Drawing.Point(534, 80);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(0, 24);
            this.lbl_result.TabIndex = 22;
            this.lbl_result.Visible = false;
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(227, 38);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(158, 23);
            this.btn_calc.TabIndex = 23;
            this.btn_calc.Text = "Calculate Readability";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.NNP,
            this.NR,
            this.PR,
            this.Fog,
            this.AWL,
            this.Flesch_Reading_Ease,
            this.Flesch_Kincaid_Grade_Level});
            this.dataGridView1.Location = new System.Drawing.Point(28, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(843, 156);
            this.dataGridView1.TabIndex = 24;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            // 
            // NNP
            // 
            this.NNP.HeaderText = "NNP";
            this.NNP.Name = "NNP";
            // 
            // NR
            // 
            this.NR.HeaderText = "NR";
            this.NR.Name = "NR";
            // 
            // PR
            // 
            this.PR.HeaderText = "PR";
            this.PR.Name = "PR";
            // 
            // Fog
            // 
            this.Fog.HeaderText = "Fog";
            this.Fog.Name = "Fog";
            // 
            // AWL
            // 
            this.AWL.HeaderText = "AWL";
            this.AWL.Name = "AWL";
            // 
            // Flesch_Reading_Ease
            // 
            this.Flesch_Reading_Ease.HeaderText = "Flesch Reading Ease";
            this.Flesch_Reading_Ease.Name = "Flesch_Reading_Ease";
            // 
            // Flesch_Kincaid_Grade_Level
            // 
            this.Flesch_Kincaid_Grade_Level.HeaderText = "Flesch Kincaid Grade Level";
            this.Flesch_Kincaid_Grade_Level.Name = "Flesch_Kincaid_Grade_Level";
            // 
            // lengthBaseline
            // 
            this.lengthBaseline.AutoSize = true;
            this.lengthBaseline.Location = new System.Drawing.Point(25, 402);
            this.lengthBaseline.Name = "lengthBaseline";
            this.lengthBaseline.Size = new System.Drawing.Size(118, 13);
            this.lengthBaseline.TabIndex = 48;
            this.lengthBaseline.Text = "The length of baseline -";
            this.lengthBaseline.Visible = false;
            // 
            // btn_compare
            // 
            this.btn_compare.Location = new System.Drawing.Point(227, 387);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Size = new System.Drawing.Size(172, 43);
            this.btn_compare.TabIndex = 46;
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
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dataGridView2.Location = new System.Drawing.Point(28, 450);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(843, 147);
            this.dataGridView2.TabIndex = 49;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "File Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "NNP";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "NR";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "PR";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Fog";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "AWL";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Flesch Reading Ease";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Flesch Kincaid Grade Level";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // ReadabilityMetricsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 664);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.lengthBaseline);
            this.Controls.Add(this.btn_compare);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.lbl_result);
            this.Name = "ReadabilityMetricsForm";
            this.Text = "ReadabilityMetricsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NNP;
        private System.Windows.Forms.DataGridViewTextBoxColumn NR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fog;
        private System.Windows.Forms.DataGridViewTextBoxColumn AWL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flesch_Reading_Ease;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flesch_Kincaid_Grade_Level;
        private System.Windows.Forms.Label lengthBaseline;
        private System.Windows.Forms.Button btn_compare;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}