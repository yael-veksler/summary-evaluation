using System;

namespace SummaryEvaluation
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SingleFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exampleFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metricsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rougeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meMoGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rougeWSUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readabilityMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topicModelingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oracleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correlationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spearmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rougeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.meMoGToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.topKToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oracleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_lengthbaseline = new System.Windows.Forms.TextBox();
            this.lengthBaseline = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.checkBox_cutSummary = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.languages = new System.Windows.Forms.ComboBox();
            this.englishFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.germanFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.metricsToolStripMenuItem,
            this.baseLinesToolStripMenuItem,
            this.correlationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SingleFileToolStripMenuItem,
            this.CorpusToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exampleFilesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // SingleFileToolStripMenuItem
            // 
            this.SingleFileToolStripMenuItem.Name = "SingleFileToolStripMenuItem";
            this.SingleFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SingleFileToolStripMenuItem.Text = "Single file";
            this.SingleFileToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // CorpusToolStripMenuItem
            // 
            this.CorpusToolStripMenuItem.Name = "CorpusToolStripMenuItem";
            this.CorpusToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CorpusToolStripMenuItem.Text = "Corpus";
            this.CorpusToolStripMenuItem.Click += new System.EventHandler(this.CorpusToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exampleFilesToolStripMenuItem
            // 
            this.exampleFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishFilesToolStripMenuItem,
            this.germanFilesToolStripMenuItem});
            this.exampleFilesToolStripMenuItem.Name = "exampleFilesToolStripMenuItem";
            this.exampleFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exampleFilesToolStripMenuItem.Text = "Example Files";
            this.exampleFilesToolStripMenuItem.Click += new System.EventHandler(this.exampleFilesToolStripMenuItem_Click);
            // 
            // metricsToolStripMenuItem
            // 
            this.metricsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rougeToolStripMenuItem,
            this.meMoGToolStripMenuItem,
            this.rougeWSUToolStripMenuItem,
            this.readabilityMToolStripMenuItem,
            this.topicModelingToolStripMenuItem});
            this.metricsToolStripMenuItem.Enabled = false;
            this.metricsToolStripMenuItem.Name = "metricsToolStripMenuItem";
            this.metricsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.metricsToolStripMenuItem.Text = "Metrics";
            // 
            // rougeToolStripMenuItem
            // 
            this.rougeToolStripMenuItem.Name = "rougeToolStripMenuItem";
            this.rougeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rougeToolStripMenuItem.Text = "Rouge";
            this.rougeToolStripMenuItem.Click += new System.EventHandler(this.rougeToolStripMenuItem_Click);
            // 
            // meMoGToolStripMenuItem
            // 
            this.meMoGToolStripMenuItem.Name = "meMoGToolStripMenuItem";
            this.meMoGToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.meMoGToolStripMenuItem.Text = "MeMoG";
            this.meMoGToolStripMenuItem.Click += new System.EventHandler(this.meMoGToolStripMenuItem_Click);
            // 
            // rougeWSUToolStripMenuItem
            // 
            this.rougeWSUToolStripMenuItem.Name = "rougeWSUToolStripMenuItem";
            this.rougeWSUToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rougeWSUToolStripMenuItem.Text = "Rouge-WSU";
            this.rougeWSUToolStripMenuItem.Click += new System.EventHandler(this.rougeWSUToolStripMenuItem_Click);
            // 
            // readabilityMToolStripMenuItem
            // 
            this.readabilityMToolStripMenuItem.Name = "readabilityMToolStripMenuItem";
            this.readabilityMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.readabilityMToolStripMenuItem.Text = "Readability Metrics";
            this.readabilityMToolStripMenuItem.Click += new System.EventHandler(this.readabilityMToolStripMenuItem_Click);
            // 
            // topicModelingToolStripMenuItem
            // 
            this.topicModelingToolStripMenuItem.Name = "topicModelingToolStripMenuItem";
            this.topicModelingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.topicModelingToolStripMenuItem.Text = "Topic Modeling";
            this.topicModelingToolStripMenuItem.Click += new System.EventHandler(this.topicModelingToolStripMenuItem_Click);
            // 
            // baseLinesToolStripMenuItem
            // 
            this.baseLinesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topKToolStripMenuItem,
            this.oracleToolStripMenuItem});
            this.baseLinesToolStripMenuItem.Enabled = false;
            this.baseLinesToolStripMenuItem.Name = "baseLinesToolStripMenuItem";
            this.baseLinesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.baseLinesToolStripMenuItem.Text = "BaseLines";
            // 
            // topKToolStripMenuItem
            // 
            this.topKToolStripMenuItem.Name = "topKToolStripMenuItem";
            this.topKToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.topKToolStripMenuItem.Text = "Top K";
            this.topKToolStripMenuItem.Click += new System.EventHandler(this.topKToolStripMenuItem_Click);
            // 
            // oracleToolStripMenuItem
            // 
            this.oracleToolStripMenuItem.Name = "oracleToolStripMenuItem";
            this.oracleToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.oracleToolStripMenuItem.Text = "Oracle";
            this.oracleToolStripMenuItem.Click += new System.EventHandler(this.oracleToolStripMenuItem_Click);
            // 
            // correlationToolStripMenuItem
            // 
            this.correlationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spearmanToolStripMenuItem});
            this.correlationToolStripMenuItem.Enabled = false;
            this.correlationToolStripMenuItem.Name = "correlationToolStripMenuItem";
            this.correlationToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.correlationToolStripMenuItem.Text = "Correlation";
            // 
            // spearmanToolStripMenuItem
            // 
            this.spearmanToolStripMenuItem.Name = "spearmanToolStripMenuItem";
            this.spearmanToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.spearmanToolStripMenuItem.Text = "Spearman";
            this.spearmanToolStripMenuItem.Click += new System.EventHandler(this.spearmanToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articleToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // articleToolStripMenuItem
            // 
            this.articleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rougeToolStripMenuItem1,
            this.meMoGToolStripMenuItem1,
            this.topKToolStripMenuItem1,
            this.oracleToolStripMenuItem1});
            this.articleToolStripMenuItem.Name = "articleToolStripMenuItem";
            this.articleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.articleToolStripMenuItem.Text = "Article";
            // 
            // rougeToolStripMenuItem1
            // 
            this.rougeToolStripMenuItem1.Name = "rougeToolStripMenuItem1";
            this.rougeToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.rougeToolStripMenuItem1.Text = "Rouge";
            this.rougeToolStripMenuItem1.Click += new System.EventHandler(this.rougeToolStripMenuItem1_Click);
            // 
            // meMoGToolStripMenuItem1
            // 
            this.meMoGToolStripMenuItem1.Name = "meMoGToolStripMenuItem1";
            this.meMoGToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.meMoGToolStripMenuItem1.Text = "MeMoG";
            this.meMoGToolStripMenuItem1.Click += new System.EventHandler(this.meMoGToolStripMenuItem1_Click);
            // 
            // topKToolStripMenuItem1
            // 
            this.topKToolStripMenuItem1.Name = "topKToolStripMenuItem1";
            this.topKToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.topKToolStripMenuItem1.Text = "Top K";
            // 
            // oracleToolStripMenuItem1
            // 
            this.oracleToolStripMenuItem1.Name = "oracleToolStripMenuItem1";
            this.oracleToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.oracleToolStripMenuItem1.Text = "Oracle";
            this.oracleToolStripMenuItem1.Click += new System.EventHandler(this.oracleToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutUsToolStripMenuItem.Text = "About us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(994, 80);
            this.label1.TabIndex = 6;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(35, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(618, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(37, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(398, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "*  Each original document and system summary can have more than one reference.\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(290, 52);
            this.label4.TabIndex = 9;
            this.label4.Text = "For example:\r\n                       Original document: D123.txt\r\n               " +
    "        System summary: D123.sum\r\n                       Reference summaries: D1" +
    "23.A.txt, D123.B.txt";
            // 
            // txt_lengthbaseline
            // 
            this.txt_lengthbaseline.Location = new System.Drawing.Point(205, 351);
            this.txt_lengthbaseline.Name = "txt_lengthbaseline";
            this.txt_lengthbaseline.Size = new System.Drawing.Size(98, 20);
            this.txt_lengthbaseline.TabIndex = 32;
            this.txt_lengthbaseline.Text = "100";
            this.txt_lengthbaseline.TextChanged += new System.EventHandler(this.txt_lengthbaseline_TextChanged);
            // 
            // lengthBaseline
            // 
            this.lengthBaseline.AutoSize = true;
            this.lengthBaseline.Location = new System.Drawing.Point(43, 354);
            this.lengthBaseline.Name = "lengthBaseline";
            this.lengthBaseline.Size = new System.Drawing.Size(139, 13);
            this.lengthBaseline.TabIndex = 31;
            this.lengthBaseline.Text = "Enter the length of baseline:";
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(364, 347);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 33;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // checkBox_cutSummary
            // 
            this.checkBox_cutSummary.AutoSize = true;
            this.checkBox_cutSummary.Location = new System.Drawing.Point(46, 401);
            this.checkBox_cutSummary.Name = "checkBox_cutSummary";
            this.checkBox_cutSummary.Size = new System.Drawing.Size(220, 17);
            this.checkBox_cutSummary.TabIndex = 34;
            this.checkBox_cutSummary.Text = "Cut system summaries to summary length.";
            this.checkBox_cutSummary.UseVisualStyleBackColor = true;
            this.checkBox_cutSummary.CheckedChanged += new System.EventHandler(this.checkBox_cutSummary_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Select language:";
            // 
            // languages
            // 
            this.languages.FormattingEnabled = true;
            this.languages.Items.AddRange(new object[] {
            "czech",
            "danish",
            "dutch",
            "english",
            "estonian",
            "finnish",
            "french",
            "german",
            "greek ",
            "italian ",
            "norwegian ",
            "polish ",
            "portuguess ",
            "slovene ",
            "spanish ",
            "swedish ",
            "turkish"});
            this.languages.Location = new System.Drawing.Point(205, 313);
            this.languages.Name = "languages";
            this.languages.Size = new System.Drawing.Size(98, 21);
            this.languages.TabIndex = 36;
            this.languages.SelectedIndexChanged += new System.EventHandler(this.languages_SelectedIndexChanged);
            // 
            // englishFilesToolStripMenuItem
            // 
            this.englishFilesToolStripMenuItem.Name = "englishFilesToolStripMenuItem";
            this.englishFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.englishFilesToolStripMenuItem.Text = "English Files";
            this.englishFilesToolStripMenuItem.Click += new System.EventHandler(this.englishFilesToolStripMenuItem_Click);
            // 
            // germanFilesToolStripMenuItem
            // 
            this.germanFilesToolStripMenuItem.Name = "germanFilesToolStripMenuItem";
            this.germanFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.germanFilesToolStripMenuItem.Text = "German Files";
            this.germanFilesToolStripMenuItem.Click += new System.EventHandler(this.germanFilesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 666);
            this.Controls.Add(this.languages);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_cutSummary);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.txt_lengthbaseline);
            this.Controls.Add(this.lengthBaseline);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "-";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SingleFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CorpusToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem metricsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rougeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meMoGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baseLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rougeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem meMoGToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem topKToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oracleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem correlationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spearmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oracleToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_lengthbaseline;
        private System.Windows.Forms.Label lengthBaseline;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.ToolStripMenuItem exampleFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rougeWSUToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_cutSummary;
        private System.Windows.Forms.ToolStripMenuItem readabilityMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topicModelingToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox languages;
        private System.Windows.Forms.ToolStripMenuItem englishFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem germanFilesToolStripMenuItem;
    }
}

