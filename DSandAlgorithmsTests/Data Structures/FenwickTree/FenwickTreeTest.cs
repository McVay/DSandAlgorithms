using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DSandAlgorithmsTests.Data_Structures.FenwickTree
{
    [TestClass]
    public class FenwickTreeTest
    {
        [TestMethod]
        public void PrefixSumTest()
        {
            long[] inputList = new long[] { 0, 3, 4, -2, 7, 3, 11, 5, -8, -9, 2, 4, -8 };
            DSandAlgorithms.Data_Structures.FenwickTree.FenwickTree tree = new DSandAlgorithms.Data_Structures.FenwickTree.FenwickTree(inputList);

            Assert.ThrowsException<IndexOutOfRangeException>(() => tree.PrefixSum(20));
            Assert.ThrowsException<IndexOutOfRangeException>(() => tree.PrefixSum(-5));

            Assert.ThrowsException<ArgumentNullException>(() => new DSandAlgorithms.Data_Structures.FenwickTree.FenwickTree(new long[] { }));
            Assert.ThrowsException<ArgumentNullException>(() => new DSandAlgorithms.Data_Structures.FenwickTree.FenwickTree(null));

            Assert.AreEqual(12, tree.PrefixSum(4));
            Assert.AreEqual(12, tree.PrefixSum(12));
            Assert.AreEqual(7, tree.PrefixSum(2));
        }

        [TestMethod]
        public void SumTest()
        {
            long[] inputList = new long[] { 0, 3, 4, -2, 7, 3, 11, 5, -8, -9, 2, 4, -8 };
            DSandAlgorithms.Data_Structures.FenwickTree.FenwickTree tree = new DSandAlgorithms.Data_Structures.FenwickTree.FenwickTree(inputList);

            Assert.AreEqual(21, tree.Sum(4, 6));
            Assert.AreEqual(12, tree.Sum(1, 12));
            Assert.AreEqual(12, tree.Sum(1, 12));
            Assert.AreEqual(7, tree.Sum(3, 9));

            Assert.ThrowsException<IndexOutOfRangeException>(() => tree.Sum(1, 20));
            Assert.ThrowsException<IndexOutOfRangeException>(() => tree.Sum(-5, 4));

            Assert.ThrowsException<ArgumentException>(() => tree.Sum(9, 3));
            Assert.ThrowsException<ArgumentException>(() => tree.Sum(9, 3));
        }
    }
}