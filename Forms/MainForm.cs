using EASY.Forms;
using EASY_Summary_Evaluation.Forms;
using IronPython.Hosting;
using SummaryEvaluation.forms;
using SummaryEvaluationWindowsFormsApp;
using SummaryEvaluationWindowsFormsApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummaryEvaluation
{
    public partial class MainForm : Form
    {
        public static bool start { get; set; }
        public static bool singleFile  { get; set; }
        public static int baselineLength { get; set; }
        public static bool readability { get; set; }
        public static string language { get; set; }
        public MainForm()
        {
            InitializeComponent();
            singleFile = false;
            baselineLength = 100;
            Data.lenCutSummary = 100;
            readability = false;
            language = "english";
            languages.SelectedItem = "english";

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AddSingleFileForm form = new AddSingleFileForm();
            form.ShowDialog();
            if (start)
            {
               
                metricsToolStripMenuItem.Enabled = true;
                baseLinesToolStripMenuItem.Enabled = true;
                if (language == "english")
                    readabilityMToolStripMenuItem.Enabled = true;
                else
                    readabilityMToolStripMenuItem.Enabled = false;
                RougeForSingleForm.first = true;
                RougeForSingleForm.N_changed = false;
                RougeForSingleForm.Dskip_changed = false;
            }
            if (singleFile)
                correlationToolStripMenuItem.Enabled = false;
            
        }
        

        private void rougeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.aclweb.org/anthology/W/W04/W04-1013.pdf");
        }

        private void meMoGToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://pdfs.semanticscholar.org/171c/34a28f4853aa2a198183ce03e2346f27d5cc.pdf");
        }

        private void rougeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainForm.singleFile)
            {
                RougeForSingleForm form = new RougeForSingleForm();
                form.ShowDialog();
            }
            else
            {
                RougeForMultiple form = new RougeForMultiple();
                form.ShowDialog();
            }
        }

        private void meMoGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeMoGForm form = new MeMoGForm();
            form.ShowDialog();
        }

        private void topKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (singleFile)
            {
                TopKForm form = new TopKForm();
                form.ShowDialog();
            }
            else
            {
                TopKForMulti form = new TopKForMulti();
                form.ShowDialog();
            }
        }

        private void oracleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (singleFile)
            {
                OracleForm form = new OracleForm();
                form.ShowDialog();
            }
            else
            {
                OracleForMulti form = new OracleForMulti();
                form.ShowDialog();
            }
        }

        private void CorpusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMultipleFiles form = new AddMultipleFiles();
            form.ShowDialog();
            if (start)
            {
                metricsToolStripMenuItem.Enabled = true;
                baseLinesToolStripMenuItem.Enabled = true;
                if (language == "english")
                    readabilityMToolStripMenuItem.Enabled = true;
                else
                    readabilityMToolStripMenuItem.Enabled = false;
                RougeForMultiple.first = true;
                RougeForMultiple.N_changed = false;
                RougeForMultiple.Dskip_changed = false;
            }
            if (!singleFile)
                correlationToolStripMenuItem.Enabled = true;
            //SpearmanCorrelation form = new SpearmanCorrelation();
            //form.ShowDialog();
        }

        private void spearmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpearmanCorrelation form = new SpearmanCorrelation();
            form.ShowDialog();
        }

        private void oracleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.researchgate.net/publication/261096993_OCCAMS_--_An_Optimal_Combinatorial_Covering_Algorithm_for_Multi-document_Summarization");

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (int.Parse(txt_lengthbaseline.Text) >= 10)
            {
                baselineLength = int.Parse(txt_lengthbaseline.Text);
                Data.lenCutSummary = baselineLength;
            }
            else
            {
                MessageBox.Show("Summary's length must be at least 10 words");
                baselineLength = 100;
                Data.lenCutSummary = baselineLength;
                txt_lengthbaseline.Text = "100";
            }
        }

        private void txt_lengthbaseline_TextChanged(object sender, EventArgs e)
        {
            //if (txt_lengthbaseline.Text.Length > 2)
            //    btn_update.Enabled = true;
            //else
            //    btn_update.Enabled = false;
        }

        private void exampleFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void rougeWSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RougeWSUForm form = new RougeWSUForm();
            form.ShowDialog();
        }

        private void checkBox_cutSummary_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_cutSummary.Checked)
            {
                Data.cutSummary = true;
            }
            else
                Data.cutSummary = false;
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs form = new AboutUs();
            form.ShowDialog();
        }

       

        private void readabilityMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadabilityMetricsForm form = new ReadabilityMetricsForm();
            form.ShowDialog();
        }

        private void topicModelingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TMForm form = new TMForm();
            form.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("python -m pip install nltk");
            cmd.StandardInput.WriteLine("python -m pip install stop-words"); 
            //cmd.StandardInput.WriteLine("python -m pip install gensim");
            //cmd.StandardInput.WriteLine("python -m pip install numpy");
            //cmd.StandardInput.WriteLine("python -m pip install pandas");

            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            var engine = Python.CreateEngine();
            var source = engine.CreateScriptSourceFromFile(AppDomain.CurrentDomain.BaseDirectory + "initIronPython.py");
            ICollection<string> Paths = engine.GetSearchPaths();
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\Lib\\site-packages");
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\Lib");
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\DLLs");
            engine.SetSearchPaths(Paths);
            var scope = engine.CreateScope();
            source.Execute(scope);

            ProcessStartInfo start = new ProcessStartInfo();
            start.CreateNoWindow = true;
            start.FileName = "python.exe";
            start.Arguments = @"initPython.py ";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            Process process = Process.Start(start);
        }

        private void languages_SelectedIndexChanged(object sender, EventArgs e)
        {
            language = languages.SelectedItem.ToString();
        }

        private void englishFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExampleFiles form = new ExampleFiles();
            form.ShowDialog();
            if (start)
            {
                metricsToolStripMenuItem.Enabled = true;
                baseLinesToolStripMenuItem.Enabled = true;
                if (language == "english")
                    readabilityMToolStripMenuItem.Enabled = true;
                else
                    readabilityMToolStripMenuItem.Enabled = false;
                RougeForSingleForm.first = true;
                RougeForSingleForm.N_changed = false;
                RougeForSingleForm.Dskip_changed = false;
            }
            if (singleFile)
                correlationToolStripMenuItem.Enabled = false;
        }

        private void germanFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GermanFiles form = new GermanFiles();
            form.ShowDialog();
            if (start)
            {
                metricsToolStripMenuItem.Enabled = true;
                baseLinesToolStripMenuItem.Enabled = true;
                readabilityMToolStripMenuItem.Enabled = false;
                RougeForSingleForm.first = true;
                RougeForSingleForm.N_changed = false;
                RougeForSingleForm.Dskip_changed = false;
            }
            if (singleFile)
                correlationToolStripMenuItem.Enabled = false;
        }
    }
}

