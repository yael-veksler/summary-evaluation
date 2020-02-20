namespace SummaryEvaluation
{
    partial class TopKForMulti
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
            this.checkedListBox_filesName = new System.Windows.Forms.CheckedListBox();
            this.lbl_checkFiles = new System.Windows.Forms.Label();
            this.txt_TopK = new System.Windows.Forms.TextBox();
            this.CreateTopK = new System.Windows.Forms.Button();
            this.sizeOfK = new System.Windows.Forms.Label();
            this.lbl_fileforTopk = new System.Windows.Forms.Label();
            this.listBox_fileName = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // checkedListBox_filesName
            // 
            this.checkedListBox_filesName.FormattingEnabled = true;
            this.checkedListBox_filesName.Location = new System.Drawing.Point(29, 109);
            this.checkedListBox_filesName.Name = "checkedListBox_filesName";
            this.checkedListBox_filesName.Size = new System.Drawing.Size(217, 259);
            this.checkedListBox_filesName.TabIndex = 0;
            // 
            // lbl_checkFiles
            // 
            this.lbl_checkFiles.AutoSize = true;
            this.lbl_checkFiles.Location = new System.Drawing.Point(26, 53);
            this.lbl_checkFiles.Name = "lbl_checkFiles";
            this.lbl_checkFiles.Size = new System.Drawing.Size(67, 13);
            this.lbl_checkFiles.TabIndex = 1;
            this.lbl_checkFiles.Text = "Choose files:";
            // 
            // txt_TopK
            // 
            this.txt_TopK.Location = new System.Drawing.Point(600, 53);
            this.txt_TopK.Multiline = true;
            this.txt_TopK.Name = "txt_TopK";
            this.txt_TopK.ReadOnly = true;
            this.txt_TopK.Size = new System.Drawing.Size(416, 461);
            this.txt_TopK.TabIndex = 7;
            // 
            // CreateTopK
            // 
            this.CreateTopK.Enabled = false;
            this.CreateTopK.Location = new System.Drawing.Point(73, 462);
            this.CreateTopK.Name = "CreateTopK";
            this.CreateTopK.Size = new System.Drawing.Size(111, 52);
            this.CreateTopK.TabIndex = 6;
            this.CreateTopK.Text = "Create baseline - Top K";
            this.CreateTopK.UseVisualStyleBackColor = true;
            this.CreateTopK.Click += new System.EventHandler(this.CreateTopK_Click);
            // 
            // sizeOfK
            // 
            this.sizeOfK.AutoSize = true;
            this.sizeOfK.Location = new System.Drawing.Point(30, 414);
            this.sizeOfK.Name = "sizeOfK";
            this.sizeOfK.Size = new System.Drawing.Size(99, 13);
            this.sizeOfK.TabIndex = 4;
            this.sizeOfK.Text = "Enter the size of K: ";
            // 
            // lbl_fileforTopk
            // 
            this.lbl_fileforTopk.AutoSize = true;
            this.lbl_fileforTopk.Location = new System.Drawing.Point(314, 53);
            this.lbl_fileforTopk.Name = "lbl_fileforTopk";
            this.lbl_fileforTopk.Size = new System.Drawing.Size(150, 13);
            this.lbl_fileforTopk.TabIndex = 8;
            this.lbl_fileforTopk.Text = "Choose a file to view its TopK:";
            this.lbl_fileforTopk.Visible = false;
            // 
            // listBox_fileName
            // 
            this.listBox_fileName.FormattingEnabled = true;
            this.listBox_fileName.Location = new System.Drawing.Point(317, 109);
            this.listBox_fileName.Name = "listBox_fileName";
            this.listBox_fileName.Size = new System.Drawing.Size(217, 264);
            this.listBox_fileName.TabIndex = 9;
            this.listBox_fileName.Visible = false;
            this.listBox_fileName.SelectedIndexChanged += new System.EventHandler(this.listBox_fileName_SelectedIndexChanged);
            // 
            // TopKForMulti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 557);
            this.Controls.Add(this.listBox_fileName);
            this.Controls.Add(this.lbl_fileforTopk);
            this.Controls.Add(this.txt_TopK);
            this.Controls.Add(this.CreateTopK);
            this.Controls.Add(this.sizeOfK);
            this.Controls.Add(this.lbl_checkFiles);
            this.Controls.Add(this.checkedListBox_filesName);
            this.Name = "TopKForMulti";
            this.Text = "TopKForMulti";
            this.Load += new System.EventHandler(this.TopKForMulti_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_filesName;
        private System.Windows.Forms.Label lbl_checkFiles;
        private System.Windows.Forms.TextBox txt_TopK;
        private System.Windows.Forms.Button CreateTopK;
        private System.Windows.Forms.Label sizeOfK;
        private System.Windows.Forms.Label lbl_fileforTopk;
        private System.Windows.Forms.ListBox listBox_fileName;
    }
}