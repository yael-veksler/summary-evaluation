namespace SummaryEvaluation
{
    partial class OracleForMulti
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
            this.listBox_fileName = new System.Windows.Forms.ListBox();
            this.lbl_fileforTopk = new System.Windows.Forms.Label();
            this.txt_Oracle = new System.Windows.Forms.TextBox();
            this.CreateOracle = new System.Windows.Forms.Button();
            this.sizeOfK = new System.Windows.Forms.Label();
            this.lbl_checkFiles = new System.Windows.Forms.Label();
            this.checkedListBox_filesName = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // listBox_fileName
            // 
            this.listBox_fileName.FormattingEnabled = true;
            this.listBox_fileName.Location = new System.Drawing.Point(304, 119);
            this.listBox_fileName.Name = "listBox_fileName";
            this.listBox_fileName.Size = new System.Drawing.Size(217, 264);
            this.listBox_fileName.TabIndex = 17;
            this.listBox_fileName.Visible = false;
            this.listBox_fileName.SelectedIndexChanged += new System.EventHandler(this.listBox_fileName_SelectedIndexChanged);
            // 
            // lbl_fileforTopk
            // 
            this.lbl_fileforTopk.AutoSize = true;
            this.lbl_fileforTopk.Location = new System.Drawing.Point(301, 63);
            this.lbl_fileforTopk.Name = "lbl_fileforTopk";
            this.lbl_fileforTopk.Size = new System.Drawing.Size(155, 13);
            this.lbl_fileforTopk.TabIndex = 16;
            this.lbl_fileforTopk.Text = "Choose a file to view its Oracle:";
            this.lbl_fileforTopk.Visible = false;
            // 
            // txt_Oracle
            // 
            this.txt_Oracle.Location = new System.Drawing.Point(587, 63);
            this.txt_Oracle.Multiline = true;
            this.txt_Oracle.Name = "txt_Oracle";
            this.txt_Oracle.ReadOnly = true;
            this.txt_Oracle.Size = new System.Drawing.Size(416, 461);
            this.txt_Oracle.TabIndex = 15;
            // 
            // CreateOracle
            // 
            this.CreateOracle.Enabled = false;
            this.CreateOracle.Location = new System.Drawing.Point(60, 472);
            this.CreateOracle.Name = "CreateOracle";
            this.CreateOracle.Size = new System.Drawing.Size(111, 52);
            this.CreateOracle.TabIndex = 14;
            this.CreateOracle.Text = "Create baseline - Oracle";
            this.CreateOracle.UseVisualStyleBackColor = true;
            this.CreateOracle.Click += new System.EventHandler(this.CreateOracle_Click);
            // 
            // sizeOfK
            // 
            this.sizeOfK.AutoSize = true;
            this.sizeOfK.Location = new System.Drawing.Point(17, 424);
            this.sizeOfK.Name = "sizeOfK";
            this.sizeOfK.Size = new System.Drawing.Size(99, 13);
            this.sizeOfK.TabIndex = 12;
            this.sizeOfK.Text = "Enter the size of K: ";
            // 
            // lbl_checkFiles
            // 
            this.lbl_checkFiles.AutoSize = true;
            this.lbl_checkFiles.Location = new System.Drawing.Point(13, 63);
            this.lbl_checkFiles.Name = "lbl_checkFiles";
            this.lbl_checkFiles.Size = new System.Drawing.Size(67, 13);
            this.lbl_checkFiles.TabIndex = 11;
            this.lbl_checkFiles.Text = "Choose files:";
            // 
            // checkedListBox_filesName
            // 
            this.checkedListBox_filesName.FormattingEnabled = true;
            this.checkedListBox_filesName.Location = new System.Drawing.Point(16, 119);
            this.checkedListBox_filesName.Name = "checkedListBox_filesName";
            this.checkedListBox_filesName.Size = new System.Drawing.Size(217, 259);
            this.checkedListBox_filesName.TabIndex = 10;
            // 
            // OracleForMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 721);
            this.Controls.Add(this.listBox_fileName);
            this.Controls.Add(this.lbl_fileforTopk);
            this.Controls.Add(this.txt_Oracle);
            this.Controls.Add(this.CreateOracle);
            this.Controls.Add(this.sizeOfK);
            this.Controls.Add(this.lbl_checkFiles);
            this.Controls.Add(this.checkedListBox_filesName);
            this.Name = "OracleForMulti";
            this.Text = "Occams";
            this.Load += new System.EventHandler(this.OracleForMulti_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_fileName;
        private System.Windows.Forms.Label lbl_fileforTopk;
        private System.Windows.Forms.TextBox txt_Oracle;
        private System.Windows.Forms.Button CreateOracle;
        private System.Windows.Forms.Label sizeOfK;
        private System.Windows.Forms.Label lbl_checkFiles;
        private System.Windows.Forms.CheckedListBox checkedListBox_filesName;
    }
}