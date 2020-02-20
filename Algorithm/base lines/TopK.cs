using SummaryEvaluationAPI.Infrustructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class TopK
    {
        string topK;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="k">number of words. min length is 100</param>
        public TopK(string text, int k)
        {
            StringBuilder temp = new StringBuilder();
            int total = 0;
            foreach (string sentence in text.GetSentences())
            {
                if (sentence != null)
                    total += sentence.GetWords().Count();

                if (total <= k)
                {
                    if (MainForm.language == "english")
                        temp.Append(sentence + ". ");
                    else
                        temp.Append(sentence);

                }
                else
                {
                    topK = temp.ToString();
                    return;
                }
            }
            topK = temp.ToString();
        }
        public string GetTopK() { return topK; }
    }
}
