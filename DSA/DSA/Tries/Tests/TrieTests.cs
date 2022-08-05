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

        [Theory]
        [MemberData(nameof(TestInsertData))]
        public void Insert_InsertsElementInTrie(List<string> words)
        {
            //Arrange
            var trie = new Trie();

            //Act
            foreach (var word in words) trie.Insert(word);
            var contains = true;
            foreach (var word in words) contains = contains && trie.Contains(word);

            //Assert
            Assert.True(contains);
        }

        [Theory]
        [MemberData(nameof(TestDeleteData))]
        public void Delete_DeletesWordThatExists(List<string> words, string wordToDelete)
        {
            //Arrange
            var trie = new Trie();
            foreach (var word in words) trie.Insert(word);

            //Act
            var beforeDeleteContains = trie.Contains(wordToDelete);
            trie.Delete(wordToDelete);
            var containsAfterDelete = trie.Contains(wordToDelete);

            //Assert
            Assert.True(beforeDeleteContains);
            Assert.False(containsAfterDelete);
        }

        [Theory]
        [MemberData(nameof(TestFindWordsData))]
        public void FindWords_FindsWordsThatStartWithGivenPrefix(List<string> words, string prefix, List<string> expectedPrefixedWords)
        {
            //Arrange
            var trie = new Trie();
            foreach (var word in words) trie.Insert(word);

            //Act
            var prefixedWords = trie.FindWords(prefix);

            //Assert
            Assert.Equal(expectedPrefixedWords, prefixedWords);
        }

        [Theory]
        [MemberData(nameof(TestCountWordsData))]
        public void CountWords_CountsNumberOfExistingWords(List<string> words, int expectedCount)
        {
            //Arrange
            var trie = new Trie();
            foreach (var word in words) trie.Insert(word);

            //Act
            var countWords = trie.CountWords();

            //Assert
            Assert.Equal(expectedCount, countWords);
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

        public static IEnumerable<object[]> TestInsertData
        {
            get
            {
                var values = new List<string> { "car", "card", "dog", "cat", "look", "news", "motor" };
                var values1 = new List<string> { "fly", "tart", "house", "plane" };
                var values2 = new List<string> { "canada", "toronto", "USA", "NewYork", "London"};

                return new List<object[]>
                        {
                            new object[] { values },
                            new object[] { values1 },
                            new object[] { values2 },
                        };
            }
        }

        public static IEnumerable<object[]> TestDeleteData
        {
            get
            {
                var values = new List<string> { "car", "card", "dog", "cat", "look", "news", "motor" };
                var values1 = new List<string> { "fly", "tart", "house", "plane" };
                var values2 = new List<string> { "canada", "toronto", "usa", "newyork", "london" };

                return new List<object[]>
                        {
                            new object[] { values, "car" },
                            new object[] { values, "card" },
                            new object[] { values, "dog" },
                            new object[] { values1, "fly" },
                            new object[] { values1, "tart" },
                            new object[] { values1, "house" },
                            new object[] { values2, "canada" },
                            new object[] { values2, "toronto" },
                            new object[] { values2, "london" },
                        };
            }
        }

        public static IEnumerable<object[]> TestFindWordsData
        {
            get
            {
                var values = new List<string> { "car", "card", "dog", "cat", "look", "news", "motor" };

                return new List<object[]>
                        {
                            new object[] { values, "car", new List<string> { "car", "card" } },
                            new object[] { values, "c", new List<string> { "car", "card", "cat" } },
                        };
            }
        }

        public static IEnumerable<object[]> TestCountWordsData
        {
            get
            {
                var values = new List<string> { "car", "card", "dog", "cat", "look", "news", "motor" };
                var values2 = new List<string> { "car", "card", "motor" };

                return new List<object[]>
                        {
                            new object[] { values, 7},
                            new object[] { values2, 3},
                        };
            }
        }

    }
}

