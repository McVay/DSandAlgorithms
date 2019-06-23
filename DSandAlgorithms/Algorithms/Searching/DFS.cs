using DSandAlgorithms.Data_Structures.BinaryTree;
using DSandAlgorithms.Data_Structures.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithms.Algorithms.Searching
{
    public class DFS
    {
        public static BinaryTreeNode<T> FindBinaryTreeNode<T>(BinaryTreeNode<T> root, T value) where T : IComparable
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                BinaryTreeNode<T> node = stack.Pop();

                if (EqualityComparer<T>.Default.Equals(node.Value, value))
                {
                    return node;
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
            }
            return null;
        }

        public static GraphNode<T> FindGraphNode<T>(GraphNode<T> root, T value) where T : IComparable
        {
            Stack<GraphNode<T>> stack = new Stack<GraphNode<T>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                GraphNode<T> node = stack.Pop();

                if (EqualityComparer<T>.Default.Equals(node.Value, value))
                {
                    return node;
                }

                node.IsVisited = true;

                foreach (var child in node.Neighbors.Enumerate())
                {
                    if (!child.IsVisited)
                    {
                        stack.Push(child);
                    }
                }
            }
            return null;
        }

        public static List<T> InOrder<T>(BinaryTreeNode<T> root) where T : IComparable
        {
            return TraverseInOrder(root, new List<T> { });
        }

        private static List<T> TraverseInOrder<T>(BinaryTreeNode<T> node, List<T> data) where T : IComparable
        {
            if (node.Left != null)
            {
                TraverseInOrder(node.Left, data);
            }

            data.Add(node.Value);

            if (node.Right != null)
            {
                TraverseInOrder(node.Right, data);
            }

            return data;
        }

        public static List<T> OutOrder<T>(BinaryTreeNode<T> root) where T : IComparable
        {
            return TraverseOutOrder(root, new List<T> { });
        }

        private static List<T> TraverseOutOrder<T>(BinaryTreeNode<T> node, List<T> data) where T : IComparable
        {
            if (node.Right != null)
            {
                TraverseOutOrder(node.Right, data);
            }

            data.Add(node.Value);

            if (node.Left != null)
            {
                TraverseOutOrder(node.Left, data);
            }

            return data;
        }

        public static List<T> PostOrder<T>(BinaryTreeNode<T> root) where T : IComparable
        {
            return TraversePostOrder(root, new List<T> { });
        }

        private static List<T> TraversePostOrder<T>(BinaryTreeNode<T> node, List<T> data) where T : IComparable
        {
            if (node.Left != null)
            {
                TraversePostOrder(node.Left, data);
            }

            if (node.Right != null)
            {
                TraversePostOrder(node.Right, data);
            }

            data.Add(node.Value);

            return data;
        }

        public static List<T> PreOrder<T>(BinaryTreeNode<T> root) where T : IComparable
        {
            return TraversePreOrder(root, new List<T> { });
        }

        private static List<T> TraversePreOrder<T>(BinaryTreeNode<T> node, List<T> data) where T : IComparable
        {
            data.Add(node.Value);

            if (node.Left != null)
            {
                TraversePreOrder(node.Left, data);
            }

            if (node.Right != null)
            {
                TraversePreOrder(node.Right, data);
            }

            return data;
        }
    }
}