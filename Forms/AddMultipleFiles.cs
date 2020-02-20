using EASY_Summary_Evaluation.Forms;
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

namespace SummaryEvaluation.forms
{
    public partial class AddMultipleFiles : Form
    {
        public AddMultipleFiles()
        {
            InitializeComponent();
        }

        private void btn_doc_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    listBoxDuc.Items.Add(ExtractedFileName(file));
                }
            }
        }


        private void btn_sys_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                foreach (string file in openFileDialog2.FileNames)
                {
                    listBoxSystem.Items.Add(ExtractedFileName(file));
                }
            }
        }

        private void btn_ref_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog3.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                foreach (string file in openFileDialog3.FileNames)
                {
                    listBoxReferencies.Items.Add(ExtractedFileName(file));
                }
                
            }
        }

        private void btn_uploadFiles_Click(object sender, EventArgs e)
        {
            int count = 0;
            MainForm.readability = false;
            Data.AddFile(ref count, openFileDialog1.FileNames, "doc");
            Data.AddFile(ref count, openFileDialog2.FileNames, "system");
            Data.AddFile(ref count, openFileDialog3.FileNames, "refernces");

            MainForm.start = true;

            Data.createCorpus();
            MainForm.singleFile = false;
            List<string> files = new List<string>();
            foreach (var i in openFileDialog1.FileNames)
                files.Add(new StreamReader(i).ReadToEnd());
            foreach (var i in openFileDialog2.FileNames)
                files.Add(new StreamReader(i).ReadToEnd());
            foreach (var i in openFileDialog3.FileNames)
                files.Add(new StreamReader(i).ReadToEnd());
            //Parallel.ForEach(files, (currentFile) =>
            foreach(var currentFile in files)
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
            this.Close();
        }
        public static string ExtractedFileName(OpenFileDialog openFileDialog)
        {
            string fileName = openFileDialog.FileName;
            string[] FilenameName = fileName.Split('\\');
            return FilenameName[FilenameName.Length - 1];
        }
        public static string ExtractedFileName(string openFileDialogName)
        {
            string[] FilenameName = openFileDialogName.Split('\\');
            return FilenameName[FilenameName.Length - 1];
        }
        
        
        
        
    }
}
