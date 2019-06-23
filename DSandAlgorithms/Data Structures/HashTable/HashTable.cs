using DSandAlgorithms.Data_Structures.LinkedList;
using System;
using System.Collections.Generic;

namespace DSandAlgorithms.Data_Structures.HashTable
{
    public class HashTable<K, V>
    {
        private KeyValueLinkedList<K, V>[] _buckets;
        private const double MAX_LOAD_FACTOR = 0.75;

        private int _numOfBuckets;
        private int _maxBuckets;
        private int _numOfItems;

        public HashTable(int initialSize)
        {
            _buckets = new KeyValueLinkedList<K, V>[initialSize];
            _maxBuckets = initialSize;
        }

        public V this[K key]
        {
            get => Get(key);
            set => Put(key, value);
        }

        public void Put(K key, V value)
        {
            AttemptRehash();
            int index = GetIndex(key);

            if (_buckets[index] == null) // There was no collision
            {
                _buckets[index] = new KeyValueLinkedList<K, V>();
                _buckets[index].Add(new KeyValuePair<K, V>(key, value));
                _numOfBuckets += 1;
                _numOfItems += 1;
            }
            else // There was a collision
            {
                KeyValuePair<K, V> keyValue = _buckets[index].Find(key);
                if (keyValue != null) // Update value for key
                {
                    keyValue.Value = value;
                }
                else
                {
                    _buckets[index].Add(new KeyValuePair<K, V>(key, value));
                    _numOfItems += 1;
                }
            }
        }

        public void Remove(K key)
        {
            int index = GetIndex(key);
            if (_buckets[index] != null)
            {
                Node<KeyValuePair<K, V>> node = _buckets[index].FindNode(key);
                if (node != null)
                {
                    _buckets[index].Remove(node);
                    _numOfItems--;
                }
            }
        }

        public V Get(K key)
        {
            int index = GetIndex(key);

            if (_buckets[index] != null)
            {
                KeyValuePair<K, V> keyValue = _buckets[index].Find(key);
                if (keyValue != null)
                {
                    return keyValue.Value;
                }
            }
            throw new InvalidOperationException("The key could not be found!");
        }

        public bool TryGet(K key, out V value)
        {
            bool success = true;

            try
            {
                value = Get(key);
            }
            catch
            {
                value = default(V);
                success = false;
            }

            return success;
        }

        public bool Contains(K key)
        {
            if (TryGet(key, out V value))
            {
                return true;
            }

            return false;
        }

        private void AttemptRehash()
        {
            double loadFactor = (1.0 * _numOfBuckets) / _maxBuckets;
            if (loadFactor >= MAX_LOAD_FACTOR)
            {
                List<KeyValueLinkedList<K, V>> keyValueLists = GetKeyValueList();
                _maxBuckets = _maxBuckets * 2;

                _buckets = new KeyValueLinkedList<K, V>[2 * _maxBuckets];
                foreach (KeyValueLinkedList<K, V> keyValueList in keyValueLists)
                {
                    int index = GetIndex(keyValueList.PeekFirst().Key);

                    if (_buckets[index] == null)
                    {
                        _buckets[index] = keyValueList;
                    }
                    else
                    {
                        //Collision, add all items in the list to the bucket
                        _buckets[index].Add(keyValueList.GetKeyValueList());
                    }
                }
            }
        }

        private int Hash(K key)
        {
            return key.GetHashCode();
        }

        private int GetIndex(K key)
        {
            return Math.Abs(Hash(key)) % _maxBuckets;
        }

        public int BucketCount => _numOfBuckets;

        public int ItemCount => _numOfItems;

        public int MaxSize => _maxBuckets;

        private List<KeyValueLinkedList<K, V>> GetKeyValueList()
        {
            List<KeyValueLinkedList<K, V>> keyValues = new List<KeyValueLinkedList<K, V>>();
            for (int i = 0; i < _buckets.Length; i++)
            {
                if (_buckets[i] != null)
                {
                    keyValues.Add(_buckets[i]);
                }
            }
            return keyValues;
        }
    }
}