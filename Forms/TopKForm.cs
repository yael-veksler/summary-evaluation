using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummaryEvaluation
{
    public partial class TopKForm : Form
    {
        public TopKForm()
        {
            InitializeComponent();
            sizeOfK.Text = "Summary length : " + Data.lenCutSummary;
            CreateTopK.Enabled = true;
        }

        private void txt_k_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

      

        private void CreateTopK_Click(object sender, EventArgs e)
        {
            CreateTopK.Enabled = false;
            txt_KopK.Text = Data.CreateTopK(Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, Data.lenCutSummary);
            CreateTopK.Enabled = true;

        }





    }
}
