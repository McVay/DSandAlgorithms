using System;
using System.Collections.Generic;

namespace DSandAlgorithms.Data_Structures.BinaryTree
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public int Count = 0;
        private BinaryTreeNode<T> root;

        public void AddChild(T value)
        {
            root = AddNodeRecursively(root, value);
            IncrementCount();
        }

        private BinaryTreeNode<T> AddNodeRecursively(BinaryTreeNode<T> current, T value)
        {
            if (current == null)
            {
                return new BinaryTreeNode<T>(value);
            }

            int compare = value.CompareTo(current.Value);

            if (compare < 0)
            {
                current.Left = AddNodeRecursively(current.Left, value);
            }
            else if (compare > 0)
            {
                current.Right = AddNodeRecursively(current.Right, value);
            }
            else
            {
                return current;
            }

            return current;
        }

        public bool Remove(T value)
        {
            BinaryTreeNode<T> nodeToRemove = Find(value);

            // Value is not in BST
            if (nodeToRemove == null)
            {
                return false;
            }

            BinaryTreeNode<T> parent = FindParent(value);

            // Removing the only node in BST
            if (Count == 1)
            {
                root = null;
            }
            else if (nodeToRemove.Left == null && nodeToRemove.Right == null)
            {
                if (nodeToRemove.Value.CompareTo(parent.Value) < 0)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (nodeToRemove.Left == null && nodeToRemove.Right != null)
            {
                if (nodeToRemove.Value.CompareTo(parent.Value) < 0)
                {
                    parent.Left = nodeToRemove.Right;
                }
                else
                {
                    parent.Right = nodeToRemove.Right;
                }
            }
            else if (nodeToRemove.Left != null && nodeToRemove.Right == null)
            {
                if (nodeToRemove.Value.CompareTo(parent.Value) < 0)
                {
                    parent.Left = nodeToRemove.Left;
                }
                else
                {
                    parent.Right = nodeToRemove.Left;
                }
            }
            else
            {
                BinaryTreeNode<T> successor = nodeToRemove.Right;
                BinaryTreeNode<T> succesorParent = nodeToRemove;

                if (successor.Left == null)
                {
                    nodeToRemove.Value = successor.Value;
                    nodeToRemove.Right = successor.Right;
                    DecrementCount();
                    return true;
                }

                successor = FindMin(successor);
                succesorParent = FindParent(successor.Value);

                nodeToRemove.Value = successor.Value;
                succesorParent.Left = successor.Right;
            }
            DecrementCount();
            return true;
        }

        public BinaryTreeNode<T> Find(T value) => FindNodeRecursively(root, value);

        private BinaryTreeNode<T> FindNodeRecursively(BinaryTreeNode<T> current, T target)
        {
            if (current == null)
            {
                return null;
            }

            int compare = target.CompareTo(current.Value);

            if (compare < 0)
            {
                return FindNodeRecursively(current.Left, target);
            }
            else if (compare > 0)
            {
                return FindNodeRecursively(current.Right, target);
            }
            else
            {
                return current;
            }
        }

        public BinaryTreeNode<T> FindParent(T value)
        {
            int compare = value.CompareTo(root.Value);
            if (compare == 0)
            {
                return null;
            }
            else
            {
                return FindParentRecursively(root, value);
            }
        }

        private BinaryTreeNode<T> FindParentRecursively(BinaryTreeNode<T> current, T value)
        {
            int compare = value.CompareTo(current.Value);

            if (compare < 0)
            {
                if (root.Left == null)
                {
                    return null;
                }
                else if (value.CompareTo(current.Left.Value) == 0)
                {
                    return current;
                }
                else
                {
                    return FindParentRecursively(current.Left, value);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    return null;
                }
                else if (value.CompareTo(current.Right.Value) == 0)
                {
                    return current;
                }
                else
                {
                    return FindParentRecursively(current.Right, value);
                }
            }
        }

        public BinaryTreeNode<T> FindMin()
        {
            BinaryTreeNode<T> current = root;

            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }

        public BinaryTreeNode<T> FindMin(BinaryTreeNode<T> current)
        {
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }

        public BinaryTreeNode<T> FindMax()
        {
            BinaryTreeNode<T> current = root;

            while (current.Right != null)
            {
                current = current.Right;
            }
            return current;
        }

        public BinaryTreeNode<T> FindMax(BinaryTreeNode<T> current)
        {
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current;
        }

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
            if (current != null)
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

        private void IncrementCount() => Count++;

        private void DecrementCount() => Count--;
    }
}