using DSandAlgorithms.Algorithms.Searching;
using DSandAlgorithms.Data_Structures.BinaryTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithms.Algorithms
{
    public class ValidateBST
    {
        public static bool IsValid<T>(BinarySearchTree<T> bst) where T : IComparable
        {
            var inOrder = DFS.InOrder(bst.root);

            for (int i = 0; i < inOrder.Count - 1; i++)
            {
                if (inOrder[i].CompareTo(inOrder[i + 1]) > 0) return false;
            }
            return true;
        }
    }
}