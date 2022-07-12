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
        [Theory]
        [MemberData(nameof(TestNodesAtDistanceFromRootData))]
        public void GetNodesAtDistanceFromRoot_ReturnsListOfNodeAtGivenDistance(List<int> elementsToInsert, int distance, List<int> expectedNodesAtDistance)
        {
            //Arrange
            var bst = new BST();
            foreach (var element in elementsToInsert) bst.Insert(element);

            //Act
            var elementsAtDistance = bst.GetNodesAtDistanceFromRoot(distance);

            //Assert
            Assert.Equal(expectedNodesAtDistance, elementsAtDistance);
        }

        [Fact]
        public void GetNodesAtDistanceFromRoot_ThrowsExceptionWhenRootNull()
        {
            //Arrange
            var bst = new BST();
            var expectedExceptionMessage = "There are no nodes!";

            //Act

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(() => bst.GetNodesAtDistanceFromRoot(0));
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void GetNodesAtDistanceFromRoot_ThrowsExceptionWhenDistanceIsLessThanZero()
        {
            //Arrange
            var bst = new BST();
            bst.Insert(10);
            var expectedExceptionMessage = "Please insert distance from 0 onwards!";

            //Act

            //Assert
            var exception = Assert.Throws<ArgumentException>(() => bst.GetNodesAtDistanceFromRoot(-1));
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        //Find
        [Theory]
        [MemberData(nameof(TestFindElementData))]
        public void Find_ReturnsTrueIfElementExistsFalseOtherwise(List<int> elements, int elementToFind, bool expectedResult)
        {
            //Arrange
            var bst = new BST();
            foreach (var element in elements) bst.Insert(element);

            //Act
            var found = bst.Find(elementToFind);

            //Assert
            Assert.Equal(expectedResult, found);
        }

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
                            new object[] { values3, 1},
                            new object[] { values4, 0}
                        };
            }
        }
        public static IEnumerable<object[]> TestFindElementData
        {
            get
            {
                var values1 = new List<int> { 10, 6, 3, 8, 1, 4, 7, 9, 17, 14, 13, 15, 20, 18, 21 };
                var values2 = new List<int> { 10, 6, 3, 8, 17, 14, 20 };
                var values3 = new List<int> { 10, 6, 17 };
                var values4 = new List<int> { 10 };
                return new List<object[]>
                        {
                            new object[] { values1, 3, true},
                            new object[] { values2, 2, false},
                            new object[] { values3, 17, true},
                            new object[] { values4, 0, false},
                            new object[] { values1, 76, false},
                            new object[] { values2, 14, true},
                            new object[] { values3, 25, false},
                            new object[] { values4, 10, true}
                        };
            }
        }
        public static IEnumerable<object[]> TestNodesAtDistanceFromRootData
        {
            get
            {
                var values1 = new List<int> { 10, 6, 3, 8, 1, 4, 7, 9, 17, 14, 13, 15, 20, 18, 21 };
                var values2 = new List<int> { 10, 6, 3, 8, 17, 14, 20 };
                var values3 = new List<int> { 10, 6, 17 };
                var values4 = new List<int> { 10 };
                return new List<object[]>
                        {
                            new object[] { values1, 3, new List<int> { 1, 4, 7, 9, 13, 15, 18, 21}},
                            new object[] { values2, 2, new List<int> { 3, 8, 14, 20}},
                            new object[] { values3, 1, new List<int> { 6, 17}},
                            new object[] { values4, 0, new List<int> { 10 } }
                        };
            }
        }

    }
}