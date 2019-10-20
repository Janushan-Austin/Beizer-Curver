using System.Collections;
using System.Collections.Generic;

public class List<Type>
{
    private class Node
    {
        public Type Data = default(Type);
        public Node Next = null;

        public Node(Type value = default(Type), Node next_ = null)
        {
            Data = value;
            Next = next_;
        }
    }

    Node Head, Tail;
    int Length;


    public List(List<Type> copy = null)
    {
        Length = 0;
        Head = null;
        Tail = null;

        CopyList(copy);
    }

    public void CopyList(List<Type> copy)
    {
        if (Head != null)
        {
            DestroyList();
        }

        if (copy != null && copy.Head != null)
        {
            Node currentCopy = copy.Head;
            Head = new Node(currentCopy.Data, null);
            Tail = Head;
            Node previousThis = Head;
            currentCopy = currentCopy.Next;

            for (this.Length = 1; this.Length < copy.Length; Length++)
            {
                Tail = new Node(currentCopy.Data, null);
                previousThis.Next = Tail;
                previousThis = Tail;

                currentCopy = currentCopy.Next;

                Length++;
            }
        }
    }


    public void Add(Type value)
    {
        Node temp = new Node(value, Head);
        Length++;
        Head = temp;
    }

    public void AddBack(Type value)
    {
        if (Tail == null)
        {
            Head = new Node(value);
            Tail = Head;
        }
        else
        {
            Node temp = new Node(value, null);
            Tail.Next = temp;
            Tail = temp;
        }
        Length++;
    }

    public bool Remove(Type value)
    {
        bool found = false;
        Node current = Head;
        Node previous = null;

        while (current != null && !found)
        {
            if (current.Data.Equals(value))
            {
                Length--;
                found = true;

                if (previous != null)
                {
                    previous.Next = current.Next;
                }
                else
                {
                    Head = Head.Next;
                }
            }
            else
            {
                previous = current;
                current = current.Next;
            }
        }

        return found;
    }

    public bool Remove(Type value, ref Type output)
    {
        bool found = false;
        Node current = Head;
        Node previous = null;

        while (current != null && !found)
        {
            if (current.Data.Equals(value))
            {
                Length--;
                found = true;
                output = current.Data;

                if (previous != null)
                {
                    previous.Next = current.Next;
                }
                else
                {
                    Head = Head.Next;
                }
            }
            else
            {
                previous = current;
                current = current.Next;
            }
        }

        return found;
    }

    public void DestroyList()
    {
        Head = null;
        Tail = null;
        Length = 0;
    }

    public bool Find(Type value)
    {
        Node current = Head;
        bool found = false;

        while(current != null && !found)
        {
            if (current.Data.Equals(value))
            {
                found = true;
                break;
            }
            current = current.Next;
        }

        return found;
    }

    public void PrintList()
    {
        Node temp = Head;
        for (int i = 0; i < Length; i++)
        {
            temp = temp.Next;
        }
    }


    //public void RemoveFront()
    //{
    //    if (Head != null)
    //    {
    //        Node temp = Head;
    //        Head = Head.Next;
    //        Length--;
    //    }
    //}

    public Type RemoveFront()
    {
        Node temp = new Node();
        if (Head != null)
        {
            temp = Head;
            Head = Head.Next;
            Length--;
        }
        if(Head == null)
        {
            Tail = null;
        }

        return temp.Data;
    }


    public bool RemoveFront(ref Type output)
    {
        bool removed = false;

        if (output == null)
        {
            output = default(Type);
        }
        if (Head != null)
        {
            removed = true;
            Node temp = Head;
            output = Head.Data;
            Head = Head.Next;
            Length--;
        }
        if (Head == null)
        {
            Tail = null;
        }
        return removed;
    }

    public Type Index(int index)
    {
        Node temp = Head;
        if (temp == null || index < 0 || index > Length)
        {
            return default(Type);
        }

        for(int i=0; i<index; i++)
        {
            temp = temp.Next;
        }

        return temp.Data;
    }

    public int GetLength()
    {
        return Length;
    }


    public int CountChildren()
    {
        int count = 0;
        Node temp = Head;

        while(temp != null)
        {
            count++;
            temp = temp.Next;
        }

        return count;
    }

    public bool IsEmpty()
    {
        return Head == null;
    }
}
