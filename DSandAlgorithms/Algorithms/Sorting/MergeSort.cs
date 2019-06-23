using System;
using System.Linq;

namespace DSandAlgorithms.Algorithms.Sorting
{
    public class MergeSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            MergeSortCore(array);
        }

        private static T[] MergeSortCore<T>(T[] array) where T : IComparable
        {
            if (array.Length == 1)
            {
                return array;
            }

            SplitArrayInMiddle(array, out T[] leftArray, out T[] rightArray);

            return MergeArrays(MergeSortCore(leftArray), MergeSortCore(rightArray), array);
        }

        private static T[] MergeArrays<T>(T[] leftArray, T[] rightArray, T[] array) where T : IComparable
        {
            int leftIdx = 0;
            int rightIdx = 0;
            int currIdx = 0;

            while (leftIdx < leftArray.Length && rightIdx < rightArray.Length)
            {
                int cmp = leftArray[leftIdx].CompareTo(rightArray[rightIdx]);
                if (cmp > 0)
                {
                    array[currIdx] = rightArray[rightIdx];
                    rightIdx++;
                }
                else
                {
                    array[currIdx] = leftArray[leftIdx];
                    leftIdx++;
                }
                currIdx++;
            }

            while (leftIdx < leftArray.Length)
            {
                array[currIdx] = leftArray[leftIdx];
                leftIdx++;
                currIdx++;
            }

            while (rightIdx < rightArray.Length)
            {
                array[currIdx] = rightArray[rightIdx];
                rightIdx++;
                currIdx++;
            }

            return array;
        }

        private static void SplitArrayInMiddle<T>(T[] array, out T[] left, out T[] right) where T : IComparable
        {
            Split(array, array.Length / 2, out left, out right);
        }

        private static void Split<T>(T[] array, int index, out T[] left, out T[] right) where T : IComparable
        {
            left = array.Take(index).ToArray();
            right = array.Skip(index).ToArray();
        }
    }
}