using DSandAlgorithms.Data_Structures.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSandAlgorithmsTests.Data_Structures.Graph
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void AddTest()
        {
            UndirectedGraph<string> graph = new UndirectedGraph<string>();

            graph.AddNode(new GraphNode<string>("node1"));
            graph.AddNode(new GraphNode<string>("node2"));
            graph.AddNode(new GraphNode<string>("node3"));
            graph.AddNode(new GraphNode<string>("node4"));
            graph.AddNode(new GraphNode<string>("node5"));

            Assert.IsTrue(graph.Contains("node4"));
            Assert.AreEqual(5, graph.Size);
            Assert.IsFalse(graph.Contains("dylan"));
        }

        [TestMethod]
        public void AddEdgeTest()
        {
            UndirectedGraph<string> graph = new UndirectedGraph<string>();

            GraphNode<string> node1 = new GraphNode<string>("node1");
            GraphNode<string> node2 = new GraphNode<string>("node2");
            GraphNode<string> node3 = new GraphNode<string>("node3");
            GraphNode<string> node4 = new GraphNode<string>("node4");
            GraphNode<string> node5 = new GraphNode<string>("node5");

            graph.AddPair(node1, node4);
            graph.AddPair(node4, node5);

            Assert.AreEqual(1, node1.NeighborCount);
            Assert.AreEqual(2, node4.NeighborCount);
            Assert.IsTrue(node4.Neighbors.Contains(node5));
        }

        [TestMethod]
        public void ValidEdgeTest()
        {
            UndirectedGraph<string> graph = new UndirectedGraph<string>();

            GraphNode<string> node1 = new GraphNode<string>("node1");
            GraphNode<string> node2 = new GraphNode<string>("node2");
            GraphNode<string> node3 = new GraphNode<string>("node3");
            GraphNode<string> node4 = new GraphNode<string>("node4");
            GraphNode<string> node5 = new GraphNode<string>("node5");

            graph.AddPair(node1, node4);

            Assert.IsTrue(graph.IsValidEdge(node1, node4));
            Assert.IsTrue(graph.IsValidEdge(node4, node1));
            Assert.IsFalse(graph.IsValidEdge(node1, node5));
        }
    }
}