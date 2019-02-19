using DSandAlgorithms.DataStructures.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace DSandAlgorithmsTests.DataStructures.Stack
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void PushTest()
        {
            Stack<int> stack = new Stack<int>();

            Assert.ThrowsException<InvalidOperationException>(() => stack.Top);

            stack.Push(1);
            Assert.AreEqual(1, stack.Top);

            stack.Push(2);
            Assert.AreEqual(2, stack.Top);

            stack.Push(3);
            Assert.AreEqual(3, stack.Top);
        }

        [TestMethod]
        public void PopTest()
        {
            Stack<int> stack = new Stack<int>();

            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());

            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Stack<int> stack = new Stack<int>();

            Assert.AreEqual(stack.IsEmpty, true);

            stack.Push(1);
            Assert.AreEqual(stack.IsEmpty, false);

            stack.Pop();
            Assert.AreEqual(stack.IsEmpty, true);
        }
    }
}
