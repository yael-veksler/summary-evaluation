using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SummaryEvaluation
{
    public class RougeN : Rouge
    {
        private static Dictionary<string, int> SystemDic;
        public Dictionary<string, List<double>> CalcRouge(string system, List<string> references, int n)
        {
            if (system == "" || references == null || (references != null && references.Any(x => x == "")))
            {
                Dictionary<string, List<double>> rougen = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                return rougen;
            }
            List<double> avg = new List<double>() { 0, 0, 0 };
            List<double> max = new List<double>() { 0, 0, 0 };
            SystemDic = CreateDictionary(nGram.makeNgrams(system, n));
            Parallel.ForEach(references, (reference) =>
            {
                List<double> res = base.CalcRouge(SystemDic, CreateDictionary(nGram.makeNgrams(reference, n)));
                CalcAvg(ref avg, res);
                CalcBest(ref max, res);
            });
            return new Dictionary<string, List<double>> { { "avg", avg }, { "best", max } };
        }
        

    }
}
