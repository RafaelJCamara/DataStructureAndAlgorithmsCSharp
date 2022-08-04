using System;
using Xunit;

namespace DSA.Tries.Tests
{
    public class TrieTests
    {

        [Theory]
        [MemberData(nameof(TestContainsData))]
        public void Contains_ReturnsTrueIfContainsWordFalseOtherwise(List<string> words, string wordToLook, bool expected)
        {
            //Arrange
            var trie = new Trie();
            foreach (var word in words) trie.Insert(word);

            //Act
            var contains = trie.Contains(wordToLook);

            //Assert
            Assert.Equal(expected, contains);
        }

        public static IEnumerable<object[]> TestContainsData
        {
            get
            {
                var values = new List<string> { "car", "card", "dog", "cat", "look", "news", "motor" };
                return new List<object[]>
                        {
                            new object[] { values, "car", true},
                            new object[] { values, "card", true},
                            new object[] { values, "dog", true},
                            new object[] { values, "cat", true},
                            new object[] { values, "look", true},
                            new object[] { values, "news", true},
                            new object[] { values, "motor", true},
                            new object[] { values, "cab", false},
                            new object[] { values, "do", false},
                            new object[] { values, "ca", false},
                            new object[] { values, "lo", false},
                        };
            }
        }

    }
}

