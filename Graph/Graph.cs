
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class Graph
    {
        private int v;
        private int e;
        private List<string> vertices; //list of n-grams
        private List<Edge> edges;


        public Graph(List<string> vertices)
        {
            int V = vertices.Count;
            if (V < 0)
                throw new Exception("Number of vertices in a Graph must be nonnegative");

            this.v = V;

            this.e = 0;

            edges = new List<Edge>();

            this.vertices = new List<string>(vertices.ToArray());
        }
        public void setVertices(List<string> vertices)
        {
            this.vertices = vertices;
            v = vertices.Count;
        }
        public List<string> GetVertices()
        {
            return vertices;
        }
        /// <summary>
        /// the edges are weighted by the number of co-occurrences of 
        /// thier respective n-grams whutun a given window in the 
        /// source text of the graph
        /// </summary>
        /// <param name="ngrams"> n-gram and indexs in which appear</param>
        /// <param name="Dwin">window</param>
        /// <param name="ngram1">vertice u</param>
        /// <param name="ngram2">vertice v</param>
        /// <returns></returns>
        public int EdgeWeights(Dictionary<string, List<int>> ngrams, int Dwin, string ngram1, string ngram2)
        {
            int count = 0;
            List<int> index1, index2;
            try
            {
                index1 = ngrams[ngram1];
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
            try
            {
                index2 = ngrams[ngram2];
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
            foreach (var i in index1)
            {
                foreach (var j in index2)
                {
                    if (Math.Abs(i - j) <= Dwin)
                        count++;
                }
            }
            return count;
        }
        /// <summary>
        /// The definition of the weighting performed in the graph resulting from U is:
        /// Wi(e) = W1(e) + (W2(e) − W1(e)) × l
        /// </summary>
        /// <param name="w1">the weight of e in G1</param>
        /// <param name="w2">the weight of e in G2</param>
        /// <param name="l">1/i i is number of new graph that updates the overall graph</param>
        /// <returns></returns>
        public static double CalcWeightAfterMerge(double w1, double w2, double l)
        {
            return w1 + (w2 - w1) * l;
        }
        public double EdgeWeight(string u, string v)
        {
            var e = edges.FirstOrDefault(x => (x.Source().Equals(u) && x.Target(u).Equals(v)));
            if (e == null)
                e = edges.SingleOrDefault(x => (x.Source().Equals(v) && x.Target(v).Equals(u)));
            if (e == null)
                return 0;
            else
                return e.Weight();
        }
        public int getV()
        {
            return v;
        }

        public int getE()
        {
            return e;
        }

        public void AddEdge(Edge e)
        {
            edges.Add(e);
            this.e++;
        }


        //return the list of edge in graph
        public List<Edge> Edges()
        {
            return edges;

        }


        /// <summary>
        /// union the lists of n-grams
        /// </summary>
        /// <param name="v1">list of vertices (n-grams) in G1</param>
        /// <param name="v2">list of vertices (n-grams) in G2</param>
        /// <returns>list of vertices</returns>
        public static List<string> UnionVertices(List<string> v1, List<string> v2)
        {
            List<string> vertices = new List<string>();
            foreach (var v in v1)
                vertices.Add(v);
            foreach (var v in v2)
            {
                if (vertices.IndexOf(v) == -1)
                    vertices.Add(v);
            }
            return vertices;
        }
        public bool edgeExsist(Edge e)
        {
            string u = e.Source();
            string v = e.Target(u);

            if(edges.SingleOrDefault(x=>(x.Source().Equals(u) &&x.Target(u).Equals(v)))==null)
                if (edges.SingleOrDefault(x => (x.Source().Equals(v) && x.Target(v).Equals(u))) == null)
                    return false;
            return true;

        }
    }
}