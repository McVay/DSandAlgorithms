using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithms.Data_Structures.Trie
{
    internal class TrieNode
    {
        public char Data { get; set; }
        public bool IsWord { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }

        public TrieNode()
        {
            this.Data = '#';
            this.IsWord = true;
            this.Children = new Dictionary<char, TrieNode>();
        }

        public TrieNode(char ch)
        {
            this.Data = ch;
            this.IsWord = false;
            this.Children = new Dictionary<char, TrieNode>();
        }
    }
}
