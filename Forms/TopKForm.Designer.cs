namespace SummaryEvaluation
{
    partial class TopKForm
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
            this.sizeOfK = new System.Windows.Forms.Label();
            this.CreateTopK = new System.Windows.Forms.Button();
            this.txt_KopK = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sizeOfK
            // 
            this.sizeOfK.AutoSize = true;
            this.sizeOfK.Location = new System.Drawing.Point(38, 39);
            this.sizeOfK.Name = "sizeOfK";
            this.sizeOfK.Size = new System.Drawing.Size(99, 13);
            this.sizeOfK.TabIndex = 0;
            this.sizeOfK.Text = "Enter the size of K: ";
            // 
            // CreateTopK
            // 
            this.CreateTopK.Enabled = false;
            this.CreateTopK.Location = new System.Drawing.Point(327, 17);
            this.CreateTopK.Name = "CreateTopK";
            this.CreateTopK.Size = new System.Drawing.Size(80, 76);
            this.CreateTopK.TabIndex = 2;
            this.CreateTopK.Text = "Create baseline - Top K";
            this.CreateTopK.UseVisualStyleBackColor = true;
            this.CreateTopK.Click += new System.EventHandler(this.CreateTopK_Click);
            // 
            // txt_KopK
            // 
            this.txt_KopK.Location = new System.Drawing.Point(37, 118);
            this.txt_KopK.Multiline = true;
            this.txt_KopK.Name = "txt_KopK";
            this.txt_KopK.ReadOnly = true;
            this.txt_KopK.Size = new System.Drawing.Size(370, 259);
            this.txt_KopK.TabIndex = 3;
            // 
            // TopKForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 425);
            this.Controls.Add(this.txt_KopK);
            this.Controls.Add(this.CreateTopK);
            this.Controls.Add(this.sizeOfK);
            this.Name = "TopKForm";
            this.Text = "TopK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sizeOfK;
        private System.Windows.Forms.Button CreateTopK;
        private System.Windows.Forms.TextBox txt_KopK;
    }
}