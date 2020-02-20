using EASY_Summary_Evaluation.Forms;
using SummaryEvaluationAPI.Infrustructure.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummaryEvaluation
{
    public partial class AddSingleFileForm : Form
    {
        public AddSingleFileForm()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.
            ////////  this.openFileDialog1.Filter =


            // Allow the user to select multiple images.
            this.openFileDialog3.Multiselect = true;
        }
        private void btn_doc_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txt_doc.Text = Data.ExtractedFileName(openFileDialog1);
            }
        }
        private void btn_sys_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txt_sys.Text = Data.ExtractedFileName(openFileDialog2);
            }
        }
        private void btn_ref_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog3.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {

                var str = new StringBuilder();
                foreach (string file in openFileDialog3.FileNames)
                {
                    str.Append(Data.ExtractedFileName(file));
                    str.Append(Environment.NewLine);
                }
                txt_ref.Text = str.ToString();
            }
        }
        private void btn_uploadFiles_Click(object sender, EventArgs e)
        {
            MainForm.readability = false;
            int count = 0;
            try
            {
                Data.AddFile(ref count, openFileDialog1.FileNames, "doc");
                Data.AddFile(ref count, openFileDialog2.FileNames, "system");
                Data.AddFile(ref count, openFileDialog3.FileNames, "refernces");

                Data.createCorpus();

                MainForm.start = true;
                MainForm.singleFile = true;
                List<string> files = new List<string>();
                foreach (var i in openFileDialog1.FileNames)
                    files.Add(new StreamReader(i).ReadToEnd());
                foreach (var i in openFileDialog2.FileNames)
                    files.Add(new StreamReader(i).ReadToEnd());
                foreach (var i in openFileDialog3.FileNames)
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
            }
            catch(Exception){}
            this.Close();
            //MessageBox.Show(Convert.ToString(count) + " File(s) copied");
           
        }
        
        
    }
}