using System;
namespace DSA.Tries
{
    public class TrieNode
    {
        private int _englishAlphabetSize = 26;
        public char Value { get; private set; }
        public TrieNode[] Children { get; set; }
        public bool IsEndOfWord { get; set; }

        public TrieNode(char value)
        {
            Children = new TrieNode[_englishAlphabetSize];
            Value = value;
        }

    }
}

