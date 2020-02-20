using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class RougeVariable
    {
        public string system { get; set; }
        public int n { get; set; }
        public int Dskip { get; set; }
        public Dictionary<string, Dictionary<string, List<double>>> result { get; set; }

        public  Dictionary<string, List<double>> resN { get; set; }

        public  Dictionary<string, List<double>> resL { get; set; }
        public  Dictionary<string, List<double>> resW { get; set; }
        public  Dictionary<string, List<double>> resS { get; set; }
        public  Dictionary<string, List<double>> resSU { get; set; }

        public RougeVariable(string system, int n, int Dskip, Dictionary<string, List<double>> resN, Dictionary<string, List<double>> resL, Dictionary<string, List<double>> resW, Dictionary<string, List<double>> resS, Dictionary<string, List<double>> resSU)
        {
            this.system = system;
            this.n = n;
            this.Dskip = Dskip;
            this.resN = new Dictionary<string, List<double>>(resN);
            this.resL = new Dictionary<string, List<double>>(resL);
            this.resW = new Dictionary<string, List<double>>(resW);
            this.resS = new Dictionary<string, List<double>>(resS);
            this.resSU = new Dictionary<string, List<double>>(resSU);

            this.result = new Dictionary<string, Dictionary<string, List<double>>>(){ { "rougeN", resN }, { "rougeL", resL}, { "rougeW", resW}, { "rougeS", resS}, { "rougeSU", resSU} };
        }
        
    }
}
