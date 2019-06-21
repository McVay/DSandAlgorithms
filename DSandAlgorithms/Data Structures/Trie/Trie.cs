using System;
using System.Collections.Generic;
using System.Text;

namespace DSandAlgorithms.Data_Structures.Trie
{
    public class Trie
    {

        private readonly TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode currNode = root;
            foreach(char ch in word)
            {
                if(!currNode.Children.ContainsKey(ch))
                {
                    var newNode = new TrieNode(ch);
                    currNode.Children.Add(ch, newNode);
                }
                currNode = currNode.Children[ch];
            }
            currNode.IsWord = true;
        }

        public bool Search(string word)
        {
            TrieNode currNode = root;
            foreach(char ch in word)
            {
                if(!currNode.Children.ContainsKey(ch))
                {
                    return false;
                }
                currNode = currNode.Children[ch];
            }
            return currNode.IsWord;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode currNode = root;
            foreach (char ch in prefix)
            {
                if (!currNode.Children.ContainsKey(ch))
                {
                    return false;
                }
                currNode = currNode.Children[ch];
            }
            return true;
        }
    }
}
