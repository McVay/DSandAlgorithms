using DSandAlgorithms.Algorithms.Searching;
using DSandAlgorithms.Data_Structures.BinaryTree;
using DSandAlgorithms.Data_Structures.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DSandAlgorithmsTests.Algorithms.Searching
{
    [TestClass]
    public class BFSTest
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

            Assert.AreEqual(4, BFS.FindBinaryTreeNode(bst.root, 4).Value);
            Assert.AreEqual(null, BFS.FindBinaryTreeNode(bst.root, 24));
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

            Assert.AreEqual(node2, BFS.FindGraphNode(node1, "node2"));
            Assert.AreEqual(null, BFS.FindGraphNode(node1, "node3"));
        }
    }
}