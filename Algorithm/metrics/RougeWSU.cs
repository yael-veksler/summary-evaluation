using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    class RougeWSU
    {
        private static List<string> SystemList;

        public Dictionary<string, List<double>> CalcRouge(  string doc, string system, int Dskip, List<string> references)
        {
            string CutSystemSummary=null;
            if (system == "" || references == null || (references != null && references.Any(x => x == "")))
            {

                Dictionary<string, List<double>> rougesu = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                return rougesu;
            }
            if (Data.cutSummary)
            {
                TopK cutSystem = new TopK(system, Data.lenCutSummary);
                CutSystemSummary = cutSystem.GetTopK();
            }
            List<double> avg = new List<double>() { 0, 0, 0 };
            List<double> max = new List<double>() { 0, 0, 0 };
            if (Data.cutSummary)
                SystemList = SkipBigram.MakeSkipBigrams(CutSystemSummary, Dskip, false, true);
            else
                SystemList = SkipBigram.MakeSkipBigrams(system, Dskip, false, true);
            Dictionary<string, double> res = new Dictionary<string, double>();
            Dictionary<string, double> weight = new Dictionary<string, double>();
            //Parallel.ForEach(references, (reference) =>
            //{
            foreach (var reference in references)
            {
                var ReferenceSkipBigram = SkipBigram.MakeSkipBigrams(reference, Dskip, false, true);
                calcWeigth(ref weight, ReferenceSkipBigram, reference);
                res.Add(reference, wsuMatch(SystemList, ReferenceSkipBigram));
                //CalcAvg(ref avg, res);
                //CalcBest(ref max, res);
            }
            //});

            List<double> MaxRecall = new List<double>();
            List<double> MaxPrecision = new List<double>();

            double recall = Recall(res, references.Count, weight, ref MaxRecall);
            double precision = Precision(res, SystemList, references.Count, ref MaxPrecision);
            double F_measure = F_Measure(recall, precision);
            avg[0] = recall;
            avg[1] = precision;
            avg[2] = F_measure;

            foreach (var i in MaxRecall)
            {
                int j = 0;
                double f = F_Measure(i, MaxPrecision[j]);
                if (max[2] < f)
                {
                    max[0] = i;
                    max[1] = MaxPrecision[j];
                    max[2] = f;
                }
                j++;
            }
            return new Dictionary<string, List<double>> { { "avg", avg }, { "best", max } };

        }

        private void calcWeigth(ref Dictionary<string, double> weight, List<string> referenceSkipBigram, string reference)
        {
            double w = 0;
            foreach (var i in referenceSkipBigram)
            {
                var str = i.Split(' ');
                if (str.Count() == 3)
                    w += (1 / (double)int.Parse(str[2]));
                else
                    w += (1 / (double)int.Parse(str[1]));
            }
            lock (weight)
            {
                weight.Add(reference, w);
            }
        }

        public double F_Measure(double recall, double precision)
        {
            if (precision != 0 && recall != 0)
                return 2 * (precision * recall / (precision + recall));
            else
                return 0;
        }
        private double Precision(Dictionary<string, double> res, List<string> SystemList, int count, ref List<double> max)
        {
            double SumWeight = 0;
            double sum = 0;
            foreach (var i in SystemList)
            {
                var str = i.Split(' ');
                if (str.Count() == 3)
                    SumWeight += (1 / (double)int.Parse(str[2]));
                else if (str.Count() == 2)
                    SumWeight += (1 / (double)int.Parse(str[1]));
            }
            foreach (var i in res)
            {
                sum += i.Value;
                max.Add(i.Value / SumWeight);
            }
            return (sum / SumWeight) / count;
        }

        public double wsuMatch(List<string> SystemList, List<string> ReferenceList)
        {
            List<VariableRougeWSU> system = CreateListOfVariableRougeWSU(SystemList);
            List<VariableRougeWSU> reference = CreateListOfVariableRougeWSU(ReferenceList);
            double d1 = 0, d2 = 0;
            double res = 0;

            foreach (var v in system)
            {
                int distance = 0;
                if (system.Any(x => (x.Unigram == true && x.First == v.First && v.Unigram == true) || (x.Unigram == false && x.First == v.First && x.Second == v.Second)))
                {
                    foreach (var i in system.FindAll(x => (x.Unigram == true && x.First == v.First && v.Unigram == true) || (x.Unigram == false && x.First == v.First && x.Second == v.Second)).ToList())
                    {
                        distance += i.Distance;
                        i.Distance = 0;
                    }
                    v.Distance = distance;
                }
            }


            foreach (var v in system)
            {
                d1 = 0;
                d2 = 0;
                if (v.Unigram)
                {
                    if (reference.Any(x => x.Unigram == true && x.First == v.First))
                    {
                        foreach (var i in reference.FindAll(x => x.Unigram == true && x.First == v.First))
                            d2 += i.Distance;
                        d1 = v.Distance;
                        if (d1 != 0 && d2 != 0)
                            res += (2 / (d1 + d2));
                    }
                }
                else
                    if (reference.Any(x => x.Unigram == false && x.First == v.First && x.Second == v.Second))
                {
                    foreach (var i in reference.FindAll(x => x.Unigram == false && x.First == v.First && x.Second == v.Second))
                        d2 += i.Distance;
                    d1 = v.Distance;
                    if (d1 != 0 && d2 != 0)
                        res += (2 / (d1 + d2));
                }
            }
            return res;
        }
        private List<VariableRougeWSU> CreateListOfVariableRougeWSU(List<string> list)
        {
            List<VariableRougeWSU> temp = new List<VariableRougeWSU>();
            foreach (var i in list)
            {
                var split = i.Split(' ');
                try
                {
                    if (split.Count() == 3)
                    {


                        temp.Add(new VariableRougeWSU
                        {
                            First = split[0],
                            Second = split[1],
                            Unigram = false,
                            Distance = int.Parse(split[2])
                        });
                    }
                    else
                        temp.Add(new VariableRougeWSU
                        {
                            First = split[0],
                            Second = null,
                            Unigram = true,
                            Distance = int.Parse(split[1])
                        });

                }
                catch (Exception e) { }
            }
            return temp;
        }
        private double Recall(Dictionary<string, double> res, int count, Dictionary<string, double> weight, ref List<double> max)
        {
            double sum = 0;
            foreach (var i in weight)
            {
                var temp = res.SingleOrDefault(x => x.Key == i.Key);
                sum += temp.Value / i.Value;
                max.Add(temp.Value / i.Value);
            }
            return sum / count;
        }
    }
}
