using DSandAlgorithms.Data_Structures.BinaryTree;
using DSandAlgorithms.Data_Structures.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithms.Algorithms.Searching
{
    public class BFS
    {
        public static BinaryTreeNode<T> FindBinaryTreeNode<T>(BinaryTreeNode<T> root, T value) where T : IComparable
        {
            BinaryTreeNode<T> currNode = root;
            var queue = new Queue<BinaryTreeNode<T>>();

            queue.Enqueue(currNode);

            while (queue.Count > 0)
            {
                currNode = queue.Dequeue();

                if (EqualityComparer<T>.Default.Equals(value, currNode.Value))
                {
                    return currNode;
                }

                if (currNode.Left != null)
                {
                    queue.Enqueue(currNode.Left);
                }

                if (currNode.Right != null)
                {
                    queue.Enqueue(currNode.Right);
                }
            }

            return null;
        }

        public static GraphNode<T> FindGraphNode<T>(GraphNode<T> root, T value) where T : IComparable
        {
            GraphNode<T> currNode = root;
            var queue = new Queue<GraphNode<T>>();

            queue.Enqueue(currNode);

            while (queue.Count > 0)
            {
                currNode = queue.Dequeue();

                if (EqualityComparer<T>.Default.Equals(value, currNode.Value))
                {
                    return currNode;
                }
                else
                {
                    currNode.IsVisited = true;
                }

                foreach (var child in currNode.Neighbors.Enumerate())
                {
                    if (!child.IsVisited)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
            return null;
        }
    }
}