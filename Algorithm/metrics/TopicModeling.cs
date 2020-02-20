using IronPython.Hosting;
using SummaryEvaluation;
using SummaryEvaluationAPI.Infrustructure.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EASY_Summary_Evaluation.Algorithm.metrics
{
    class TopicModeling // dont work : estonish,greek,slovene
    {
        public static int NumOfTopics = 10;
        private static List<Dictionary<string, double>> CalcTopics(string text) // text - > original full text
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.CreateNoWindow = true;
            //start.FileName = @"C:\Users\Isana\AppData\Local\Programs\Python\Python37-32\python.exe";

            start.FileName = "python.exe";
            start.Arguments = @"TM.py " + $"\"{text}\"" + " " + MainForm.language;
            //start.Arguments = AppDomain.CurrentDomain.BaseDirectory + "TM.py " + $"\"{text}\"";
            

            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    try
                    {
                        string result = reader.ReadToEnd();
                        List<string> topics = result.Split('\n').ToList();
                        return createMatric(topics);
                        //Console.Write(result);
                    }
                    catch(Exception e)
                    {
                        string type=null, name =null;
                        foreach (var item in Data.Files)
                        {
                            if (item.Value["original"].doc.Equals(text))
                            {
                                type = "original document";
                                name = item.Value["original"].name;
                            }
                            else if (item.Value["original"].system.Equals(text))
                            {
                                type = "system summary";
                                name = item.Value["original"].name;
                            }
                            foreach (var reference in item.Value["original"].references)
                                if (reference.Equals(text))
                                {
                                    type = "reference summary";
                                    name = item.Value["original"].name;
                                }
                        }
                        MessageBox.Show("The "+ type +": " + name + " is not valid");
                        return new List<Dictionary<string, double>>();

                    }
                }
            }

        }

        //private static List<Dictionary<string, double>> CalcTopics(string text) // text - > original full text
        //{
        //    //instance of python engine
        //    var engine = Python.CreateEngine();

        //    //reading code from file
        //    var source = engine.CreateScriptSourceFromFile(AppDomain.CurrentDomain.BaseDirectory + "TopicModeling.py");
        //    var scope = engine.CreateScope();
        //    ICollection<string> Paths = engine.GetSearchPaths();
        //    Paths.Add(@"C:\Program Files\IronPython 2.7\Lib\site-packages");
        //    Paths.Add(@"C:\Program Files\IronPython 2.7\Lib");
        //    Paths.Add(@"C:\Program Files\IronPython 2.7\DLLs");
        //    Paths.Add(@"'C:\Users\Isana\AppData\Local\Programs\Python\Python37-32\python37.zip");
        //    Paths.Add(@"'C:\Users\Isana\AppData\Local\Programs\Python\Python37-32\DLLs");
        //    Paths.Add(@"'C:\Users\Isana\AppData\Local\Programs\Python\Python37-32\lib");
        //    Paths.Add(@"'C:\Users\Isana\AppData\Local\Programs\Python\Python37-32");
        //    Paths.Add(@"''C:\Users\Isana\AppData\Roaming\Python\Python37\site-packages");
        //    Paths.Add(@"''C:\Users\Isana\AppData\Local\Programs\Python\Python37-32\lib\site-packages");
        //    //Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "Lib\\site-packages");
        //    //Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "Lib");
        //    //Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "DLLs");
        //    engine.SetSearchPaths(Paths);
        //    //executing script in scope
        //    source.Execute(scope);
        //    var classCalculator = scope.GetVariable("Calculator");
        //    //initializing class
        //    var calculatorInstance = engine.Operations.CreateInstance(classCalculator);
        //    var x = calculatorInstance.calc(text);
        //    return x;

        //}


        private static List<Dictionary<string, double>> createMatric(List<string> topics)
        {
            List<Dictionary<string, double>> metric = new List<Dictionary<string, double>>();
            int index = 0;
            foreach(var topic in topics)
            {
                if (index == NumOfTopics)
                    return metric;
                metric.Add(new Dictionary<string, double>());
                var tuple = topic.Split('+');
                foreach(var t in tuple)
                {
                    var i = t.Split('*');
                    metric[index].Add(i[1].Replace("\"","").Replace("\r",""),Convert.ToDouble(i[0]));
                }
                index++;
            }
            return metric;
        }

        public static List<double> Calc(string original, string summary,List<string> references)
        {
            List<string> OriginalWords= new List<string>();
            foreach (var i in original.GetWords().Distinct(StringComparer.InvariantCultureIgnoreCase).ToList())
                OriginalWords.Add(i.ToLower());
            List<string> SummaryWords = new List<string>();
            foreach (var i in summary.GetWords().Distinct(StringComparer.InvariantCultureIgnoreCase).ToList())
                SummaryWords.Add(i.ToLower());
            var topics =CalcTopics(original);
            double[,] OriginalArray = new double[OriginalWords.Count,topics.Count];
            double[,] SummaryArray = new double[SummaryWords.Count, topics.Count];
            initTextArray(OriginalWords, topics, ref OriginalArray);
            initTextArray(SummaryWords, topics, ref SummaryArray);
            double[] OriginalMAXV=initMAXVector(OriginalWords, topics, ref OriginalArray);
            double[] SummaryMAXV = initMAXVector(SummaryWords, topics, ref SummaryArray);

            double[] OriginalV = initVector(original.GetWords().ToList(), OriginalWords, OriginalMAXV);
            double[] SummaryV = initVector(summary.GetWords().ToList(), SummaryWords, SummaryMAXV);

            var cosSimilarity = CosineSimilarity(OriginalV.ToList(), SummaryV.ToList());
            var cosSimilarity2= Calc(OriginalV.ToList(), topics, references);
            return new List<double>() { cosSimilarity, cosSimilarity2 };
        }

        private static double Calc(List<double> OriginalV, List<Dictionary<string, double>> topics, List<string> references)
        {
            double max = 0;
            foreach (var reference in references)
            {
                List<string> ReferenceWords = new List<string>();
                foreach (var i in reference.GetWords().Distinct(StringComparer.InvariantCultureIgnoreCase).ToList())
                    ReferenceWords.Add(i.ToLower());
                double[,] ReferenceArray = new double[ReferenceWords.Count, topics.Count];
                initTextArray(ReferenceWords, topics, ref ReferenceArray);
                double[] ReferenceMAXV = initMAXVector(ReferenceWords, topics, ref ReferenceArray);
                double[] ReferenceV = initVector(reference.GetWords().ToList(), ReferenceWords, ReferenceMAXV);

                var cosSimilarity = CosineSimilarity(OriginalV.ToList(), ReferenceV.ToList());
                
                if (cosSimilarity > max) max = cosSimilarity;
            }
            return max;
        }
        

        private static double[] initVector(List<string> TextWordsList, List<string> DistinctWordsList, double[] MAXVector)
        {
            double[] v = new double[TextWordsList.Count];
            for(int i=0; i<v.Count(); i++)
            {
                v[i] = MAXVector[DistinctWordsList.IndexOf(TextWordsList[i].ToLower())];
            }
            return v;
        }

        private static double[] initMAXVector(List<string> originalWords, List<Dictionary<string, double>> topics, ref double[,] originalArray)
        {
            double[] v = new double[originalWords.Count];
            for (int j = 0; j < originalWords.Count; j++)
            {
                double max = 0;
                for (int i = 0; i < topics.Count; i++)
                {
                    if (max < originalArray[j, i])
                        max = originalArray[j, i];
                }
                v[j] = max;
            }
            return v;
        }

        private static void initTextArray(List<string> TextWords, List<Dictionary<string, double>> Topics, ref double[,] TextArray)
        {
            int row = 0, col = 0;
            foreach(var i  in TextWords)
            {
                col = 0;
                foreach(var j in Topics)
                {
                    if (j.Any(x => x.Key.Equals(i+" ")))
                    {
                        TextArray[row, col] = j[i+" "];
                    }
                    else
                        TextArray[row, col] = 0;
                    col++;
                }
                row++;
            }
        }
        private static double CalculateCosineSimilarity(double[] vecA, double[] vecB)
        {
            var dotProduct = DotProduct(vecA, vecB);
            var magnitudeOfA = Magnitude(vecA);
            var magnitudeOfB = Magnitude(vecB);

            return dotProduct / (magnitudeOfA * magnitudeOfB);
        }

        private static double DotProduct(double[] vecA, double[] vecB)
        {
            // I'm not validating inputs here for simplicity.            
            double dotProduct = 0;
            for (var i = 0; i < vecA.Length; i++)
            {
                dotProduct += (vecA[i] * vecB[i]);
            }

            return dotProduct;
        }

        // Magnitude of the vector is the square root of the dot product of the vector with itself.
        private static double Magnitude(double[] vector)
        {
            return Math.Sqrt(DotProduct(vector, vector));
        }

        public static double CosineSimilarity(List<double> V1, List<double> V2)
        {
            int N = 0;
            N = ((V2.Count < V1.Count) ? V2.Count : V1.Count);
            double dot = 0.0d;
            double mag1 = 0.0d;
            double mag2 = 0.0d;
            for (int n = 0; n < N; n++)
            {
                dot += V1[n] * V2[n];
                mag1 += Math.Pow(V1[n], 2);
                mag2 += Math.Pow(V2[n], 2);
            }

            return dot / (Math.Sqrt(mag1) * Math.Sqrt(mag2));
        }
    }
}
