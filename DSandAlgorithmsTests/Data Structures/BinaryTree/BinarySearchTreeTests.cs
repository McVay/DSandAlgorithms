using DSandAlgorithms.Data_Structures.BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DSandAlgorithmsTests.Data_Structures.BinaryTree
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        /*
                 5
                / \
               3   6
              / \
             2   4
            /
           1
        */

        [TestMethod]
        public void AddTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            Assert.AreEqual(0, bst.Count);

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            Assert.AreEqual(true, bst.Contains(6));
            Assert.AreEqual(true, bst.Contains(3));
            Assert.AreEqual(false, bst.Contains(23));

            Assert.AreEqual(6, bst.Count);
        }

        [TestMethod]
        public void FindParentTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            Assert.AreEqual(0, bst.Count);

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            Assert.AreEqual(2, bst.FindParent(1).Value);
            Assert.AreEqual(3, bst.FindParent(4).Value);
            Assert.AreEqual(5, bst.FindParent(3).Value);
            Assert.AreEqual(5, bst.FindParent(6).Value);
            Assert.AreEqual(null, bst.FindParent(5));
        }

        [TestMethod]
        public void RemoveTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            Assert.AreEqual(0, bst.Count);

            bst.AddChild(1337);
            Assert.AreEqual(1, bst.Count);

            bst.Remove(1337);
            Assert.AreEqual(0, bst.Count);

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            Assert.AreEqual(2, bst.FindParent(1).Value);
            bst.Remove(2);
            Assert.AreEqual(3, bst.FindParent(1).Value);
            bst.Remove(4);
            Assert.AreEqual(null, bst.Find(3).Right);
            bst.Remove(5);
            Assert.AreEqual(6, bst.FindParent(3).Value);
            Assert.IsFalse(bst.Remove(100));
        }

        [TestMethod]
        public void FindTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            BinaryTreeNode<int> Node;

            Node = bst.Find(4);
            Assert.AreEqual(4, Node.Value);

            Node = bst.Find(23);
            Assert.AreEqual(null, Node);
        }

        [TestMethod]
        public void FindMaxTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            Assert.AreEqual(6, bst.FindMax().Value);
            bst.Remove(6);
            Assert.AreEqual(5, bst.FindMax().Value);
        }

        [TestMethod]
        public void FindMinTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            Assert.AreEqual(1, bst.FindMin().Value);
            bst.Remove(1);
            Assert.AreEqual(2, bst.FindMin().Value);
        }

        [TestMethod]
        public void PreOrderTraversalTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            string preOrder = String.Join(',', bst.PreOrderTraversal());
            Assert.AreEqual("5,3,2,1,4,6", preOrder);
        }

        [TestMethod]
        public void InOrderTraversalTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            string inOrder = String.Join(',', bst.InOrderTraversal());
            Assert.AreEqual("1,2,3,4,5,6", inOrder);
        }

        [TestMethod]
        public void OutOrderTraversalTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            string outOrder = String.Join(',', bst.OutOrderTraversal());
            Assert.AreEqual("6,5,4,3,2,1", outOrder);
        }

        [TestMethod]
        public void PostOrderTraversalTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            string postOrder = String.Join(',', bst.PostOrderTraversal());
            Assert.AreEqual("1,2,4,3,6,5", postOrder);
        }
    }
}