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
    public partial class RougeForMultiple : Form
    {

        private int n, Dskip;
        public  Dictionary<string, Dictionary<string, List<double>>> resN { get; set; } //key:avg/best

        public  Dictionary<string, Dictionary<string, List<double>>> resL { get; set; }
        public  Dictionary<string, Dictionary<string, List<double>>> resW { get; set; }
        public  Dictionary<string, Dictionary<string, List<double>>> resS { get; set; }
        public  Dictionary<string, Dictionary<string, List<double>>> resSU { get; set; }

        //first calc
        public static bool first;
        public static bool N_changed;
        public static bool Dskip_changed;
        public static bool firstCompare;
        

        public RougeForMultiple()
        {
            InitializeComponent();
        }
        private void RougeForMultiple_Load(object sender, EventArgs e)
        {
            comboBox_n.SelectedIndex = 0;
            comboBox_Dskip.SelectedIndex = 0;
            first = true;
            N_changed = false;
            Dskip_changed = false;
            firstCompare = true;

            label2.Visible = false;
            groupBox_bestORavg.Visible = false;
            checkedListBox_filesName.Visible = false;
        }

        private void comboBox_Dskip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dskip = int.Parse(comboBox_Dskip.SelectedItem.ToString());
            Dskip_changed = true;
        }

        private void comboBox_n_SelectedIndexChanged(object sender, EventArgs e)
        {
            n = int.Parse(comboBox_n.SelectedItem.ToString());
            N_changed = true;
        }

        private void btn_calcRouge_Click(object sender, EventArgs e)
        {
            btn_calcRouge.Enabled = false;
            btn_compare.Enabled = false;
            if (first || N_changed || Dskip_changed)
            {
                checkBox_comparetobaseline.Checked = false;
                btn_compare.Visible = false;
                lengthBaseline.Visible = false;
                dataGridView4.Visible = false;
            }
            if (first)
            {
                resN = new Dictionary<string, Dictionary<string, List<double>>>();
                resL = new Dictionary<string, Dictionary<string, List<double>>>();
                resW = new Dictionary<string, Dictionary<string, List<double>>>();
                resS = new Dictionary<string, Dictionary<string, List<double>>>();
                resSU = new Dictionary<string, Dictionary<string, List<double>>>();
                foreach (var item in Data.Files)
                {
                    var result = Data.CalcRouge("original",item.Key, item.Value["original"].doc, item.Value["original"].system, n, Dskip, item.Value["original"].references);
                    resN.Add(item.Key, result["rougeN"]);
                    resL.Add(item.Key, result["rougeL"]);
                    resW.Add(item.Key, result["rougeW"]);
                    resS.Add(item.Key, result["rougeS"]);
                    resSU.Add(item.Key, result["rougeSU"]);
                }
            }
            else
            {
                if (N_changed)
                {
                    foreach (var item in Data.Files)
                    {
                        resN[item.Key] = Data.CalcRougeN(item.Key, item.Value["original"].doc, item.Value["original"].system, item.Value["original"].references, n, Dskip, resL[item.Key], resW[item.Key], resS[item.Key], resSU[item.Key]);

                        N_changed = false;
                    }
                }
                if (Dskip_changed)
                {
                    foreach (var item in Data.Files)
                    {
                        var res = Data.CalcRougeS_SU(item.Key, item.Value["original"].doc, item.Value["original"].system, item.Value["original"].references, n, Dskip, resL[item.Key], resW[item.Key], resN[item.Key]);
                        resS[item.Key] = res["rougeS"];
                        resSU[item.Key] = res["rougeSU"];
                        Dskip_changed = false;
                    }
                }

            }
            dataGridView1.Visible = true;
            title.Text = "The result for N=" + n + " and Dskip=" + Dskip + " are:";
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
            checkedListBox_filesName.Items.Clear();
            if (!MainForm.singleFile) {
                groupBox_bestORavg.Visible = true;
                foreach (var item in Data.Files)
                    checkedListBox_filesName.Items.Add(item.Value["original"].name);
                checkedListBox_filesName.SelectedIndex = 0;
            }
            if (checkedListBox_filesName.CheckedItems.Count != 0)
                for (int i = checkedListBox_filesName.CheckedItems.Count; i > 0; i--)
                    checkedListBox_filesName.Items.RemoveAt(checkedListBox_filesName.CheckedIndices[i -1]);
            checkBox_comparetobaseline.Visible = true;
            checkedListBox_filesName.Visible = false;
            label2.Visible = false;

            btn_calcRouge.Enabled = true;
            btn_compare.Enabled = true;

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

            this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);

            this.dataGridView1.Paint += new PaintEventHandler(dataGridView2_Paint1);


        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)

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
        void dataGridView1_Paint(object sender, PaintEventArgs e)

        {

            string[] type = { "avg", "best" };


            for (int j = 1; j < 7;)

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

                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);

                j += 3;

            }

        }
        private void AddColumn()
        {
            this.dataGridView1.Columns.Add("  ", " ");
            this.dataGridView1.Columns.Add("rougeNavgR", "avg R");
            this.dataGridView1.Columns.Add("rougeNavgP", "avg P");
            this.dataGridView1.Columns.Add("rougeNavgF", "avg F");
            this.dataGridView1.Columns.Add("rougeNbestR", "best R");
            this.dataGridView1.Columns.Add("rougeNbestP", "best P");
            this.dataGridView1.Columns.Add("rougeNbestF", "best F");
            this.dataGridView1.Columns.Add("rougeLavgR", "avg R");
            this.dataGridView1.Columns.Add("rougeLavgP", "avg P");
            this.dataGridView1.Columns.Add("rougeLavgF", "avg F");
            this.dataGridView1.Columns.Add("rougeLbestR", "best R");
            this.dataGridView1.Columns.Add("rougeLbestP", "best P");
            this.dataGridView1.Columns.Add("rougeLbestF", "best F");
            this.dataGridView1.Columns.Add("rougeWavgR", "avg R");
            this.dataGridView1.Columns.Add("rougeWavgP", "avg P");
            this.dataGridView1.Columns.Add("rougeWavgF", "avg F");
            this.dataGridView1.Columns.Add("rougeWbestR", "best R");
            this.dataGridView1.Columns.Add("rougeWbestP", "best P");
            this.dataGridView1.Columns.Add("rougeWbestF", "best F");
            this.dataGridView1.Columns.Add("rougeSavgR", "avg R");
            this.dataGridView1.Columns.Add("rougeSavgP", "avg P");
            this.dataGridView1.Columns.Add("rougeSavgF", "avg F");
            this.dataGridView1.Columns.Add("rougeSbestR", "best R");
            this.dataGridView1.Columns.Add("rougeSbestP", "best P");
            this.dataGridView1.Columns.Add("rougeSbestF", "best F");
            this.dataGridView1.Columns.Add("rougeSUavgR", "avg R");
            this.dataGridView1.Columns.Add("rougeSUavgP", "avg P");
            this.dataGridView1.Columns.Add("rougeSUavgF", "avg F");
            this.dataGridView1.Columns.Add("rougeSUbestR", "best R");
            this.dataGridView1.Columns.Add("rougeSUbestP", "best P");
            this.dataGridView1.Columns.Add("rougeSUbestF", "best F");
        }
        void dataGridView2_Paint1(object sender, PaintEventArgs e)

        {
            string[] metric = { "Rouge-N", "Rouge-L", "Rouge-W", "Rouge-S", "Rouge-SU" };


            for (int j = 1; j <= 30;)

            {
                Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(j, -1, true); //get the column header cell

                r1.X += 1;

                r1.Y += 1;

                r1.Width = r1.Width * 6 - 6;

                r1.Height = r1.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(metric[j / 6],

                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),

                    r1,

                    format);

                j += 6;

            }
            
            

        }
        void DataGridView1_Paint2(object sender, PaintEventArgs e)

        {
            string[] type = { "avg", "best", "avg", "best", "avg", "best", "avg", "best", "avg", "best" };


            for (int j = 1; j <= 30;)

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

                    this.dataGridView4.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor),

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

        private void btn_compare_Click(object sender, EventArgs e)
        {
            btn_calcRouge.Enabled = false;
            btn_compare.Enabled = false;
            dataGridView4.Rows.Clear();
            dataGridView4.Refresh();
            string type;
            if (radioButtonBest.Checked)
                type = "best";
            else
                type = "avg";
            if (firstCompare) { CompareTable_Load( type); firstCompare = false; } //type:best/avg
            else compareResults(type);
        }
        private void CompareTable_Load(string type)
        {

            this.dataGridView4.Columns.Add("  ", " ");

            this.dataGridView4.Columns.Add("RougeN-R", "R");

            this.dataGridView4.Columns.Add("RougeN-P", "P");

            this.dataGridView4.Columns.Add("RougeN-F", "F");

            this.dataGridView4.Columns.Add("RougeL-R", "R");

            this.dataGridView4.Columns.Add("RougeL-P", "P");

            this.dataGridView4.Columns.Add("RougeL-F", "F");

            this.dataGridView4.Columns.Add("RougeW-R", "R");

            this.dataGridView4.Columns.Add("RougeW-P", "P");

            this.dataGridView4.Columns.Add("RougeW-F", "F");

            this.dataGridView4.Columns.Add("RougeS-R", "R");

            this.dataGridView4.Columns.Add("RougeS-P", "P");

            this.dataGridView4.Columns.Add("RougeS-F", "F");

            this.dataGridView4.Columns.Add("RougeSU-R", "R");

            this.dataGridView4.Columns.Add("RougeSU-P", "P");

            this.dataGridView4.Columns.Add("RougeSU-F", "F");

            compareResults(type);

            this.dataGridView4.Columns[0].Width = 80;
            for (int j = 1; j < this.dataGridView4.ColumnCount; j++)

            {
                this.dataGridView4.Columns[j].Width = 120;

            }

            this.dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            this.dataGridView4.ColumnHeadersHeight = this.dataGridView4.ColumnHeadersHeight * 2;

            this.dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            this.dataGridView4.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridView2_CellPainting);

            this.dataGridView4.Paint += new PaintEventHandler(DataGridView2_Paint);

            btn_calcRouge.Enabled = true;
            btn_compare.Enabled = true;

        }
        void showResult()
        {
            foreach (var item in Data.Files) {
                string FileName = item.Value["original"].name;
                double[] Navg = GetResult(resN[FileName], "avg");
                double[] Nbest = GetResult(resN[FileName], "best");
                var Lavg = GetResult(resL[FileName], "avg");
                var Lbest = GetResult(resL[FileName], "best");
                var Wavg = GetResult(resW[FileName], "avg");
                var Wbest = GetResult(resW[FileName], "best");
                var Savg = GetResult(resS[FileName], "avg");
                var Sbest = GetResult(resS[FileName], "best");
                var SUavg = GetResult(resSU[FileName], "avg");
                var SUbest = GetResult(resSU[FileName], "best");
                this.dataGridView1.Rows.Add(FileName, Navg[0], Navg[1], Navg[2], Nbest[0], Nbest[1], Nbest[2],
                                                       Lavg[0], Lavg[1], Lavg[2], Lbest[0], Lbest[1], Lbest[2],
                                                       Wavg[0], Wavg[1], Wavg[2], Wbest[0], Wbest[1], Wbest[2],
                                                       Savg[0], Savg[1], Savg[2], Sbest[0], Sbest[1], Sbest[2],
                                                       SUavg[0], SUavg[1], SUavg[2], SUbest[0], SUbest[1], SUbest[2]);
            }
        }
        void DataGridView2_Paint(object sender, PaintEventArgs e)

        {

            string[] type = { "Rouge-N", "Rouge_L", "Rouge_W", "Rouge_S", "Rouge_SU" };


            for (int j = 1; j <= 15;)

            {
                Rectangle r1 = this.dataGridView4.GetCellDisplayRectangle(j, -1, true); //get the column header cell

                r1.X += 1;

                r1.Y += 1;

                r1.Width = r1.Width * 3 - 3;

                r1.Height = r1.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView4.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;

                format.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(type[j / 3],

                    this.dataGridView4.ColumnHeadersDefaultCellStyle.Font,

                    new SolidBrush(this.dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor),

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
        private void printResults(Dictionary<string, Dictionary<string, List<double>>> res, string SummaryName, string type)
        {
            this.dataGridView4.Rows.Add(SummaryName, res["rougeN"][type][0], res["rougeN"][type][1], res["rougeN"][type][2],
                                                     res["rougeL"][type][0], res["rougeL"][type][1], res["rougeL"][type][2],
                                                     res["rougeW"][type][0], res["rougeW"][type][1], res["rougeW"][type][2],
                                                     res["rougeS"][type][0], res["rougeS"][type][1], res["rougeS"][type][2],
                                                     res["rougeSU"][type][0], res["rougeSU"][type][1], res["rougeSU"][type][2]
                );
        }
        private void printResults(Dictionary<string, List<double>> res, string SummaryName)
        {
            this.dataGridView4.Rows.Add(SummaryName, res["rougeN"][0], res["rougeN"][1], res["rougeN"][2],
                                                     res["rougeL"][0], res["rougeL"][1], res["rougeL"][2],
                                                     res["rougeW"][0], res["rougeW"][1], res["rougeW"][2],
                                                     res["rougeS"][0], res["rougeS"][1], res["rougeS"][2],
                                                     res["rougeSU"][0], res["rougeSU"][1], res["rougeSU"][2]
                );
        }
        private void compareResults(string type)
        {

            foreach (var file in checkedListBox_filesName.CheckedItems)
            {
                Dictionary<string, List<double>> results = new Dictionary<string, List<double>>();
                Dictionary<string, Dictionary<string, List<double>>> resSystem = new Dictionary<string, Dictionary<string, List<double>>>();
                Dictionary<string, Dictionary<string, List<double>>> resTopK = null;
                Dictionary<string, Dictionary<string, List<double>>> resOracle = null;
                var item = Data.Files.SingleOrDefault(x => x.Value["original"].name.Equals(file));
                resSystem.Add(item.Value["original"].name, new Dictionary<string, List<double>>() { { "rougeN", resN[item.Key][type] }, { "rougeL", resL[item.Value["original"].name][type] }, { "rougeW", resW[item.Value["original"].name][type] }, { "rougeS", resS[item.Value["original"].name][type] }, { "rougeSU", resSU[item.Value["original"].name][type] } });
                results.Add(item.Value["original"].name, resN[item.Value["original"].name][type]);
                int length = MainForm.baselineLength;
                string TopKsummary = Data.CreateTopK(item.Key, item.Value["original"].doc, length);
                string OracleSummary = Data.CreateOracle(item.Key, item.Value["original"].doc, item.Value["original"].references, length);
                resTopK = Data.CalcRouge("topk",item.Key, item.Value["original"].doc, TopKsummary, n, Dskip, item.Value["original"].references);
                resOracle = Data.CalcRouge("oracle",item.Key, item.Value["original"].doc, OracleSummary, n, Dskip, item.Value["original"].references);
                results.Add("TopK " + item.Key, resTopK["rougeN"][type]);
                results.Add("Oracle " + item.Key, resOracle["rougeN"][type]);

                var ordered = results.OrderBy(x => x.Value[2]);
                foreach (var i in ordered)
                {
                    if (i.Key.Contains("TopK"))
                        printResults(resTopK, i.Key, type);
                    else if (i.Key.Contains("Oracle"))
                        printResults(resOracle, i.Key, type);
                    else
                        printResults(resSystem[i.Key], i.Key);
                }
            }
            //var ordered = results.OrderBy(x => x.Value[2]);
            
            int index = 0;
            int c = 0;
            Color[] color = { Color.MediumAquamarine, Color.PowderBlue, Color.Thistle, Color.LemonChiffon, Color.LightBlue, Color.SandyBrown, Color.Wheat, Color.LimeGreen, Color.DarkKhaki };
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                row.DefaultCellStyle.BackColor =color[c];
                
                index++;
                if (index % 3 == 0)
                    c++;
                if (c > color.Count())
                    c = 0;
            }
                dataGridView4.Visible = true;

        }

       

    }
}
