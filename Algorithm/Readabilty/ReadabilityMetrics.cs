using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using OpenNLP.Tools.PosTagger;
//using OpenNLP.Tools.SentenceDetect;
//using OpenNLP.Tools.Tokenize;
using System.Diagnostics;

namespace SummaryEvaluation
{
    class ReadabilityMetrics
    {
        //public static void CalcReadability()
        //{
        //    foreach (var item in Data.Files)
        //    {
        //        string text = item.Value["original"].system;
        //        //string text = "the dog fanciers club organized a lunch at sardi's on Wednesday for two of their champions, the city's top police dog and the nation's top show dog.";
        //        var modelPathForSentences = $@"{Directory.GetCurrentDirectory()}\EnglishSD.nbin";
        //        //var paragraph = "Mr. & Mrs. Smith is a 2005 American romantic comedy action film. The film stars Brad Pitt and Angelina Jolie as a bored upper-middle class married couple. They are surprised to learn that they are both assassins hired by competing agencies to kill each other.";
        //        var sentenceDetector = new EnglishMaximumEntropySentenceDetector(modelPathForSentences);
        //        var sentences = sentenceDetector.SentenceDetect(text);

        //        var modelPath = $@"{Directory.GetCurrentDirectory()}\EnglishPOS.nbin";
        //        var tagDictDir = $@"{Directory.GetCurrentDirectory()}\tagdict";
        //        var posTagger = new EnglishMaximumEntropyPosTagger(modelPath, tagDictDir);
        //        var tokenizer = new EnglishRuleBasedTokenizer(true);
        //        //var sentence = "- Sorry Mrs. Hudson, I'll skip the tea.";
        //        int NumOfNNP = 0, NumOfNN = 0, NumOfPR = 0;
        //        int NumOfWords = 0, NumOfCharacters = 0;
        //        foreach (var sentence in sentences)
        //        {
        //            var tokens = tokenizer.Tokenize(sentence);
        //            tokens = tokens.Where(s => s != "-" && s != "." && s != "£" && s != "$" && s != "%" && s != "^" &&
        //                                          s != "&" && s != "," && s != "_" && s != ";" && s != ":" && s != "+" && s != "=" &&
        //                                          s != "(" && s != ")" && s != "{" && s != "}" && s != "[" && s != "]" && s != "@" &&
        //                                          s != "#" && s != "!" && s != "?").ToArray();
        //            //var tokens = new string[] { "-", "Sorry", "Mrs.", "Hudson", ",", "I", "'ll", "skip", "the", "tea", "." };
        //            var pos = posTagger.Tag(tokens);
        //            foreach (var tag in pos)
        //            {
        //                if (tag == "NNP")
        //                    NumOfNNP++;
        //                else if (tag == "NN" || tag == "NNS")
        //                    NumOfNN++;
        //                else if (tag == "PRP" || tag == "PRP$") //|| tag == "WP" || tag == "WP$"
        //                    NumOfPR++;
        //            }
        //            NumOfWords += tokens.Count();
        //            int count = 0;
        //            foreach (var token in tokens)
        //            {
        //                foreach (char c in token)
        //                {
        //                    count++;
        //                }
        //            }
        //            NumOfCharacters += count;
        //        }
        //        //var NNP = (double)NumOfNNP / NumOfWords;
        //        //var NR = (double)NumOfNN / NumOfWords;
        //        //var PR = (double)NumOfPR / NumOfWords;
        //        //var AWL = (double)NumOfCharacters / NumOfWords;
        //        item.Value["original"].PNR= (double)NumOfNNP / NumOfWords;
        //        item.Value["original"].NR= (double)NumOfNN / NumOfWords;
        //        item.Value["original"].PR= (double)NumOfPR / NumOfWords;
        //        item.Value["original"].AWL= (double)NumOfCharacters / NumOfWords;
        //        var Tags = new Dictionary<string, string>
        //        {
        //            ["CC"] = "Coordinating conjunction",
        //            ["CD"] = "Cardinal number",
        //            ["DT"] = "Determiner",
        //            ["EX"] = "Existential there",
        //            ["FW"] = "Foreign word",
        //            ["IN"] = "Preposition or subordinating conjunction",
        //            ["JJ"] = "Adjective",
        //            ["JJR"] = "Adjective",
        //            ["JJS"] = "Adjective",
        //            ["LS"] = "List item marker",
        //            ["MD"] = "Modal",
        //            ["NN"] = "Noun",
        //            ["NNS"] = "Noun",
        //            ["NNP"] = "Proper noun",
        //            ["NNPS"] = "Proper noun",
        //            ["PDT"] = "Predeterminer",
        //            ["POS"] = "Possessive ending",
        //            ["PRP"] = "Personal pronoun",
        //            ["PRP$"] = "Possessive pronoun",
        //            ["RB"] = "Adverb",
        //            ["RBR"] = "Adverb",
        //            ["RBS"] = "Adverb",
        //            ["RP"] = "Particle",
        //            ["SYM"] = "Symbol",
        //            ["TO"] = "to",
        //            ["UH"] = "Interjection",
        //            ["VB"] = "Verb",
        //            ["VBD"] = "Verb",
        //            ["VBG"] = "Verb",
        //            ["VBN"] = "Verb",
        //            ["VBP"] = "Verb",
        //            ["VBZ"] = "Verb",
        //            ["WDT"] = "Wh-determiner",
        //            ["WP"] = "Wh-pronoun",
        //            ["WP$"] = "Possessive wh-pronoun",
        //            ["WRB"] = "Wh-adverb"
        //        };
        //    }
        //}

        public static string CalcReadabilityNLTK(string text)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.CreateNoWindow = true;
            //start.FileName = @"C:\Users\Isana\AppData\Local\Programs\Python\Python37-32\python.exe";
            
            start.FileName = "python.exe";
            start.Arguments = @"Readability.py " + $"\"{text}\""; 
            //start.Arguments = AppDomain.CurrentDomain.BaseDirectory + "TM.py " + $"\"{text}\"";

            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                    return result;
                    //List<string> results = result.Split(',').ToList();
                    //item.Value["original"].PNR = Convert.ToDouble(results[0]);
                    //item.Value["original"].NR = Convert.ToDouble(results[1]);
                    //item.Value["original"].PR = Convert.ToDouble(results[2]);
                    //item.Value["original"].Fog = Convert.ToDouble(results[3]);
                    //item.Value["original"].AWL = Convert.ToDouble(results[4]);
                    //item.Value["original"].FRES = Convert.ToDouble(results[5]);
                    //item.Value["original"].FKGL = Convert.ToDouble(results[6]);
                }
            }
        }
        
    }
}