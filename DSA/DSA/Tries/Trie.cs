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

                if (!current.Children.ContainsKey(character))
                    current.Children.Add(character, new TrieNode(character));
                current = current.Children[character];
                /*
                    int index = character - 'a';
                    if (current.Children[index] == null)
                        current.Children[index] = new TrieNode(character);
                    current = current.Children[index];
                */
            }
            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (word == null) return false;

            var current = Root;
            foreach(var character in word)
            {
                if (!current.Children.ContainsKey(character)) return false;
                current = current.Children[character];
            }
            return current.IsEndOfWord;
        }

        public void Traverse()
        {
            PreOrderTraversal(Root);
        }

        public void PreOrderTraversal(TrieNode root)
        {
            Console.WriteLine(root.Value);
            foreach (var child in root.Children.Keys)
            {
                Console.WriteLine(child);
            }
        }

        public void PostOrderTraversal(TrieNode root)
        {
            foreach (var child in root.Children.Keys)
            {
                Console.WriteLine(child);
            }
            Console.WriteLine(root.Value);
        }

    }
}

