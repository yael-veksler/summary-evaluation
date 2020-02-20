namespace SummaryEvaluation
{
    partial class AddSingleFileForm
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
            this.btn_uploadFiles = new System.Windows.Forms.Button();
            this.txt_ref = new System.Windows.Forms.TextBox();
            this.txt_sys = new System.Windows.Forms.TextBox();
            this.txt_doc = new System.Windows.Forms.TextBox();
            this.btn_ref = new System.Windows.Forms.Button();
            this.btn_sys = new System.Windows.Forms.Button();
            this.btn_doc = new System.Windows.Forms.Button();
            this.lbl_Document = new System.Windows.Forms.Label();
            this.lbl_referenceSummary = new System.Windows.Forms.Label();
            this.lbl_systemSummary = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_uploadFiles);
            this.groupBox1.Controls.Add(this.txt_ref);
            this.groupBox1.Controls.Add(this.txt_sys);
            this.groupBox1.Controls.Add(this.txt_doc);
            this.groupBox1.Controls.Add(this.btn_ref);
            this.groupBox1.Controls.Add(this.btn_sys);
            this.groupBox1.Controls.Add(this.btn_doc);
            this.groupBox1.Controls.Add(this.lbl_Document);
            this.groupBox1.Controls.Add(this.lbl_referenceSummary);
            this.groupBox1.Controls.Add(this.lbl_systemSummary);
            this.groupBox1.Location = new System.Drawing.Point(54, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 241);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Files:";
            // 
            // btn_uploadFiles
            // 
            this.btn_uploadFiles.Location = new System.Drawing.Point(86, 203);
            this.btn_uploadFiles.Name = "btn_uploadFiles";
            this.btn_uploadFiles.Size = new System.Drawing.Size(143, 23);
            this.btn_uploadFiles.TabIndex = 9;
            this.btn_uploadFiles.Text = "Upload Selected Files";
            this.btn_uploadFiles.UseVisualStyleBackColor = true;
            this.btn_uploadFiles.Click += new System.EventHandler(this.btn_uploadFiles_Click);
            // 
            // txt_ref
            // 
            this.txt_ref.Location = new System.Drawing.Point(125, 145);
            this.txt_ref.Multiline = true;
            this.txt_ref.Name = "txt_ref";
            this.txt_ref.ReadOnly = true;
            this.txt_ref.Size = new System.Drawing.Size(171, 52);
            this.txt_ref.TabIndex = 8;
            // 
            // txt_sys
            // 
            this.txt_sys.Location = new System.Drawing.Point(125, 92);
            this.txt_sys.Name = "txt_sys";
            this.txt_sys.ReadOnly = true;
            this.txt_sys.Size = new System.Drawing.Size(171, 20);
            this.txt_sys.TabIndex = 7;
            // 
            // txt_doc
            // 
            this.txt_doc.Location = new System.Drawing.Point(125, 38);
            this.txt_doc.Name = "txt_doc";
            this.txt_doc.ReadOnly = true;
            this.txt_doc.Size = new System.Drawing.Size(171, 20);
            this.txt_doc.TabIndex = 6;
            // 
            // btn_ref
            // 
            this.btn_ref.Location = new System.Drawing.Point(302, 145);
            this.btn_ref.Name = "btn_ref";
            this.btn_ref.Size = new System.Drawing.Size(88, 23);
            this.btn_ref.TabIndex = 5;
            this.btn_ref.Text = "Add File";
            this.btn_ref.UseVisualStyleBackColor = true;
            this.btn_ref.Click += new System.EventHandler(this.btn_ref_Click);
            // 
            // btn_sys
            // 
            this.btn_sys.Location = new System.Drawing.Point(302, 89);
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
            // lbl_Document
            // 
            this.lbl_Document.AutoSize = true;
            this.lbl_Document.Location = new System.Drawing.Point(6, 45);
            this.lbl_Document.Name = "lbl_Document";
            this.lbl_Document.Size = new System.Drawing.Size(56, 13);
            this.lbl_Document.TabIndex = 0;
            this.lbl_Document.Text = "Document";
            // 
            // lbl_referenceSummary
            // 
            this.lbl_referenceSummary.AutoSize = true;
            this.lbl_referenceSummary.Location = new System.Drawing.Point(7, 149);
            this.lbl_referenceSummary.Name = "lbl_referenceSummary";
            this.lbl_referenceSummary.Size = new System.Drawing.Size(111, 13);
            this.lbl_referenceSummary.TabIndex = 2;
            this.lbl_referenceSummary.Text = "Reference Summaries";
            // 
            // lbl_systemSummary
            // 
            this.lbl_systemSummary.AutoSize = true;
            this.lbl_systemSummary.Location = new System.Drawing.Point(6, 99);
            this.lbl_systemSummary.Name = "lbl_systemSummary";
            this.lbl_systemSummary.Size = new System.Drawing.Size(87, 13);
            this.lbl_systemSummary.TabIndex = 1;
            this.lbl_systemSummary.Text = "System Summary";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // AddSingleFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 454);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddSingleFileForm";
            this.Text = "Add Single File";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_uploadFiles;
        private System.Windows.Forms.TextBox txt_ref;
        private System.Windows.Forms.TextBox txt_sys;
        private System.Windows.Forms.TextBox txt_doc;
        private System.Windows.Forms.Button btn_ref;
        private System.Windows.Forms.Button btn_sys;
        private System.Windows.Forms.Button btn_doc;
        private System.Windows.Forms.Label lbl_Document;
        private System.Windows.Forms.Label lbl_referenceSummary;
        private System.Windows.Forms.Label lbl_systemSummary;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
    }
}