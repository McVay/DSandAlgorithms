using DSandAlgorithms.Algorithms.Searching;
using DSandAlgorithms.Data_Structures.BinaryTree;
using DSandAlgorithms.Data_Structures.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithmsTests.Algorithms.Searching
{
    [TestClass]
    public class DFSTest
    {
        [TestMethod]
        public void BinarySearchTest()
        {
            /*
                  5
                 / \
                3   6
               /  \
              2   4
             /
            1
                        */

            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.AddChild(5);
            bst.AddChild(3);
            bst.AddChild(2);
            bst.AddChild(6);
            bst.AddChild(1);
            bst.AddChild(4);

            Assert.AreEqual(4, DFS.FindBinaryTreeNode(bst.root, 4).Value);
            Assert.AreEqual(null, DFS.FindBinaryTreeNode(bst.root, 24));
        }

        [TestMethod]
        public void GraphSearchTest()
        {
            UndirectedGraph<string> graph = new UndirectedGraph<string>();

            GraphNode<string> node1 = new GraphNode<string>("node1");
            GraphNode<string> node2 = new GraphNode<string>("node2");
            GraphNode<string> node3 = new GraphNode<string>("node3");
            GraphNode<string> node4 = new GraphNode<string>("node4");
            GraphNode<string> node5 = new GraphNode<string>("node5");

            graph.AddPair(node1, node4);
            graph.AddPair(node4, node5);
            graph.AddPair(node5, node2);

            Assert.AreEqual(node2, DFS.FindGraphNode(node1, "node2"));
            Assert.AreEqual(null, DFS.FindGraphNode(node1, "node3"));
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

            string preOrder = String.Join(',', DFS.PreOrder(bst.root));
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

            string inOrder = String.Join(',', DFS.InOrder(bst.root));
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

            string outOrder = String.Join(',', DFS.OutOrder(bst.root));
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

            string postOrder = String.Join(',', DFS.PostOrder(bst.root));
            Assert.AreEqual("1,2,4,3,6,5", postOrder);
        }
    }
}