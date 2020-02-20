using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class SkipBigram
    {
        //public static List<string> MakeSkipBigrams(string text, int n, bool su)
        //{
        //    List<string> ret = nGram.makeNgrams(text, 1);
        //    List<string> SkipBigram = new List<string>();
        //    int FirstLen = 0;
        //    int SecondLen = 0;
        //    for (int i = 0; i < ret.Count; i++)
        //    {
        //        StringBuilder s = new StringBuilder();
        //        s.Append(ret[i]);
        //        FirstLen = ret[i].Length;
        //        if (su)
        //            SkipBigram.Add(ret[i]);
        //        for (int j = i+1; j <=i+n && j<ret.Count; j ++)
        //        {
        //            s.Append(" ");
        //            s.Append(ret[j]);
        //            SecondLen = ret[j].Length;
        //            SkipBigram.Add(s.ToString());
        //            s.Remove(FirstLen, SecondLen + 1);
        //        }
        //        s.Remove(0, FirstLen);
        //    }

        //    return SkipBigram;
        //}
        public static List<string> MakeSkipBigrams(string text, int n, bool su, bool wsu)
        {
            List<string> ret = nGram.makeNgrams(text, 1);
            List<string> SkipBigram = new List<string>();
            int FirstLen = 0;
            int SecondLen = 0;
            for (int i = 0; i < ret.Count; i++)
            {
                StringBuilder s = new StringBuilder();
                s.Append(ret[i]);
                FirstLen = ret[i].Length;
                if (su)
                {
                    SkipBigram.Add(ret[i]);

                }
                if (wsu)
                {
                    SkipBigram.Add(ret[i] + " 1");

                }
                for (int j = i + 1; j <= i + n + 1 && j < ret.Count; j++) 
                {
                    s.Append(" ");
                    s.Append(ret[j]);
                    SecondLen = ret[j].Length;
                    if (wsu)
                        SkipBigram.Add(s.ToString() + " " + (j - i));
                    else
                        SkipBigram.Add(s.ToString());
                    s.Remove(FirstLen, SecondLen + 1);
                }
                s.Remove(0, FirstLen);
            }

            return SkipBigram;
        }

        }
}
