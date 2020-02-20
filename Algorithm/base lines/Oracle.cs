
using SummaryEvaluationAPI.Infrustructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SummaryEvaluation
{
    public class Oracle
    {

        //public const int k = 200; // k is rank to compute the weights of our terms

        public int L; //the target length of the summary (given in number of words).
        private Dictionary<string, int> unionDic;
        private Dictionary<string, List<Tuple<int, int>>> indexes;

        public List<string> occams { get; set; }
        public Oracle(List<string> references, string doc, int L )
        {
            this.L = L;
            unionDic = new Dictionary<string, int>();
            foreach (var reference in references)
            {
                UnionDic(GetTermsFromText(reference));
            }
            indexes = GetTermAndNumSentence(doc);
            int row = indexes.Keys.Count; //num of terms
            //count of sentences in full duc
            int col = doc.GetSentences().ToList().Count;//num of sentence in orginal duc
            double[,] matrix = new double[row, col];
            initMatrix(ref matrix, row, col);
            calcPij(ref matrix);
            UpdateGlobalWeight(ref matrix, row, col);

            double[] s; // w in alglib.rmatrixsvd
            double[,] u;
            double[,] vt;
            alglib.rmatrixsvd(matrix, row, col, 1, 1, 2, out s, out u, out vt);

            int termNum = 0;
            double[] W = new double[indexes.Keys.Count];
            foreach (var term in indexes.Keys)
            {
                W[termNum] = CalcW_ti(termNum, u, row, row, s);
                termNum++;
            }

            int SentenceNum = 0;
            int[] C = new int[doc.GetSentences().Count()];
            foreach (var sentence in doc.GetSentences())
            {
                C[SentenceNum++] = sentence.GetWords().Count();
            }

            occams = OCCAMS(indexes.Keys.ToList(), doc.GetSentences().ToList(), W, C, L);


        }
        public string GetOccams()
        {
            StringBuilder str = new StringBuilder();
            foreach (var s in occams)
            {
                if (MainForm.language == "english")
                    str.Append(s + ". ");
                else
                    str.Append(s);
            }
            return str.ToString();
        }

        public void calcPij(ref double[,] matrix)
        {
            //calc Pij 
            int c = 0;
            int Tij;
            foreach (var term in indexes.Keys)
            {
                if (unionDic.Keys.Contains(term))
                {
                    int gi = unionDic[term];
                    foreach (var sen_count in indexes[term])
                    {
                        Tij = sen_count.Item2;
                        double Pij = (double)Tij / gi;
                        matrix[c, sen_count.Item1] = Pij;
                    }
                }
                c++;
            }
        }
        public void initMatrix(ref double[,] matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    matrix[i, j] = 0;

        }
        public Dictionary<string, int> GetTermsFromText(string text)
        {
            Dictionary<string, int> terms = new Dictionary<string, int>();
            foreach (var sen in text.GetSentences().ToList())
            {
                foreach (string word in sen.GetWords().ToList())
                {
                    if (terms.Keys.Contains(word))
                        terms[word]++;
                    else
                        terms.Add(word, 1);
                }
            }
            return terms;
        }

        public void UnionDic(Dictionary<string, int> dic)
        {
            //Dictionary<string, int> unionDic = dic1.ToDictionary(entry => entry.Key,entry => entry.Value);
            foreach (var item in dic)
            {
                if (unionDic.Keys.Contains(item.Key))
                    unionDic[item.Key] = dic[item.Key] + item.Value;
                else
                    unionDic.Add(item.Key, item.Value);
            }
        }

        public Dictionary<string, List<Tuple<int, int>>> GetTermAndNumSentence(string text)
        {
            // indexes: 
            //string - word
            //List<int, int> - Item1 is num of sentence, Item2 is number of times term i appears in sentence j
            Dictionary<string, List<Tuple<int, int>>> indexes = new Dictionary<string, List<Tuple<int, int>>>();
            int index = 0;
            foreach (var sen in text.GetSentences().ToList())
            {
                foreach (string term in sen.GetWords().ToList())
                {
                    if (!indexes.Keys.Contains(term))
                    {
                        indexes.Add(term, new List<Tuple<int, int>>());
                        indexes[term].Add(new Tuple<int, int>(index, 1));
                    }
                    else
                    {
                        var i = indexes[term].FirstOrDefault(x => x.Item1 == index);
                        if (i != null)
                        {
                            indexes[term].Remove(i);
                            indexes[term].Add(new Tuple<int, int>(index, i.Item2 + 1));
                        }
                        else
                            indexes[term].Add(new Tuple<int, int>(index, 1));

                    }
                }
                index++;
            }
            return indexes;
        }

        public void UpdateGlobalWeight(ref double[,] A, int row, int col)
        {
            //update global weight
            for (int i = 0; i < col; i++)
            {
                double sum = 0;
                for (int j = 0; j < row; j++)
                {
                    if (A[j, i] > 0)
                        sum += A[j, i] * Math.Log(A[j, i]) / Math.Log(col); //col- num of sentences , matrix[i,j]- Pij
                }
                double Gi = 1 + sum; //global weight
                for (int j = 0; j < row; j++)
                    if (A[j, i] != 0)
                        A[j, i] = Gi;
            }
        }


        public double[,] calcW(double[,] Uk, int row, int col, double[,] Sk)
        {
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    Uk[i, j] = Math.Abs(Uk[i, j]);

            double[,] W = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < col; k++)
                        sum += Uk[i, k] * Sk[k, j];
                    W[i, j] = sum;
                }
            }
            return W;
        }
        /// <summary>
        /// calc weight of term ti in T 
        /// </summary>
        /// <returns></returns>
        public double CalcW_ti(int i, double[,] U, int row, int col, double[,] S)
        {
            double sum = 0;
            for (int j = 0; j < col; j++)
            {
                sum += Math.Abs(U[i, j]) * S[j, j];
            }
            return sum;
        }
        /// <summary>
        /// calc weight of term ti in T 
        /// </summary>
        /// <returns></returns>
        public double CalcW_ti(int i, double[,] U, int row, int col, double[] S)
        {
            double sum = 0;
            for (int j = 0; j < col && j < S.Length; j++)
            {
                sum += Math.Abs(U[i, j]) * S[j];
            }
            return sum;
        }
        //return Smax - the first choosing the heaviest weight sentence
        public string argmaxS(List<string> T, List<string> D, double[] W, int[] C)
        {
            double[] res = new double[D.Count()];
            int index = 0; //num of sentence
            foreach (string sentence in D)
            {
                if (sentence == null)
                {
                    index++;
                    continue;
                }
                int c_si = C[D.IndexOf(sentence)];
                double sum = 0;
                foreach (var ti in sentence.GetWords())
                {
                    sum += W[T.IndexOf(ti)];
                }
                res[index++] = sum / c_si;

            }
            double max = res[0];


            for (int j = 1; j < res.Count(); j++)
                if (res[j] > max)
                    max = res[j];

            return D[Array.IndexOf(res, max)];
        }

        public List<string> Greedy_BMC(List<string> T, List<string> D, double[] W, int[] C, int L)
        {
            List<string> K = new List<string>();
            List<string> U = new List<string>();
            int count = 0; //num of words in K

            for (int i = 0; i < D.Count(); i++)
            {
                double[] res = new double[D.Count()];
                int index = 0; //num of sentence
                foreach (string sentence in D)
                {
                    if (sentence == null)
                    {
                        res[index] = 0;
                        index++;
                        continue;
                    }
                    int c_si = C[D.IndexOf(sentence)];
                    double sum = 0;
                    foreach (var ti in sentence.GetWords())
                    {
                        if (!U.Contains(ti))
                            sum += W[T.IndexOf(ti)];
                    }
                    res[index++] = sum / c_si;
                }
                double max = res[0];
                for (int j = 1; j < res.Count(); j++)
                    if (res[j] > max)
                        max = res[j];
                if (max == 0)
                    return K;
                if ((count + D[Array.IndexOf(res, max)].GetWords().Count()) < L)
                {
                    K.Add(D[Array.IndexOf(res, max)]);
                    count += D[Array.IndexOf(res, max)].GetWords().Count();
                    foreach (var term in D[Array.IndexOf(res, max)].GetWords())
                        U.Add(term); ///יכול להיות שהיה יותר מפעם אחת את המונח ברשימה
                }
                else
                    D[Array.IndexOf(res, max)] = null;

                D[Array.IndexOf(res, max)] = null;
            }
            return K;
        }
        public double factorial(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * factorial(number - 1);
        }
        public List<string> KS(List<string> K, List<string> T, List<string> D, double[] W, int[] C, int L)
        {

            //calc profit p(Si) of a sentence Si be the combined weight of the terms in it
            double[] p = new double[D.Count()];
            double[] val = new double[D.Count()];
            int[] wt = new int[D.Count()];
            int index = 0; //num of sentence
            foreach (string sentence in D)
            {
                double sum = 0;
                foreach (var ti in sentence.GetWords())
                {
                    sum += W[T.IndexOf(ti)];
                }
                p[index] = sum;
                val[index] = sum;
                wt[index] = sentence.GetWords().Count();
                index++;
            }
            double maxRes = 0;
            List<int> indexOfmax = null;
            List<int> indexOfSummary = null;
            for (int summaryLen = L; summaryLen >= L - 50; summaryLen--)
            {
                indexOfSummary = new List<int>();
                double result = CalcKnapSack(ref indexOfSummary, summaryLen, wt, val, D.Count);
                if (result != -1 && result > maxRes)
                {
                    maxRes = result;
                    indexOfmax = new List<int>(indexOfSummary);
                }

            }
            List<string> summary = new List<string>();
            int len = 0;
            if (indexOfmax == null)
                return new List<string>();
            foreach (int i in indexOfmax)
            {
                len += wt[i];
                summary.Add(D[i]);
            }
            return summary;

        }
        //Compute the sets of terms T(Ki)
        public List<string> T_K(List<string> K)
        {
            List<string> T = new List<string>();
            foreach (var sentence in K)
            {
                foreach (var word in sentence.GetWords())
                    if (!T.Contains(word))
                        T.Add(word);
            }
            return T;
        }
        public double W_T_Ki(List<string> Ki, List<string> T, double[] W)
        {
            double sum = 0;
            if (Ki == null)
                return 0;
            foreach (var sentence in Ki)
            {
                foreach (var term in sentence.GetWords())
                    sum += W[T.IndexOf(term)];
            }
            return sum;
        }
        public List<string> argmaxT_Ki(List<string> K1, List<string> K2, List<string> K3, List<string> T, double[] W)
        {
            double x1 = W_T_Ki(K1, T, W);
            double x2 = W_T_Ki(K2, T, W);
            double x3 = W_T_Ki(K3, T, W);

            if (x1 >= x2 && x1 >= x3)
                return K1;
            else if (x2 >= x1 && x2 >= x3)
                return K2;
            else
                return K3;

        }
        public List<string> OCCAMS(List<string> T, List<string> D, double[] W, int[] C, int L)
        {
            List<string> K1 = Greedy_BMC(T, new List<string>(D), W, C, L);
            string Smax = argmaxS(T, D, W, C);
            List<string> K2 = new List<string>();
            K2.Add(Smax);
            List<string> _T = new List<string>();
            _T.AddRange(T);
            //Let T' = T-K(Smax);
            List<string> _D = new List<string>();
            _D.AddRange(D);
            _D[D.IndexOf(Smax)] = null;
            int[] _C = new int[D.Count];
            _C[D.IndexOf(Smax)] = 0;
            int _L = L - C[D.IndexOf(Smax)];
            K2.AddRange(Greedy_BMC(_T, _D, W, _C, _L));

            List<string> K3 = KS(Greedy_BMC(T, new List<string>(D), W, C, 5 * L), T, new List<string>(D), W, C, L);

            return argmaxT_Ki(K1, K2, K3, T, W);
        }



        // A utility function that returns  
        // maximum of two integers  
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Prints the items which are put  
        // in a knapsack of capacity W  
        static double CalcKnapSack(ref List<int> index, int W, int[] wt,
                                double[] val, int n)
        {
            int i, w;
            double[,] K = new double[n + 1, W + 1];
            double sum = 0;
            // Build table K[][] in bottom up manner  
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                    {
                        K[i, w] = Math.Max(val[i - 1] +
                                K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    }
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            // stores the result of Knapsack  
            double res = K[n, W];
            double result = K[n, W];
            int length = 0;
            //Console.WriteLine(res + "\n");


            w = W;
            for (i = n; i > 0 && res > 0; i--)
            {

                // either the result comes from the top  
                // (K[i-1][w]) or from (val[i-1] + K[i-1]  
                // [w-wt[i-1]]) as in Knapsack table. If  
                // it comes from the latter one/ it means  
                // the item is included.  
                if (res == K[i - 1, w])
                    continue;
                else
                {

                    // This item is included.  
                    //Console.Write(wt[i - 1] + " (" + i + ") ");
                    index.Add(i - 1);
                    sum += val[i - 1];
                    length += wt[i - 1];
                    // Since this weight is included its  
                    // value is deducted  
                    res = res - val[i - 1];
                    w = w - wt[i - 1];
                    if (w <= 0)
                    {
                        //Console.WriteLine(" " + sum);
                        //return false;
                        i = 0;

                    }
                }
            }
            //Console.WriteLine(" " + sum);
            if (result == sum || length < W)
                return sum;
            return -1;

        }


    }
}
