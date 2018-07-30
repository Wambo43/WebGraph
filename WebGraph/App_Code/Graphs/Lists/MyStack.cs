
namespace Graphs.Lists
{
    class MyStack<T>  
        where T : new()
    {
        public class Node
        {
            private Node next;
            private Node prev;
            private T data;
            public Node(T _t)
            {
                next = null;
                prev = null;
                data = _t;
            }
            public Node Prev
            {
                get { return prev; }
                set { prev = value; }
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            } 
            public T Data {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        public bool NotEmpty()
        {
            if (head != null)
                return true;
            return false;
        }

        private bool NotEmpty(T _t)
        {
            if (head != null)
                return true;
            else
            {
                head = new Node(_t);
                return false;
            }
        }

        public void AddFirst(T _t)
        {
            if (_t != null)
            {
                if (NotEmpty(_t))
                {
                    Node insert = new Node(_t);
                    insert.Next = head;
                    head = insert;
                }
            }
        }

        public void AddLast(T _t)
        {
            if (_t != null)
            {
                if (NotEmpty(_t))
                {
                    Node tmp = head;
                    while (tmp.Next != null)
                    {
                        tmp = tmp.Next;
                    }
                    tmp.Next = new Node(_t);
                }
                
            }
        }
        public T GetFirstNode()
        {
            return head.Data;
        }

        public void deliteFirst()
        {
            if (NotEmpty())
            {
                head = head.Next;
            }
        }
    }
}