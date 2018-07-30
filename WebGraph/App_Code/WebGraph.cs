using System;
using System.Linq;
using System.Collections.Generic;
using Graphs;

/// <summary>
/// Zusammenfassungsbeschreibung für MyClass
/// </summary>

public class WebGraph
{
    public List<Node>   nodes;
    public List<Edge>   edges;
    public List<int>[]  adjzentsListe;

    public WebGraph()
    {
        this.nodes = new List<Node>();
        this.edges = new List<Edge>();
    }
    public WebGraph(List<Node> _nodes, List<Edge> _edges)
    {
        this.nodes = new List<Node>();
        this.edges = new List<Edge>();
        this.nodes = _nodes;
        this.edges = _edges;
        //konvertiere
        for (int i = 0; i < nodes.Count; i++)
        {
            int nodeId = _nodes[i].id;
            this.nodes[i].id = i;
            this.edges.Where(x => x.to == nodeId).ToList().ForEach(s => s.to = i);
            this.edges.Where(x => x.from == nodeId).ToList().ForEach(s => s.from = i);
        }

        SetAdjazentsliste();
    }
    public WebGraph GetMST()
    {
        SetEdgeColor();
        MinimalSpaningTree MST = new MinimalSpaningTree();
        List<Edge> Edges = MST.Kruskal(this);
        SetEdgesColor(Edges, "red");
        return this;
    }

    private void SetEdgeColor()
    {
        foreach (Edge edge in edges)
        {
            edge.color = "blue";
        }
    }

    private void SetEdgesColor(List<Edge> _Edges, string _EdgeColor)
    {
        foreach (var Edge in _Edges)
        {
                
            if (_Edges.Contains(Edge))
            {
                edges.Remove(Edge);
                edges.Add(new Edge(Edge, _EdgeColor));
            }
        }
    }
    private void SetAdjazentsliste()
    {
        int verticesCount = nodes.Count;
        int edgesCount = edges.Count;
        adjzentsListe = new List<int>[verticesCount];
        for (int i = 0; i < verticesCount; ++i)
        {
            adjzentsListe[i] = new List<int>();
        }
        for (int i = 0; i < verticesCount; ++i)
        {
            foreach (var edge in edges)
            {
                if (edge.from == nodes[i].id)
                {
                    adjzentsListe[i].Add(edge.to);
                    int n = nodes.FindIndex(x => x.id == edge.to);
                    adjzentsListe[n].Add(nodes[i].id);
                }
            }
        }
    }
    public bool Connectivity()
    {
        var node = nodes.ElementAt(0);
        foreach(var n in nodes)
        {
            var dsf = new DepthFirstSearch(this, node.id);
            if (!dsf.DFS(this, n.id) && n.id != node.id)
                return true;
        }
        return false;
    }
}



