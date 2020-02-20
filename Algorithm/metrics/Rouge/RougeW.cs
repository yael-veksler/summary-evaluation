using SummaryEvaluationAPI.Infrustructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    class RougeW : Rouge
    {
        public static double f(double k)
        {
            return k * k;
        }

        public static double wlcs(string X, string Y)
        {

            int m = X.GetWords().Count();
            int n = Y.GetWords().Count();

            double[,] c_table = new double[m + 1, n + 1];
            double[,] w_table = new double[m + 1, n + 1];


            for (int i = 0; i <= m; i++)
                for (int j = 0; j <= n; j++)
                {
                    c_table[i, j] = 0; // Initialize the c-table
                    w_table[i, j] = 0;// Initialize the w-table
                }

            List<string> x = X.GetWords().ToList();
            List<string> y = Y.GetWords().ToList();

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // The length of consecutive matches at 
                    // position i-1 and j-1
                    if (x[i - 1] == y[j - 1])
                    {
                        // Increment would be +1 for normal LCS
                        double k = w_table[i - 1, j - 1];
                        double increment = f(k + 1) - f(k);
                        // Add the increment
                        c_table[i, j] = c_table[i - 1, j - 1] + increment;
                        w_table[i, j] = k + 1;
                    }
                    else
                    {
                        if (c_table[i - 1, j] > c_table[i, j - 1])
                        {
                            c_table[i, j] = c_table[i - 1, j];
                            w_table[i, j] = 0; // no match at i,j
                        }
                        else
                        {
                            c_table[i, j] = c_table[i, j - 1];
                            w_table[i, j] = 0; // no match at i,j
                        }
                    }
                }
            }
            return c_table[m, n];
        }
        public Dictionary<string, List<double>> CalcRouge(string EvaluatedSummary, List<string> ReferencesSummary)
        {
            if (EvaluatedSummary == "" || ReferencesSummary == null || (ReferencesSummary != null && ReferencesSummary.Any(x => x == "")))
            {

                Dictionary<string, List<double>> rougew = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                return rougew;
            }
            List<double> avg = new List<double>() { 0, 0, 0 };
            List<double> max = new List<double>() { 0, 0, 0 };
            int n = 0; //lenght of reference
            foreach (var sentence in EvaluatedSummary.GetSentences())
                n += sentence.GetWords().Count();
            Parallel.ForEach(ReferencesSummary, (reference) =>
            {
                double wlcsScore = wlcs(EvaluatedSummary, reference);
                int m = 0; //lenght of reference
                foreach (var sentence in reference.GetSentences())
                    m += sentence.GetWords().Count();
                List<double> res = base.CalcRouge(wlcsScore, f(m), f(n));
                CalcAvg(ref avg, res);
                CalcBest(ref max, res);
            });
            return new Dictionary<string, List<double>> { { "avg", avg }, { "best", max } };

        }

        //private List<double> RougeW_R_P_F(double wlcsScore, double f_m, double f_n)
        //{
        //    List<double> res = new List<double>();
        //    R = Math.Sqrt(wlcsScore / f_m);
        //    P = Math.Sqrt(wlcsScore / f_n);
        //    res.Add(R);
        //    res.Add(P);
        //    res.Add(F_Measure());
        //    return res;
        //}
    }
}
