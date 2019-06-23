using System;

namespace DSandAlgorithms.Algorithms.Sorting
{
    public class BubbleSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    int cmp = array[j].CompareTo(array[j + 1]);
                    if (cmp > 0)
                    {
                        T tmp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = tmp;
                    }
                }
            }
        }
    }
}