using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    class RougeSU : Rouge
    {
        private static Dictionary<string, int> SystemDic;
        
        public Dictionary<string, List<double>> CalcRouge(string system, List<string> references, int Dskip)
        {
            if (system == "" || references == null || (references != null && references.Any(x => x == "")))
            {
                
                Dictionary<string, List<double>> rougesu = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                return rougesu;
            }
            List<double> avg = new List<double>() { 0, 0, 0 };
            List<double> max = new List<double>() { 0, 0, 0 };
            SystemDic = CreateDictionary(SkipBigram.MakeSkipBigrams(system, Dskip, true,false));
            Parallel.ForEach(references, (reference) =>
            {
                List<double> res = base.CalcRouge(SystemDic, CreateDictionary(SkipBigram.MakeSkipBigrams(reference, Dskip, true,false)));
                CalcAvg(ref avg, res);
                CalcBest(ref max, res);
            });
            return new Dictionary<string, List<double>> { { "avg", avg }, { "best", max } };

        }
    }
}
