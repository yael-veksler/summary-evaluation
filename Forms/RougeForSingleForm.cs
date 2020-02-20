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
    public partial class RougeForSingleForm : Form
    {
        private int n, Dskip;
        public static Dictionary<string, List<double>> resN { get; set; }

        public static Dictionary<string, List<double>> resL { get; set; }
        public static Dictionary<string, List<double>> resW { get; set; }
        public static Dictionary<string, List<double>> resS { get; set; }
        public static Dictionary<string, List<double>> resSU { get; set; }

        //first calc
        public static bool first ;
        public static bool N_changed ;
        public static bool Dskip_changed ;
        public static bool firstCompare;
        public RougeForSingleForm()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox_n.SelectedIndex = 0;
            comboBox_Dskip.SelectedIndex = 0;
            first = true;
            N_changed = false;
            Dskip_changed = false;
            firstCompare = true;
            groupBox_bestORavg.Visible = false;
            lengthBaseline.Text = "The length of baseline - " + Data.lenCutSummary;


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
                dataGridView2.Visible = false;
            }

            if (first)
            {
                var result = Data.CalcRouge("original",Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, Data.Files[Data.SingleFileName]["original"].system, n, Dskip, Data.Files[Data.SingleFileName]["original"].references);
                resN = result["rougeN"];
                resL = result["rougeL"];
                resW = result["rougeW"];
                resS = result["rougeS"];
                resSU = result["rougeSU"];
            }
            else
            {
                if (N_changed)
                {
                    resN = Data.CalcRougeN(Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, Data.Files[Data.SingleFileName]["original"].system, Data.Files[Data.SingleFileName]["original"].references, n, Dskip, resL, resW, resS, resSU);
                    
                    N_changed = false;
                }
                if (Dskip_changed)
                {
                    var res = Data.CalcRougeS_SU(Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, Data.Files[Data.SingleFileName]["original"].system, Data.Files[Data.SingleFileName]["original"].references, n, Dskip, resL, resW, resN);
                    resS = res["rougeS"];
                    resSU = res["rougeSU"];
                   Dskip_changed = false;
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
            else { 
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                showResult();
            }
            checkBox_comparetobaseline.Visible = true;
            groupBox_bestORavg.Visible = true;
            btn_calcRouge.Enabled = true;
            btn_compare.Enabled = true;
        }

        
        private void comboBox_n_SelectedIndexChanged(object sender, EventArgs e)
        {
            n= int.Parse(comboBox_n.SelectedItem.ToString());
            N_changed = true;
        }

        private void comboBox_Dskip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dskip = int.Parse(comboBox_Dskip.SelectedItem.ToString());
            Dskip_changed = true;
        }

        private void Table_Load()
        {

            this.dataGridView1.Columns.Add("  ", " ");


            this.dataGridView1.Columns.Add("avgR", "R");

            this.dataGridView1.Columns.Add("avgP", "P");

            this.dataGridView1.Columns.Add("avgF", "F");

            this.dataGridView1.Columns.Add("bestR", "R");

            this.dataGridView1.Columns.Add("bestP", "P");

            this.dataGridView1.Columns.Add("bestF", "F");


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

            this.dataGridView1.Paint += new PaintEventHandler(dataGridView1_Paint);
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
                btn_compare.Enabled = true;
                lengthBaseline.Text = "The length of baseline - " + Data.lenCutSummary;


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
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            if (firstCompare) { CompareTable_Load(); firstCompare = false; }
            else compareResults();
            btn_calcRouge.Enabled = true;
            btn_compare.Enabled = true;

        }
        private void compareResults() {
            int length = Data.lenCutSummary;
            string TopKsummary = Data.CreateTopK(Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, length);
            string OracleSummary = Data.CreateOracle(Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, Data.Files[Data.SingleFileName]["original"].references, length);
            Dictionary<string, Dictionary<string, List<double>>> resTopK = Data.CalcRouge("topk",Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, TopKsummary, n, Dskip, Data.Files[Data.SingleFileName]["original"].references);
            Dictionary<string, Dictionary<string, List<double>>> resOracle = Data.CalcRouge("oracle",Data.SingleFileName, Data.Files[Data.SingleFileName]["original"].doc, OracleSummary, n, Dskip, Data.Files[Data.SingleFileName]["original"].references);
            Dictionary<string, Dictionary<string, List<double>>> resSystem = new Dictionary<string, Dictionary<string, List<double>>>() { { "rougeN", resN }, { "rougeL", resL }, { "rougeW", resW }, { "rougeS", resS }, { "rougeSU", resSU } };

            if (resTopK["rougeN"]["best"][2] > resOracle["rougeN"]["best"][2] && resTopK["rougeN"]["best"][2] > resN["best"][2])
            {
                printResults(resTopK, "TopK", "best");
                if (resOracle["rougeN"]["best"][2] > resN["best"][2])
                {
                    printResults(resOracle, "Oracle", "best");
                    printResults(resSystem, "System", "best");
                }
                else
                {
                    printResults(resSystem, "System", "best");
                    printResults(resOracle, "Oracle", "best");
                }
            }
            else if (resOracle["rougeN"]["best"][2] > resTopK["rougeN"]["best"][2] && resOracle["rougeN"]["best"][2] > resN["best"][2])
            {
                printResults(resOracle, "Oracle", "best");
                if (resTopK["rougeN"]["best"][2] > resN["best"][2])
                {
                    printResults(resTopK, "TopK", "best");
                    printResults(resSystem, "System", "best");
                }
                else
                {
                    printResults(resSystem, "System", "best");
                    printResults(resTopK, "TopK", "best");
                }
            }
            else
            {
                printResults(resSystem, "System", "best");
                if (resTopK["rougeN"]["best"][2] > resOracle["rougeN"]["best"][2])
                {
                    printResults(resTopK, "TopK", "best");
                    printResults(resOracle, "Oracle", "best");
                }
                else
                {
                    printResults(resOracle, "Oracle", "best");
                    printResults(resTopK, "TopK", "best");
                }
            }
            dataGridView2.Visible = true;
        }

        void showResult()
        {
            double[] res = GetResult(RougeForSingleForm.resN, "avg");
            double[] res2 = GetResult(RougeForSingleForm.resN, "best");
            this.dataGridView1.Rows.Add("Rouge-N", res[0], res[1], res[2], res2[0], res2[1], res2[2]);
            //this.dataGridView1.Rows.Insert(0," ");

            res = GetResult(RougeForSingleForm.resL, "avg");
            res2 = GetResult(RougeForSingleForm.resL, "best");
            this.dataGridView1.Rows.Add("Rouge-L", res[0], res[1], res[2], res2[0], res2[1], res2[2]);

            res = GetResult(RougeForSingleForm.resW, "avg");
            res2 = GetResult(RougeForSingleForm.resW, "best");
            this.dataGridView1.Rows.Add("Rouge-W", res[0], res[1], res[2], res2[0], res2[1], res2[2]);

            res = GetResult(RougeForSingleForm.resS, "avg");
            res2 = GetResult(RougeForSingleForm.resS, "best");
            this.dataGridView1.Rows.Add("Rouge-S", res[0], res[1], res[2], res2[0], res2[1], res2[2]);

            res = GetResult(RougeForSingleForm.resSU, "avg");
            res2 = GetResult(RougeForSingleForm.resSU, "best");
            this.dataGridView1.Rows.Add("Rouge-SU", res[0], res[1], res[2], res2[0], res2[1], res2[2]);
        }

        private void CompareTable_Load()
        {

            this.dataGridView2.Columns.Add("  ", " ");

            this.dataGridView2.Columns.Add("RougeN-R", "R");

            this.dataGridView2.Columns.Add("RougeN-P", "P");

            this.dataGridView2.Columns.Add("RougeN-F", "F");

            this.dataGridView2.Columns.Add("RougeL-R", "R");

            this.dataGridView2.Columns.Add("RougeL-P", "P");

            this.dataGridView2.Columns.Add("RougeL-F", "F");

            this.dataGridView2.Columns.Add("RougeW-R", "R");

            this.dataGridView2.Columns.Add("RougeW-P", "P");

            this.dataGridView2.Columns.Add("RougeW-F", "F");

            this.dataGridView2.Columns.Add("RougeS-R", "R");

            this.dataGridView2.Columns.Add("RougeS-P", "P");

            this.dataGridView2.Columns.Add("RougeS-F", "F");

            this.dataGridView2.Columns.Add("RougeSU-R", "R");

            this.dataGridView2.Columns.Add("RougeSU-P", "P");

            this.dataGridView2.Columns.Add("RougeSU-F", "F");

            compareResults();

            this.dataGridView2.Columns[0].Width = 80;
            for (int j = 1; j < this.dataGridView2.ColumnCount; j++)

            {
                this.dataGridView2.Columns[j].Width = 120;

            }

            this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            this.dataGridView2.ColumnHeadersHeight = this.dataGridView2.ColumnHeadersHeight * 2;

            this.dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            this.dataGridView2.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView2_CellPainting);

            this.dataGridView2.Paint += new PaintEventHandler(dataGridView2_Paint);

            

        }
        void dataGridView2_Paint(object sender, PaintEventArgs e)

        {

            string[] type = { "Rouge-N" , "Rouge_L", "Rouge_W", "Rouge_S", "Rouge_SU" };


            for (int j = 1; j <=15;)

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



        void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)

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
        private void printResults(Dictionary<string, Dictionary<string, List<double>>> res,string SummaryName ,string type) {
            this.dataGridView2.Rows.Add(SummaryName, res["rougeN"][type][0], res["rougeN"][type][1], res["rougeN"][type][2],
                                                     res["rougeL"][type][0], res["rougeL"][type][1], res["rougeL"][type][2],
                                                     res["rougeW"][type][0], res["rougeW"][type][1], res["rougeW"][type][2],
                                                     res["rougeS"][type][0], res["rougeS"][type][1], res["rougeS"][type][2],
                                                     res["rougeSU"][type][0], res["rougeSU"][type][1], res["rougeSU"][type][2]
                );
        }
    }
}
