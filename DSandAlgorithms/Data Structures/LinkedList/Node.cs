namespace DSandAlgorithms.DataStructures.LinkedList
{
    public class Node<T>
    {
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
        public T Value { get; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
