using DSandAlgorithms.Data_Structures.LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DSandAlgorithmsTests.Data_Structures.LinkedList
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void AddTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            Assert.AreEqual(0, linkedList.Count);

            linkedList.Add(1);

            Assert.AreEqual(1, linkedList.Count);

            linkedList.Add(new System.Collections.Generic.List<int> { 2, 3, 4, 5 });

            Assert.AreEqual(5, linkedList.Count);
        }

        [TestMethod]
        public void AddFirstTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            Assert.AreEqual(linkedList.Count, 0);

            linkedList.AddFirst(1);
            Assert.AreEqual(1, linkedList.PeekFirst());
            Assert.AreEqual(1, linkedList.Count);

            linkedList.AddFirst(10);
            Assert.AreEqual(10, linkedList.PeekFirst());
            Assert.AreEqual(2, linkedList.Count);
            Assert.AreEqual(1, linkedList.PeekLast());
        }

        [TestMethod]
        public void InsertTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            Assert.AreEqual(linkedList.Count, 0);

            linkedList.Insert(-15, 1);
            Assert.AreEqual(1, linkedList.PeekFirst());
            Assert.AreEqual(1, linkedList.Count);

            linkedList.Insert(23, 5);
            Assert.AreEqual(5, linkedList.PeekLast());
            Assert.AreEqual(2, linkedList.Count);

            linkedList.Insert(2, 15);
            Assert.AreEqual(15, linkedList.PeekLast());
            Assert.AreEqual(3, linkedList.Count);

            linkedList.Insert(2, 69);
            Assert.AreEqual(15, linkedList.PeekLast());
            Assert.AreEqual(4, linkedList.Count);

            linkedList = new LinkedList<int>();
            linkedList.Add(new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            linkedList.Insert(7, 20);
            Assert.AreEqual(20, linkedList.PeekIndex(7));
            Assert.AreEqual(11, linkedList.Count);
        }

        [TestMethod]
        public void PeekFirstTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Assert.AreEqual(1, linkedList.PeekFirst());
        }

        [TestMethod]
        public void PeekLastTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Assert.AreEqual(10, linkedList.PeekLast());
        }

        [TestMethod]
        public void PeekIndexTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Assert.AreEqual(2, linkedList.PeekIndex(1));
            Assert.AreEqual(6, linkedList.PeekIndex(5));
            Assert.ThrowsException<IndexOutOfRangeException>(() => linkedList.PeekIndex(-34));
            Assert.ThrowsException<IndexOutOfRangeException>(() => linkedList.PeekIndex(23));
        }

        [TestMethod]
        public void RemoveFirstTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.Add(1);
            linkedList.RemoveFirst();
            Assert.AreEqual(0, linkedList.Count);
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.PeekFirst());

            Assert.ThrowsException<InvalidOperationException>(() => linkedList.RemoveFirst());

            linkedList.Add(new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Assert.AreEqual(1, linkedList.PeekFirst());
            Assert.AreEqual(10, linkedList.Count);
            linkedList.RemoveFirst();
            Assert.AreEqual(2, linkedList.PeekFirst());
            Assert.AreEqual(9, linkedList.Count);
        }

        [TestMethod]
        public void RemoveLastTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            Assert.ThrowsException<InvalidOperationException>(() => linkedList.RemoveLast());

            linkedList.Add(1);
            linkedList.RemoveLast();
            Assert.AreEqual(0, linkedList.Count);
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.PeekFirst());

            linkedList.Add(new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Assert.AreEqual(10, linkedList.PeekLast());
            Assert.AreEqual(10, linkedList.Count);
            linkedList.RemoveLast();
            Assert.AreEqual(9, linkedList.PeekLast());
            Assert.AreEqual(9, linkedList.Count);
        }

        [TestMethod]
        public void RemoveIndexTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.Add(1);
            linkedList.RemoveIndex(0);
            Assert.AreEqual(0, linkedList.Count);
            Assert.ThrowsException<InvalidOperationException>(() => linkedList.PeekFirst());

            linkedList.Add(new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            linkedList.RemoveIndex(0);
            Assert.AreEqual(2, linkedList.PeekFirst());
            Assert.AreEqual(9, linkedList.Count);
            linkedList.RemoveIndex(6);
            Assert.AreEqual(9, linkedList.PeekIndex(6));
            Assert.AreEqual(8, linkedList.Count);
        }

        [TestMethod]
        public void ContainsTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.Add(new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Assert.AreEqual(true, linkedList.Contains(10));
            Assert.AreEqual(true, linkedList.Contains(1));
            Assert.AreEqual(true, linkedList.Contains(5));
            Assert.AreEqual(false, linkedList.Contains(-10));
            Assert.AreEqual(false, linkedList.Contains(32));
        }

        [TestMethod]
        public void PrintAllNodesTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.Add(new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Assert.AreEqual("1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10", linkedList.PrintAllNodes());

            linkedList.RemoveIndex(5);

            Assert.AreEqual("1 -> 2 -> 3 -> 4 -> 5 -> 7 -> 8 -> 9 -> 10", linkedList.PrintAllNodes());

            linkedList.Add(23);

            Assert.AreEqual("1 -> 2 -> 3 -> 4 -> 5 -> 7 -> 8 -> 9 -> 10 -> 23", linkedList.PrintAllNodes());
        }

        [TestMethod]
        public void PrintAllNodesBackwardsTest()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.Add(new System.Collections.Generic.List<int> { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });

            Assert.AreEqual("1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 -> 10", linkedList.PrintAllNodesReversed());

            linkedList.RemoveIndex(5);

            Assert.AreEqual("1 -> 2 -> 3 -> 4 -> 6 -> 7 -> 8 -> 9 -> 10", linkedList.PrintAllNodesReversed());

            linkedList.Add(23);

            Assert.AreEqual("23 -> 1 -> 2 -> 3 -> 4 -> 6 -> 7 -> 8 -> 9 -> 10", linkedList.PrintAllNodesReversed());
        }
    }
}