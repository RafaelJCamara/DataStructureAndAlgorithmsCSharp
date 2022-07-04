using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DSA.Queues.Tests
{
    public class CustomQueueTests
    {
        [Theory]
        [InlineData(1)]
        public void Enqueue_EnqueuesItemInEmptyQueue(int value)
        {
            //Arrange
            var customQueue = new CustomQueue();

            //Act
            customQueue.Enqueue(value);

            //Assert
            Assert.Equal(1, customQueue.Count);
            Assert.Equal(value, customQueue.Queue[customQueue.Front]);
        }

        [Theory]
        [InlineData(40)]
        public void Enqueue_EnqueuesItemInANonFullQueue(int value)
        {
            //Arrange
            var customQueue = new CustomQueue();
            for (int i = 0; i != 40; i++) customQueue.Enqueue(i);
            var countBeforeEnqueue = customQueue.Count;
            var expectedCountAfterEnqueue = countBeforeEnqueue + 1;

            //Act
            customQueue.Enqueue(value);
            var countAfterEnqueue = customQueue.Count;

            //Assert
            Assert.Equal(expectedCountAfterEnqueue, countAfterEnqueue);
            Assert.Equal(value, customQueue.Queue[customQueue.Back-1]);
        }

        [Fact]
        public void Enqueue_ThrowsExceptionWhenEnqueuingItemInFullQueue()
        {
            //Arrange
            var customQueue = new CustomQueue();
            for (int i = 0; i != 50; i++) customQueue.Enqueue(i);
            var expectedExceptionMessage = "Queue is full!";

            //Act

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(() => customQueue.Enqueue(1));
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void Dequeue_DequeuesItemFromOneItemQueue()
        {
            //Arrange
            var customQueue = new CustomQueue();
            customQueue.Enqueue(1);
            var countBeforeDequeue = customQueue.Count;
            var expectedCountAfterDequeue = countBeforeDequeue - 1;

            //Act
            customQueue.Dequeue();
            var countAfterDequeue = customQueue.Count;

            //Assert
            Assert.Equal(expectedCountAfterDequeue, countAfterDequeue);
            Assert.Equal(1, customQueue.Front);
            Assert.Equal(1, customQueue.Back);
        }


        [Fact]
        public void Dequeue_DequeuesItemInANonFullQueue()
        {
            //Arrange
            var customQueue = new CustomQueue();
            for (int i = 0; i != 40; i++) customQueue.Enqueue(i);
            var countBeforeDequeue = customQueue.Count;
            var expectedCountAfterDequeue = countBeforeDequeue - 1;
            var expectedValueAfterDequeue = customQueue.Queue[customQueue.Front+1];

            //Act
            customQueue.Dequeue();
            var countAfterDequeue = customQueue.Count;
            var valueAfterDequeue = customQueue.Queue[customQueue.Front];

            //Assert
            Assert.Equal(expectedCountAfterDequeue, countAfterDequeue);
            Assert.Equal(expectedValueAfterDequeue, valueAfterDequeue);
        }

        [Fact]
        public void Dequeue_ThrowsExceptionWhenDequeuingInEmptyQueue()
        {
            //Arrange
            var customQueue = new CustomQueue();
            var expectedExceptionMessage = "Queue is empty!";

            //Act

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(() => customQueue.Dequeue());
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }


        [Fact]
        public void Peek_PeeksItemInANonFullQueue()
        {
            //Arrange
            var customQueue = new CustomQueue();
            for (int i = 0; i != 40; i++) customQueue.Enqueue(i);
            var expectedCountAfterPeek = customQueue.Count;
            var expectedValueAfterPeek = customQueue.Queue[customQueue.Front];

            //Act
            int peekedValue = customQueue.Peek();
            var countAfterPeek = customQueue.Count;

            //Assert
            Assert.Equal(expectedCountAfterPeek, countAfterPeek);
            Assert.Equal(expectedValueAfterPeek, peekedValue);
        }

        [Fact]
        public void Peek_ThrowsExceptionWhenPeekingInEmptyQueue()
        {
            //Arrange
            var customQueue = new CustomQueue();
            var expectedExceptionMessage = "Queue is empty!";

            //Act

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(() => customQueue.Peek());
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void IsQueueEmpty()
        {
            //Arrange
            var customQueue = new CustomQueue();

            //Act

            //Assert
            Assert.Equal(0, customQueue.Count);
        }

        [Theory]
        [MemberData(nameof(TestIsQueueFullData))]
        public void IsQueueFull(List<int> itemsToInsert, bool expected)
        {
            //Arrange
            var customQueue = new CustomQueue();
            foreach (int val in itemsToInsert) customQueue.Enqueue(val);

            //Act

            //Assert
            Assert.Equal(expected, customQueue.Count==50);
        }

        public static IEnumerable<object[]> TestIsQueueFullData
        {
            get
            {
                var values = new List<int> { 1, 2, 3, 101, 102, 103 };
                var fullValues = new List<int>();
                for (int i = 0; i != 50; i++) fullValues.Add(i);
                return new List<object[]>
                        {
                            new object[] { values, false},
                            new object[] { fullValues, true}
                        };
            }
        }

    }
}
