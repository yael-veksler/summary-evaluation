using EASY_Summary_Evaluation.Algorithm.metrics;
using SummaryEvaluation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EASY_Summary_Evaluation.Forms
{
    public partial class TMForm : Form
    {
        private readonly object CalcLock = new object();
        private List<double> res;
        public TMForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //string text = "2005 / 01 / 08 Tsunami aid donations in 2005 deductible for 2004 in the U.S. Saturday, January 8, 2005 U.S.citizens donating in 2005 to help tsunami victims may write off their donations on their 2004 tax returns, thanks to a bill quickly passed in the U.S.House of Representatives and the U.S.Senate on a voice vote, and signed into law by president George W.Bush. Without the new law, contributors would have waited until 2006 and their 2005 tax returns to be able to write off their charitable donations.The law is intended to promote donating towards the tsunami relief effort. CBS News reports Indiana University's Center on Philanthropy is estimating approximately 322 million U.S. dollars in goods and cash have been donated by private U.S. citizens and corporations, in addition to the 350 million that was promised by the government. An AP / ISOS poll has found three in ten U.S.citizens have donated to Tsunami Aid organizations.";
            //StreamReader sr = new StreamReader(Path.Combine(appPath, "AP880310-0062.txt"));
            //TopicModeling.Calc(text, text);

            dataGridView2.Visible = false;
            btn_compare.Visible = false;
            Calc.Enabled = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
           // Parallel.ForEach(Data.Files, (item) =>
            //{
                foreach (var item in Data.Files) { 
                res = TopicModeling.Calc(item.Value["original"].doc, item.Value["original"].system, item.Value["original"].references);

                dataGridView1.Rows.Add(item.Key, res[0], res[1]);
            }

            //dataGridView1.Invoke(new Action(() => { dataGridView1.Rows.Add(item.Key, res[0], res[1]); }));

            // });
            btn_compare.Visible = true;
            Calc.Enabled = true;
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
            foreach(var item in Data.Files)
            {
                TopKsummary = Data.CreateTopK(item.Value["original"].name, item.Value["original"].doc, length);
                OracleSummary = Data.CreateOracle(item.Value["original"].name, item.Value["original"].doc, item.Value["original"].references, length);
                res = TopicModeling.Calc(item.Value["original"].doc, item.Value["original"].system, item.Value["original"].references);
                var resTopK = TopicModeling.Calc(item.Value["original"].doc, TopKsummary, item.Value["original"].references);
                var resOracle = TopicModeling.Calc(item.Value["original"].doc, OracleSummary, item.Value["original"].references);
                dataGridView2.Rows.Add("TopK", resTopK[0], resTopK[1]);
                dataGridView2.Rows.Add("OCCAMS", resOracle[0], resOracle[1]);
                dataGridView2.Rows.Add(item.Key, res[0], res[1]);

            }
            dataGridView2.Visible = true;
            Calc.Enabled = true;
            btn_compare.Enabled = true;
        }
        
    }
}
