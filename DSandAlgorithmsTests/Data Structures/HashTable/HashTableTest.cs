using DSandAlgorithms.Data_Structures.HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSandAlgorithmsTests.Data_Structures.HashTable
{
    [TestClass]
    public class HashTableTest
    {
        [TestMethod]
        public void AddTest()
        {
            HashTable<int, int> hashTable = new HashTable<int, int>(100);
            hashTable.Put(1, 24);
            hashTable.Put(2, 2);
            hashTable.Put(3, 24);
            hashTable.Put(101, 25); // This should cause a collision

            Assert.AreEqual(4, hashTable.ItemCount);
            Assert.AreEqual(3, hashTable.BucketCount);
        }

        [TestMethod]
        public void RemoveTest()
        {
            HashTable<int, int> hashTable = new HashTable<int, int>(100);
            hashTable.Put(1, 24);
            hashTable.Put(2, 2);
            hashTable.Put(3, 24);

            Assert.AreEqual(3, hashTable.ItemCount);
            Assert.AreEqual(3, hashTable.BucketCount);

            Assert.IsTrue(hashTable.Contains(2));

            hashTable.Remove(2);
            hashTable.Remove(102);

            Assert.AreEqual(2, hashTable.ItemCount);
            Assert.IsFalse(hashTable.Contains(2));
        }

        [TestMethod]
        public void GetTest()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(100);
            hashTable.Put("Dylan", 25);

            Assert.AreEqual(25, hashTable.Get("Dylan"));
        }

        [TestMethod]
        public void TryGetTest()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(100);
            hashTable.Put("Dylan", 25);

            Assert.IsTrue(hashTable.TryGet("Dylan", out int value));
            Assert.AreEqual(value, 25);

            Assert.IsFalse(hashTable.TryGet("Charlie", out int value2));
            Assert.AreEqual(default(int), value2);
        }

        [TestMethod]
        public void UpdateTest()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(100);
            hashTable.Put("Dylan", 25);

            Assert.AreEqual(1, hashTable.ItemCount);
            Assert.AreEqual(25, hashTable.Get("Dylan"));

            hashTable.Put("Dylan", 400);

            Assert.AreEqual(1, hashTable.ItemCount);
            Assert.AreNotEqual(25, hashTable.Get("Dylan"));
            Assert.AreEqual(400, hashTable.Get("Dylan"));
        }

        [TestMethod]
        public void ContainsTest()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(100);

            Assert.IsFalse(hashTable.Contains("Dylan"));
            hashTable.Put("Dylan", 25);
            Assert.IsTrue(hashTable.Contains("Dylan"));
        }

        [TestMethod]
        public void RehashTest()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>(100);

            for (int i = 0; i < 1000; i++)
            {
                hashTable.Put(i.ToString(), i);
            }

            Assert.AreNotEqual(100, hashTable.MaxSize);
        }
    }
}