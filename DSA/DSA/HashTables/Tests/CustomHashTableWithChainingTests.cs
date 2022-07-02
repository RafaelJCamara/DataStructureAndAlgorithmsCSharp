using System;
using Xunit;

namespace DSA.HashTables.Tests
{
    public class CustomHashTableWithChainingTests
    {

        [Theory]
        [InlineData(1, "One")]
        [InlineData(2, "Two")]
        [InlineData(3, "Three")]
        public void Get_RetrieveStoredValueForAnExistingKey(int key, string value)
        {
            //Arrange
            var hashTable = new CustomHashTableWithChaining();

            //Act
            hashTable.Add(key, value);
            var retrievedValue = hashTable.Get(key);

            //Assert
            Assert.Equal(value, retrievedValue);
        }

        [Theory]
        [InlineData(1)]
        public void Get_ThrowsExceptionWhenLookingForNonExistingKey(int key)
        {
            //Arrange
            var hashTable = new CustomHashTableWithChaining();
            var expectedErrorMessage = "Key not found!";

            //Act

            //Assert
            var exception = Assert.Throws<Exception>(() => hashTable.Get(key));
            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Theory]
        [MemberData(nameof(TestGetValueForAGivenKey))]
        public void ContainsKey_RetrievesTrueOrFalseDependingIfTheKeyExistsOrNot(
            List<int> keys, List<string> values, int key, bool expected)
        {
            //Arrange
            var hashTable = new CustomHashTableWithChaining();
            for(int i = 0; i != keys.Count; i++)
            {
                hashTable.Add(keys[i], values[i]);
            }

            //Act
            var doesKeyExists = hashTable.ContainsKey(key);

            //Assert
            Assert.Equal(expected, doesKeyExists);
        }

        [Theory]
        [InlineData(1, "one")]
        public void Add_AddsKeyAndValueSpecified(int key, string value)
        {
            //Arrange
            var hashTable = new CustomHashTableWithChaining();
            int index = hashTable.Hash(key);
            var currentEntryListCountBeforeInsertion = hashTable.Dictionary[index].Count;
            var expectedEntryListCountAfterInsertion = currentEntryListCountBeforeInsertion + 1;

            //Act
            hashTable.Add(key, value);
            var currentEntryListCountAfterInsertion = hashTable.Dictionary[index].Count;
            var insertedElement = hashTable.GetEntryForKey(key);

            //Assert
            Assert.Equal(expectedEntryListCountAfterInsertion, currentEntryListCountAfterInsertion);
            Assert.Equal(key, insertedElement.Key);
            Assert.Equal(value, insertedElement.Value);
        }

        [Theory]
        [InlineData(1)]
        public void Remove_RemovesEntryForSpecifiedKey(int key)
        {
            //Arrange
            var hashTable = new CustomHashTableWithChaining();
            var index = hashTable.Hash(key);
            hashTable.Add(key, "");
            var currentEntryListCountBeforeDeletion = hashTable.Dictionary[index].Count;
            var expectedEntryListCountAfterDeletion = currentEntryListCountBeforeDeletion - 1;
            var expectedErrorMessage = "Key not found!";

            //Act
            hashTable.Remove(key);
            var currentEntryListCountAfterDeletion = hashTable.Dictionary[index].Count;

            //Assert
            Assert.Equal(expectedEntryListCountAfterDeletion, currentEntryListCountAfterDeletion);
            var exception = Assert.Throws<Exception>(() => hashTable.Get(key));
            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Theory]
        [InlineData(1)]
        public void Remove_ThrowsExceptionByRemovingNonExistingKey(int key)
        {
            //Arrange
            var hashTable = new CustomHashTableWithChaining();

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => hashTable.Remove(key));
        }

        [Theory]
        [InlineData(1, "one")]
        [InlineData(2, "two")]
        [InlineData(3, "three")]
        public void GetEntryForKey_ReturnsEntryForTheExistentGivenKey(int key, string value)
        {
            //Arrange
            var hashTable = new CustomHashTableWithChaining();

            //Act
            hashTable.Add(key, value);
            var insertedElement = hashTable.GetEntryForKey(key);

            //Assert
            Assert.Equal(key, insertedElement.Key);
            Assert.Equal(value, insertedElement.Value);
        }

        [Theory]
        [InlineData(1, "one")]
        [InlineData(2, "two")]
        [InlineData(3, "three")]
        public void GetEntryForKey_ThrowsExceptionForTheNonExistingKey(int key, string value)
        {
            //Arrange
            var hashTable = new CustomHashTableWithChaining();
            var randomKey = new Random().Next();
            var expectedErrorMessage = "Key not found!";

            //Act
            hashTable.Add(key, value);

            //Assert
            var exception = Assert.Throws<Exception>(() => hashTable.GetEntryForKey(randomKey));
            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        public static IEnumerable<object[]> TestGetValueForAGivenKey
        {
            get
            {
                var keys = new List<int> { 1, 2, 3, 101, 102, 103 };
                var values = new List<string> { "one", "two", "three", "one0one", "one0two", "one0three" };
                return new List<object[]>
                        {
                            new object[] { keys, values, 1, true },
                            new object[] { keys, values, 102, true },
                            new object[] { keys, values, 154, false },
                            new object[] { keys, values, 289, false }
                        };
            }
        }

    }
}