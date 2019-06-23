using System;

namespace DSandAlgorithms.Algorithms.Sorting
{
    public class QuickSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            QuickSortCore(array, 0, array.Length - 1);
        }

        private static void QuickSortCore<T>(T[] array, int minIdx, int maxIdx) where T : IComparable
        {
            if (minIdx < maxIdx)
            {
                int pivotIdx = Partition(array, minIdx, maxIdx);
                QuickSortCore(array, minIdx, pivotIdx - 1);
                QuickSortCore(array, pivotIdx + 1, maxIdx);
            }
        }

        private static int Partition<T>(T[] array, int minIdx, int maxIdx) where T : IComparable
        {
            T pivotValue = array[maxIdx];
            int partitionIdx = minIdx;

            for (int i = minIdx; i < maxIdx; i++)
            {
                if (array[i].CompareTo(pivotValue) <= 0)
                {
                    Swap(array, partitionIdx, i);
                    partitionIdx++;
                }
            }

            Swap(array, partitionIdx, maxIdx);
            return partitionIdx;
        }

        private static void Swap<T>(T[] array, int a, int b)
        {
            T temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}