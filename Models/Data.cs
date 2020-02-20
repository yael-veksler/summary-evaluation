using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummaryEvaluation
{
    public class Data
    {
        public static Dictionary<string, List<string>> listSentences { get; set; }
        public static Dictionary<string, List<string>> listWords { get; set; }

        public static bool cutSummary { get; set; }
        public static int lenCutSummary { get; set; }
        public static string SingleFileName { get; set; }
        public static Dictionary<string, List<string>> DocName { get; private set; }
        public static Dictionary<string, List<string>> SystemName { get; private set; }
        public static Dictionary<string, List<string>> ReferenceName { get; private set; }


        public static Dictionary<string, string> ListOriginalDoc { get; private set; }

        public static Dictionary<string, string> ListSystemSummary { get; private set; }
        public static Dictionary<string, List<string>> ListReferencesSummaries { get; private set; }
        //files name  + (system:topk,oracle,other +set of files)
        public static Dictionary<string, Dictionary<string, Item>> Files { get; private set; }


        //type: original, oracle, topk
        public static List<double> CalcMeMoG(string type, string FileName, string doc, string system, List<string> refs, int min, int max, int Dwin)
        {
            string CutSystemSummary = null;
            if (doc == "" || system == "" || refs == null || (refs != null && refs.Any(x => x == "")))
            {
                return new List<double>() { 0, 0 };
            }
            if (cutSummary)
            {
                TopK cutSystem = new TopK(system, lenCutSummary);
                CutSystemSummary = cutSystem.GetTopK();
                if (Files[FileName][type] != null)
                {

                    var temp = Files[FileName][type].MeMoGResultsForCutSummary.SingleOrDefault(x => x.system.Equals(CutSystemSummary) && x.min == min && x.max == max && x.Dwin == Dwin);
                    if (temp != null)
                        return ((MeMoGVariable)temp).result;
                }
            }
            else
            {
                if (Files[FileName][type] != null)
                {

                    var temp = Files[FileName][type].MeMoGResults.SingleOrDefault(x => x.system.Equals(system) && x.min == min && x.max == max && x.Dwin == Dwin);
                    if (temp != null)
                        return ((MeMoGVariable)temp).result;
                }
            }
            if (cutSummary)
            {
                MeMoG memog1 = new MeMoG(refs, CutSystemSummary, min, max, Dwin);
                List<double> res1 = memog1.CalcMeMoG();
                if (Files[FileName][type] == null)
                    Files[FileName][type] = new Item(FileName, doc, system, refs);
                Files[FileName][type].MeMoGResultsForCutSummary.Add(new MeMoGVariable(CutSystemSummary, min, max, Dwin, res1));
                return res1;
            }

            MeMoG memog = new MeMoG(refs, system, min, max, Dwin);
            List<double> res = memog.CalcMeMoG();
            if (Files[FileName][type] == null)
                Files[FileName][type] = new Item(FileName, doc, system, refs);
            Files[FileName][type].MeMoGResults.Add(new MeMoGVariable(system, min, max, Dwin, res));
            return res;
        }

        public static Dictionary<string, List<double>> CalcMeMoG(int min, int max, int dwin)
        {
            Dictionary<string, List<double>> res = new Dictionary<string, List<double>>();
            foreach (var file in Files)
                res[file.Key] = CalcMeMoG("original", file.Key, file.Value["original"].doc, file.Value["original"].system, file.Value["original"].references, min, max, dwin);
            return res;
        }

        //type: original, topk,oracle
        public static Dictionary<string, Dictionary<string, List<double>>> CalcRouge(string type, string FileName, string doc, string system, int n, int Dskip, List<string> refs)
        {
            if (doc == "" || system == "" || refs == null || (refs != null && refs.Any(x => x == "")))
            {
                Dictionary<string, List<double>> rougen = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                Dictionary<string, List<double>> rougel = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                Dictionary<string, List<double>> rougew = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                Dictionary<string, List<double>> rouges = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                Dictionary<string, List<double>> rougesu = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                return new Dictionary<string, Dictionary<string, List<double>>>()
                {
                    {"rougeN",rougen },{"rougeL",rougel },{"rougeW",rougew},{"rougeS",rouges },{"rougeSU",rougesu }
                };
            }
            string CutSystemSummary = null;
            if (Files[FileName][type] != null)
            {
                if (cutSummary == false)
                {
                    RougeVariable temp = Files[FileName][type].RougeResults.SingleOrDefault(x => x.system.Equals(system) && x.n == n && x.Dskip == Dskip);
                    if (temp != null)
                    {
                        return temp.result;
                    }
                }
                else
                {
                    TopK cutSystem = new TopK(system, MainForm.baselineLength);
                    CutSystemSummary = cutSystem.GetTopK();
                    RougeVariable temp = Files[FileName][type].RougeResultsForCutSummary.SingleOrDefault(x => x.system.Equals(CutSystemSummary) && x.n == n && x.Dskip == Dskip);
                    if (temp != null)
                    {
                        return temp.result;
                    }
                }

            }


            RougeN rougeN = new RougeN();
            RougeL rougeL = new RougeL();
            RougeW rougeW = new RougeW();
            RougeS rougeS = new RougeS();
            RougeSU rougeSU = new RougeSU();


            Dictionary<string, List<double>> resN, resL, resW, resS, resSU;
            List<Task<Dictionary<string, List<double>>>> task;
            if (cutSummary == false)
            {
                task = new List<Task<Dictionary<string, List<double>>>>() {

                 Task<Dictionary<string, List<double>>>.Factory.StartNew(() => { return rougeN.CalcRouge(system, refs, n); }),
                 Task<Dictionary<string, List<double>>>.Factory.StartNew(() => {return rougeL.RougeLSummaryLevel(system, refs); }),
                 Task<Dictionary<string, List<double>>>.Factory.StartNew(() => {return rougeW.CalcRouge(system, refs);}),
                 Task<Dictionary<string, List<double>>>.Factory.StartNew(() => {return rougeS.CalcRouge(system, refs, Dskip); }),
                 Task<Dictionary<string, List<double>>>.Factory.StartNew(() => {return rougeSU.CalcRouge(system, refs, Dskip); })
            };
            }
            else
            {
                task = new List<Task<Dictionary<string, List<double>>>>() {

                 Task<Dictionary<string, List<double>>>.Factory.StartNew(() => { return rougeN.CalcRouge(CutSystemSummary, refs, n); }),
                 Task<Dictionary<string, List<double>>>.Factory.StartNew(() => {return rougeL.RougeLSummaryLevel(CutSystemSummary, refs); }),
                 Task<Dictionary<string, List<double>>>.Factory.StartNew(() => {return rougeW.CalcRouge(CutSystemSummary, refs);}),
                 Task<Dictionary<string, List<double>>>.Factory.StartNew(() => {return rougeS.CalcRouge(CutSystemSummary, refs, Dskip); }),
                 Task<Dictionary<string, List<double>>>.Factory.StartNew(() => {return rougeSU.CalcRouge(CutSystemSummary, refs, Dskip); })
            };
            }
            try
            {
                // Wait for all the tasks to finish.
                Task.WaitAll(task.ToArray());
                resN = task[0].Result;
                resL = task[1].Result;
                resW = task[2].Result;
                resS = task[3].Result;
                resSU = task[4].Result;
                if (Files[FileName][type] == null)
                {
                    Files[FileName][type] = new Item(FileName, doc, system, refs)
                    {
                        RougeResults = new List<RougeVariable>(),
                        RougeResultsForCutSummary = new List<RougeVariable>()
                    };
                }
                if (cutSummary == false)
                    Files[FileName][type].RougeResults.Add(new RougeVariable(system, n, Dskip, resN, resL, resW, resS, resSU));
                else
                    Files[FileName][type].RougeResultsForCutSummary.Add(new RougeVariable(CutSystemSummary, n, Dskip, resN, resL, resW, resS, resSU));

                if (cutSummary == false)
                    return Files[FileName][type].RougeResults.SingleOrDefault(x => x.system.Equals(system) && x.n == n && x.Dskip == Dskip).result;
                return Files[FileName][type].RougeResultsForCutSummary.SingleOrDefault(x => x.system.Equals(CutSystemSummary) && x.n == n && x.Dskip == Dskip).result;


            }
            catch (AggregateException e)
            { return null; }

           

        }
        public static Dictionary<string, List<double>> CalcRougeN(string FileName, string doc, string system, List<string> refs, int n, int Dskip, Dictionary<string, List<double>> resL, Dictionary<string, List<double>> resW, Dictionary<string, List<double>> resS, Dictionary<string, List<double>> resSU)
        {
            string CutSystemSummary = null;
            if (cutSummary == false)
            {
                var temp = Files[FileName]["original"].RougeResults.FirstOrDefault(x => x.system.Equals(system) && x.n == n);
                if (temp != null)
                {
                    return temp.resN;
                }
            }
            else
            {
                TopK cutSystem = new TopK(system, lenCutSummary);
                CutSystemSummary = cutSystem.GetTopK();
                var temp = Files[FileName]["original"].RougeResultsForCutSummary.FirstOrDefault(x => x.system.Equals(CutSystemSummary) && x.n == n);
                if (temp != null)
                {
                    return temp.resN;
                }
            }

            RougeN rougeN = new RougeN();
            Dictionary<string, List<double>> resN;
            if (cutSummary)
            {
                resN = rougeN.CalcRouge(CutSystemSummary, refs, n);
                Files[FileName]["original"].RougeResultsForCutSummary.Add(new RougeVariable(CutSystemSummary, n, Dskip, resN, resL, resW, resS, resSU));

            }
            else
            {
                resN = rougeN.CalcRouge(system, refs, n);
                Files[FileName]["original"].RougeResults.Add(new RougeVariable(system, n, Dskip, resN, resL, resW, resS, resSU));
            }
            return resN;

        }
        public static Dictionary<string, Dictionary<string, List<double>>> CalcRougeS_SU(string FileName, string doc, string system, List<string> refs, int n, int Dskip, Dictionary<string, List<double>> resL, Dictionary<string, List<double>> resW, Dictionary<string, List<double>> resN)
        {
            string CutSystemSummary = null;
            if (cutSummary)
            {
                TopK cutSystem = new TopK(system, lenCutSummary);
                CutSystemSummary = cutSystem.GetTopK();
                var temp = Files[FileName]["original"].RougeResultsForCutSummary.FirstOrDefault(x => x.system.Equals(CutSystemSummary) && x.Dskip == Dskip);
                if (temp != null)
                {
                    return new Dictionary<string, Dictionary<string, List<double>>>() { { "rougeS", temp.resS }, { "rougeSU", temp.resSU } };
                }
            }
            else
            {
                var temp = Files[FileName]["original"].RougeResults.FirstOrDefault(x => x.system.Equals(system) && x.Dskip == Dskip);
                if (temp != null)
                {
                    return new Dictionary<string, Dictionary<string, List<double>>>() { { "rougeS", temp.resS }, { "rougeSU", temp.resSU } };
                }
            }

            RougeS rougeS = new RougeS();
            Dictionary<string, List<double>> resS;
            if (cutSummary)
                resS = rougeS.CalcRouge(CutSystemSummary, refs, Dskip);
            else
                resS = rougeS.CalcRouge(system, refs, Dskip);
            RougeSU rougeSU = new RougeSU();
            Dictionary<string, List<double>> resSU;
            if (cutSummary)
                resSU = rougeSU.CalcRouge(CutSystemSummary, refs, Dskip);
            else
                resSU = rougeSU.CalcRouge(system, refs, Dskip);
            if (cutSummary)
                Files[FileName]["original"].RougeResultsForCutSummary.Add(new RougeVariable(CutSystemSummary, n, Dskip, resN, resL, resW, resS, resSU));
            else
                Files[FileName]["original"].RougeResults.Add(new RougeVariable(system, n, Dskip, resN, resL, resW, resS, resSU));
            return new Dictionary<string, Dictionary<string, List<double>>>() { { "rougeS", resS }, { "rougeSU", resSU } };

        }
        public static string CreateTopK(string FileName, string doc, int k)
        {
            if (doc == "") return "The summary is empty.";
            if (Files[FileName]["original"].TopKDic != null)
            {
                if (Files[FileName]["original"].TopKDic.ContainsKey(k))
                    return Files[FileName]["original"].TopKDic[k];
            }
            TopK topk = new TopK(doc, k);
            string TopKsummary = topk.GetTopK();
            Files[FileName]["original"].TopKDic.Add(k, TopKsummary);
            return TopKsummary;

        }
        public static string CreateOracle(string FileName, string doc, List<string> refs, int L)
        {
            if (doc == "") return "The summary is empty.";
            if (Files[FileName]["original"].OracleDic != null)
            {
                if (Files[FileName]["original"].OracleDic.ContainsKey(L))
                    return Files[FileName]["original"].OracleDic[L];
            }

            Oracle oracle = new Oracle(refs, doc, L);
            string OracleSummary = oracle.GetOccams();

            Files[FileName]["original"].OracleDic.Add(L, OracleSummary);

            return OracleSummary;
        }

        public static void AddFile(ref int count, string[] FileNames, string type)
        {
            //Process cmd = new Process();
            //cmd.StartInfo.FileName = "cmd.exe";
            //cmd.StartInfo.RedirectStandardInput = true;
            //cmd.StartInfo.RedirectStandardOutput = true;
            //cmd.StartInfo.CreateNoWindow = true;
            //cmd.StartInfo.UseShellExecute = false;
            //cmd.Start();

            //cmd.StandardInput.WriteLine("python -m pip install nltk");
            //cmd.StandardInput.Flush();
            //cmd.StandardInput.Close();
            //cmd.WaitForExit();
            //Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            //MessageBox.Show(cmd.StandardOutput.ReadToEnd());
            listSentences = new Dictionary<string, List<string>>();
            listWords = new Dictionary<string, List<string>>();
            if (type == "doc")
            {
                ListOriginalDoc = null;
                foreach (string file in FileNames)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        if (ListOriginalDoc == null)
                            ListOriginalDoc = new Dictionary<string, string>();
                        ListOriginalDoc.Add(ExtractedFileName(file).Split('.')[0], sr.ReadToEnd());//all text wil be saved in text enters are also saved
                    }
                }
            }

            else if (type == "system")
            {
                ListSystemSummary = null;
                foreach (string file in FileNames)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        if (ListSystemSummary == null)
                            ListSystemSummary = new Dictionary<string, string>();
                        ListSystemSummary.Add(ExtractedFileName(file).Split('.')[0], sr.ReadToEnd());//all text wil be saved in text enters are also saved
                    }
                }
            }
            else
            {
                ListReferencesSummaries = null;
                foreach (string file in FileNames)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        if (ListReferencesSummaries == null)
                            ListReferencesSummaries = new Dictionary<string, List<string>>();
                        var temp = ListReferencesSummaries.SingleOrDefault(x => x.Key.Equals(ExtractedFileName(file).Split('.')[0]));
                        if (temp.Key == null)
                            ListReferencesSummaries.Add(ExtractedFileName(file).Split('.')[0], new List<string> { sr.ReadToEnd() });//all text wil be saved in text enters are also saved
                        else
                            ListReferencesSummaries[temp.Key].Add(sr.ReadToEnd());
                    }
                }
            }
            
           
        }
        public static void createCorpus()
        {
            Files = new Dictionary<string, Dictionary<string, Item>>();
            foreach (var system in ListSystemSummary)
            {
                var doc = ListOriginalDoc.SingleOrDefault(x => x.Key.Contains(system.Key)).Value;
                var refs = ListReferencesSummaries.SingleOrDefault(x => x.Key.Contains(system.Key)).Value;
                if (ListSystemSummary.Count == 1)
                {
                    SingleFileName = system.Key;
                    Files.Add(SingleFileName, new Dictionary<string, Item>());
                    Files[SingleFileName].Add("original", new Item(system.Key, doc, system.Value, refs));
                    Files[SingleFileName].Add("topk", null);
                    Files[SingleFileName].Add("oracle", null);

                }
                else
                {
                    SingleFileName = null;
                    Files.Add(system.Key, new Dictionary<string, Item>());
                    Files[system.Key].Add("original", new Item(system.Key, doc, system.Value, refs));
                    Files[system.Key].Add("topk", null);
                    Files[system.Key].Add("oracle", null);
                }
            }
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
