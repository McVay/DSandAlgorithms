using System.Collections.Generic;

namespace DSandAlgorithms.Data_Structures.Trie
{
    internal class TrieNode
    {
        public char Data { get; set; }
        public bool IsWord { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }

        public TrieNode()
        {
            Data = '#';
            IsWord = true;
            Children = new Dictionary<char, TrieNode>();
        }

        public TrieNode(char ch)
        {
            Data = ch;
            IsWord = false;
            Children = new Dictionary<char, TrieNode>();
        }
    }
}