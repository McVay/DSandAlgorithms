using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithms.Algorithms.Searching
{
    public class BinarySearch
    {
        public static bool Search<T>(T[] array, T target) where T : IComparable
        {
            return SearchCore(array, target, 0, array.Length - 1);
        }

        private static bool SearchCore<T>(T[] array, T target, int left, int right) where T : IComparable
        {

            if(left > right)
            {
                return false;
            }

            int midPoint = left + ((right - left) / 2);
            int cmp = array[midPoint].CompareTo(target);

            if(cmp == 0)
            {
                return true;
            }

            if(cmp > 0)
            {
                return SearchCore(array, target, left, midPoint - 1);
            }
            else
            {
                return SearchCore(array, target, midPoint + 1, right);
            }
        }
    }
}
