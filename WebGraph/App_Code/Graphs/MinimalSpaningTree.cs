using System;
using System.Collections.Generic;
/// 
/// Code von https://www.programmingalgorithms.com/algorithm/kruskal%27s-algorithm
/// kopiert am 01.05.
/// 

namespace Graphs
{

    class MinimalSpaningTree
    {
        public struct Subset
        {
            public int Parent;
            public int Rank;
        }
        public MinimalSpaningTree()
        {
        }
        public List<Edge> Kruskal(WebGraph _graph)
        {
            int verticesCount = _graph.nodes.Count;
            Edge[] result = new Edge[verticesCount];
            Edge[] edges = _graph.edges.ToArray();
            int i = 0;
            int e = 0;

            Array.Sort(edges, delegate (Edge a, Edge b)
            {
                return a.value.CompareTo(b.value);
            });

            Subset[] subsets = new Subset[verticesCount];

            for (int v = 0; v < verticesCount; ++v)
            {
                subsets[v].Parent = v;
                subsets[v].Rank = 0;
            }

            while (e < verticesCount - 1)
            {
                Edge nextEdge = edges[i++];
                int x = Find(subsets, nextEdge.to);
                int y = Find(subsets, nextEdge.from);

                if (x != y)
                {
                    result[e++] = nextEdge;
                    Union(subsets, x, y);
                }
            }
            List<Edge> Edges = new List<Edge>(result);
            Edges.RemoveAt(Edges.Count - 1);
            return Edges;
        }

        private int Find(Subset[] subsets, int i)
        {
            if (subsets[i].Parent != i)
                subsets[i].Parent = Find(subsets, subsets[i].Parent);

            return subsets[i].Parent;
        }
        private void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            if (subsets[xroot].Rank < subsets[yroot].Rank)
                subsets[xroot].Parent = yroot;
            else if (subsets[xroot].Rank > subsets[yroot].Rank)
                subsets[yroot].Parent = xroot;
            else
            {
                subsets[yroot].Parent = xroot;
                ++subsets[xroot].Rank;
            }
        }
    }
}//Graphs
