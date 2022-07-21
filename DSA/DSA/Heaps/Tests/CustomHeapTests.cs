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

        [Fact]
        public void Remove_ThrowsExceptionWhenHeapIsEmpty()
        {
            //Arrange
            var customHeap = new CustomHeap(1);
            var expectedExceptionMessage = "Heap is empty!";

            //Act

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(() => customHeap.Remove());
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Theory]
        [MemberData(nameof(TestRemoveFromHeapData))]
        public void Remove_RemovesElementFromHeapAndLeavesHeapInAValidState(int size, int[] initValues, int[] expectedFinalHeap)
        {
            //Arrange
            var customHeap = new CustomHeap(size);
            foreach (var value in initValues) customHeap.Insert(value);

            //Act
            customHeap.Remove();

            //Assert
            Assert.Equal(expectedFinalHeap, customHeap.Heap);
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

        public static IEnumerable<object[]> TestRemoveFromHeapData
        {
            get
            {
                var valuesInit1 = new int[] { 40, 30, 20, 10 };
                var valuesFinal1 = new int[] { 30, 10, 20, 0 };

                var valuesInit2 = new int[] { 40, 30, 20 };
                var valuesFinal2 = new int[] { 30, 20, 0 };

                return new List<object[]>
                        {
                            new object[] { 4, valuesInit1, valuesFinal1},
                            new object[] { 3, valuesInit2, valuesFinal2 }
                        };
            }
        }

    }
}

