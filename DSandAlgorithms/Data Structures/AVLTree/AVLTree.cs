using DSandAlgorithms.Data_Structures.BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithms.Data_Structures.AVLTree
{
    public class AVLTree<T> where T: IComparable
    {
        private AVLTreeNode<T> root;
        private int nodeCount;

        private AVLTreeNode<T> RightRotate(AVLTreeNode<T> node)
        {
            var newParent = node.Left;
            node.Left = newParent.Right;
            newParent.Right = node;
            Update(node);
            Update(newParent);
            return newParent;
        }

        private AVLTreeNode<T> LeftRotate(AVLTreeNode<T> node)
        {
            var newParent = node.Right;
            node.Right = newParent.Left;
            newParent.Left = node;
            Update(node);
            Update(newParent);
            return newParent;
        }

        public int Height()
        {
            if (root == null) return 0;
            return root.Height;
        }

        public int Size()
        {
            return nodeCount;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public bool Contains(T value)
        {
            return Contains(root, value);
        }

        public bool Contains(AVLTreeNode<T> current, T target)
        {
            if (current == null)
            {
                return false;
            }

            int compare = target.CompareTo(current.Value);

            if(compare < 0)
            {
                return Contains(current.Left, target);
            }
            else if(compare > 0)
            {
                return Contains(current.Right, target);
            }
            else
            {
                return true;
            }
        }

        public bool Insert(T value)
        {
            if (value == null) return false;

            if(!Contains(value))
            {
                this.root = Insert(this.root, value);
                this.nodeCount++;
                return true;
            }
            return false;
        }

        public bool Remove(T value)
        {
            if (value == null) return false;
            if(Contains(value))
            {
                this.root = Remove(this.root, value);
                this.nodeCount--;
                return true;
            }
            return false;
        }

        private AVLTreeNode<T> Remove(AVLTreeNode<T> node, T value)
        {
            if (node == null) return null;

            int cmp = value.CompareTo(node.Value);

            if(cmp < 0)
            {
                node.Left = Remove(node.Left, value);
            }
            else if(cmp > 0)
            {
                node.Right = Remove(node.Right, value);
            }
            // Found the node to remove
            else
            {
                if(node.Left == null)
                {
                    return node.Right;
                }
                else if(node.Right == null)
                {
                    return node.Left;
                }
                else
                {
                    if(node.Left.Height > node.Right.Height)
                    {
                        T sucessorValue = FindMax(node.Left);
                        node.Value = sucessorValue;
                        node.Left = Remove(node.Left, sucessorValue);
                    }
                    else
                    {
                        T sucessorValue = FindMin(node.Right);
                        node.Value = sucessorValue;
                        node.Right = Remove(node.Right, sucessorValue);
                    }
                }
            }

            Update(node);
            return Balance(node);
        }

        private T FindMin(AVLTreeNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.Value;
        }

        private T FindMax(AVLTreeNode<T> node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node.Value;
        }

        private AVLTreeNode<T> Insert(AVLTreeNode<T> node, T value)
        {
            // Base case, we found where we want to insert the node!
            if (node == null) return new AVLTreeNode<T>(value);

            int cmp = value.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }

            Update(node);
            return Balance(node);
        }

        private AVLTreeNode<T> Balance(AVLTreeNode<T> node)
        {
            // Left Heavy Tree
            if (node.BalanceFactor == -2)
            {
                // Left-Left Case
                if(node.Left.BalanceFactor <= 0)
                {
                    return LeftLeftCase(node);
                }
                // Left-Right Case
                else
                {
                    return LeftRightCase(node);
                }
            }
            // Right Heavy Tree
            else if (node.BalanceFactor == 2)
            {
                // Left-Left Case
                if (node.Right.BalanceFactor >= 0)
                {
                    return RightRightCase(node);
                }
                // Left-Right Case
                else
                {
                    return RightLeftCase(node);
                }
            }
            else
            {
                return node;
            }
        }

        private AVLTreeNode<T> RightRightCase(AVLTreeNode<T> node)
        {
            return LeftRotate(node);
        }

        private AVLTreeNode<T> RightLeftCase(AVLTreeNode<T> node)
        {
            node.Right = RightRotate(node.Right);
            return LeftLeftCase(node);
        }

        private AVLTreeNode<T> LeftLeftCase(AVLTreeNode<T> node)
        {
            return RightRotate(node);
        }

        private AVLTreeNode<T> LeftRightCase(AVLTreeNode<T> node)
        {
            node.Left = LeftRotate(node.Left);
            return LeftLeftCase(node);
        }

        // Update a node's height and balance Factor
        private void Update(AVLTreeNode<T> node)
        {
            int leftNodeHeight = (node.Left == null) ? -1 : node.Left.Height;
            int rightNodeHeight = (node.Right == null) ? -1 : node.Right.Height;

            node.Height = 1 + Math.Max(leftNodeHeight, rightNodeHeight);
            node.BalanceFactor = rightNodeHeight - leftNodeHeight;
        }

        public bool ValidateBSTInvariant()
        {
            return ValidateBSTInvariant(this.root);
        }
        private bool ValidateBSTInvariant(AVLTreeNode<T> node)
        {
            if (node == null) return true;
            T val = node.Value;
            bool isValid = true;
            if (node.Left != null) isValid = isValid && node.Left.Value.CompareTo(val) < 0;
            if (node.Right != null) isValid = isValid && node.Right.Value.CompareTo(val) > 0;
            return isValid && ValidateBSTInvariant(node.Left) && ValidateBSTInvariant(node.Right);
        }
    }
}
