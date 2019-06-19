using DSandAlgorithms.Data_Structures.LinkedList;
using System;

namespace DSandAlgorithms.Data_Structures.Stack
{
    public class Stack<T>
    {
        private LinkedList<T> _linkedList { get; set; }

        public Stack(T value)
        {
            _linkedList = new LinkedList<T>(value);
        }

        public Stack(System.Collections.Generic.IEnumerable<T> values)
        {
            _linkedList = new LinkedList<T>();
            foreach (var value in values)
            {
                _linkedList.AddFirst(value);
            }
        }

        public Stack()
        {
            _linkedList = new LinkedList<T>();
        }

        public void Push(T value)
        {
            _linkedList.AddFirst(value);
        }

        public T Pop()
        {
            if (!IsEmpty)
            {
                var temp = Top;
                _linkedList.RemoveFirst();
                return temp;
            }

            throw new InvalidOperationException("The stack is empty!");
        }

        public T Top => _linkedList.PeekFirst();
        public long Count => _linkedList.Count;
        public bool IsEmpty => Count == 0;
    }
}