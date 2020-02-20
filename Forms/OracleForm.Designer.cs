namespace SummaryEvaluation
{
    partial class OracleForm
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
            this.txt_Occams = new System.Windows.Forms.TextBox();
            this.CreateOcamms = new System.Windows.Forms.Button();
            this.sizeOfL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Occams
            // 
            this.txt_Occams.Location = new System.Drawing.Point(68, 127);
            this.txt_Occams.Multiline = true;
            this.txt_Occams.Name = "txt_Occams";
            this.txt_Occams.ReadOnly = true;
            this.txt_Occams.Size = new System.Drawing.Size(370, 259);
            this.txt_Occams.TabIndex = 7;
            // 
            // CreateOcamms
            // 
            this.CreateOcamms.Enabled = false;
            this.CreateOcamms.Location = new System.Drawing.Point(358, 26);
            this.CreateOcamms.Name = "CreateOcamms";
            this.CreateOcamms.Size = new System.Drawing.Size(80, 76);
            this.CreateOcamms.TabIndex = 6;
            this.CreateOcamms.Text = "Create baseline - Oracle";
            this.CreateOcamms.UseVisualStyleBackColor = true;
            this.CreateOcamms.Click += new System.EventHandler(this.CreateOcamms_Click);
            // 
            // sizeOfL
            // 
            this.sizeOfL.AutoSize = true;
            this.sizeOfL.Location = new System.Drawing.Point(69, 48);
            this.sizeOfL.Name = "sizeOfL";
            this.sizeOfL.Size = new System.Drawing.Size(98, 13);
            this.sizeOfL.TabIndex = 4;
            this.sizeOfL.Text = "Enter the size of L: ";
            // 
            // OracleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 518);
            this.Controls.Add(this.txt_Occams);
            this.Controls.Add(this.CreateOcamms);
            this.Controls.Add(this.sizeOfL);
            this.Name = "OracleForm";
            this.Text = "Occams";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Occams;
        private System.Windows.Forms.Button CreateOcamms;
        private System.Windows.Forms.Label sizeOfL;
    }
}