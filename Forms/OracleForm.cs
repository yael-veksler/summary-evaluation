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
    public partial class OracleForm : Form
    {
        public OracleForm()
        {
            InitializeComponent();
            sizeOfL.Text = "Summary length : " + Data.lenCutSummary;
            CreateOcamms.Enabled = true;
        }

        private void CreateOcamms_Click(object sender, EventArgs e)
        {
            CreateOcamms.Enabled = false;
            txt_Occams.Text = Data.CreateOracle(Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, Data.Files[Data.SingleFileName]["original"].references, Data.lenCutSummary);
            CreateOcamms.Enabled = true;
        }

     

        private void txt_L_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        
    }
}
