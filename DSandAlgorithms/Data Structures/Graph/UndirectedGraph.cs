using System;
using System.Collections.Generic;

namespace DSandAlgorithms.Data_Structures.Graph
{
    public class UndirectedGraph<T>
    {
        private List<GraphNode<T>> _nodes;
        public int Size => _nodes.Count;

        public UndirectedGraph(List<GraphNode<T>> initialNodes = null)
        {
            _nodes = initialNodes ?? new List<GraphNode<T>>();
        }

        public void AddNode(GraphNode<T> node)
        {
            if (!_nodes.Contains(node))
            {
                _nodes.Add(node);
            }
        }

        public bool Contains(T value)
        {
            foreach (var node in _nodes)
            {
                if (EqualityComparer<T>.Default.Equals(node.Value, value))
                {
                    return true;
                }
            }
            return false;
        }

        public GraphNode<T> GetGraphNode(T value)
        {
            foreach (var node in _nodes)
            {
                if (EqualityComparer<T>.Default.Equals(node.Value, value))
                {
                    return node;
                }
            }
            throw new InvalidOperationException("The node you are looking for doesn't exsist!");
        }

        public bool IsValidEdge(GraphNode<T> first, GraphNode<T> second)
        {
            if (first == null || second == null)
            {
                throw new InvalidOperationException("One of graph nodes is null!");
            }

            if (first == second)
            {
                throw new InvalidOperationException("The two nodes cannot be the same!");
            }

            return first.Neighbors.Contains(second) && second.Neighbors.Contains(first);
        }

        public void AddPair(GraphNode<T> first, GraphNode<T> second)
        {
            if (first == null || second == null)
            {
                throw new InvalidOperationException("One of graph nodes is null!");
            }

            if (first == second)
            {
                throw new InvalidOperationException("The two nodes cannot be the same!");
            }

            AddNode(first);
            AddNode(second);
            AddNeighbors(first, second);
        }

        private void AddNeighbors(GraphNode<T> first, GraphNode<T> second)
        {
            AddNeighbor(first, second);
            AddNeighbor(second, first);
        }

        private void AddNeighbor(GraphNode<T> first, GraphNode<T> second)
        {
            if (!first.Neighbors.Contains(second))
            {
                first.AddEdge(second);
            }
        }

        private void UnvisitAll()
        {
            foreach (var node in _nodes)
            {
                node.IsVisited = false;
            }
        }
    }
}