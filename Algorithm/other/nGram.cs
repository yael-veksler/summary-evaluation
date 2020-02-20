using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class nGram
    {
        public static List<string> makeNgrams(string text, int nGramSize)
        {
            if (nGramSize == 0) throw new Exception("nGram size was not set");
            if (nGramSize >4 ) throw new Exception("nGram size should be smaller than 4");
            List<string> nGrams = new List<string>();
            StringBuilder nGram = new StringBuilder();
            Queue<int> wordLengths = new Queue<int>();

            int wordCount = 0;
            int lastWordLen = 0;

            //append the first character, if valid.
            //avoids if statement for each for loop to check i==0 for before and after vars.
            if (text != "" && char.IsLetterOrDigit(text[0]))
            {
                nGram.Append(text[0]);
                lastWordLen++;
            }

            //generate ngrams
            for (int i = 1; i < text.Length - 1; i++)
            {
                char before = text[i - 1];
                char after = text[i + 1];

                if (char.IsLetterOrDigit(text[i])
                        ||
                        //keep all punctuation that is surrounded by letters or numbers on both sides.
                        (text[i] != ' '
                        && (char.IsSeparator(text[i]) || char.IsPunctuation(text[i]))
                        && (char.IsLetterOrDigit(before) && char.IsLetterOrDigit(after))
                        )
                    )
                {
                    nGram.Append(text[i]);
                    lastWordLen++;
                }
                else
                {
                    if (lastWordLen > 0)
                    {
                        wordLengths.Enqueue(lastWordLen);
                        lastWordLen = 0;
                        wordCount++;

                        if (wordCount >= nGramSize)
                        {
                            nGrams.Add(nGram.ToString());
                            if (nGramSize == 1)
                            {
                                nGram.Append(" ");
                                
                            }
                            nGram.Remove(0, wordLengths.Dequeue() + 1);
                            wordCount -= 1;
                        }
                        if(nGramSize > 1)
                            nGram.Append(" ");
                    }
                }
            }
            nGram.Append(text.Last());
            nGrams.Add(nGram.ToString());

            return nGrams;
        }
        /// <summary>
        /// create character n-grams based on disjointness prerequisite
        /// </summary>
        /// <param name="text"></param>
        /// <param name="Dmin"></param>
        /// <param name="Dmax"></param>
        /// <returns></returns>
        public static Dictionary<string, List<int>> CreateCharNgrams(string text, int Dmin=3, int Dmax=3)
        {
            if (Dmin == 0) throw new Exception("nGram size was not set");
            if (Dmax < Dmin) throw new Exception("Dmax should be bigger than Dmin") ;
            if (Dmax > 4) throw new Exception("Dmax should be smaller than 4");
            Dictionary<string, List<int>> charNgram = new Dictionary<string,List<int>>();
            for (int j = Dmin; j <= Dmax; j++) {
                for (int i = 0; i <= text.Length - j; i++)
                {
                    StringBuilder ngram = new StringBuilder();
                    for (int k = i; k < i+j; k++) {
                        ngram.Append(text[k]);
                            }
                    if (charNgram.ContainsKey(ngram.ToString()))
                    {
                        List<int> list = charNgram[ngram.ToString()];
                        if (list.Contains(i) == false)
                        {
                            list.Add(i);
                        }
                    }
                    else
                    {
                        List<int> list = new List<int>();
                        list.Add(i);
                        charNgram.Add(ngram.ToString(),list);
                    }
                }
            }
            return charNgram;
        }

    }
}



//foreach (string str in nGram.makeNgrams("SMU is the best college in Texas", 1))
//    {
//                Console.WriteLine(str);
//    }