namespace SummaryEvaluationWindowsFormsApp
{
    partial class RougeWSUForm
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
            this.groupBox_bestORavg = new System.Windows.Forms.GroupBox();
            this.radioButtonAvg = new System.Windows.Forms.RadioButton();
            this.radioButtonBest = new System.Windows.Forms.RadioButton();
            this.checkedListBox_filesName = new System.Windows.Forms.CheckedListBox();
            this.btn_compare = new System.Windows.Forms.Button();
            this.lengthBaseline = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.checkBox_comparetobaseline = new System.Windows.Forms.CheckBox();
            this.title = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox_Dskip = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_calcRouge = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_bestORavg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_bestORavg
            // 
            this.groupBox_bestORavg.Controls.Add(this.radioButtonAvg);
            this.groupBox_bestORavg.Controls.Add(this.radioButtonBest);
            this.groupBox_bestORavg.Location = new System.Drawing.Point(171, 390);
            this.groupBox_bestORavg.Name = "groupBox_bestORavg";
            this.groupBox_bestORavg.Size = new System.Drawing.Size(217, 47);
            this.groupBox_bestORavg.TabIndex = 47;
            this.groupBox_bestORavg.TabStop = false;
            // 
            // radioButtonAvg
            // 
            this.radioButtonAvg.AutoSize = true;
            this.radioButtonAvg.Location = new System.Drawing.Point(124, 19);
            this.radioButtonAvg.Name = "radioButtonAvg";
            this.radioButtonAvg.Size = new System.Drawing.Size(44, 17);
            this.radioButtonAvg.TabIndex = 35;
            this.radioButtonAvg.Text = "Avg";
            this.radioButtonAvg.UseVisualStyleBackColor = true;
            // 
            // radioButtonBest
            // 
            this.radioButtonBest.AutoSize = true;
            this.radioButtonBest.Checked = true;
            this.radioButtonBest.Location = new System.Drawing.Point(22, 19);
            this.radioButtonBest.Name = "radioButtonBest";
            this.radioButtonBest.Size = new System.Drawing.Size(46, 17);
            this.radioButtonBest.TabIndex = 34;
            this.radioButtonBest.TabStop = true;
            this.radioButtonBest.Text = "Best";
            this.radioButtonBest.UseVisualStyleBackColor = true;
            // 
            // checkedListBox_filesName
            // 
            this.checkedListBox_filesName.FormattingEnabled = true;
            this.checkedListBox_filesName.Location = new System.Drawing.Point(529, 434);
            this.checkedListBox_filesName.Name = "checkedListBox_filesName";
            this.checkedListBox_filesName.Size = new System.Drawing.Size(217, 94);
            this.checkedListBox_filesName.TabIndex = 46;
            // 
            // btn_compare
            // 
            this.btn_compare.Location = new System.Drawing.Point(817, 412);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Size = new System.Drawing.Size(97, 65);
            this.btn_compare.TabIndex = 45;
            this.btn_compare.Text = "compare";
            this.btn_compare.UseVisualStyleBackColor = true;
            this.btn_compare.Visible = false;
            this.btn_compare.Click += new System.EventHandler(this.btn_compare_Click_1);
            // 
            // lengthBaseline
            // 
            this.lengthBaseline.AutoSize = true;
            this.lengthBaseline.Location = new System.Drawing.Point(9, 460);
            this.lengthBaseline.Name = "lengthBaseline";
            this.lengthBaseline.Size = new System.Drawing.Size(118, 13);
            this.lengthBaseline.TabIndex = 44;
            this.lengthBaseline.Text = "The length of baseline -";
            this.lengthBaseline.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 583);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(940, 191);
            this.dataGridView2.TabIndex = 43;
            this.dataGridView2.Visible = false;
            // 
            // checkBox_comparetobaseline
            // 
            this.checkBox_comparetobaseline.AutoSize = true;
            this.checkBox_comparetobaseline.Location = new System.Drawing.Point(12, 408);
            this.checkBox_comparetobaseline.Name = "checkBox_comparetobaseline";
            this.checkBox_comparetobaseline.Size = new System.Drawing.Size(140, 17);
            this.checkBox_comparetobaseline.TabIndex = 42;
            this.checkBox_comparetobaseline.Text = "compare to baselines by";
            this.checkBox_comparetobaseline.UseVisualStyleBackColor = true;
            this.checkBox_comparetobaseline.Visible = false;
            this.checkBox_comparetobaseline.CheckedChanged += new System.EventHandler(this.checkBox_comparetobaseline_CheckedChanged_1);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(23, 130);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(80, 13);
            this.title.TabIndex = 41;
            this.title.Text = "The results are:";
            this.title.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(940, 183);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.Visible = false;
            // 
            // comboBox_Dskip
            // 
            this.comboBox_Dskip.FormattingEnabled = true;
            this.comboBox_Dskip.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_Dskip.Location = new System.Drawing.Point(216, 42);
            this.comboBox_Dskip.Name = "comboBox_Dskip";
            this.comboBox_Dskip.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Dskip.TabIndex = 39;
            this.comboBox_Dskip.SelectedIndexChanged += new System.EventHandler(this.comboBox_Dskip_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Choose the length of the Dskip :";
            // 
            // btn_calcRouge
            // 
            this.btn_calcRouge.Location = new System.Drawing.Point(747, 42);
            this.btn_calcRouge.Name = "btn_calcRouge";
            this.btn_calcRouge.Size = new System.Drawing.Size(75, 23);
            this.btn_calcRouge.TabIndex = 36;
            this.btn_calcRouge.Text = "calc";
            this.btn_calcRouge.UseVisualStyleBackColor = true;
            this.btn_calcRouge.Click += new System.EventHandler(this.btn_calcRouge_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(526, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Choose files:";
            // 
            // RougeWSUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 733);
            this.Controls.Add(this.groupBox_bestORavg);
            this.Controls.Add(this.checkedListBox_filesName);
            this.Controls.Add(this.btn_compare);
            this.Controls.Add(this.lengthBaseline);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.checkBox_comparetobaseline);
            this.Controls.Add(this.title);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox_Dskip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_calcRouge);
            this.Controls.Add(this.label2);
            this.Name = "RougeWSUForm";
            this.Text = "RougeWSU";
            this.Load += new System.EventHandler(this.RougeWSU_Load);
            this.groupBox_bestORavg.ResumeLayout(false);
            this.groupBox_bestORavg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_bestORavg;
        private System.Windows.Forms.RadioButton radioButtonAvg;
        private System.Windows.Forms.RadioButton radioButtonBest;
        private System.Windows.Forms.CheckedListBox checkedListBox_filesName;
        private System.Windows.Forms.Button btn_compare;
        private System.Windows.Forms.Label lengthBaseline;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.CheckBox checkBox_comparetobaseline;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox_Dskip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_calcRouge;
        private System.Windows.Forms.Label label2;
    }
}