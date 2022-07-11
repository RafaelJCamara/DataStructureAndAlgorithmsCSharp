using System;
using Xunit;

namespace DSA.Trees.BinarySearchTree.Tests
{
    public class BSTTests
    {

        [Theory]
        [MemberData(nameof(TestHeightOfTreeData))]
        public void Height_ReturnsCorrectHeightAfter(List<int> nodesToInsert, int expectedHeight)
        {
            //Arrange
            var bst = new BST();
            foreach (var node in nodesToInsert) bst.Insert(node);

            //Act
            var height = bst.Height();

            //Assert
            Assert.Equal(expectedHeight, height);
        }

        [Fact]
        public void Height_ThrowsExceptionWhenTreeIsEmpty()
        {
            //Arrange
            var bst = new BST();
            var expectExceptionMessage = "There are no nodes!";

            //Act

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(() => bst.Height());
            Assert.Equal(expectExceptionMessage, exception.Message);
        }

        //GetNodesAtDistanceFromRoot

        //Find

        //Insert

        public static IEnumerable<object[]> TestHeightOfTreeData
        {
            get
            {
                var values1 = new List<int> { 10, 6, 3, 8, 1, 4, 7, 9, 17, 14, 13, 15, 20, 18, 21 };
                var values2 = new List<int> { 10, 6, 3, 8, 17, 14, 20};
                var values3 = new List<int> { 10, 6, 17 };
                var values4 = new List<int> { 10 };
                return new List<object[]>
                        {
                            new object[] { values1, 3},
                            new object[] { values2, 2},
                            new object[] { values2, 1},
                            new object[] { values2, 0}
                        };
            }
        }
    }
}