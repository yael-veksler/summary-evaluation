using SummaryEvaluation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using IronPython.Hosting;

namespace SummaryEvaluationAPI.Infrustructure.Extensions
{
    public static class StringExtensions
    {
        private static readonly object SentLock = new object();
        private static readonly object WordLock = new object();
        public static List<string> sent_tokenize(this string str) //use ironpython
        {
            //instance of python engine
            var engine = Python.CreateEngine();

            //reading code from file
            var source = engine.CreateScriptSourceFromFile(AppDomain.CurrentDomain.BaseDirectory + "sentTokenize.py");
            var scope = engine.CreateScope();
            ICollection<string> Paths = engine.GetSearchPaths();
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\Lib\\site-packages");
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\Lib");
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\DLLs");

            engine.SetSearchPaths(Paths);
            //executing script in scope
            source.Execute(scope);
            var classCalculator = scope.GetVariable("calculator");
            //initializing class
            var calculatorInstance = engine.Operations.CreateInstance(classCalculator);
            var x = calculatorInstance.add(str, MainForm.language);
            List<string> res = new List<string>();
            foreach (object element in x)
            {
                res.Add((string)element);
            }
            lock (SentLock)
            {
                if (!Data.listSentences.Any(i => i.Key.Equals(str)))
                    Data.listSentences.Add(str, res);
            }
            return res;
        }
       
        public static IEnumerable<string> GetSentences(this string str) 
        {
            if (Data.listSentences != null)
            {
                if (Data.listSentences.Any(x => x.Key.Equals(str)))
                    return Data.listSentences[str];
            }
            //if (MainForm.language == "english")
            //{
            //    var letterDotLetterRegex = new Regex("([A-Z])[.]([A-Z])[.]?");
            //    var output = letterDotLetterRegex.Replace(str, "$1$2");

            //    var regex = new Regex("([jJ][aA][nN]|[fF][eE][bB]|[mM][aA][rR]|[aA][pP][rR]|[mM][aA][yY]|[jJ][uU][nN][eE]|[jJ][uU][lL][yY]|[aA][uU][gG]|[sS][eE][pP]|[sS][eE][pP][tT]|[oO][cC][tT]|[nN][oO][vV]|[dD][eE][cC]).[ ]*([0-9]+)");
            //    output = regex.Replace(output, "$1 $2");

            //    var commaSeperatedNumber = new Regex("([0-9]),([0-9])");
            //    output = commaSeperatedNumber.Replace(output, "$1$2");

            //    string removedBreaks = output.Replace("\r", "").Replace("\\", "").Replace("\"", "");

            //    List<string> sentences = Regex.Split(removedBreaks, "[.?!]\n|\n|[.?!]").ToList();
            //    if (sentences.FirstOrDefault(x => x.Equals("")) != null)
            //        sentences.RemoveAll(x => x.Equals(""));
            //    if (sentences.FirstOrDefault(x => x.Equals(" ")) != null)
            //        sentences.RemoveAll(x => x.Equals(" "));
            //    lock (SentLock) {
            //        if (!Data.listSentences.Any(x => x.Key.Equals(str)))
            //            Data.listSentences.Add(str, sentences);
            //    }
            //    return sentences;
            //}
            //else 
                return sent_tokenize(str);
          
        }
        public static void word_tokenize_ForText(this string text)
        {
            //Console.WriteLine(str);
            //instance of python engine
            var engine = Python.CreateEngine();

            //reading code from file
            var source = engine.CreateScriptSourceFromFile(AppDomain.CurrentDomain.BaseDirectory + "wordTokenizeForText.py");
            var scope = engine.CreateScope();
            ICollection<string> Paths = engine.GetSearchPaths();
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\Lib\\site-packages");
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\Lib");
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\DLLs");
            engine.SetSearchPaths(Paths);
            //executing script in scope
            source.Execute(scope);
            var classCalculator = scope.GetVariable("calculator");
            //initializing class
            var calculatorInstance = engine.Operations.CreateInstance(classCalculator);
            var x = calculatorInstance.add(text, MainForm.language);
            // List<string> res = new List<string>();
            //foreach (object element in x)
            //{
            //    res.Add((string)element);
            //}
            List<string> sentences=null;
            if (Data.listSentences != null)
            {
                if (Data.listSentences.Any(y => y.Key.Equals(text)))
                    sentences = Data.listSentences[text];
            }
            int i = 0;
            foreach (var sen in sentences)
            {
                
                lock (WordLock)
                {
                    if (!Data.listWords.Any(y => y.Key.Equals(sen)))
                    {
                        List<string> list = new List<string>();
                        foreach(var obj in x[i])
                        {
                            list.Add((string)obj);
                        }
                        Data.listWords.Add(sen, list);
                        i++;
                    }
                }
            }
            //return res;
        }


        public static List<string> word_tokenize(this string str)
        {
            //Console.WriteLine(str);
            //instance of python engine
            var engine = Python.CreateEngine();

            //reading code from file
            var source = engine.CreateScriptSourceFromFile(AppDomain.CurrentDomain.BaseDirectory + "wordTokenize.py");
            var scope = engine.CreateScope();
            ICollection<string> Paths = engine.GetSearchPaths();
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\Lib\\site-packages");
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\Lib");
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "IronPython 2.7\\DLLs");
            engine.SetSearchPaths(Paths);
            //executing script in scope
            source.Execute(scope);
            var classCalculator = scope.GetVariable("calculator");
            //initializing class
            var calculatorInstance = engine.Operations.CreateInstance(classCalculator);
            var x = calculatorInstance.add(str, MainForm.language);
            List<string> res = new List<string>();
            foreach (object element in x)
            {
                res.Add((string)element);
            }
            lock (WordLock)
            {
                if (!Data.listWords.Any(i => i.Key.Equals(str)))
                    Data.listWords.Add(str, res);
            }
            return res;
        }
        //public static IEnumerable<string> GetWords(this string str)
        //{
        //    if (Data.listWords.Any(x => x.Key.Equals(str)))
        //        return Data.listWords[str];
        //    return null;
        //}

        public static IEnumerable<string> GetWords(this string str)
        {
            if (str == null)
                return null;
            if (Data.listWords != null)
            {
                lock (Data.listWords)
                {
                    if (Data.listWords.Any(x => x.Key.Equals(str)))
                        return Data.listWords[str];
                }
            }
            if (MainForm.language == "english")
            {
                string cleanedString = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Replace(",", "").Replace(":", "").Replace(".", "").Replace("\n", " ");
                List<string> Words = Regex.Replace(cleanedString, "[^a-zA-Z0-9 ]", "").Split(' ').ToList();
                if (Words.FirstOrDefault(x => x.Equals("")) != null)
                    Words.RemoveAll(x => x.Equals(""));
                lock (WordLock)
                {
                    if (!Data.listWords.Any(x => x.Key.Equals(str)))
                        Data.listWords.Add(str, Words.ToList());
                }
                return Words;
            }
            else
                return word_tokenize(str);
         
    }




    }

}