using DSandAlgorithms.DataStructures.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DSandAlgorithmsTests.DataStructures.Queue
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void EnqueuAndDequeTest()
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Count);

            Assert.AreEqual(1, queue.Front);
            queue.Dequeue();

            Assert.AreEqual(2, queue.Front);

            queue.Dequeue();
            Assert.AreEqual(3, queue.Front);

            queue.Dequeue();
            Assert.AreEqual(0, queue.Count);

            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestMethod]
        public void QueueConstructorTest()
        {
            Queue<int> queue = new Queue<int>(1);

            queue.Enqueue(2);
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Count);


            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);

            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());

            queue = new Queue<int>(new System.Collections.Generic.List<int> { 1, 2, 3 });
            Assert.AreEqual(3, queue.Count);

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Queue<int> Queue = new Queue<int>();

            Assert.AreEqual(Queue.IsEmpty, true);

            Queue.Enqueue(1);
            Assert.AreEqual(Queue.IsEmpty, false);

            Queue.Dequeue();
            Assert.AreEqual(Queue.IsEmpty, true);
        }
    }
}
