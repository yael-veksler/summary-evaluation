namespace SummaryEvaluation
{
    partial class RougeForMultiple
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
            this.btn_compare = new System.Windows.Forms.Button();
            this.lengthBaseline = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.checkBox_comparetobaseline = new System.Windows.Forms.CheckBox();
            this.title = new System.Windows.Forms.Label();
            this.comboBox_Dskip = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_chooseN = new System.Windows.Forms.Label();
            this.btn_calcRouge = new System.Windows.Forms.Button();
            this.comboBox_n = new System.Windows.Forms.ComboBox();
            this.checkedListBox_filesName = new System.Windows.Forms.CheckedListBox();
            this.groupBox_bestORavg = new System.Windows.Forms.GroupBox();
            this.radioButtonAvg = new System.Windows.Forms.RadioButton();
            this.radioButtonBest = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.groupBox_bestORavg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_compare
            // 
            this.btn_compare.Location = new System.Drawing.Point(833, 343);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Size = new System.Drawing.Size(97, 65);
            this.btn_compare.TabIndex = 31;
            this.btn_compare.Text = "compare";
            this.btn_compare.UseVisualStyleBackColor = true;
            this.btn_compare.Visible = false;
            this.btn_compare.Click += new System.EventHandler(this.btn_compare_Click);
            // 
            // lengthBaseline
            // 
            this.lengthBaseline.AutoSize = true;
            this.lengthBaseline.Location = new System.Drawing.Point(25, 391);
            this.lengthBaseline.Name = "lengthBaseline";
            this.lengthBaseline.Size = new System.Drawing.Size(118, 13);
            this.lengthBaseline.TabIndex = 29;
            this.lengthBaseline.Text = "The length of baseline -";
            this.lengthBaseline.Visible = false;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(28, 469);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.Size = new System.Drawing.Size(940, 191);
            this.dataGridView4.TabIndex = 28;
            this.dataGridView4.Visible = false;
            // 
            // checkBox_comparetobaseline
            // 
            this.checkBox_comparetobaseline.AutoSize = true;
            this.checkBox_comparetobaseline.Location = new System.Drawing.Point(28, 339);
            this.checkBox_comparetobaseline.Name = "checkBox_comparetobaseline";
            this.checkBox_comparetobaseline.Size = new System.Drawing.Size(140, 17);
            this.checkBox_comparetobaseline.TabIndex = 27;
            this.checkBox_comparetobaseline.Text = "compare to baselines by";
            this.checkBox_comparetobaseline.UseVisualStyleBackColor = true;
            this.checkBox_comparetobaseline.Visible = false;
            this.checkBox_comparetobaseline.CheckedChanged += new System.EventHandler(this.checkBox_comparetobaseline_CheckedChanged);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(39, 83);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(80, 13);
            this.title.TabIndex = 26;
            this.title.Text = "The results are:";
            this.title.Visible = false;
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
            this.comboBox_Dskip.Location = new System.Drawing.Point(577, 41);
            this.comboBox_Dskip.Name = "comboBox_Dskip";
            this.comboBox_Dskip.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Dskip.TabIndex = 24;
            this.comboBox_Dskip.SelectedIndexChanged += new System.EventHandler(this.comboBox_Dskip_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Choose the length of the Dskip :";
            // 
            // lbl_chooseN
            // 
            this.lbl_chooseN.AutoSize = true;
            this.lbl_chooseN.Location = new System.Drawing.Point(36, 41);
            this.lbl_chooseN.Name = "lbl_chooseN";
            this.lbl_chooseN.Size = new System.Drawing.Size(166, 13);
            this.lbl_chooseN.TabIndex = 22;
            this.lbl_chooseN.Text = "Choose the length of the N-gram :";
            // 
            // btn_calcRouge
            // 
            this.btn_calcRouge.Location = new System.Drawing.Point(763, 41);
            this.btn_calcRouge.Name = "btn_calcRouge";
            this.btn_calcRouge.Size = new System.Drawing.Size(75, 23);
            this.btn_calcRouge.TabIndex = 21;
            this.btn_calcRouge.Text = "calc";
            this.btn_calcRouge.UseVisualStyleBackColor = true;
            this.btn_calcRouge.Click += new System.EventHandler(this.btn_calcRouge_Click);
            // 
            // comboBox_n
            // 
            this.comboBox_n.FormattingEnabled = true;
            this.comboBox_n.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_n.Location = new System.Drawing.Point(227, 38);
            this.comboBox_n.Name = "comboBox_n";
            this.comboBox_n.Size = new System.Drawing.Size(121, 21);
            this.comboBox_n.TabIndex = 20;
            this.comboBox_n.SelectedIndexChanged += new System.EventHandler(this.comboBox_n_SelectedIndexChanged);
            // 
            // checkedListBox_filesName
            // 
            this.checkedListBox_filesName.FormattingEnabled = true;
            this.checkedListBox_filesName.Location = new System.Drawing.Point(545, 365);
            this.checkedListBox_filesName.Name = "checkedListBox_filesName";
            this.checkedListBox_filesName.Size = new System.Drawing.Size(217, 94);
            this.checkedListBox_filesName.TabIndex = 32;
            // 
            // groupBox_bestORavg
            // 
            this.groupBox_bestORavg.Controls.Add(this.radioButtonAvg);
            this.groupBox_bestORavg.Controls.Add(this.radioButtonBest);
            this.groupBox_bestORavg.Location = new System.Drawing.Point(187, 321);
            this.groupBox_bestORavg.Name = "groupBox_bestORavg";
            this.groupBox_bestORavg.Size = new System.Drawing.Size(217, 47);
            this.groupBox_bestORavg.TabIndex = 33;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Choose files:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(940, 191);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.Visible = false;
            // 
            // RougeForMultiple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 733);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox_bestORavg);
            this.Controls.Add(this.checkedListBox_filesName);
            this.Controls.Add(this.btn_compare);
            this.Controls.Add(this.lengthBaseline);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.checkBox_comparetobaseline);
            this.Controls.Add(this.title);
            this.Controls.Add(this.comboBox_Dskip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_chooseN);
            this.Controls.Add(this.btn_calcRouge);
            this.Controls.Add(this.comboBox_n);
            this.Name = "RougeForMultiple";
            this.Text = "Rouge";
            this.Load += new System.EventHandler(this.RougeForMultiple_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.groupBox_bestORavg.ResumeLayout(false);
            this.groupBox_bestORavg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_compare;
        private System.Windows.Forms.Label lengthBaseline;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.CheckBox checkBox_comparetobaseline;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.ComboBox comboBox_Dskip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_chooseN;
        private System.Windows.Forms.Button btn_calcRouge;
        private System.Windows.Forms.ComboBox comboBox_n;
        private System.Windows.Forms.CheckedListBox checkedListBox_filesName;
        private System.Windows.Forms.GroupBox groupBox_bestORavg;
        private System.Windows.Forms.RadioButton radioButtonAvg;
        private System.Windows.Forms.RadioButton radioButtonBest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}