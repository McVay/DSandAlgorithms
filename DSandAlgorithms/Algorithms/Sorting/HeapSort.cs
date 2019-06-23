using System;

namespace DSandAlgorithms.Algorithms.Sorting
{
    public class HeapSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            int heapSize = array.Length;
            BuildHeap(array);
            for (int i = heapSize - 1; i >= 0; i--)
            {
                Swap(array, 0, i);
                heapSize--;
                MaxHeapify(array, heapSize, 0);
            }
        }

        private static void BuildHeap<T>(T[] array) where T : IComparable
        {
            int heapSize = array.Length;
            for (int i = heapSize / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(array, heapSize, i);
            }
        }

        private static void MaxHeapify<T>(T[] array, int heapSize, int i) where T : IComparable
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < heapSize && array[left].CompareTo(array[largest]) > 0)
            {
                largest = left;
            }

            if (right < heapSize && array[right].CompareTo(array[largest]) > 0)
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(array, i, largest);
                MaxHeapify(array, heapSize, largest);
            }
        }

        private static void Swap<T>(T[] array, int a, int b)
        {
            T temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}