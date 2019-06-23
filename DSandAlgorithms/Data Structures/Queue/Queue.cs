using DSandAlgorithms.Data_Structures.Stack;
using System;

namespace DSandAlgorithms.Data_Structures.Queue
{
    public class Queue<T>
    {
        private Stack<T> mainStack { get; set; }
        private Stack<T> stagingStack { get; set; }

        public Queue()
        {
            mainStack = new Stack<T>();
            stagingStack = new Stack<T>();
        }

        public Queue(T value)
        {
            mainStack = new Stack<T>(value);
            stagingStack = new Stack<T>();
        }

        public Queue(System.Collections.Generic.List<T> values)
        {
            mainStack = new Stack<T>();
            stagingStack = new Stack<T>();

            foreach (T value in values)
            {
                Enqueue(value);
            }
        }

        public void Enqueue(T value)
        {
            while (!mainStack.IsEmpty)
            {
                stagingStack.Push(mainStack.Pop());
            }

            mainStack.Push(value);

            while (!stagingStack.IsEmpty)
            {
                mainStack.Push(stagingStack.Pop());
            }
        }

        public T Dequeue()
        {
            if (mainStack.IsEmpty)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            return mainStack.Pop();
        }

        public bool IsEmpty => Count == 0;
        public long Count => mainStack.Count;
        public T Front => mainStack.Top;
    }
}