using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class RougeS : Rouge
    {
        private static Dictionary<string, int> SystemDic;
        public  double factorial(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * factorial(number - 1);
        }
        public Dictionary<string, List<double>> CalcRouge(string system, List<string> references, int Dskip)
        {
            if ( system == "" || references == null || (references != null && references.Any(x => x == "")))
            {
                
                Dictionary<string, List<double>> rouges = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                return rouges;
            }
            List<double> avg = new List<double>() { 0, 0, 0 };
            List<double> max = new List<double>() { 0, 0, 0 };
            SystemDic = CreateDictionary(SkipBigram.MakeSkipBigrams(system, Dskip, false,false));
            Parallel.ForEach(references, (reference) =>
            {
                List<double> res = base.CalcRouge(SystemDic, CreateDictionary(SkipBigram.MakeSkipBigrams(reference, Dskip, false,false)));
                CalcAvg(ref avg, res);
                CalcBest(ref max, res);
            });
            return new Dictionary<string, List<double>> { { "avg", avg }, { "best", max } };
        }

    }
}
