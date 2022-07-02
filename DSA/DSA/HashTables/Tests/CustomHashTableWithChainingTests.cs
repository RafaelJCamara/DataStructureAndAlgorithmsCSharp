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
            hashTable.Add(key,value);
            var retrievedValue = hashTable.Get(key);

            //Assert
            Assert.Equal(value, retrievedValue);
        }
    }
}

