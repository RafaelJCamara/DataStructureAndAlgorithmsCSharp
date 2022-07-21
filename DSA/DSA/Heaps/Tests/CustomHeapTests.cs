using System;
using Xunit;

namespace DSA.Heaps.Tests
{
    public class CustomHeapTests
    {

        [Fact]
        public void Insert_ThrowsExceptionWhenHeapIsFull()
        {
            //Arrange
            var customHeap = new CustomHeap(1);
            customHeap.Insert(10);
            var expectedExceptionMessage = "Heap is full!";

            //Act

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(() => customHeap.Insert(2));
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [MemberData(nameof(TestInsertValueInHeapData))]
        public void Insert_InsertsElementInCorrectPosition(int[] valuesToInsert, int[] expectedHeapAfterInsert)
        {
            //Arrange
            var customHeap = new CustomHeap(3);

            //Act
            foreach(var value in valuesToInsert)
            {
                customHeap.Insert(value);
            }

            //Assert
            Assert.Equal(expectedHeapAfterInsert, customHeap.Heap);
        }


        public void Remove_ThrowsExceptionWhenHeapIsEmpty()
        {

        }

        public void Remove_RemovesElementFromHeapAndLeavesHeapInAValidState()
        {

        }

        public static IEnumerable<object[]> TestInsertValueInHeapData
        {
            get
            {
                var values1 = new int[] { 40, 30, 20};
                var values2 = new int[] { 20, 30, 40};
                var expectedValues2 = new int[] { 40, 20, 30 };

                return new List<object[]>
                        {
                            new object[] { values1, values1},
                            new object[] { values2, expectedValues2 }
                        };
            }
        }

    }
}

