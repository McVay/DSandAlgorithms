using DSandAlgorithms.Data_Structures.Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DSandAlgorithmsTests.DataStructures.Heap
{
    [TestClass]
    public class HeapTest
    {
        [TestMethod]
        public void AddTest()
        {
            MinHeap<int> heap = new MinHeap<int>();

            Assert.AreEqual(0, heap.Count);
            heap.Add(5);
            Assert.AreEqual(1, heap.Count);
            Assert.AreEqual(5, heap.PeekMin());
            heap.Add(10);
            Assert.AreEqual(5, heap.PeekMin());
            Assert.AreEqual(10, heap.Get(1));
            heap.Add(2);
            Assert.AreEqual(2, heap.PeekMin());
        }

        [TestMethod]
        public void RemoveTest()
        {
            MinHeap<int> heap = new MinHeap<int>();
            heap.Add(new List<int> { 2, 5, 10 });

            Assert.IsTrue(heap.Remove(2));
            Assert.AreEqual(5, heap.PeekMin());

            Assert.IsTrue(heap.Remove(5));
            Assert.AreEqual(10, heap.PeekMin());

            Assert.IsFalse(heap.Remove(20));
            Assert.IsTrue(heap.Remove(10));
            Assert.AreEqual(0, heap.Count);
        }

        [TestMethod]
        public void PopTest()
        {
            MinHeap<int> heap = new MinHeap<int>();
            heap.Add(new List<int> { 2, 5, 10 });

            Assert.AreEqual(2, heap.PopMin());
            Assert.AreEqual(5, heap.PopMin());
            Assert.AreEqual(10, heap.PopMin());
            Assert.AreEqual(default(int), heap.PopMin());
        }
    }
}