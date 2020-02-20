namespace SummaryEvaluation
{
    partial class MeMoGForm
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
            this.lbl_MinN = new System.Windows.Forms.Label();
            this.btn_calcMeMoG = new System.Windows.Forms.Button();
            this.comboBox_MinN = new System.Windows.Forms.ComboBox();
            this.lbl_MaxN = new System.Windows.Forms.Label();
            this.lbl_Win = new System.Windows.Forms.Label();
            this.comboBox_MaxN = new System.Windows.Forms.ComboBox();
            this.comboBox_Win = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NVS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox_comparetobaseline = new System.Windows.Forms.CheckBox();
            this.lengthBaseline = new System.Windows.Forms.Label();
            this.btn_compare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox_filesName = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_MinN
            // 
            this.lbl_MinN.AutoSize = true;
            this.lbl_MinN.Location = new System.Drawing.Point(34, 56);
            this.lbl_MinN.Name = "lbl_MinN";
            this.lbl_MinN.Size = new System.Drawing.Size(191, 13);
            this.lbl_MinN.TabIndex = 6;
            this.lbl_MinN.Text = "Choose the minimum length of N-gram :";
            // 
            // btn_calcMeMoG
            // 
            this.btn_calcMeMoG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_calcMeMoG.Location = new System.Drawing.Point(454, 83);
            this.btn_calcMeMoG.Name = "btn_calcMeMoG";
            this.btn_calcMeMoG.Size = new System.Drawing.Size(75, 23);
            this.btn_calcMeMoG.TabIndex = 5;
            this.btn_calcMeMoG.Text = "calc";
            this.btn_calcMeMoG.UseVisualStyleBackColor = true;
            this.btn_calcMeMoG.Click += new System.EventHandler(this.btn_calcRouge_Click);
            // 
            // comboBox_MinN
            // 
            this.comboBox_MinN.FormattingEnabled = true;
            this.comboBox_MinN.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_MinN.Location = new System.Drawing.Point(267, 53);
            this.comboBox_MinN.Name = "comboBox_MinN";
            this.comboBox_MinN.Size = new System.Drawing.Size(121, 21);
            this.comboBox_MinN.TabIndex = 4;
            // 
            // lbl_MaxN
            // 
            this.lbl_MaxN.AutoSize = true;
            this.lbl_MaxN.Location = new System.Drawing.Point(34, 88);
            this.lbl_MaxN.Name = "lbl_MaxN";
            this.lbl_MaxN.Size = new System.Drawing.Size(194, 13);
            this.lbl_MaxN.TabIndex = 7;
            this.lbl_MaxN.Text = "Choose the maximum length of N-gram :";
            // 
            // lbl_Win
            // 
            this.lbl_Win.AutoSize = true;
            this.lbl_Win.Location = new System.Drawing.Point(34, 123);
            this.lbl_Win.Name = "lbl_Win";
            this.lbl_Win.Size = new System.Drawing.Size(227, 13);
            this.lbl_Win.TabIndex = 8;
            this.lbl_Win.Text = "Choose thewindow size between twoN-grams :";
            // 
            // comboBox_MaxN
            // 
            this.comboBox_MaxN.FormattingEnabled = true;
            this.comboBox_MaxN.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_MaxN.Location = new System.Drawing.Point(267, 85);
            this.comboBox_MaxN.Name = "comboBox_MaxN";
            this.comboBox_MaxN.Size = new System.Drawing.Size(121, 21);
            this.comboBox_MaxN.TabIndex = 9;
            // 
            // comboBox_Win
            // 
            this.comboBox_Win.FormattingEnabled = true;
            this.comboBox_Win.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_Win.Location = new System.Drawing.Point(267, 115);
            this.comboBox_Win.Name = "comboBox_Win";
            this.comboBox_Win.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Win.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(595, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(340, 112);
            this.dataGridView1.TabIndex = 11;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.summary,
            this.VS,
            this.NVS});
            this.dataGridView2.Location = new System.Drawing.Point(595, 305);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(340, 106);
            this.dataGridView2.TabIndex = 13;
            this.dataGridView2.Visible = false;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // summary
            // 
            this.summary.HeaderText = "";
            this.summary.Name = "summary";
            this.summary.ReadOnly = true;
            // 
            // VS
            // 
            this.VS.HeaderText = "VS";
            this.VS.Name = "VS";
            this.VS.ReadOnly = true;
            // 
            // NVS
            // 
            this.NVS.HeaderText = "NVS";
            this.NVS.Name = "NVS";
            this.NVS.ReadOnly = true;
            // 
            // checkBox_comparetobaseline
            // 
            this.checkBox_comparetobaseline.AutoSize = true;
            this.checkBox_comparetobaseline.Location = new System.Drawing.Point(41, 296);
            this.checkBox_comparetobaseline.Name = "checkBox_comparetobaseline";
            this.checkBox_comparetobaseline.Size = new System.Drawing.Size(126, 17);
            this.checkBox_comparetobaseline.TabIndex = 12;
            this.checkBox_comparetobaseline.Text = "compare to baselines";
            this.checkBox_comparetobaseline.UseVisualStyleBackColor = true;
            this.checkBox_comparetobaseline.Visible = false;
            this.checkBox_comparetobaseline.CheckedChanged += new System.EventHandler(this.checkBox_comparetobaseline_CheckedChanged);
            // 
            // lengthBaseline
            // 
            this.lengthBaseline.AutoSize = true;
            this.lengthBaseline.Location = new System.Drawing.Point(38, 355);
            this.lengthBaseline.Name = "lengthBaseline";
            this.lengthBaseline.Size = new System.Drawing.Size(139, 13);
            this.lengthBaseline.TabIndex = 15;
            this.lengthBaseline.Text = "Enter the length of baseline:";
            this.lengthBaseline.Visible = false;
            this.lengthBaseline.Click += new System.EventHandler(this.lengthBaseline_Click);
            // 
            // btn_compare
            // 
            this.btn_compare.Location = new System.Drawing.Point(416, 348);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Size = new System.Drawing.Size(113, 63);
            this.btn_compare.TabIndex = 17;
            this.btn_compare.Text = "compare";
            this.btn_compare.UseVisualStyleBackColor = true;
            this.btn_compare.Visible = false;
            this.btn_compare.Click += new System.EventHandler(this.btn_compare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Choose files:";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkedListBox_filesName
            // 
            this.checkedListBox_filesName.FormattingEnabled = true;
            this.checkedListBox_filesName.Location = new System.Drawing.Point(130, 410);
            this.checkedListBox_filesName.Name = "checkedListBox_filesName";
            this.checkedListBox_filesName.Size = new System.Drawing.Size(217, 94);
            this.checkedListBox_filesName.TabIndex = 33;
            this.checkedListBox_filesName.Visible = false;
            this.checkedListBox_filesName.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_filesName_SelectedIndexChanged);
            // 
            // MeMoGForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 680);
            this.Controls.Add(this.checkedListBox_filesName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_compare);
            this.Controls.Add(this.lengthBaseline);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.checkBox_comparetobaseline);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox_Win);
            this.Controls.Add(this.comboBox_MaxN);
            this.Controls.Add(this.lbl_Win);
            this.Controls.Add(this.lbl_MaxN);
            this.Controls.Add(this.lbl_MinN);
            this.Controls.Add(this.btn_calcMeMoG);
            this.Controls.Add(this.comboBox_MinN);
            this.Name = "MeMoGForm";
            this.Text = "MeMoG";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_MinN;
        private System.Windows.Forms.Button btn_calcMeMoG;
        private System.Windows.Forms.ComboBox comboBox_MinN;
        private System.Windows.Forms.Label lbl_MaxN;
        private System.Windows.Forms.Label lbl_Win;
        private System.Windows.Forms.ComboBox comboBox_MaxN;
        private System.Windows.Forms.ComboBox comboBox_Win;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.CheckBox checkBox_comparetobaseline;
        private System.Windows.Forms.Label lengthBaseline;
        private System.Windows.Forms.Button btn_compare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox_filesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn VS;
        private System.Windows.Forms.DataGridViewTextBoxColumn NVS;
    }
}