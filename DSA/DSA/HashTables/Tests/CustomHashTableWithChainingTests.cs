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

