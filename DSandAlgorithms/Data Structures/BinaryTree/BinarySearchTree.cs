using System;
using System.Collections.Generic;

namespace DSandAlgorithms.DataStructures.BinaryTree
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private BinaryTreeNode<T> root;

        private BinaryTreeNode<T> AddNodeRecursively(BinaryTreeNode<T> current, T value)
        {
            if (current == null)
            {
                return new BinaryTreeNode<T>(value);
            }

            int compare = value.CompareTo(current.Value);

            if(compare < 0)
            {
                current.Left = AddNodeRecursively(current.Left, value);
            }
            else if(compare > 0)
            {
                current.Right = AddNodeRecursively(current.Right, value);
            }
            else
            {
                return current;
            }

            return current;
        }

        public void AddChild(T value) => root = AddNodeRecursively(root, value);

        private BinaryTreeNode<T> FindNodeRecursively(BinaryTreeNode<T> current, T target)
        {
            if (current == null)
            {
                return null;
            }

            int compare = target.CompareTo(current.Value);

            if (compare == 0)
            {
                return current;
            } 
            else
            {
                if (compare < 0)
                {
                    return FindNodeRecursively(current.Left, target);
                }
                else
                {
                    return FindNodeRecursively(current.Right, target);
                }
            }
        }

        public BinaryTreeNode<T> Find(T value) => FindNodeRecursively(root, value);

        private void PreOrderTraversalRecursive(BinaryTreeNode<T> current, List<T> preOrderList)
        {
            if (current != null)
            {
                preOrderList.Add(current.Value);
                PreOrderTraversalRecursive(current.Left, preOrderList);
                PreOrderTraversalRecursive(current.Right, preOrderList);
            }
        }

        public List<T> PreOrderTraversal()
        {
            List<T> preOrderList = new List<T>();
            PreOrderTraversalRecursive(root, preOrderList);

            return preOrderList;
        }

        private void InOrderTraversalRecursive(BinaryTreeNode<T> current, List<T> inOrderList)
        {
            if(current != null)
            {
                InOrderTraversalRecursive(current.Left, inOrderList);
                inOrderList.Add(current.Value);
                InOrderTraversalRecursive(current.Right, inOrderList);
            }
        }

        public List<T> InOrderTraversal()
        {
            List<T> inOrderList = new List<T>();
            InOrderTraversalRecursive(root, inOrderList);

            return inOrderList;
        }

        private void OutOrderTraversalRecursive(BinaryTreeNode<T> current, List<T> outOrderList)
        {
            if (current != null)
            {
                OutOrderTraversalRecursive(current.Right, outOrderList);
                outOrderList.Add(current.Value);
                OutOrderTraversalRecursive(current.Left, outOrderList);
            }
        }

        public List<T> OutOrderTraversal()
        {
            List<T> outOrderList = new List<T>();
            OutOrderTraversalRecursive(root, outOrderList);

            return outOrderList;
        }

        private void PostOrderTraversalRecursive(BinaryTreeNode<T> current, List<T> postOrderList)
        {
            if (current != null)
            {
                PostOrderTraversalRecursive(current.Left, postOrderList);
                PostOrderTraversalRecursive(current.Right, postOrderList);
                postOrderList.Add(current.Value);
            }
        }

        public List<T> PostOrderTraversal()
        {
            List<T> postOrderList = new List<T>();
            PostOrderTraversalRecursive(root, postOrderList);

            return postOrderList;
        }

        public bool Contains(T value) => Find(value) != null;

        public int Count => InOrderTraversal().Count;
    }
}
