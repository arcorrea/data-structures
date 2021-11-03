using DataStructure.Tests.Utils;
using DataStructure.Trees;
using System;
using Xunit;

namespace DataStructure.Tests
{
    public class LeafTreeTests
    {
        [Fact]
        public void IsEmpty_NewTreeWithIntKey_ReturnsTrue()
        {
            //Arrange
            var tree = new LeafTree<int, int>();

            //Act
            var isEmpty = tree.IsEmpty();

            //Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void IsEmpty_NewTreeWithIntKeyAndEmptyKey_ReturnsTrue()
        {
            //Arrange
            var tree = new LeafTree<int, int>(emptyKey: -1);

            //Act
            var isEmpty = tree.IsEmpty();

            //Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void IsEmpty_NewTreeWithNullableKey_ReturnsTrue()
        {
            //Arrange
            var tree = new LeafTree<NullableKey, int>();

            //Act
            var isEmpty = tree.IsEmpty();

            //Assert
            Assert.True(isEmpty);
        }

        [Theory]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 4, 1, 8, 2, 3 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 5, 4, 3, 2, 1 })]
        public void Insert_Values_OnlyLeavesHaveValue(int[] values)
        {
            //Arrange
            var tree = new LeafTree<int, int>();

            //Act
            foreach (var value in values)
            {
                tree.Insert(value, value);
            }

            //Assert
            Assert.True(LeafTreeHelper.AreInternalNoteWithoutValues(tree));
            Assert.True(LeafTreeHelper.DoLeavesNodeHasValues(tree));
        }

        [Fact]
        public void Insert_EmptyKey_ThrowArgumentNullException()
        {
            //Arrange
            var tree = new LeafTree<int, int>();

            //Assert
            Assert.Throws<ArgumentNullException>(() => tree.Insert(0, 1));
        }

        [Fact]
        public void Insert_EmptyValue_DoesNotThrowException()
        {
            //Arrange
            var tree = new LeafTree<int, int>();

            //Act
            tree.Insert(1, 0);

            //Assert
            Assert.False(tree.IsEmpty());
        }

        [Fact]
        public void Insert_DuplicatedKey_ThrowArgumentException()
        {
            //Arrange
            var tree = new LeafTree<int, int>();

            //Act
            tree.Insert(1, 0);

            //Assert
            Assert.Throws<ArgumentException>(() => tree.Insert(1, 1));
        }

        [Theory]
        [InlineData(new int[] { 4, 1, 8, 2, 3 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 5, 4, 3, 2, 1 })]
        public void Insert_Values_TheSmallestKeyAreToTheLeftAndTheOthersKeyAreToTheRight(int[] values)
        {
            //Arrange
            var tree = new LeafTree<int, int>();

            //Act
            foreach (var value in values)
            {
                tree.Insert(value, value);
            }

            //Assert
            Assert.True(LeafTreeHelper.HasSortedNodes(tree));
        }

        [Theory]
        [InlineData(new int[] { }, 1)]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 10)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 10)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 10)]
        public void Find_MissingValue_ReturnsEmptyValue(int[] nodes, int lookFor)
        {
            //Arrange
            var tree = new LeafTree<int, int>();
            foreach (var node in nodes)
            {
                tree.Insert(node, node);
            }

            //Act
            var result = tree.Find(lookFor);

            //Assert
            Assert.Equal(tree.EmptyKey, result);
        }

        [Theory]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 8)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 4)]
        public void Find_ExistingValue_ReturnsTheSearchedValue(int[] nodes, int lookFor)
        {
            //Arrange
            var tree = new LeafTree<int, int>();
            foreach (var node in nodes)
            {
                tree.Insert(node, node);
            }

            //Act
            var result = tree.Find(lookFor);

            //Assert
            Assert.Equal(lookFor, result);
        }

        [Fact]
        public void Delete_EmptyKey_ThrowsArgumentNullException()
        {
            //Arrange
            var tree = new LeafTree<int, int>();

            //Assert
            Assert.Throws<ArgumentNullException>(() => tree.Delete(0));
        }

        [Theory]
        [InlineData(new int[] { }, 1)]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 10)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 10)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 10)]
        public void Delete_MissingKey_ReturnsEmptyValue(int[] nodes, int keyToDelete)
        {
            //Arrange
            var tree = new LeafTree<int, int>();
            foreach (var node in nodes)
            {
                tree.Insert(node, node);
            }

            //Act
            var result = tree.Delete(keyToDelete);

            //Assert
            Assert.Equal(tree.EmptyValue, result);
        }

        [Theory]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 8)]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 4)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 3)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 1)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 2)]
        public void Delete_ExistingKey_ReturnsDeletedValue(int[] nodes, int keyToDelete)
        {
            //Arrange
            var tree = new LeafTree<int, int>();
            foreach (var node in nodes)
            {
                tree.Insert(node, node);
            }

            //Act
            var result = tree.Delete(keyToDelete);

            //Assert
            Assert.Equal(keyToDelete, result);
        }

        [Theory]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 8)]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 4)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 3)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 1)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 2)]
        public void Delete_ExistingKey_OnlyOnlyLeavesHaveValue(int[] nodes, int keyToDelete)
        {
            //Arrange
            var tree = new LeafTree<int, int>();
            foreach (var node in nodes)
            {
                tree.Insert(node, node);
            }

            //Act
            tree.Delete(keyToDelete);

            //Assert
            Assert.True(LeafTreeHelper.AreInternalNoteWithoutValues(tree));
            Assert.True(LeafTreeHelper.DoLeavesNodeHasValues(tree));
        }

        [Theory]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 8)]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 4)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 3)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 1)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 2)]
        public void Delete_ExistingKey_TheSmallestKeyAreToTheLeftAndTheOthersKeyAreToTheRight(int[] nodes, int keyToDelete)
        {
            //Arrange
            var tree = new LeafTree<int, int>();
            foreach (var node in nodes)
            {
                tree.Insert(node, node);
            }

            //Act
            tree.Delete(keyToDelete);

            //Assert
            Assert.True(LeafTreeHelper.HasSortedNodes(tree));
        }

        [Theory]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 8)]
        [InlineData(new int[] { 4, 1, 8, 2, 3 }, 4)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 3)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 1)]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, 2)]
        public void Delete_ExistingKey_ExistTheOthersLeavesExceptTheDeletedKey(int[] nodes, int keyToDelete)
        {
            //Arrange
            var tree = new LeafTree<int, int>();
            foreach (var node in nodes)
            {
                tree.Insert(node, node);
            }

            //Act
            tree.Delete(keyToDelete);

            //Assert
            foreach (var node in nodes)
            {
                Assert.Equal(node == keyToDelete ? tree.EmptyValue : node, tree.Find(node));
            }
        }
    }
}
