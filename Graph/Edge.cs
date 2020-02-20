using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class Edge
    {
        string u;
        string v;
        double weight;

        public Edge(string u, string v, double weight)
        {
            this.u = u;
            this.v = v;
            this.weight = weight;
        }

        public double Weight()
        {
            return weight;
        }
        public int CompareTo(Edge that)
        {
            if (this.Weight() < that.Weight())
                return -1;
            else if (this.Weight() > that.Weight())
                return +1;
            else
                return 0;
        }
        public bool EqualTo(Edge that)
        {
            if ((this.v.Equals(that.v) && this.u.Equals(that.u)) || (this.v.Equals(that.u) && this.u.Equals(that.v)))
                return true;
            return false;
        }

        public string Source()
        {
            return u;
        }
        public string Target(string vertex)
        {
            if (vertex.Equals(u)) return v;
            else if (vertex.Equals(v)) return u;
            return "invalid";
        }

        public String toString()
        {
            return String.Format("{0:d}-{1:d} {2:f5}", u, v, weight);
        }
    }
}