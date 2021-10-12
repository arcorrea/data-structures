using DataStructure.Queue;
using System;
using Xunit;

namespace DataStructure.Tests
{
    public class LinkedQueueTests
    {
        [Fact]
        public void IsEmpty_NewQueue_ReturnsTrue()
        {
            //Arrange
            var queue = new LinkedQueue<int>();

            //Act
            var isEmpty = queue.IsEmpty();

            //Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void IsEmpty_AfterEnqueueAItem_ReturnsFalse()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            queue.Enqueue(10);

            //Act
            var isEmpty = queue.IsEmpty();

            //Assert
            Assert.False(isEmpty);
        }

        [Fact]
        public void IsEmpty_AfterEnqueueAndDequeueAnItem_ReturnsTrue()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            queue.Enqueue(10);
            queue.Dequeue();

            //Act
            var isEmpty = queue.IsEmpty();

            //Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void IsEmpty_AfterClearTheQueue_ReturnsTrue()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            queue.Enqueue(10);
            queue.Clear();

            //Act
            var isEmpty = queue.IsEmpty();

            //Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void Enqueue_TwoItemsToEmptyQueue_CountEquals2()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            var expected = 2;

            //Act
            queue.Enqueue(1);
            queue.Enqueue(2);

            //Assert
            Assert.Equal(expected, queue.Count);
        }

        [Fact]
        public void Dequeue_QueueWithSingleItem_ReturnsTheFirstItem()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            var expected = 15;
            queue.Enqueue(expected);

            //Act
            var actual = queue.Dequeue();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Dequeue_QueueWithSeveralItems_ReturnsTheFirstItem()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            var expected = 15;
            queue.Enqueue(expected);
            queue.Enqueue(20);
            queue.Enqueue(1);

            //Act
            var actual = queue.Dequeue();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Dequeue_QueueWithSingleItem_CountShouldDecreasingIn1()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            queue.Enqueue(15);
            var expected = queue.Count - 1;

            //Act
            queue.Dequeue();

            //Assert
            Assert.Equal(expected, queue.Count);
        }

        [Fact]
        public void Dequeue_QueueWithSeveralItems_CountShouldDecreasingIn1()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            queue.Enqueue(20);
            queue.Enqueue(1);
            queue.Enqueue(15);
            var expected = queue.Count - 1;

            //Act
            queue.Dequeue();

            //Assert
            Assert.Equal(expected, queue.Count);
        }

        [Fact]
        public void Dequeue_EmptyQueue_ThrowInvalidOperationException()
        {
            //Arrange
            var queue = new LinkedQueue<int>();

            //Assert
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Fact]
        public void Peek_QueueWithSingleItem_ReturnsTheFirstItem()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            var expected = 15;
            queue.Enqueue(expected);

            //Act
            var actual = queue.Peek();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Peek_QueueWithSeveralItems_ReturnsTheFirstItem()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            var expected = 15;
            queue.Enqueue(expected);
            queue.Enqueue(20);
            queue.Enqueue(1);

            //Act
            var actual = queue.Peek();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Peek_QueueWithSingleItem_CountShouldNotChange()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            queue.Enqueue(15);
            var expected = queue.Count;

            //Act
            queue.Peek();

            //Assert
            Assert.Equal(expected, queue.Count);
        }

        [Fact]
        public void Peek_QueueWithSeveralItems_CountShouldNotChange()
        {
            //Arrange
            var queue = new LinkedQueue<int>();
            queue.Enqueue(20);
            queue.Enqueue(1);
            queue.Enqueue(15);
            var expected = queue.Count;

            //Act
            queue.Peek();

            //Assert
            Assert.Equal(expected, queue.Count);
        }

        [Fact]
        public void Peek_EmptyQueue_ThrowInvalidOperationException()
        {
            //Arrange
            var queue = new LinkedQueue<int>();

            //Assert
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
    }
}
