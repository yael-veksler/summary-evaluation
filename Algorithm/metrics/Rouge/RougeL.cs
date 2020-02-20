using SummaryEvaluationAPI.Infrustructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class RougeL : Rouge
    {
        /// <summary>
        /// Returns the length of the Longest Common Subsequence between sequences x and y.
        ///Source: http://www.algorithmist.com/index.php/Longest_Common_Subsequence
        /// </summary>
        /// <param name="x">sequence of words</param>
        /// <param name="y">sequence of words</param>
        /// <returns>integer: Length of LCS between x and y</returns>
        public int LenLcs(string x, string y)
        {
            return LCS(x, y).Count;
        }
        /// <summary>
        /// Computes the length of the longest common subsequence(lcs) between two 
        /// strings.The implementation below uses a DP programming algorithm and runs
        /// in O(nm) time where n = len(x) and m = len(y).
        /// Source: http://www.algorithmist.com/index.php/Longest_Common_Subsequence
        /// </summary>
        /// <param name="x">collection of words</param>
        /// <param name="y">collection of words</param>
        /// <returns>longest common subsequence between x and y</returns>
        public List<string> LCS(string x, string y)
        {

            if (string.IsNullOrWhiteSpace(x) || string.IsNullOrWhiteSpace(y))
            {
                return new List<string>();
            }

            var start = new List<string>();
            var end = new List<string>();

            var xWords = x.GetWords().ToList();
            var yWords = y.GetWords().ToList();

            var startIndex = 0;
            var xEndIndex = xWords.Count - 1;
            var yEndIndex = yWords.Count - 1;

            while (startIndex < xEndIndex && startIndex < yEndIndex && xWords[startIndex].Equals(yWords[startIndex]))
            {
                start.Add(xWords[startIndex++]);
            }

            while (xEndIndex >= 0 && yEndIndex >= 0 && xWords[xEndIndex].Equals(yWords[yEndIndex]))
            {
                end.Add(xWords[xEndIndex--]);
                yEndIndex--;
            }

            var remainingxWords = xWords.SubEnumerable(startIndex, xEndIndex).ToList();
            var remainingyWords = yWords.SubEnumerable(startIndex, yEndIndex).ToList();

            var lastFoundIndex = 0;
            var maxMatchedWords = new List<string>();
            List<string> tempMatchedWords;

            for (int k = 0; k < remainingxWords.Count(); k++)
            {
                tempMatchedWords = new List<string>();
                for (int i = 0; i < remainingxWords.Count(); i++)
                {
                    for (int j = lastFoundIndex; j < remainingyWords.Count(); j++)
                    {
                        if (remainingxWords[i].Equals(remainingyWords[j]))
                        {
                            lastFoundIndex = j + 1;
                            tempMatchedWords.Add(remainingxWords[i]);
                            break;
                        }
                    }
                }
                //first max sequence
                if (tempMatchedWords.Count > maxMatchedWords.Count)
                {
                    maxMatchedWords.Clear();
                    maxMatchedWords.AddRange(tempMatchedWords);
                }

            }

            return Merge(maxMatchedWords, start, end);
        }

        private List<string> Merge(List<string> middle, List<string> start, List<string> end)
        {
            return start.Concat(middle).Concat(end).ToList();
        }

        private string UnionLCS(string evaluated_sentences, string reference_sentence)
        {
            if (string.IsNullOrWhiteSpace(evaluated_sentences) || string.IsNullOrWhiteSpace(reference_sentence))
            {
                return null;
            }
            List<string> UnionList = new List<string>();
            var EvaluatedSentences = evaluated_sentences.GetSentences();
            foreach (string EvalSentence in EvaluatedSentences)
            {
                var tempList = LCS(EvalSentence, reference_sentence);
                UnionList = UnionList.Union(tempList.ToList()).ToList(); //exclude the duplicate
                //UnionList.Concat(tempList); //include the duplicate
            }
            StringBuilder union = new StringBuilder();
            foreach (var str in UnionList)
                union.Append(str + " ");
            return union.ToString();
        }
        /// <summary>
        ///  Computes ROUGE-L(sentence level) of two sentences OF text.
        ///Calculated according to:
        ///R_lcs = LCS(X, Y) / m
        ///P_lcs = LCS(X, Y) / n
        ///F_lcs = ((1 + beta ^ 2) * R_lcs* P_lcs) / (R_lcs + (beta ^ 2) * P_lcs)
        /// where:
        ///X = reference summary
        ///Y = Candidate summary
        ///m = length of reference summary
        ///n = length of candidate summary
        /// </summary>
        /// <param name="EvaluatedSentence"></param>
        /// <param name="ReferenceSentence"></param>
        public void RougeLSentenceLevel(string EvaluatedSentence, string ReferenceSentence)
        {
            base.CalcRouge(LenLcs(EvaluatedSentence, ReferenceSentence), ReferenceSentence.GetWords().Count(), EvaluatedSentence.GetWords().Count());
        }

        public Dictionary<string, List<double>> RougeLSummaryLevel(string EvaluatedSentences, List<string> ReferencesSentences)
        {
            if (EvaluatedSentences == "" || ReferencesSentences == null || (ReferencesSentences != null && ReferencesSentences.Any(x => x == "")))
            {
                var r = new Dictionary<string, List<double>>()
                {
                    {"avg",new List<double>(){0,0,0} },{ "best",new List<double>(){0,0,0} }
                };
                return r;

            }
            List<double> avg = new List<double>() { 0, 0, 0 };
            List<double> max = new List<double>() { 0, 0, 0 };
            int EvalCountWords = 0;

            foreach (string EvalSentence in EvaluatedSentences.GetSentences())
            {
                EvalCountWords += EvalSentence.GetWords().Count();
            }
            Parallel.ForEach(ReferencesSentences, (referenceSentences) =>
            {
                var RefSentences = referenceSentences.GetSentences();

                int RefSenCountWords;
                int RefCountWords = 0;
                double UnionLcsValue = 0;
                string UnionLcs;
                foreach (string RefSentence in RefSentences)
                {
                    RefSenCountWords = RefSentence.GetWords().Count();
                    RefCountWords += RefSenCountWords;
                    UnionLcs = UnionLCS(EvaluatedSentences, RefSentence);
                    //UnionLcsValue += ((double)UnionLcs.Count / RefCountWords);
                    UnionLcsValue += UnionLcs.GetWords().Count();
                }
                //double lcsScore = lcs(EvaluatedSentences, referenceSentences);

                List<double> res = base.CalcRouge(UnionLcsValue, RefCountWords, EvalCountWords);
                //List<double> res = calc_R_P_F(lcsScore, RefCountWords, EvalCountWords);
                CalcAvg(ref avg, res);
                CalcBest(ref max, res);
            });
            return new Dictionary<string, List<double>> { { "avg", avg }, { "best", max } };

        }
        public static double lcs(string X, string Y)
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
                        double increment = 1;
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
    }
}
