using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class MeMoGVariable
    {
        public string system { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int Dwin { get; set; }
        public List<double> result { get; set; }

        public MeMoGVariable(string system,int min, int max, int Dwin, List<double> res)
        {
            this.system = system;
            this.min = min;
            this.max = max;
            this.Dwin = Dwin;
            this.result= new List<double>(res);
        }

    }
}
