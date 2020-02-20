using SummaryEvaluation;
using SummaryEvaluationAPI.Infrustructure.Extensions;
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

namespace SummaryEvaluationWindowsFormsApp.Forms
{
    public partial class ExampleFiles : Form
    {
        public ExampleFiles()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            MainForm.readability = false;
            try
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                string[] original = { Path.Combine(appPath, "AP880310-0062.txt") };
                string[] system = { Path.Combine(appPath, "AP880310-0062.B") };
                string[] reference = { Path.Combine(appPath, "AP880310-0062.D") };

                //string[] original = {Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AP880310-0062.txt") };
                //string[] system = { Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AP880310-0062.B") };
                //string[] reference = { Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AP880310-0062.D") };

                Data.AddFile(ref count, original, "doc");
                Data.AddFile(ref count, system, "system");
                Data.AddFile(ref count, reference, "refernces");

                Data.createCorpus();

                MainForm.start = true;
                MainForm.singleFile = true;


                List<string> files = new List<string>();
                foreach (var i in original)
                    files.Add(new StreamReader(i).ReadToEnd());
                foreach (var i in system)
                    files.Add(new StreamReader(i).ReadToEnd());
                foreach (var i in reference)
                    files.Add(new StreamReader(i).ReadToEnd());
                //Parallel.ForEach(files, (currentFile) =>
                foreach (var currentFile in files)
                {
                    currentFile.GetSentences();
                }
                foreach (var item in files)
                {
                    item.word_tokenize_ForText();
                }
                //Parallel.ForEach(Data.listSentences.Values, (sentence) =>
                //{
                //    Parallel.ForEach(sentence, (sent) =>
                //    {
                //        sent.GetWords();
                //    });
                //});
                //foreach (var item in Data.Files)
                //{
                //    foreach (var sent in item.Value["original"].doc.GetSentences())
                //        sent.GetWords();
                //    foreach (var sent in item.Value["original"].system.GetSentences())
                //        sent.GetWords();
                //    foreach (var refer in item.Value["original"].references)
                //        foreach (var sent in refer.GetSentences())
                //            sent.GetWords();
                //}
            }
            catch (Exception) { }
            this.Close();
        }
    }
}
