using System;
using System.Collections.Generic;

using Graphs.Lists;
/// 
/// Code von https://www.quora.com/What-are-the-C-simplest-examples-of-implementation-of-breadth-first-search-and-depth-first-search
/// kopiert am 01.05.
/// 
namespace Graphs
{
    class DepthFirstSearch
    {
        private bool[] marked;
        private int[] edgeTo;
        private int s;
        

        public DepthFirstSearch(WebGraph _G, int _s)
        {
            int vertikalCount = _G.nodes.Count;
            marked = new bool[vertikalCount];
            edgeTo = new int[vertikalCount];
            this.s = _s;
        }

        public bool DFS(WebGraph _G, int _v)
        {
            MyStack<int> stack = new MyStack<int>();
            marked[s] = true;
            stack.AddLast(s);
            while (stack.NotEmpty())
            {
                int Knoten = stack.GetFirstNode();
                stack.deliteFirst();
                List<int> list = _G.adjzentsListe[Knoten];
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i] == _v)
                    {
                        Console.WriteLine("es gibt einen Weg.");
                        return true;
                    }
                    if (marked[list[i]] == false)
                    {
                        marked[list[i]] = true;
                        stack.AddLast(list[i]);
                    }                    
                }
            }
            return false;
        }
    }
}
