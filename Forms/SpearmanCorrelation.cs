using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SummaryEvaluation
{
    public partial class SpearmanCorrelation : Form
    {
        public SpearmanCorrelation()
        {
            InitializeComponent();
            btn_calc.Visible = false;
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            btn_calc.Enabled = false;
            ChartClear();
            List<string> metrics = new List<string>();
            foreach (string metric in checkedListBox_metrics.CheckedItems)
                metrics.Add(metric);
            double[] arr1 = new double[Data.Files.Count];
            score(ref arr1, metrics[0]);
            double[] arr2 = new double[Data.Files.Count];
            score(ref arr2, metrics[1]);


            ////double[] resRougeN = new double[] { 0.3, 0.45, 0.234, 0.7 };
            //double[] resRougeN = new double[] { 0.543, 0.87, 0.12, 0.34, 0.75, 0.324, 0.98, 0.269 };
            ////double[] resRougeL = new double[] { 0.11, 0.13, 0.56, 0.9876 };
            //double[] resRougeL = new double[] { 0.64, 0.13, 0.87, 0.438, 0.111, 0.984, 0.254, 0.7643 };


            for (int i = 0; i < Data.Files.Count; i++)
                chart1.Series["Spearman"].Points.AddXY(arr1[i], arr2[i]);
            chart1.ChartAreas[0].AxisX.Title = metrics[0];
            chart1.ChartAreas[0].AxisY.Title = metrics[1];

            double res = alglib.spearmancorr2(arr1, arr2, Data.Files.Count);
            ///double res2 = alglib.spearmanrankcorrelation(resRougeN, resRougeL, 8); //Obsolete function, we recommend to use SpearmanCorr2().
            result.Text = "Spearman Rank Correlation: " + res.ToString();
            chart1.Visible = true;
            result.Visible = true;
            btn_calc.Enabled = true;

        }

        private void SpearmanCorrelation_Load(object sender, EventArgs e)
        {
            labelForRouge.Visible = false;
            labelForMeMoG.Visible = false;
            lblDskip.Visible = false;
            lbl_chooseN.Visible = false;
            lbl_MaxN.Visible = false;
            lbl_MinN.Visible = false;
            lbl_Win.Visible = false;
            comboBox_Dskip.Visible = false;
            comboBox_MaxN.Visible = false;
            comboBox_MinN.Visible = false;
            comboBox_n.Visible = false;
            comboBox_Win.Visible = false;
            chart1.Visible = false;
            result.Visible = false;

            var series = new Series("Spearman");
            // Frist parameter is X-Axis and Second is Collection of Y- Axis
            chart1.Series.Add(series);
            chart1.Series["Spearman"].ChartType = SeriesChartType.Point;
            /////chart1.ChartAreas[0].AxisX.Title = "RougeN";
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 1;
            chart1.ChartAreas[0].AxisX.Interval = 0.1;
            chart1.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            /////chart1.ChartAreas[0].AxisY.Title = "RougeL";
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Interval = 0.1;
            chart1.ChartAreas[0].AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            ChartClear();
        }
        private void ChartClear()
        {
            try
            {

                chart1.Series["Spearman"].Points.Clear();
            }
            catch (Exception) { }
        }
        private void score(ref double[] arr, string metricName)
        {
            int i = 0;

            foreach (var item in Data.Files)
            {
                if (metricName.Equals("Rouge-N"))
                {
                    RougeN rougeN = new RougeN();
                    arr[i++] = rougeN.CalcRouge(item.Value["original"].system, item.Value["original"].references, int.Parse(comboBox_n.Text))["best"][2];
                }
                if (metricName.Equals("Rouge-L"))
                {
                    RougeL rougeL = new RougeL();
                    arr[i++] = rougeL.RougeLSummaryLevel(item.Value["original"].system, item.Value["original"].references)["best"][2];
                }
                if (metricName.Equals("Rouge-W"))
                {
                    RougeW rougeW = new RougeW();
                    arr[i++] = rougeW.CalcRouge(item.Value["original"].system, item.Value["original"].references)["best"][2];
                }
                if (metricName.Equals("Rouge-S"))
                {
                    RougeS rougeS = new RougeS();
                    arr[i++] = rougeS.CalcRouge(item.Value["original"].system, item.Value["original"].references, int.Parse(comboBox_Dskip.Text))["best"][2];
                }
                if (metricName.Equals("Rouge-SU"))
                {
                    RougeSU rougeSU = new RougeSU();
                    arr[i++] = rougeSU.CalcRouge(item.Value["original"].system, item.Value["original"].references, int.Parse(comboBox_Dskip.Text))["best"][2];
                }
                if (metricName.Equals("MeMoG"))
                {
                    arr[i++] = Data.CalcMeMoG("original", item.Key, item.Value["original"].doc, item.Value["original"].system, item.Value["original"].references, int.Parse(comboBox_MinN.Text), int.Parse(comboBox_MaxN.Text), int.Parse(comboBox_Win.Text))[0];
                    //MeMoG memog = new MeMoG(item.Value["original"].references, item.Value["original"].system, int.Parse(comboBox_MinN.Text), int.Parse(comboBox_MaxN.Text), int.Parse(comboBox_Win.Text));
                    //arr[i++] = memog.CalcMeMoG()[0];
                }
                if (metricName.Equals("RougeWSU"))
                {
                    RougeWSU rouge = new RougeWSU();
                    arr[i++] = rouge.CalcRouge(item.Value["original"].doc, item.Value["original"].system, int.Parse(comboBox_Dskip.Text), item.Value["original"].references)["best"][2];

                }
            }
        }

        private void checkedListBox_metrics_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox items = (CheckedListBox)sender;
            if (this.checkedListBox_metrics.CheckedItems.Count > 1 && e.NewValue == CheckState.Checked)
            {
                e.NewValue = CheckState.Unchecked;
                return;
            }
            chart1.Visible = false;
            result.Visible = false;

            if (this.checkedListBox_metrics.CheckedItems.Count >= 1 && e.NewValue == CheckState.Checked)
            {
                btn_calc.Visible = true;
                ChartClear();


            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                btn_calc.Visible = false;
                ChartClear();
            }

            if (e.NewValue == CheckState.Checked && e.Index == 0) //rougeN
            {
                labelForRouge.Visible = true;
                lbl_chooseN.Visible = true;
                comboBox_n.Visible = true;
                comboBox_n.SelectedIndex = 0; //the default is n=1
            }
            if (e.NewValue == CheckState.Checked && (e.Index == 3 || e.Index == 4 || e.Index == 6)) //rougeS or rougeSU or rougeWSU
            {
                labelForRouge.Visible = true;
                lblDskip.Visible = true;
                comboBox_Dskip.Visible = true;
                comboBox_Dskip.SelectedIndex = 0; //the default is Dskip=1
            }
            if (e.NewValue == CheckState.Checked && e.Index == 5) //memog
            {
                labelForMeMoG.Visible = true;
                lbl_MaxN.Visible = true;
                lbl_MinN.Visible = true;
                lbl_Win.Visible = true;
                comboBox_MaxN.Visible = true;
                comboBox_MinN.Visible = true;
                comboBox_Win.Visible = true;
                comboBox_MinN.SelectedIndex = 2; //the default is min=3
                comboBox_MaxN.SelectedIndex = 2;//the default is max=3
                comboBox_Win.SelectedIndex = 2;//the default is win=3
            }

            if (e.NewValue == CheckState.Unchecked && e.Index == 0) //rougeN
            {
                if (checkedListBox_metrics.GetItemCheckState(3) == CheckState.Unchecked || checkedListBox_metrics.GetItemCheckState(4) == CheckState.Unchecked)
                    labelForRouge.Visible = false;
                lbl_chooseN.Visible = false;
                comboBox_n.Visible = false;
            }
            if (e.NewValue == CheckState.Unchecked && (e.Index == 3 || e.Index == 4) && (checkedListBox_metrics.GetItemCheckState(3) == CheckState.Unchecked || checkedListBox_metrics.GetItemCheckState(4) == CheckState.Unchecked)) //rougeS or rougeSU
            {
                if (checkedListBox_metrics.GetItemCheckState(0) == CheckState.Unchecked)
                    labelForRouge.Visible = false;
                lblDskip.Visible = false;
                comboBox_Dskip.Visible = false;
            }
            if (e.NewValue == CheckState.Unchecked && e.Index == 5) //memog
            {
                labelForMeMoG.Visible = false;
                lbl_MaxN.Visible = false;
                lbl_MinN.Visible = false;
                lbl_Win.Visible = false;
                comboBox_MaxN.Visible = false;
                comboBox_MinN.Visible = false;
                comboBox_Win.Visible = false;
            }
        }
    }
}
