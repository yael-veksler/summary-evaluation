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
    public partial class ReadabilityMetricsForm : Form
    {

        public ReadabilityMetricsForm()
        {
            InitializeComponent();
            

        }

       
       

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            btn_compare.Visible = false;
            btn_calc.Enabled = false;

            if (!MainForm.readability)
            {
                foreach (var item in Data.Files)
                {
                    string result = ReadabilityMetrics.CalcReadabilityNLTK(item.Value["original"].system);
                    List<string> results = result.Split('\n').ToList();
                    item.Value["original"].PNR = Convert.ToDouble(results[0]);
                    item.Value["original"].NR = Convert.ToDouble(results[1]);
                    item.Value["original"].PR = Convert.ToDouble(results[2]);
                    item.Value["original"].Fog = Convert.ToDouble(results[3]);
                    item.Value["original"].AWL = Convert.ToDouble(results[4]);
                    item.Value["original"].FRES = Convert.ToDouble(results[5]);
                    item.Value["original"].FKGL = Convert.ToDouble(results[6]);
                }
                MainForm.readability = true;
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (var item in Data.Files)
                dataGridView1.Rows.Add(item.Key, Data.Files[item.Key]["original"].PNR, Data.Files[item.Key]["original"].NR, Data.Files[item.Key]["original"].PR, Data.Files[item.Key]["original"].Fog, Data.Files[item.Key]["original"].AWL, Data.Files[item.Key]["original"].FRES, Data.Files[item.Key]["original"].FKGL);

            btn_compare.Visible = true;
            btn_calc.Enabled = true;
        }

        private void btn_compare_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView1.Refresh();
            btn_compare.Enabled = false;
            int length = Data.lenCutSummary;
            lengthBaseline.Text = "Summary length: " + Data.lenCutSummary;
            string TopKsummary = null;
            string OracleSummary = null;
            foreach (var item in Data.Files)
            {
                TopKsummary = Data.CreateTopK(item.Value["original"].name, item.Value["original"].doc, length);
                OracleSummary = Data.CreateOracle(item.Value["original"].name, item.Value["original"].doc, item.Value["original"].references, length);
                string result = ReadabilityMetrics.CalcReadabilityNLTK(item.Value["original"].system);
                List<string> results = result.Split('\n').ToList();
                string resultTopK = ReadabilityMetrics.CalcReadabilityNLTK(TopKsummary);
                List<string> resultsTopK = result.Split('\n').ToList();
                string resultOracle = ReadabilityMetrics.CalcReadabilityNLTK(OracleSummary);
                List<string> resultsOracle = result.Split('\n').ToList();
                dataGridView2.Rows.Add("TopK", Convert.ToDouble(resultsTopK[0]), Convert.ToDouble(resultsTopK[1]),
                        Convert.ToDouble(resultsTopK[2]), Convert.ToDouble(resultsTopK[3]), Convert.ToDouble(resultsTopK[4]),
                        Convert.ToDouble(resultsTopK[5]), Convert.ToDouble(resultsTopK[6]));
                dataGridView2.Rows.Add("OCCAMS", Convert.ToDouble(resultsOracle[0]), Convert.ToDouble(resultsOracle[1]),
                        Convert.ToDouble(resultsOracle[2]), Convert.ToDouble(resultsOracle[3]), Convert.ToDouble(resultsOracle[4]),
                        Convert.ToDouble(resultsOracle[5]), Convert.ToDouble(resultsOracle[6]));
                dataGridView2.Rows.Add(item.Key, Convert.ToDouble(results[0]), Convert.ToDouble(results[1]),
                        Convert.ToDouble(results[2]), Convert.ToDouble(results[3]), Convert.ToDouble(results[4]),
                        Convert.ToDouble(results[5]), Convert.ToDouble(results[6]));
            }
            dataGridView2.Visible = true;
            btn_calc.Enabled = true;
            btn_compare.Enabled = true;
        }
    }
}



