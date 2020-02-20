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
    public partial class OracleForMulti : Form
    {
        /// <summary>
     /// key- file name
     /// value- [key- size of k, value- topK]
     /// </summary>


        public OracleForMulti()
        {
            InitializeComponent();
            listBox_fileName.Items.Clear();
            checkedListBox_filesName.Items.Clear();
            CreateOracle.Enabled = true;
            sizeOfK.Text = "Summary length: " + Data.lenCutSummary;
        }

        private void OracleForMulti_Load(object sender, EventArgs e)
        {
            foreach (var item in Data.Files)
                checkedListBox_filesName.Items.Add(item.Key);
        }


        private void txt_k_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        

        private void CreateOracle_Click(object sender, EventArgs e)
        {
            CreateOracle.Enabled = false;
            string summary = null;
            foreach (string item in checkedListBox_filesName.CheckedItems)
            {
                
                if (!Data.Files[item]["original"].OracleDic.Any(x => x.Key == (MainForm.baselineLength)))
                    Data.CreateOracle(item, Data.Files[item]["original"].doc,Data.Files[item]["original"].references, MainForm.baselineLength);    
            }
            listBox_fileName.Items.Clear();
            foreach (var item in checkedListBox_filesName.CheckedItems)
            {

                listBox_fileName.Items.Add(item);
                listBox_fileName.Visible = true;
                lbl_fileforTopk.Visible = true;
            }
            txt_Oracle.Text = "";
            CreateOracle.Enabled = true;
        }

        private void listBox_fileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_Oracle.Text = Data.Files[listBox_fileName.SelectedItem.ToString()]["original"].OracleDic[MainForm.baselineLength];
            }
            catch (Exception)
            {

            }
        }
    }
}


