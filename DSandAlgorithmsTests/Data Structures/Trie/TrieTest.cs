using DSandAlgorithms.Data_Structures.Trie;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSandAlgorithmsTests.Data_Structures.TrieTest
{
    [TestClass]
    public class TrieTest
    {
        [TestMethod]
        public void AddTest()
        {
            var trie = new Trie();
            trie.Insert("Apple");
            trie.Insert("Banana");
            trie.Insert("Bananas");
            trie.Insert("Apple Pie");

            Assert.AreEqual(true, trie.Search("Apple"));
            Assert.AreEqual(true, trie.Search("Banana"));
            Assert.AreEqual(false, trie.Search("pple"));
            Assert.AreEqual(true, trie.Search("Apple Pie"));
        }

        [TestMethod]
        public void PrefixTest()
        {
            var trie = new Trie();
            trie.Insert("Apple");
            trie.Insert("Banana");
            trie.Insert("Bananas");
            trie.Insert("Apple Pie");

            Assert.AreEqual(true, trie.StartsWith("Apple"));
            Assert.AreEqual(true, trie.StartsWith("Ban"));
            Assert.AreEqual(true, trie.StartsWith("Apple "));
        }
    }
}
