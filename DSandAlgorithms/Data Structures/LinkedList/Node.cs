namespace DSandAlgorithms.Data_Structures.LinkedList
{
    public class Node<T>
    {
        internal Node<T> Prev { get; set; }
        internal Node<T> Next { get; set; }
        internal T Value { get; }

        public Node(T value)
        {
            Value = value;
        }
    }
}