using DSandAlgorithms.Algorithms.Searching;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DSandAlgorithmsTests.Algorithms.Searching
{
    [TestClass]
    public class BinarySearchTest
    {
        [TestMethod]
        public void SearchTest()
        {
            int[] input = new int[] { 1, 5, 10, 25, 2000, 3550 };

            Assert.AreEqual(true, BinarySearch.Search(input, 2000));
            Assert.AreEqual(false, BinarySearch.Search(input, 35));
            Assert.AreEqual(true, BinarySearch.Search(input, 1));
        }
    }
}