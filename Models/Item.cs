using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class Item
    {
        public string name { get; set; }
        public string doc { get; set; }
        public string system { get; set; }
        public List<string> references { get; set; }
        public  Dictionary<int, string> TopKDic { get; set; }
        public  Dictionary<int, string> OracleDic { get; set; }

        public List<RougeVariable> RougeResults { get; set; }
        public List<MeMoGVariable> MeMoGResults { get; set; }
        public List<RougeVariable> RougeResultsForCutSummary { get; set; }
        public List<MeMoGVariable> MeMoGResultsForCutSummary { get; set; }

        public double PNR { get; set; }
        public double NR { get; set; }
        public double PR { get; set; }
        public double Fog { get; set; }
        public double AWL { get; set; }
        public double FRES { get; set; }
        public double FKGL { get; set; }

        public Item(string name, string duc, string system, List<string> references)
        {
            this.name = name;
            this.doc = duc;
            this.system = system;
            if (references != null)
                this.references = new List<string>(references);
            else
                this.references = new List<string>();
            TopKDic = new Dictionary<int, string>();
            OracleDic = new Dictionary<int, string>();
            RougeResults = new List<RougeVariable>();
            MeMoGResults = new List<MeMoGVariable>();
            RougeResultsForCutSummary = new List<RougeVariable>();
            MeMoGResultsForCutSummary = new List<MeMoGVariable>();
        }
        
    }

    public class TMVariable
    {
    }
}
