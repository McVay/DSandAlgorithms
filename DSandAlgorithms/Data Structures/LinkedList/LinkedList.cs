using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithms.DataStructures.LinkedList
{ 
    public class LinkedList<T>
    {
       Node<T> Head { get; set; }
       public long Count { get; set; }

        public LinkedList(T value)
        {
            Add(value);
        }

        public LinkedList(IEnumerable<T> values)
        {
            Add(values);
        }

        public LinkedList()
        {

        }

        public void AddFirst(T value)
        {
            var newHead = new Node<T>(value);

            if (Head == null)
            {
                Head = newHead;
            }
            else
            {
                Node<T> oldHead = Head;
                oldHead.Prev = newHead;
                newHead.Next = oldHead;
                Head = newHead;
            }

            IncrementCount();
        }
        public void Add(IEnumerable<T> values)
        {
            foreach(var value in values)
            {
                Add(value);
            }
        }
        public void Add(T value)
        {
            var newNode = new Node<T>(value);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node<T> curr = Head;

                while (curr.Next != null)
                {
                    curr = curr.Next;
                }

                newNode.Prev = curr;
                curr.Next = newNode;
            }

            IncrementCount();            
        }
        public void Insert(long index, T value)
        {
            if(index <= 0)
            {
                AddFirst(value);
            }
            else if(index >= Count)
            {
                Add(value);
            }
            else
            {
                Node<T> curr = Head;
                for(var i = 0; i < index; i++)
                {
                    curr = curr.Next;
                }

                Node<T> newNode = new Node<T>(value);
                Node<T> prevNode = curr.Prev;

                prevNode.Next = newNode;
                newNode.Prev = prevNode;
                newNode.Next = curr;
                curr.Prev = newNode;
                
                IncrementCount();
            }
        }

        public T PeekFirst()
        {
            if (Head == null) throw new InvalidOperationException("There is no head node defined!");

            return Head.Value;
        }
        public T PeekLast()
        {
            if(Head == null) throw new InvalidOperationException("There is no head node defined!");

            Node<T> curr = Head;
            while(curr.Next != null)
            {
                curr = curr.Next;
            }
            return curr.Value;
        }
        public T PeekIndex(long index)
        {
            if (Head == null) throw new InvalidOperationException("There is no head node defined!");

            Node<T> curr = Head;

            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            for(var i = 0; i < Count && curr != null; i++)
            {
                if(i == index)
                {
                    return curr.Value;
                }

                curr = curr.Next;
            }

            throw new InvalidOperationException();
        }

        public void RemoveIndex(long index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            Node<T> curr = Head;

            if(index == 0)
            {
                Node<T> newHead = curr.Next;
                if(newHead == null)
                {
                    Head = null;
                }
                else
                {
                    newHead.Prev = null;
                    Head = newHead;
                }
            }

            curr = curr.Next;

            for (var i = 1; i < Count; i++)
            {
                if(i == index)
                {
                    Node<T> prevNode = curr.Prev;
                    prevNode.Next = curr.Next;
                }
                else
                {
                    curr = curr.Next;
                }
            }

            DecrementCount();
        }
        public void RemoveFirst()
        {
            if (Head == null) throw new InvalidOperationException("The linked list is empty.");

            Head = Head.Next;
            DecrementCount();
        }
        public void RemoveLast()
        {
            if (Head == null) throw new InvalidOperationException("The linked list is empty.");

            Node<T> curr = Head;


            while (curr.Next != null)
            {
                curr = curr.Next;
            }

            if(curr.Prev == null)
            {
                Head = null;
            }
            else
            {
                curr.Prev.Next = null;
            }

            DecrementCount();
        }

        public bool Contains(T value)
        {
            Node<T> curr = Head;

            while(curr != null)
            {
                if(EqualityComparer<T>.Default.Equals(curr.Value, value))
                {
                    return true;
                }
                curr = curr.Next;
            }
            return false;
        }

        public string PrintAllNodes()
        {
            StringBuilder sb = new StringBuilder();
            string separator = "";
            foreach(var value in this.Enumerate())
            {
                sb.Append(separator);
                sb.Append(value.ToString());
                separator = " -> ";
            }

            return sb.ToString();
        }

        private void IncrementCount() => Count++;
        private void DecrementCount() => Count--;

        public IEnumerable<T> Enumerate()
        {
            Node<T> curr = Head;
            while(curr != null)
            {
                yield return curr.Value;
                curr = curr.Next;
            }
        }

    }
}
