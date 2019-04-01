using DSandAlgorithms.DataStructures.LinkedList;
using SysCollections = System.Collections.Generic;

namespace DSandAlgorithms.Data_Structures.HashTable
{
    internal class KeyValueLinkedList<K, V> : LinkedList<KeyValuePair<K, V>>
    {
        public KeyValuePair<K, V> Find(K key)
        {
            Node<KeyValuePair<K, V>> curr = _head;
            while (curr != null)
            {
                if (SysCollections.EqualityComparer<K>.Default.Equals(curr.Value.Key, key))
                {
                    return curr.Value;
                }

                curr = curr.Next;
            }
            return null;
        }

        public Node<KeyValuePair<K, V>> FindNode(K key)
        {
            Node<KeyValuePair<K, V>> curr = _head;
            while (curr != null)
            {
                if (SysCollections.EqualityComparer<K>.Default.Equals(curr.Value.Key, key))
                {
                    return curr;
                }

                curr = curr.Next;
            }
            return null;
        }

        internal SysCollections.IEnumerable<KeyValuePair<K, V>> GetKeyValueList()
        {
            Node<KeyValuePair<K, V>> curr = _head;

            while (curr != null)
            {
                yield return curr.Value;
                curr = curr.Next;
            }
        }
    }
}