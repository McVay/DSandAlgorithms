using DSandAlgorithms.Data_Structures.Extensions;
using System;
using System.Collections.Generic;

namespace DSandAlgorithms.Data_Structures.Heap
{
    public class MinHeap<T> where T : IComparable
    {
        private List<T> _items = new List<T>();

        public int Count = 0;

        public void Add(List<T> values)
        {
            foreach (T val in values)
            {
                _items.Add(val);
                IncrementCount();
            }

            MinHeapify();
        }

        public void Add(T value)
        {
            _items.Add(value);
            IncrementCount();
            MinHeapify();
        }

        public bool Remove(T value)
        {
            int index = _items.IndexOf(value);

            if (index < 0)
            {
                return false;
            }

            _items[index] = _items[Count - 1];
            _items.RemoveAt(Count - 1);
            MinHeapify();
            DecrementCount();
            return true;
        }

        public bool Contains(T value)
        {
            int start = 0;
            int nodes = 1;

            while (start < _items.Count)
            {
                start = nodes - 1;
                int end = nodes + start;
                int count = _items.Count;

                while (start < count && start < end)
                {
                    if (value.CompareTo(_items[start]) == 0)
                    {
                        return true;
                    }
                    else if (value.CompareTo(_items[GetParentIndex(start)]) > 0 && value.CompareTo(_items[start]) < 0)
                    {
                        count++;
                    }
                    start++;
                }
                if (count == nodes)
                {
                    return false;
                }
                nodes = nodes + 2;
            }
            return false;
        }

        public T PopMin()
        {
            if (Count > 0)
            {
                T tmp = _items[0];
                Remove(tmp);
                return tmp;
            }

            return default(T);
        }

        public T PeekMin()
        {
            if (Count > 0)
            {
                return _items[0];
            }

            return default(T);
        }

        private void MinHeapify()
        {
            int i = _items.Count - 1;
            while (i > 0 && _items[i].CompareTo(_items[GetParentIndex(i)]) < 0)
            {
                _items.Swap(i, GetParentIndex(i));
                i = GetParentIndex(i);
            }
        }

        public T Get(int i) => _items[i];

        private void IncrementCount() => Count++;

        private void DecrementCount() => Count--;

        private int GetParentIndex(int index) => (index - 1) / 2;

        private int GetLeftIndex(int index) => 2 * index + 1;

        private int GetRightIndex(int index) => 2 * index + 2;
    }
}