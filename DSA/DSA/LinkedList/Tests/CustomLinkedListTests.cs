using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DSA.LinkedList.Tests
{
    public class CustomLinkedListTests
    {
        [Theory]
        [InlineData(1)]
        public void AddFirst_AddFirstElementWhenLinkedListIsEmpty(int value)
        {
            //Arrange
            var linkedList = new CustomLinkedList();

            //Act
            linkedList.AddFirst(value);

            //Assert
            Assert.Equal(value, linkedList.Head.Value);
            Assert.Equal(linkedList.Head.Value, linkedList.Tail.Value);
        }

        [Theory]
        [InlineData(1)]
        public void AddFirst_AddFirstElementWhenLinkedListIsNotEmpty(int value)
        {
            //Arrange
            var linkedList = new CustomLinkedList();
            for(int i = 100; i < 201; i++) linkedList.AddFirst(i);

            //Act
            linkedList.AddFirst(value);

            //Assert
            Assert.Equal(value, linkedList.Head.Value);
        }

        [Theory]
        [InlineData(1)]
        public void AddLast_AddLastElementWhenLinkedListIsEmpty(int value)
        {
            //Arrange
            var linkedList = new CustomLinkedList();

            //Act
            linkedList.AddLast(value);

            //Assert
            Assert.Equal(value, linkedList.Tail.Value);
            Assert.Equal(linkedList.Tail.Value, linkedList.Head.Value);
        }

        [Theory]
        [InlineData(1)]
        public void AddLast_AddLastElementWhenLinkedListIsNotEmpty(int value)
        {
            //Arrange
            var linkedList = new CustomLinkedList();
            for (int i = 100; i < 201; i++) linkedList.AddLast(i);

            //Act
            linkedList.AddLast(value);

            //Assert
            Assert.Equal(value, linkedList.Tail.Value);
        }

        [Fact]
        public void RemoveFirst_RemovesFirstElementOfNonEmptyLinkedListWithSingleElement()
        {
            //Arrange
            var linkedList = new CustomLinkedList();
            linkedList.AddFirst(1);

            //Act
            linkedList.RemoveFirst();

            //Assert
            Assert.Null(linkedList.Head);
            Assert.Null(linkedList.Tail);
        }

        [Fact]
        public void RemoveFirst_RemovesFirstElementOfNonEmptyLinkedListWithMultipleElements()
        {
            //Arrange
            var linkedList = new CustomLinkedList();
            for (int i = 100; i < 201; i++) linkedList.AddLast(i);
            var oldHeadValue = linkedList.Head.Value;

            //Act
            linkedList.RemoveFirst();
            var newHeadValue = linkedList.Head.Value;

            //Assert
            Assert.NotNull(linkedList.Head);
            Assert.NotNull(linkedList.Tail);
            Assert.NotEqual(oldHeadValue, newHeadValue); //we are assuming that node values are unique, although there is no proper validation
        }

        [Fact]
        public void RemoveFirst_ThrowsExceptionWhenRemovingFirstElementOfEmptyLinkedList()
        {
            //Arrange
            var linkedList = new CustomLinkedList();
            var expectedExceptionMessage = "No nodes to be removed!";

            //Act

            //Assert
            Assert.Null(linkedList.Head);
            Assert.Null(linkedList.Tail);
            var exception = Assert.Throws<NullReferenceException>(() => linkedList.RemoveFirst());
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void RemoveLast_RemovesLastElementOfNonEmptyLinkedListWithSingleElement()
        {
            //Arrange
            var linkedList = new CustomLinkedList();
            linkedList.AddLast(1);

            //Act
            linkedList.RemoveLast();

            //Assert
            Assert.Null(linkedList.Head);
            Assert.Null(linkedList.Tail);
        }

        [Fact]
        public void RemoveLast_RemovesLastElementOfNonEmptyLinkedListWithMultipleElements()
        {
            //Arrange
            var linkedList = new CustomLinkedList();
            for (int i = 100; i < 201; i++) linkedList.AddLast(i);
            var oldTailValue = linkedList.Tail.Value;

            //Act
            linkedList.RemoveLast();
            var newTailValue = linkedList.Tail.Value;

            //Assert
            Assert.NotNull(linkedList.Head);
            Assert.NotNull(linkedList.Tail);
            Assert.NotEqual(oldTailValue, newTailValue); //we are assuming that node values are unique, although there is no proper validation
        }

        [Fact]
        public void RemoveLast_ThrowsExceptionWhenRemovingFirstElementOfEmptyLinkedList()
        {
            //Arrange
            var linkedList = new CustomLinkedList();
            var expectedExceptionMessage = "No nodes to be removed!";

            //Act

            //Assert
            Assert.Null(linkedList.Head);
            Assert.Null(linkedList.Tail);
            var exception = Assert.Throws<NullReferenceException>(() => linkedList.RemoveLast());
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [MemberData(nameof(TestContainsValue))]
        public void Contains(List<int> values, int valueToSearch, bool expectedContains)
        {
            //Arrange
            var linkedList = new CustomLinkedList();
            foreach (int value in values) linkedList.AddLast(value);

            //Act
            var containsValue = linkedList.Contains(valueToSearch);

            //Assert
            Assert.Equal(expectedContains, containsValue);
        }

        [Theory]
        [MemberData(nameof(TestIndexOfValue))]
        public void IndexOf(List<int> values, int valueToSearch, int expectedIndex)
        {
            //Arrange
            var linkedList = new CustomLinkedList();
            foreach (int value in values) linkedList.AddLast(value);

            //Act
            var indexOf = linkedList.IndexOf(valueToSearch);

            //Assert
            Assert.Equal(expectedIndex, indexOf);
        }


        public static IEnumerable<object[]> TestContainsValue
        {
            get
            {
                var values = new List<int> { 1, 2, 3, 101, 102, 103 };
                return new List<object[]>
                        {
                            new object[] { values, 1, true },
                            new object[] { values, 102, true },
                            new object[] { values, 154, false },
                            new object[] { values, 289, false }
                        };
            }
        }

        public static IEnumerable<object[]> TestIndexOfValue
        {
            get
            {
                var values = new List<int> { 1, 2, 3, 101, 102, 103 };
                return new List<object[]>
                        {
                            new object[] { values, 1, 0 },
                            new object[] { values, 102, 4 },
                            new object[] { values, 103, 5 },
                            new object[] { values, 154, -1 },
                            new object[] { values, 289, -1 }
                        };
            }
        }

    }
}
