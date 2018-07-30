using System;

namespace Graphs.Lists
{
    class ListStack
    {
        Node m_Header;
        Node m_Footer;

        public void InsertSorted(int _Knoten, int _Abstand)
        {
            if (!IsContent(_Knoten, _Abstand))
            {
                if (m_Header == null)
                {
                    m_Header = new Node(_Knoten, _Abstand);
                    m_Footer = m_Header;
                }
                else if (_Abstand < m_Header.m_Abstand)
                {
                    Node tmp = m_Header;
                    m_Header = new Node(_Knoten, _Abstand);
                    tmp.m_prev = m_Header;
                    m_Header.m_next = tmp;
                }
                else
                {
                    Node current = m_Header;
                    while (current.m_next != null && _Abstand > current.m_Abstand)
                    {
                        current = current.m_next;
                    }
                    if (current.m_next == null && _Abstand >= current.m_Abstand)
                    {
                        Node tmp = m_Footer;
                        m_Footer = new Node(_Knoten, _Abstand);
                        tmp.m_next = m_Footer;
                        m_Footer.m_prev = tmp;
                    }
                    else
                    {
                        Node insert = new Node(_Knoten, _Abstand);
                        insert.m_next = current;
                        insert.m_prev = current.m_prev;

                        current.m_prev.m_next = insert;
                        current.m_prev = insert;
                    }
                }
            }
        }

        private bool IsContent(int _Knoten, int _Abstand)
        {
            bool isContent = false;
            if (m_Header != null)
            {
                Node current = m_Header;
                while (current != null)
                {
                    //Knoten soll gelöscht werden, wenn er schon vorhanden ist und der Abstand kleiner ist als vorher
                    if (_Knoten == current.m_Knoten && _Abstand < current.m_Abstand)
                    {
                        isContent = true;
                        if (current.m_prev == null && current.m_next == null) //ist es das einzige Element
                        {
                            m_Header = null;
                            m_Footer = null;
                            isContent = false;
                        }
                        else if (current.m_prev == null)                     //ist es das letzte Element        
                        {
                            m_Header = current.m_next;
                            m_Header.m_prev = null;
                            isContent = false;
                        }
                        else if (current.m_next == null)                     //ist es das erste Element
                        {
                            m_Footer = current.m_prev;
                            m_Footer.m_prev = null;
                            isContent = false;
                        }
                        else                                                 //ist das Element mitten drin
                        {
                            current.m_prev.m_next = current.m_next;
                            current.m_next.m_prev = current.m_prev;
                            isContent = false;
                        }                                              
                    }
                    current = current.m_next;
                }
            }

            return isContent;
        }

        public bool IsEmpty()
        {
            bool IsEmpty = false;
            if (m_Header == null)
                IsEmpty = true;
            return IsEmpty;
        }
        public int FirstNode()
        {
            return m_Header.m_Knoten;
        }
        public void DeliteFirst()
        {
            if (m_Header != null)
            {
                m_Header = m_Header.m_next;
                if (m_Header != null)
                    m_Header.m_prev = null;
                else
                    m_Footer = null;
            }
        }
        public void print()
        {
            if (m_Header != null)
            {
                Node current = m_Header;
                while (current != null)
                {
                    Console.WriteLine("Knoten: " + current.m_Knoten + " Abstand: " + current.m_Abstand);
                    current = current.m_next;
                }
                Console.WriteLine("+");
            }
        }
    }
}//Graphs
