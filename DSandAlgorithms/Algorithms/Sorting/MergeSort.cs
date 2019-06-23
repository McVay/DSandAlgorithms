using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSandAlgorithms.Algorithms.Sorting
{
    public class MergeSort 
    {
        public static void Sort<T>(ref T[] array) where T : IComparable
        {
            array = MergeSortCore(array);
        }


        public static T[] MergeSortCore<T>(T[] array) where T : IComparable
        {
            if (array.Length == 1)
            {
                return array;
            }

            T[] leftArray;
            T[] rightArray;

            SplitArrayInMiddle(array, out leftArray, out rightArray);

            return mergeArrays(MergeSortCore(leftArray), MergeSortCore(rightArray));
        }

        private static T[] mergeArrays<T>(T[] leftArray, T[] rightArray) where T : IComparable
        {
            T[] mergedArray = new T[leftArray.Length + rightArray.Length];
            int leftIdx = 0;
            int rightIdx = 0;
            int currIdx = 0;

            while (leftIdx < leftArray.Length && rightIdx < rightArray.Length)
            {
                var cmp = leftArray[leftIdx].CompareTo(rightArray[rightIdx]);
                if(cmp > 0)
                {
                    mergedArray[currIdx] = rightArray[rightIdx];
                    rightIdx++;
                }
                else
                {
                    mergedArray[currIdx] = leftArray[leftIdx];
                    leftIdx++;
                }
                currIdx++;
            }

            while (leftIdx < leftArray.Length)
            {
                mergedArray[currIdx] = leftArray[leftIdx];
                leftIdx++;
                currIdx++;
            }

            while (rightIdx < rightArray.Length)
            {
                mergedArray[currIdx] = rightArray[rightIdx];
                rightIdx++;
                currIdx++;
            }

            return mergedArray;

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
