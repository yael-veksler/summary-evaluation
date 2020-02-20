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
    public partial class TopKForMulti : Form
    {/// <summary>
    /// key- file name
    /// value- [key- size of k, value- topK]
    /// </summary>
        public TopKForMulti()
        {
            InitializeComponent();
            listBox_fileName.Items.Clear();
            checkedListBox_filesName.Items.Clear();
            sizeOfK.Text = "Summary length : " + MainForm.baselineLength;
            CreateTopK.Enabled = true;
        }

        private void TopKForMulti_Load(object sender, EventArgs e)
        {
            foreach (var item in Data.Files)
                checkedListBox_filesName.Items.Add(item.Key);
            
        }

     

        private void txt_k_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CreateTopK_Click(object sender, EventArgs e)
        {
            CreateTopK.Enabled = false;
            string summary =null;
            foreach (string item in checkedListBox_filesName.CheckedItems)
            {
                if (Data.Files[item]["topk"] != null)
                {
                    bool temp = Data.Files[item]["topk"].TopKDic.Any(x => x.Key.Equals(MainForm.baselineLength));
                    if (!temp)
                        summary = Data.CreateTopK(item, Data.Files[item]["original"].doc, MainForm.baselineLength);
                    else
                        Data.Files[item]["original"].TopKDic.Add(MainForm.baselineLength, summary);
                }
                
            }
            listBox_fileName.Items.Clear();
            foreach (var item in checkedListBox_filesName.CheckedItems)
            {
                
                listBox_fileName.Items.Add(item);
                listBox_fileName.Visible = true;
                lbl_fileforTopk.Visible = true;
            }
            txt_TopK.Text = "";
            CreateTopK.Enabled = true;
        }

        private void listBox_fileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Data.Files[listBox_fileName.SelectedItem.ToString()]["original"].TopKDic.Any(x => x.Key == (MainForm.baselineLength)))
                    Data.CreateTopK(listBox_fileName.SelectedItem.ToString(), Data.Files[listBox_fileName.SelectedItem.ToString()]["original"].doc, MainForm.baselineLength);
                txt_TopK.Text = Data.Files[listBox_fileName.SelectedItem.ToString()]["original"].TopKDic[MainForm.baselineLength];
            }
            catch (Exception) { }
        }
    }
}
