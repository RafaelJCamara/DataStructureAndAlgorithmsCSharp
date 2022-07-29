using System;
namespace DSA.Tries
{
    public class Trie
    {
        public TrieNode Root { get; set; }

        public Trie()
        {
            Root = new TrieNode(' ');
        }

        public void Insert(string word)
        {
            var current = Root;
            foreach(var character in word){
                int index = character - 'a';
                if (current.Children[index] == null)
                    current.Children[index] = new TrieNode(character);
                current = current.Children[index];
            }
            current.IsEndOfWord = true;
        }

    }
}

