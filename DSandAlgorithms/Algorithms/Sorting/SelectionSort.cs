using System;

namespace DSandAlgorithms.Algorithms.Sorting
{
    public class SelectionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                int minIdx = i;
                T minValue = array[i];
                for (int j = i + 1; j < length; j++)
                {
                    int cmp = array[j].CompareTo(array[minIdx]);
                    if (cmp < 0)
                    {
                        minIdx = j;
                    }
                }
                array[i] = array[minIdx];
                array[minIdx] = minValue;
            }
        }
    }
}