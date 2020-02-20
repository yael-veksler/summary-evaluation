namespace SummaryEvaluation.forms
{
    partial class AddMultipleFiles
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxReferencies = new System.Windows.Forms.ListBox();
            this.listBoxSystem = new System.Windows.Forms.ListBox();
            this.listBoxDuc = new System.Windows.Forms.ListBox();
            this.btn_uploadFiles = new System.Windows.Forms.Button();
            this.btn_ref = new System.Windows.Forms.Button();
            this.btn_sys = new System.Windows.Forms.Button();
            this.btn_doc = new System.Windows.Forms.Button();
            this.lbl_Documents = new System.Windows.Forms.Label();
            this.lbl_referenceSummary = new System.Windows.Forms.Label();
            this.lbl_systemSummaries = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxReferencies);
            this.groupBox1.Controls.Add(this.listBoxSystem);
            this.groupBox1.Controls.Add(this.listBoxDuc);
            this.groupBox1.Controls.Add(this.btn_uploadFiles);
            this.groupBox1.Controls.Add(this.btn_ref);
            this.groupBox1.Controls.Add(this.btn_sys);
            this.groupBox1.Controls.Add(this.btn_doc);
            this.groupBox1.Controls.Add(this.lbl_Documents);
            this.groupBox1.Controls.Add(this.lbl_referenceSummary);
            this.groupBox1.Controls.Add(this.lbl_systemSummaries);
            this.groupBox1.Location = new System.Drawing.Point(50, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 443);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Files:";
            // 
            // listBoxReferencies
            // 
            this.listBoxReferencies.FormattingEnabled = true;
            this.listBoxReferencies.Location = new System.Drawing.Point(125, 293);
            this.listBoxReferencies.Name = "listBoxReferencies";
            this.listBoxReferencies.Size = new System.Drawing.Size(161, 108);
            this.listBoxReferencies.TabIndex = 12;
            // 
            // listBoxSystem
            // 
            this.listBoxSystem.FormattingEnabled = true;
            this.listBoxSystem.Location = new System.Drawing.Point(125, 166);
            this.listBoxSystem.Name = "listBoxSystem";
            this.listBoxSystem.Size = new System.Drawing.Size(161, 108);
            this.listBoxSystem.TabIndex = 11;
            // 
            // listBoxDuc
            // 
            this.listBoxDuc.FormattingEnabled = true;
            this.listBoxDuc.Location = new System.Drawing.Point(125, 35);
            this.listBoxDuc.Name = "listBoxDuc";
            this.listBoxDuc.Size = new System.Drawing.Size(161, 108);
            this.listBoxDuc.TabIndex = 10;
            // 
            // btn_uploadFiles
            // 
            this.btn_uploadFiles.Location = new System.Drawing.Point(125, 414);
            this.btn_uploadFiles.Name = "btn_uploadFiles";
            this.btn_uploadFiles.Size = new System.Drawing.Size(143, 23);
            this.btn_uploadFiles.TabIndex = 9;
            this.btn_uploadFiles.Text = "Upload Selected Files";
            this.btn_uploadFiles.UseVisualStyleBackColor = true;
            this.btn_uploadFiles.Click += new System.EventHandler(this.btn_uploadFiles_Click);
            // 
            // btn_ref
            // 
            this.btn_ref.Location = new System.Drawing.Point(302, 293);
            this.btn_ref.Name = "btn_ref";
            this.btn_ref.Size = new System.Drawing.Size(88, 23);
            this.btn_ref.TabIndex = 5;
            this.btn_ref.Text = "Add File";
            this.btn_ref.UseVisualStyleBackColor = true;
            this.btn_ref.Click += new System.EventHandler(this.btn_ref_Click);
            // 
            // btn_sys
            // 
            this.btn_sys.Location = new System.Drawing.Point(302, 156);
            this.btn_sys.Name = "btn_sys";
            this.btn_sys.Size = new System.Drawing.Size(88, 23);
            this.btn_sys.TabIndex = 4;
            this.btn_sys.Text = "Add File";
            this.btn_sys.UseVisualStyleBackColor = true;
            this.btn_sys.Click += new System.EventHandler(this.btn_sys_Click);
            // 
            // btn_doc
            // 
            this.btn_doc.Location = new System.Drawing.Point(302, 35);
            this.btn_doc.Name = "btn_doc";
            this.btn_doc.Size = new System.Drawing.Size(88, 23);
            this.btn_doc.TabIndex = 3;
            this.btn_doc.Text = "Add File";
            this.btn_doc.UseVisualStyleBackColor = true;
            this.btn_doc.Click += new System.EventHandler(this.btn_doc_Click);
            // 
            // lbl_Documents
            // 
            this.lbl_Documents.AutoSize = true;
            this.lbl_Documents.Location = new System.Drawing.Point(6, 45);
            this.lbl_Documents.Name = "lbl_Documents";
            this.lbl_Documents.Size = new System.Drawing.Size(61, 13);
            this.lbl_Documents.TabIndex = 0;
            this.lbl_Documents.Text = "Documents";
            // 
            // lbl_referenceSummary
            // 
            this.lbl_referenceSummary.AutoSize = true;
            this.lbl_referenceSummary.Location = new System.Drawing.Point(7, 297);
            this.lbl_referenceSummary.Name = "lbl_referenceSummary";
            this.lbl_referenceSummary.Size = new System.Drawing.Size(111, 13);
            this.lbl_referenceSummary.TabIndex = 2;
            this.lbl_referenceSummary.Text = "Reference Summaries";
            // 
            // lbl_systemSummaries
            // 
            this.lbl_systemSummaries.AutoSize = true;
            this.lbl_systemSummaries.Location = new System.Drawing.Point(6, 166);
            this.lbl_systemSummaries.Name = "lbl_systemSummaries";
            this.lbl_systemSummaries.Size = new System.Drawing.Size(95, 13);
            this.lbl_systemSummaries.TabIndex = 1;
            this.lbl_systemSummaries.Text = "System Summaries";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Multiselect = true;
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            this.openFileDialog3.Multiselect = true;
            // 
            // AddMultipleFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 490);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddMultipleFiles";
            this.Text = "AddMultipleFiles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_uploadFiles;
        private System.Windows.Forms.Button btn_ref;
        private System.Windows.Forms.Button btn_sys;
        private System.Windows.Forms.Button btn_doc;
        private System.Windows.Forms.Label lbl_Documents;
        private System.Windows.Forms.Label lbl_referenceSummary;
        private System.Windows.Forms.Label lbl_systemSummaries;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.ListBox listBoxReferencies;
        private System.Windows.Forms.ListBox listBoxSystem;
        private System.Windows.Forms.ListBox listBoxDuc;
    }
}