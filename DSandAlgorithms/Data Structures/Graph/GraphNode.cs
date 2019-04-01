using DSandAlgorithms.DataStructures.LinkedList;

namespace DSandAlgorithms.Data_Structures.Graph
{
    public class GraphNode<T>
    {
        public T Value { get; }
        public LinkedList<GraphNode<T>> Neighbors { get; }
        public bool IsVisited { get; set; }

        public GraphNode(T value)
        {
            Value = value;
            Neighbors = new LinkedList<GraphNode<T>>();
        }

        public long NeighborCount => Neighbors.Count;

        public void AddEdge(GraphNode<T> graphNode)
        {
            Neighbors.Add(graphNode);
        }

        public void AddEdges(System.Collections.Generic.List<GraphNode<T>> graphNodes)
        {
            foreach (var node in graphNodes)
            {
                Neighbors.Add(node);
            }
        }

        public void RemoveEdge(GraphNode<T> graphNode)
        {
            Node<GraphNode<T>> node = Neighbors.FindNodeByValue(graphNode);
            Neighbors.Remove(node);
        }
    }
}