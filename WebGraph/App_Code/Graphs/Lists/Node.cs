
namespace Graphs.Lists
{
    public class Node
    {
        public int m_Knoten;
        public int m_Abstand;
        public Node m_next = null;
        public Node m_prev = null;

        public Node(int _Knoten, int _Abstand)
        {
            m_Abstand = _Abstand;
            m_Knoten = _Knoten;
        }
    }
}//Graphs
