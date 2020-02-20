namespace SummaryEvaluation
{
    partial class SpearmanCorrelation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelForRouge = new System.Windows.Forms.Label();
            this.labelForMeMoG = new System.Windows.Forms.Label();
            this.comboBox_Win = new System.Windows.Forms.ComboBox();
            this.comboBox_MaxN = new System.Windows.Forms.ComboBox();
            this.lbl_Win = new System.Windows.Forms.Label();
            this.lbl_MaxN = new System.Windows.Forms.Label();
            this.lbl_MinN = new System.Windows.Forms.Label();
            this.comboBox_MinN = new System.Windows.Forms.ComboBox();
            this.comboBox_Dskip = new System.Windows.Forms.ComboBox();
            this.lblDskip = new System.Windows.Forms.Label();
            this.lbl_chooseN = new System.Windows.Forms.Label();
            this.comboBox_n = new System.Windows.Forms.ComboBox();
            this.result = new System.Windows.Forms.Label();
            this.btn_calc = new System.Windows.Forms.Button();
            this.checkedListBox_metrics = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelForRouge
            // 
            this.labelForRouge.AutoSize = true;
            this.labelForRouge.Location = new System.Drawing.Point(31, 188);
            this.labelForRouge.Name = "labelForRouge";
            this.labelForRouge.Size = new System.Drawing.Size(60, 13);
            this.labelForRouge.TabIndex = 84;
            this.labelForRouge.Text = "For Rouge:";
            // 
            // labelForMeMoG
            // 
            this.labelForMeMoG.AutoSize = true;
            this.labelForMeMoG.Location = new System.Drawing.Point(31, 309);
            this.labelForMeMoG.Name = "labelForMeMoG";
            this.labelForMeMoG.Size = new System.Drawing.Size(66, 13);
            this.labelForMeMoG.TabIndex = 83;
            this.labelForMeMoG.Text = "For MeMoG:";
            // 
            // comboBox_Win
            // 
            this.comboBox_Win.FormattingEnabled = true;
            this.comboBox_Win.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_Win.Location = new System.Drawing.Point(261, 405);
            this.comboBox_Win.Name = "comboBox_Win";
            this.comboBox_Win.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Win.TabIndex = 82;
            // 
            // comboBox_MaxN
            // 
            this.comboBox_MaxN.FormattingEnabled = true;
            this.comboBox_MaxN.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_MaxN.Location = new System.Drawing.Point(261, 375);
            this.comboBox_MaxN.Name = "comboBox_MaxN";
            this.comboBox_MaxN.Size = new System.Drawing.Size(121, 21);
            this.comboBox_MaxN.TabIndex = 81;
            // 
            // lbl_Win
            // 
            this.lbl_Win.AutoSize = true;
            this.lbl_Win.Location = new System.Drawing.Point(28, 413);
            this.lbl_Win.Name = "lbl_Win";
            this.lbl_Win.Size = new System.Drawing.Size(227, 13);
            this.lbl_Win.TabIndex = 80;
            this.lbl_Win.Text = "Choose thewindow size between twoN-grams :";
            // 
            // lbl_MaxN
            // 
            this.lbl_MaxN.AutoSize = true;
            this.lbl_MaxN.Location = new System.Drawing.Point(28, 378);
            this.lbl_MaxN.Name = "lbl_MaxN";
            this.lbl_MaxN.Size = new System.Drawing.Size(194, 13);
            this.lbl_MaxN.TabIndex = 79;
            this.lbl_MaxN.Text = "Choose the maximum length of N-gram :";
            // 
            // lbl_MinN
            // 
            this.lbl_MinN.AutoSize = true;
            this.lbl_MinN.Location = new System.Drawing.Point(28, 346);
            this.lbl_MinN.Name = "lbl_MinN";
            this.lbl_MinN.Size = new System.Drawing.Size(191, 13);
            this.lbl_MinN.TabIndex = 78;
            this.lbl_MinN.Text = "Choose the minimum length of N-gram :";
            // 
            // comboBox_MinN
            // 
            this.comboBox_MinN.FormattingEnabled = true;
            this.comboBox_MinN.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_MinN.Location = new System.Drawing.Point(261, 343);
            this.comboBox_MinN.Name = "comboBox_MinN";
            this.comboBox_MinN.Size = new System.Drawing.Size(121, 21);
            this.comboBox_MinN.TabIndex = 77;
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
            this.comboBox_Dskip.Location = new System.Drawing.Point(200, 264);
            this.comboBox_Dskip.Name = "comboBox_Dskip";
            this.comboBox_Dskip.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Dskip.TabIndex = 76;
            // 
            // lblDskip
            // 
            this.lblDskip.AutoSize = true;
            this.lblDskip.Location = new System.Drawing.Point(31, 268);
            this.lblDskip.Name = "lblDskip";
            this.lblDskip.Size = new System.Drawing.Size(159, 13);
            this.lblDskip.TabIndex = 75;
            this.lblDskip.Text = "Choose the length of the Dskip :";
            // 
            // lbl_chooseN
            // 
            this.lbl_chooseN.AutoSize = true;
            this.lbl_chooseN.Location = new System.Drawing.Point(28, 228);
            this.lbl_chooseN.Name = "lbl_chooseN";
            this.lbl_chooseN.Size = new System.Drawing.Size(166, 13);
            this.lbl_chooseN.TabIndex = 74;
            this.lbl_chooseN.Text = "Choose the length of the N-gram :";
            // 
            // comboBox_n
            // 
            this.comboBox_n.FormattingEnabled = true;
            this.comboBox_n.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_n.Location = new System.Drawing.Point(200, 225);
            this.comboBox_n.Name = "comboBox_n";
            this.comboBox_n.Size = new System.Drawing.Size(121, 21);
            this.comboBox_n.TabIndex = 73;
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(513, 449);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(0, 13);
            this.result.TabIndex = 72;
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(237, 108);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(75, 23);
            this.btn_calc.TabIndex = 71;
            this.btn_calc.Text = "Calc";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Visible = false;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // checkedListBox_metrics
            // 
            this.checkedListBox_metrics.FormattingEnabled = true;
            this.checkedListBox_metrics.Items.AddRange(new object[] {
            "Rouge-N",
            "Rouge-L",
            "Rouge-W",
            "Rouge-S",
            "Rouge-SU",
            "MeMoG",
            "Rouge-WSU"});
            this.checkedListBox_metrics.Location = new System.Drawing.Point(52, 54);
            this.checkedListBox_metrics.Name = "checkedListBox_metrics";
            this.checkedListBox_metrics.Size = new System.Drawing.Size(120, 109);
            this.checkedListBox_metrics.TabIndex = 70;
            this.checkedListBox_metrics.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_metrics_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "choose 2 metrics:";
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Default;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(469, 35);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 85;
            this.chart1.Text = "chart1";
            // 
            // SpearmanCorrelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelForRouge);
            this.Controls.Add(this.labelForMeMoG);
            this.Controls.Add(this.comboBox_Win);
            this.Controls.Add(this.comboBox_MaxN);
            this.Controls.Add(this.lbl_Win);
            this.Controls.Add(this.lbl_MaxN);
            this.Controls.Add(this.lbl_MinN);
            this.Controls.Add(this.comboBox_MinN);
            this.Controls.Add(this.comboBox_Dskip);
            this.Controls.Add(this.lblDskip);
            this.Controls.Add(this.lbl_chooseN);
            this.Controls.Add(this.comboBox_n);
            this.Controls.Add(this.result);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.checkedListBox_metrics);
            this.Controls.Add(this.label1);
            this.Name = "SpearmanCorrelation";
            this.Text = "SpearmanCorrelation";
            this.Load += new System.EventHandler(this.SpearmanCorrelation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelForRouge;
        private System.Windows.Forms.Label labelForMeMoG;
        private System.Windows.Forms.ComboBox comboBox_Win;
        private System.Windows.Forms.ComboBox comboBox_MaxN;
        private System.Windows.Forms.Label lbl_Win;
        private System.Windows.Forms.Label lbl_MaxN;
        private System.Windows.Forms.Label lbl_MinN;
        private System.Windows.Forms.ComboBox comboBox_MinN;
        private System.Windows.Forms.ComboBox comboBox_Dskip;
        private System.Windows.Forms.Label lblDskip;
        private System.Windows.Forms.Label lbl_chooseN;
        private System.Windows.Forms.ComboBox comboBox_n;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.CheckedListBox checkedListBox_metrics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}