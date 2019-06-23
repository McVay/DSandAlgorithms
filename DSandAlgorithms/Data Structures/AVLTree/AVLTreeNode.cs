namespace DSandAlgorithms.Data_Structures.AVLTree
{
    public class AVLTreeNode<T>
    {
        internal int BalanceFactor { get; set; }
        public T Value { get; set; }
        internal int Height { get; set; }
        public AVLTreeNode<T> Left { get; set; }
        public AVLTreeNode<T> Right { get; set; }

        public AVLTreeNode(T value)
        {
            Value = value;
        }
    }
}