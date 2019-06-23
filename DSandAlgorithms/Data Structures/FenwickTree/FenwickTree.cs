using System;

namespace DSandAlgorithms.Data_Structures.FenwickTree
{
    public class FenwickTree
    {
        private long[] Tree { get; set; }

        // The constructor requires a 1-based array!
        public FenwickTree(long[] values)
        {
            if (values == null || values.Length == 0)
            {
                throw new ArgumentNullException("Values array cannot be empty!");
            }

            Tree = (long[])values.Clone();
            for (int i = 1; i < Tree.Length; i++)
            {
                int j = i + GetLSB(i);
                if (j < Tree.Length)
                {
                    Tree[j] += Tree[i];
                }
            }
        }

        private int GetLSB(int i)
        {
            // -i is the twos complement of i, so everything to the left of the first set bit is flipped.
            // This insures we only get the first set bit (LSB).
            return i & -i;
        }

        public long PrefixSum(int i)
        {
            if (i > Tree.Length || i < 0)
            {
                throw new IndexOutOfRangeException();
            }

            long sum = 0;
            while (i != 0)
            {
                sum += Tree[i];
                i &= ~GetLSB(i); // This clears the last set bit... alternatively you could do i -= GetLSB(i)
            }
            return sum;
        }

        public long Sum(int i, int j)
        {
            if (j > Tree.Length || i < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (j < i)
            {
                throw new ArgumentException("j must be >= i!");
            }

            return PrefixSum(j) - PrefixSum(i - 1);
        }

        public void Add(int i, long k)
        {
            while (i < Tree.Length)
            {
                Tree[i] += k;
                i += GetLSB(i);
            }
        }
    }
}