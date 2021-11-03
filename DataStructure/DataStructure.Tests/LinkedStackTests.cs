using DataStructure.Stacks;
using System;
using Xunit;

namespace DataStructure.Tests
{
    public class LinkedStackTests
    {
        [Fact]
        public void IsEmpty_NewStack_ReturnsTrue()
        {
            //Arrange
            var stack = new LinkedStack<int>();

            //Act
            var isEmpty = stack.IsEmpty();

            //Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void IsEmpty_AfterPushAItem_ReturnsFalse()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            stack.Push(10);

            //Act
            var isEmpty = stack.IsEmpty();

            //Assert
            Assert.False(isEmpty);
        }

        [Fact]
        public void IsEmpty_AfterPushAndPopItem_ReturnsTrue()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            stack.Push(10);
            stack.Pop();

            //Act
            var isEmpty = stack.IsEmpty();

            //Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void IsEmpty_AfterPushAndPeekItem_ReturnsFalse()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            stack.Push(10);
            stack.Peek();

            //Act
            var isEmpty = stack.IsEmpty();

            //Assert
            Assert.False(isEmpty);
        }

        [Fact]
        public void IsEmpty_AfterClearTheStack_ReturnsTrue()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            stack.Push(10);
            stack.Clear();

            //Act
            var isEmpty = stack.IsEmpty();

            //Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void Push_TwoItemsToEmptyStack_CountEquals2()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            var expected = 2;

            //Act
            stack.Push(1);
            stack.Push(2);

            //Assert
            Assert.Equal(expected, stack.Count);
        }

        [Fact]
        public void Pop_StackWithSingleItem_ReturnsSameItem()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            var expected = 15;
            stack.Push(expected);

            //Act
            var actual = stack.Pop();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Pop_StackWithSeveralItems_ReturnsTheLastItemPushed()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            var expected = 15;
            stack.Push(20);
            stack.Push(1);
            stack.Push(expected);

            //Act
            var actual = stack.Pop();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Pop_StackWithSingleItem_CountShouldDecreasingIn1()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            stack.Push(15);
            var expected = stack.Count - 1;

            //Act
            stack.Pop();

            //Assert
            Assert.Equal(expected, stack.Count);
        }

        [Fact]
        public void Pop_StackWithSeveralItems_CountShouldDecreasingIn1()
        {
            //Arrange
            var stack = new LinkedStack<int>();            
            stack.Push(20);
            stack.Push(1);
            stack.Push(15);
            var expected = stack.Count - 1;

            //Act
            stack.Pop();

            //Assert
            Assert.Equal(expected, stack.Count);
        }

        [Fact]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            //Arrange
            var stack = new LinkedStack<int>();

            //Assert
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Peek_StackWithSingleItem_ReturnsSameItem()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            var expected = 15;
            stack.Push(expected);

            //Act
            var actual = stack.Peek();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Peek_StackWithSeveralItems_ReturnsTheLastItemPushed()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            var expected = 15;
            stack.Push(20);
            stack.Push(1);
            stack.Push(expected);

            //Act
            var actual = stack.Peek();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Peek_StackWithSingleItem_CountShouldNotChange()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            stack.Push(15);
            var expected = stack.Count;

            //Act
            stack.Peek();

            //Assert
            Assert.Equal(expected, stack.Count);
        }

        [Fact]
        public void Peek_StackWithSeveralItems_CountShouldNotChange()
        {
            //Arrange
            var stack = new LinkedStack<int>();
            stack.Push(20);
            stack.Push(1);
            stack.Push(15);
            var expected = stack.Count;

            //Act
            stack.Peek();

            //Assert
            Assert.Equal(expected, stack.Count);
        }

        [Fact]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            //Arrange
            var stack = new LinkedStack<int>();

            //Assert
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
    }
}
