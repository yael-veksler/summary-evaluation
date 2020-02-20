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

    public partial class MeMoGForm : Form
    {
        private int min;
        private int max;
        private int Dwin;
        private List<double> res;
        public MeMoGForm()
        {
            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox_MinN.SelectedIndex = 2;
            comboBox_MaxN.SelectedIndex = 2;
            comboBox_Win.SelectedIndex = 2;
        }

        private void btn_calcRouge_Click(object sender, EventArgs e)
        {
            btn_calcMeMoG.Enabled = false;
            btn_compare.Enabled = false;
            if (dataGridView2.RowCount > 1)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Visible = false;
                checkBox_comparetobaseline.Checked = false;
                btn_compare.Visible = false;
                lengthBaseline.Visible = false;
            }

            min = int.Parse(comboBox_MinN.SelectedItem.ToString());
            max = int.Parse(comboBox_MaxN.SelectedItem.ToString());
            Dwin = int.Parse(comboBox_Win.SelectedItem.ToString());
            if (min > max)
            {
                MessageBox.Show("Invalid values: Min length bigger than Max length");
                checkBox_comparetobaseline.Visible = false;
            }
            else
            {


                //List<string> references = new List<string>() { "abca", "bcab" };
                //MeMoG memog = new MeMoG(references, "abcab", min, max, int.Parse(comboBox_Win.SelectedItem.ToString()));

                //MeMoG memog = new MeMoG(Data.ReferencesSummaries , Data.SystemSummary, min, max, Dwin );
                //res=memog.calc(); 
                if (MainForm.singleFile)
                {

                    res = Data.CalcMeMoG("original", Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, Data.Files[Data.SingleFileName]["original"].system, Data.Files[Data.SingleFileName]["original"].references, min, max, Dwin);
                    dataGridView1.DataSource = GetResultsTable(res);
                }
                else //corpus
                {

                    DataTable d = new DataTable();
                    d.Columns.Add("File Name", typeof(string));
                    d.Columns.Add("VS", typeof(double));
                    d.Columns.Add("NVS", typeof(double));

                    var resultCollection = new Dictionary<string, List<double>>();
                    ParallelLoopResult result = Parallel.ForEach(Data.Files, item =>
                    {
                        resultCollection.Add(item.Key, Data.CalcMeMoG("original", item.Key, item.Value["original"].doc, item.Value["original"].system, item.Value["original"].references, min, max, Dwin));
                    });
                    foreach (var res in resultCollection)
                    {
                        d.Rows.Add(res.Key, res.Value[0], res.Value[1]);
                    }
                    //foreach (var item in Data.Corpus)
                    //{
                    //    res = Data.CalcMeMoG(item.duc, item.system, item.references, min, max, Dwin);
                    //    d.Rows.Add(item.name,res[0], res[1]);
                    //}
                    dataGridView1.DataSource = d;
                }
                checkedListBox_filesName.Items.Clear();
                if (!MainForm.singleFile)
                {

                    foreach (var item in Data.Files)
                        checkedListBox_filesName.Items.Add(item.Key);
                    checkedListBox_filesName.SelectedIndex = 0;
                    label1.Visible = false;
                    checkedListBox_filesName.Visible = false;

                }
                checkBox_comparetobaseline.Visible = true;
            }
            btn_calcMeMoG.Enabled = true;
            btn_compare.Enabled = true;
            
        }
        
        private DataTable GetResultsTable(List<double> res)
        {
            // Create the output table.
            DataTable d = new DataTable();

            d.Columns.Add("VS", typeof(double));
            d.Columns.Add("NVS", typeof(double));

            d.Rows.Add(res[0], res[1]);

            return d;
        }

        private void checkBox_comparetobaseline_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_comparetobaseline.Checked)
            {
                lengthBaseline.Text = "Summary length: "+ Data.lenCutSummary;
                btn_compare.Visible = true;
                lengthBaseline.Visible = true;
                btn_compare.Enabled = true;
                if (!MainForm.singleFile)
                {
                    label1.Visible = true;
                    checkedListBox_filesName.Visible = true;
                    checkedListBox_filesName.Visible = true;
                }

            }
        }

        private void txt_lengthbaseline_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       

        private void btn_compare_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            btn_calcMeMoG.Enabled = false;
            btn_compare.Enabled = false;
            int length = Data.lenCutSummary;
            string TopKsummary = null;
            string OracleSummary = null;
            List<double> resTopK = new List<double>();
            List<double> resOracle = new List<double>();
            Item item = null;
            if (!MainForm.singleFile)
            {
                foreach (string file in checkedListBox_filesName.CheckedItems)
                {
                    item = Data.Files.SingleOrDefault(x => x.Key.Equals(file)).Value["original"];
                    TopKsummary = Data.CreateTopK(item.name,item.doc, length);
                    OracleSummary = Data.CreateOracle(item.name,item.doc, item.references, length);
                    res = Data.CalcMeMoG("original",item.name,item.doc, item.system, item.references, min, max, Dwin);
                    resTopK = Data.CalcMeMoG("topk",item.name,item.doc, TopKsummary, item.references, min, max, Dwin);
                    resOracle = Data.CalcMeMoG("oracle",item.name, item.doc, OracleSummary, item.references, min, max, Dwin);
                    AddRowsToCompareDataGridView(resTopK, resOracle, item);
                }
            }
            else
            {

                TopKsummary = Data.CreateTopK(Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, length);
                OracleSummary = Data.CreateOracle(Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, Data.Files[Data.SingleFileName]["original"].references, length);

                resTopK = Data.CalcMeMoG("topk",Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, TopKsummary, Data.Files[Data.SingleFileName]["original"].references, min, max, Dwin);
                resOracle = Data.CalcMeMoG("oracle",Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, OracleSummary, Data.Files[Data.SingleFileName]["original"].references, min, max, Dwin);
                AddRowsToCompareDataGridView(resTopK, resOracle, item);
            }

            int index = 0;
            int c = 0;
            Color[] color = { Color.MediumAquamarine, Color.PowderBlue, Color.Thistle, Color.LemonChiffon, Color.LightBlue, Color.SandyBrown, Color.Wheat, Color.LimeGreen, Color.DarkKhaki };
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.DefaultCellStyle.BackColor = color[c];

                index++;
                if (index % 3 == 0)
                    c++;
                if (c > color.Count())
                    c = 0;
            }
            dataGridView2.Visible = true;
            btn_calcMeMoG.Enabled = true;
            btn_compare.Enabled = true;
        }

        private void AddRowsToCompareDataGridView(List<double> resTopK , List<double> resOracle ,Item item )
        {
            if (resTopK[0] > resOracle[0] && resTopK[0] > res[0])
            {
                this.dataGridView2.Rows.Add("TopK", resTopK[0],resTopK[1]);
                if (resOracle[0] > res[0])
                {
                    this.dataGridView2.Rows.Add("Oracle", resOracle[0], resOracle[1]);
                    if (MainForm.singleFile)
                        this.dataGridView2.Rows.Add("System", res[0],res[1]);
                    else
                        this.dataGridView2.Rows.Add(item.name, res[0],res[1]);
                }
                else
                {
                    if (MainForm.singleFile)
                        this.dataGridView2.Rows.Add("System", res[0],res[1]);
                    else
                        this.dataGridView2.Rows.Add(item.name, res[0],res[1]);
                    this.dataGridView2.Rows.Add("Oracle", resOracle[0],resOracle[1]);
                }
            }
            else if (resOracle[0] > resTopK[0] && resOracle[0] > res[0])
            {
                this.dataGridView2.Rows.Add("Oracle", resOracle[0],resOracle[1]);
                if (resTopK[0] > res[0])
                {
                    this.dataGridView2.Rows.Add("TopK", resTopK[0],resTopK[1]);
                    if (MainForm.singleFile)
                        this.dataGridView2.Rows.Add("System", res[0],res[1]);
                    else
                        this.dataGridView2.Rows.Add(item.name, res[0],res[1]);
                }
                else
                {
                    if (MainForm.singleFile)
                        this.dataGridView2.Rows.Add("System", res[0],res[1]);
                    else
                        this.dataGridView2.Rows.Add(item.name, res[0],res[1]);
                    this.dataGridView2.Rows.Add("TopK", resTopK[0],resTopK[1]);
                }
            }
            else
            {
                if (MainForm.singleFile)
                    this.dataGridView2.Rows.Add("System", res[0],res[1]);
                else
                    this.dataGridView2.Rows.Add(item.name, res[0],res[1]);
                if (resTopK[0] > resOracle[0])
                {
                    this.dataGridView2.Rows.Add("TopK", resTopK[0],resTopK[1]);
                    this.dataGridView2.Rows.Add("Oracle", resOracle[0],resOracle[1]);
                }
                else
                {
                    this.dataGridView2.Rows.Add("Oracle", resOracle[0],resOracle[1]);
                    this.dataGridView2.Rows.Add("TopK", resTopK[0],resTopK[1]);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox_filesName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lengthBaseline_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

