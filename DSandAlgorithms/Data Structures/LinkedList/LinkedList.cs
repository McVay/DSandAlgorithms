using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithms.DataStructures.LinkedList
{
    public class LinkedList<T>
    {
        protected Node<T> _head { get; set; }
        protected Node<T> _tail { get; set; }
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

            if (_head == null)
            {
                _head = newHead;
                _tail = newHead;
            }
            else
            {
                Node<T> oldHead = _head;
                oldHead.Prev = newHead;
                newHead.Next = oldHead;
                _head = newHead;
            }

            IncrementCount();
        }

        public void Add(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                Add(value);
            }
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Prev = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }

            IncrementCount();
        }

        public void Insert(long index, T value)
        {
            if (index <= 0)
            {
                AddFirst(value);
            }
            else if (index >= Count)
            {
                Add(value);
            }
            else
            {
                Node<T> curr = _head;
                for (var i = 0; i < index; i++)
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
            if (_head == null) throw new InvalidOperationException("There is no head node defined!");

            return _head.Value;
        }

        public T PeekLast()
        {
            if (_tail == null) throw new InvalidOperationException("There is no tail node defined!");
            return _tail.Value;
        }

        public T PeekIndex(long index)
        {
            if (_head == null) throw new InvalidOperationException("There is no head node defined!");

            Node<T> curr = _head;

            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            for (var i = 0; i < Count && curr != null; i++)
            {
                if (i == index)
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

            Node<T> curr = _head;

            if (index == 0)
            {
                Node<T> newHead = curr.Next;
                if (newHead == null)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    newHead.Prev = null;
                    _head = newHead;
                }
            }

            curr = curr.Next;

            for (var i = 1; i < Count; i++)
            {
                if (i == index)
                {
                    Node<T> prevNode = curr.Prev;
                    prevNode.Next = curr.Next;
                    curr.Next.Prev = curr.Prev;
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
            if (_head == null && _tail == null) throw new InvalidOperationException("The linked list is empty.");

            _head = _head.Next;

            if (_head == null)
            {
                _tail = null;
            }

            DecrementCount();
        }

        public void RemoveLast()
        {
            if (_tail == null && _head == null) throw new InvalidOperationException("The linked list is empty.");

            _tail = _tail.Prev;

            if (_tail == null)
            {
                _head = null;
            }
            else
            {
                _tail.Next = null;
            }

            DecrementCount();
        }

        public void Remove(Node<T> node)
        {
            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                _head = node.Next;
            }

            if (_head == null)
            {
                _tail = null;
            }
        }

        public bool Contains(T value)
        {
            Node<T> curr = _head;

            while (curr != null)
            {
                if (EqualityComparer<T>.Default.Equals(curr.Value, value))
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
            foreach (var value in this.Enumerate())
            {
                sb.Append(separator);
                sb.Append(value.ToString());
                separator = " -> ";
            }

            return sb.ToString();
        }

        public string PrintAllNodesReversed()
        {
            StringBuilder sb = new StringBuilder();
            string separator = "";
            foreach (var value in this.EnumerateBackwards())
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
            Node<T> curr = _head;
            while (curr != null)
            {
                yield return curr.Value;
                curr = curr.Next;
            }
        }

        public IEnumerable<T> EnumerateBackwards()
        {
            Node<T> curr = _tail;
            while (curr != null)
            {
                yield return curr.Value;
                curr = curr.Prev;
            }
        }
    }
}