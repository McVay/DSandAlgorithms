using System;

namespace DSandAlgorithms.Algorithms.Sorting
{
    public class InsertionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                T val = array[i];
                int flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val.CompareTo(array[j]) < 0)
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = val;
                    }
                    else
                    {
                        flag = 1;
                    }
                }
            }
        }
    }
}