using SummaryEvaluation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummaryEvaluationWindowsFormsApp
{
    public partial class RougeWSUForm : Form
    {
        private int Dskip;
        public Dictionary<string, Dictionary<string, List<double>>> res { get; set; } //key:avg/best

        //first calc
        public static bool first;
        public static bool Dskip_changed;
        public static bool firstCompare;

        public RougeWSUForm()
        {
            InitializeComponent();
            res = new Dictionary<string, Dictionary<string, List<double>>>();
        }

        private void RougeWSU_Load(object sender, EventArgs e)
        {
            comboBox_Dskip.SelectedIndex = 0;
            first = true;
            Dskip_changed = false;
            firstCompare = true;

            label2.Visible = false;
            groupBox_bestORavg.Visible = false;
            checkedListBox_filesName.Visible = false;
        }

        private void btn_calcRouge_Click(object sender, EventArgs e)
        {
            btn_calcRouge.Enabled = false;
            btn_compare.Enabled = false;
            RougeWSU rouge = new RougeWSU();
            if (first  || Dskip_changed)
            {
                checkBox_comparetobaseline.Checked = false;
                btn_compare.Visible = false;
                lengthBaseline.Visible = false;
                dataGridView2.Visible = false;
            }
                foreach (var item in Data.Files)
                {
                    res[item.Key]=rouge.CalcRouge(  item.Value["original"].doc, item.Value["original"].system, Dskip, item.Value["original"].references);
                }
            
            
            dataGridView1.Visible = true;
            title.Text = "The result for Dskip=" + Dskip + " is:";
            title.Visible = true;
            if (first)
            {
                Table_Load();
                first = false;
            }
            else
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                showResult();
            }
            //if (!MainForm.singleFile)
            //{
                groupBox_bestORavg.Visible = true;
                foreach (var item in Data.Files)
                    checkedListBox_filesName.Items.Add(item.Value["original"].name);
                checkedListBox_filesName.SelectedIndex = 0;
            //}
            if (checkedListBox_filesName.CheckedItems.Count != 0)
                for (int i = checkedListBox_filesName.CheckedItems.Count; i > 0; i--)
                    checkedListBox_filesName.Items.RemoveAt(checkedListBox_filesName.CheckedIndices[i - 1]);
            checkBox_comparetobaseline.Visible = true;
            checkedListBox_filesName.Visible = false;
            label2.Visible = false;
            btn_calcRouge.Enabled = true;
            btn_compare.Enabled = true;
        }

        private void comboBox_Dskip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dskip = int.Parse(comboBox_Dskip.SelectedItem.ToString());
            Dskip_changed = true;
        }

        private void Table_Load()
        {
            AddColumn();

            showResult();

            this.dataGridView1.Columns[0].Width = 80;
            for (int j = 1; j < this.dataGridView1.ColumnCount; j++)

            {
                this.dataGridView1.Columns[j].Width = 120;

            }

            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            this.dataGridView1.ColumnHeadersHeight = this.dataGridView1.ColumnHeadersHeight * 2;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridView1_CellPainting);


            this.dataGridView1.Paint += new PaintEventHandler(dataGridView2_Paint1);

        }

        private void dataGridView2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void AddColumn()
        {
            this.dataGridView1.Columns.Add("  ", " ");
            this.dataGridView1.Columns.Add("rougeWSUavgR", "R");
            this.dataGridView1.Columns.Add("rougeWSUavgP", "P");
            this.dataGridView1.Columns.Add("rougeWSUavgF", "F");
            this.dataGridView1.Columns.Add("rougeWSUbestR", "R");
            this.dataGridView1.Columns.Add("rougeWSUbestP", "P");
            this.dataGridView1.Columns.Add("rougeWSUbestF", "F");
        }
        void dataGridView2_Paint1(object sender, PaintEventArgs e)

        {
            string[] metric = { "Rouge-WSU" };


            for (int j = 1; j <= 6;)

            {
                Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(j, -1, true); //get the column header cell

                r1.X += 1;

                r1.Y += 1;

                r1.Width = r1.Width * 6 - 6;

                r1.Height = r1.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(metric[j / 6],

                    this.dataGridView2.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);

                j += 6;

            }



        }
        void DataGridView1_Paint2(object sender, PaintEventArgs e)

        {
            string[] type = { "avg", "best" };


            for (int j = 1; j <= 6;)

            {
                Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(j, -1, true); //get the column header cell

                r1.X += 1;

                r1.Y += 1;

                r1.Width = r1.Width * 3 - 3;

                r1.Height = r1.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(type[j / 3],

                    this.dataGridView2.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);

                j += 3;

            }
        }

        void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)

        {

            if (e.RowIndex == -1 && e.ColumnIndex > -1)

            {

                e.PaintBackground(e.CellBounds, false);



                Rectangle r2 = e.CellBounds;

                r2.Y += e.CellBounds.Height / 2;

                r2.Height = e.CellBounds.Height / 2;

                e.PaintContent(r2);

                e.Handled = true;

            }

        }
        double[] GetResult(Dictionary<string, List<double>> dic, string type)
        {
            if (type.Equals("avg"))
            {
                return dic["avg"].ToArray();
            }
            return dic["best"].ToArray();
        }

        private void checkBox_comparetobaseline_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_comparetobaseline.Checked)
            {
                btn_compare.Visible = true;
                lengthBaseline.Visible = true;
                lengthBaseline.Text = "The length of baseline - " + MainForm.baselineLength;
                btn_compare.Enabled = true;
                label2.Visible = true;
                checkedListBox_filesName.Visible = true;
            }
        }

        private void txt_lengthbaseline_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_compare_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            string type;
            if (radioButtonBest.Checked)
                type = "best";
            else
                type = "avg";
            if (firstCompare) { CompareTable_Load(type); firstCompare = false; } //type:best/avg
            else compareResults(type);
        }
        private void CompareTable_Load(string type)
        {

            this.dataGridView2.Columns.Add("  ", " ");
            

            this.dataGridView2.Columns.Add("RougeWSU-R", "R");

            this.dataGridView2.Columns.Add("RougeWSU-P", "P");

            this.dataGridView2.Columns.Add("RougeWSU-F", "F");

            compareResults(type);

            this.dataGridView2.Columns[0].Width = 80;
            for (int j = 1; j < this.dataGridView2.ColumnCount; j++)

            {
                this.dataGridView2.Columns[j].Width = 120;

            }

            this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            this.dataGridView2.ColumnHeadersHeight = this.dataGridView2.ColumnHeadersHeight * 2;

            this.dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            this.dataGridView2.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridView2_CellPainting);

            this.dataGridView2.Paint += new PaintEventHandler(dataGridView2_Paint);



        }
        void showResult()
        {
            foreach (var item in Data.Files)
            {
                string FileName = item.Value["original"].name;
                double[] avg = GetResult(res[item.Key], "avg");
                double[] best = GetResult(res[item.Key], "best");
                this.dataGridView1.Rows.Add(FileName, avg[0], avg[1], avg[2], best[0], best[1], best[2]);
            }
        }
        void DataGridView2_Paint(object sender, PaintEventArgs e)

        {

            string[] type = { "Rouge_WSU" };


            for (int j = 1; j <= 3;)

            {
                Rectangle r1 = this.dataGridView2.GetCellDisplayRectangle(j, -1, true); //get the column header cell

                r1.X += 1;

                r1.Y += 1;

                r1.Width = r1.Width * 3 - 3;

                r1.Height = r1.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(type[j / 3],

                    this.dataGridView2.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);

                j += 3;

            }

        }



        void DataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)

        {

            if (e.RowIndex == -1 && e.ColumnIndex > -1)

            {

                e.PaintBackground(e.CellBounds, false);



                Rectangle r2 = e.CellBounds;

                r2.Y += e.CellBounds.Height / 2;

                r2.Height = e.CellBounds.Height / 2;

                e.PaintContent(r2);

                e.Handled = true;

            }

        }
        //type: {avg / best}
        private void printResults(Dictionary<string, List<double>> res, string SummaryName, string type)
        {
            this.dataGridView2.Rows.Add(SummaryName, res[type][0], res[type][1], res[type][2]);
        }
       
        private void compareResults(string type)
        {
            RougeWSU rouge = new RougeWSU();
            foreach (var file in checkedListBox_filesName.CheckedItems)
            {
                Dictionary<string, List<double>> results = new Dictionary<string, List<double>>();
                Dictionary<string,  List<double>> resTopK = null;
                Dictionary<string,  List<double>> resOracle = null;
                var item = Data.Files.SingleOrDefault(x => x.Value["original"].name.Equals(file));
                int length = Data.lenCutSummary;
                string TopKsummary = Data.CreateTopK(item.Key, item.Value["original"].doc, length);
                string OracleSummary = Data.CreateOracle(item.Key, item.Value["original"].doc, item.Value["original"].references, length);
                resTopK = rouge.CalcRouge(item.Value["original"].doc, TopKsummary, Dskip, item.Value["original"].references);
                resOracle = rouge.CalcRouge(item.Value["original"].doc, OracleSummary, Dskip, item.Value["original"].references);
                results.Add("original", res[item.Key][type]);
                results.Add("TopK " + item.Key, resTopK[type]);
                results.Add("Oracle " + item.Key, resOracle[type]);

                var ordered = results.OrderBy(x => x.Value[2]);
                foreach (var i in ordered)
                {
                    if (i.Key.Contains("TopK"))
                        printResults(resTopK, i.Key, type);
                    else if (i.Key.Contains("Oracle"))
                        printResults(resOracle, i.Key, type);
                    else
                        printResults(res[item.Key], i.Key,type);
                }
            }
            //var ordered = results.OrderBy(x => x.Value[2]);

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

        }

        private void checkBox_comparetobaseline_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox_comparetobaseline.Checked)
            {
                btn_compare.Visible = true;
                lengthBaseline.Visible = true;
                lengthBaseline.Text = "The length of baseline - " + Data.lenCutSummary;
                btn_compare.Enabled = true;
                label2.Visible = true;
                checkedListBox_filesName.Visible = true;
            }
        }
    }
}
