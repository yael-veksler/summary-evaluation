using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class Rouge
    {
        public double P { get; set; }
        public double R { get; set; }
        public Rouge()
        {
            P = 0;
            R = 0;
        }

        public Dictionary<string, int> CreateDictionary(List<string> Ngrams)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string str in Ngrams)
            {
                if (dic.ContainsKey(str))
                {
                    dic[str] += 1;
                }
                else
                    dic.Add(str, 1);
            }
            return dic;
        }


        public int CalcOverlappingWords(Dictionary<string, int> d1, Dictionary<string, int> d2)
        {
            int overlappingWords = 0;
            foreach (KeyValuePair<string, int> kvp in d1)
            {
                if (d2.ContainsKey(kvp.Key))
                {
                    if (d2[kvp.Key] > kvp.Value)
                        overlappingWords += kvp.Value;
                    else
                        overlappingWords += d2[kvp.Key];

                }
            }
            return overlappingWords;
        }
        public int CountGrams(Dictionary<string, int> dict)
        {
            int count = 0;
            foreach (KeyValuePair<string, int> kvp in dict)
            {
                count += kvp.Value;
            }
            return count;
        }
        public List<double> CalcRouge(Dictionary<string, int> SystemDic, Dictionary<string, int> ReferenceDic)
        {
            List<double> results = new List<double>();
            int CountNgramReference = CountGrams(ReferenceDic);
            int CountNgramSystem = CountGrams(SystemDic);
            int OverlappingWords = CalcOverlappingWords(SystemDic, ReferenceDic);
            results.Add(Recall(OverlappingWords, CountNgramReference));
            results.Add(Pecision(OverlappingWords, CountNgramSystem));
            results.Add(F_Measure());

            return results;
        }
        public List<double> CalcRouge(double Overlapping, int CountReference,int CountSystem)
        {
            List<double> res = new List<double>();
            res.Add(Recall(Overlapping, CountReference));
            res.Add(Pecision(Overlapping, CountSystem));
            res.Add(F_Measure());
            return res;
        }
        //rougeW
        public List<double> CalcRouge(double wlcsScore, double f_m, double f_n)
        {
            List<double> res = new List<double>();
            R = Math.Sqrt(wlcsScore / f_m);
            P = Math.Sqrt(wlcsScore / f_n);
            res.Add(R);
            res.Add(P);
            res.Add(F_Measure());
            return res;
        }
        public double Recall(double OverlappingWords, int CountNgramReference)
        {
            if (OverlappingWords == 0)
                R = 0;
            else
                 R =(double)OverlappingWords / CountNgramReference;
            return R;
        }
        public double Pecision(double OverlappingWords, int CountNgramSystem)
        {
            if (OverlappingWords == 0)
                P = 0;
            else
                P = (double)OverlappingWords / CountNgramSystem;
            return P;
        }
        public double F_Measure()
        {
            if (P != 0 && R != 0)
                return 2 * (P * R / (P + R));
            else
                return 0;
        }

        public void CalcAvg(ref List<double>avg, List<double> res)
        {
            lock (avg)
            {
                avg[0] = (Rational.Parse(avg[0]) + Rational.Parse(res[0])).ToDouble();
                avg[1] = (Rational.Parse(avg[1]) + Rational.Parse(res[1])).ToDouble();
                avg[2] = (Rational.Parse(avg[2]) + Rational.Parse(res[2])).ToDouble();

                if (double.IsNaN(avg[0]))
                    avg[0] = 0;
                if (double.IsNaN(avg[1]))
                    avg[1] = 0;
                if (double.IsNaN(avg[2]))
                    avg[2] = 0;

            }
        }
        public void CalcBest(ref List<double> max, List<double> res)
        {
            lock (max)
            {
                if (res[2] > max[2])
                {
                    max[0] = res[0];
                    max[1] = res[1];
                    max[2] = res[2];
                }
            }
        }
        
    }
}
