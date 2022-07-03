using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DSA.Stack.Tests
{
    public class CustomStackTests
    {

        [Theory]
        [InlineData(1)]
        public void Push_InsertItemSpecifiedInANonFullArray(int item)
        {
            //Arrange
            var stack = new CustomStack();
            int currentItens = stack.Current;
            var expectedItemsAfterInsertion = currentItens + 1;

            //Act
            stack.Push(item);
            int currentItemsAfterInsertion = stack.Current;
            var insertedItem = stack.Peek();

            //Assert
            Assert.Equal(expectedItemsAfterInsertion, currentItemsAfterInsertion);
            Assert.Equal(item, insertedItem);
        }

        [Theory]
        [InlineData(100)]
        public void Push_ThrowsExceptionWhenInsertingItemSpecifiedInAFullArray(int item)
        {
            //Arrange
            var stack = new CustomStack();
            var expectedExceptionMessage = "Stack is full!";
            for (int i = 0; i != 100; i++) stack.Push(i);

            //Act

            //Assert
            var exception = Assert.Throws<Exception>(() => stack.Push(item));
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void Pop_RemovesLastInsertedItemFromANonEmptyStack()
        {
            //Arrange
            var stack = new CustomStack();
            var lastItem = 99;
            for (int i = 0; i <= lastItem; i++) stack.Push(i);
            var currentItemsBeforePop = stack.Current;
            var expectedItemsAfterPop = currentItemsBeforePop - 1;

            //Act
            var removedItem = stack.Pop();
            var currentItemsAfterPop = stack.Current;

            //Assert
            Assert.Equal(lastItem, removedItem);
            Assert.Equal(expectedItemsAfterPop, currentItemsAfterPop);
        }

        [Fact]
        public void Pop_ThrowsExceptionWhenRemovingFromEmptyStack()
        {
            //Arrange
            var stack = new CustomStack();
            var expectedExceptionMessage = "Stack is empty!";

            //Act

            //Assert
            var exception = Assert.Throws<Exception>(() => stack.Pop());
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void Peek_ReturnsLastInsertedItemWithoutRemovingItFromANonEmptyStack()
        {
            //Arrange
            var stack = new CustomStack();
            var lastItem = 99;
            for (int i = 0; i <= lastItem; i++) stack.Push(i);
            var currentItemsBeforePop = stack.Current;
            var expectedItemsAfterPop = currentItemsBeforePop;

            //Act
            var removedItem = stack.Peek();
            var currentItemsAfterPop = stack.Current;

            //Assert
            Assert.Equal(lastItem, removedItem);
            Assert.Equal(expectedItemsAfterPop, currentItemsAfterPop);
        }

        [Fact]
        public void Peek_ThrowsExceptionWhenPeekingAnEmptyStack()
        {
            //Arrange
            var stack = new CustomStack();
            var expectedExceptionMessage = "Stack is empty!";

            //Act

            //Assert
            var exception = Assert.Throws<Exception>(() => stack.Peek());
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }


        [Fact]
        public void Clear_StackClearedWhenClearMethodCalled()
        {
            //Arrange
            var stack = new CustomStack();
            var expectedItemsAfterClear = -1;

            //Act
            stack.Clear();

            //Assert
            Assert.Equal(expectedItemsAfterClear, stack.Current);
        }

    }
}
