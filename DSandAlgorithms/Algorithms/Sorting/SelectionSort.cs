using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithms.Algorithms.Sorting
{
    public class SelectionSort
    {
        public static void Sort<T>(T[] array) where T: IComparable
        {
            int length = array.Length;
            for(int i = 0; i < length; i++)
            {
                var minIdx = i;
                var minValue = array[i];
                for(int j = i + 1; j < length; j++)
                {
                    
                    var cmp = array[j].CompareTo(array[minIdx]);
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
