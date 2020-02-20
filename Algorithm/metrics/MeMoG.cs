using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SummaryEvaluation
{
    public class MeMoG
    {
        /// private List<string> references;
        /// private string system;
        /// private int Dmin, Dmax, Dwin;
        //List<string> ngrams;
        Dictionary<string, List<int>> ngrams;
        //List<Graph> graphs = new List<Graph>();
        Dictionary<int, Graph> graphDic = new Dictionary<int, Graph>();
        Graph systemG;
        Graph referencesG;


        public MeMoG(List<string> references, string system, int Dmin = 3, int Dmax = 3, int Dwin = 3)
        {

            int graphNum = 0;
            //create graph for reference

            /*
            Parallel.ForEach(references, (reference) =>
            {
                ngrams = nGram.CreateCharNgrams(reference, Dmin, Dmax);
                List<string> v = ngrams.Keys.ToList();
                var graph = new Graph(v);
                lock (graphDic)
                {
                    graphDic[graphNum] = graph;
                    //graphs.Add(graph);
                    graphNum++;
                }
                CreateGraph(ref graph, Dwin);
            });
            */

            foreach (var reference in references)
            {
                ngrams = nGram.CreateCharNgrams(reference, Dmin, Dmax);
                List<string> v = ngrams.Keys.ToList();
                var graph = new Graph(v);
                graphDic[graphNum] = graph;
                CreateGraph(graphDic[graphNum++], Dwin);
            }


            //g is merge graph 
            referencesG = graphDic[0];
            for (int i = 0; i < graphNum - 1; i++)
            {
                referencesG = MergoTwoGraph(referencesG, graphDic[i + 1], i + 2);
            }

            //from graph matching to summary evaluation
            ngrams = nGram.CreateCharNgrams(system, Dmin, Dmax);
            systemG = new Graph(ngrams.Keys.ToList());
            CreateGraph(systemG, Dwin);
        }


        public List<double> CalcMeMoG()
        {
            List<double> res = new List<double>();
            res.Add(CalcVS(referencesG, systemG));
            res.Add(calcNVS(referencesG, systemG, res[0]));
            return res;
        }

        private void CreateGraph(Graph graph, int Dwin)
        {
            List<string> v = graph.GetVertices();
            for (int i = 0; i < graph.getV() - 1; i++)
            {
                for (int j = i + 1; j < graph.getV(); j++)
                {
                    int weight = graph.EdgeWeights(ngrams, Dwin, v[i], v[j]);
                    if (weight != 0)
                    {
                        graph.AddEdge(new Edge(v[i], v[j], weight));
                    }
                }
            }

        }
        private void Merge(ref Graph g, Graph g1, Graph g2, int i)
        {
            double l = (double)1 / i;
            double weight = 0;

            foreach (var e1 in g1.Edges())
            {
                weight = g2.EdgeWeight(e1.Source(), e1.Target(e1.Source()));
                g.AddEdge(new Edge(e1.Source(), e1.Target(e1.Source()), Graph.CalcWeightAfterMerge(e1.Weight(), weight, l)));
            }

            foreach (var e2 in g2.Edges())
            {
                if (g.edgeExsist(e2) == false) //edge not added
                {
                    g.AddEdge(new Edge(e2.Source(), e2.Target(e2.Source()), Graph.CalcWeightAfterMerge(0, e2.Weight(), l)));
                }
            }
        }



        private Graph MergoTwoGraph(Graph g1, Graph g2, int i)
        {
            List<string> vertices = Graph.UnionVertices(g1.GetVertices(), g2.GetVertices());
            Graph g = new Graph(vertices);
            Merge(ref g, g1, g2, i);
            return g;
        }

        private double CalcVR_e_(Edge e1, Edge e2)
        {
            double min;
            double max;
            if (e1.Weight() < e2.Weight())
            {
                min = e1.Weight();
                max = e2.Weight();
            }
            else
            {
                min = e2.Weight();
                max = e1.Weight();
            }
            return (double)min / max;
        }
        public double CalcVS(Graph Gi, Graph Gj)
        {
            double SumVR = 0.0;
            foreach (var i in Gi.Edges().ToList())
            {
                string u = i.Source();
                string v = i.Target(i.Source());

                Edge j = Gj.Edges().ToList().FirstOrDefault(e => ((e.Source().Equals(u)) && (e.Target(e.Source()).Equals(v))) || ((e.Source().Equals(v)) && (e.Target(e.Source()).Equals(u))));
                if (j != null)
                    SumVR += CalcVR_e_(i, j);
                //else
                //    SumVR += 0;
            }
            double GiSize = GSize(Gi), GjSize = GSize(Gj);
            double maxSize;
            if (GiSize < GjSize)
            {
                maxSize = GjSize;
            }
            else
            {
                maxSize = GiSize;
            }
            return (double)SumVR / maxSize;
        }
        /// <summary>
        /// |G| - sum of edges weight
        /// </summary>
        /// <param name="g"></param>
        private double GSize(Graph g)
        {
            double sum = 0;
            foreach (var e in g.Edges().ToList())
                sum += e.Weight();
            return sum;
        }
        private double calcNVS(Graph Gi, Graph Gj, double VS = 0)
        {
            double GiSize = GSize(Gi), GjSize = GSize(Gj);
            double maxSize, minSize;
            if (GiSize < GjSize)
            {
                maxSize = GjSize;
                minSize = GiSize;
            }
            else
            {
                maxSize = GiSize;
                minSize = GjSize;
            }
            if (VS >= 0)
                return VS / (minSize / maxSize);
            return CalcVS(Gi, Gj) / (minSize / maxSize);
        }
    }
}

