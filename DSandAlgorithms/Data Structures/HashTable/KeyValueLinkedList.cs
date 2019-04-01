namespace DSandAlgorithms.Data_Structures.HashTable
{
    internal class KeyValuePair<K, V>
    {
        public K Key { get; }

        public V Value { get; set; }

        public KeyValuePair(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }
}