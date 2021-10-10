using DataStructure.Common;
using System;

namespace DataStructure.Queue
{
    public class LinkedQueue<T>
    {
        private DoubleLinkedEntry<T>? _first = null;
        private DoubleLinkedEntry<T>? _last = null;

        public long Count { get; private set; }

        public bool IsEmpty()
        {
            return (Count == 0);
        }

        public void Enqueue(T value)
        {
            var newItem = new DoubleLinkedEntry<T>(value);

            if (IsEmpty())
            {
                _first = _last = newItem;
            }
            else 
            {
                newItem.Previous = _last;
                _last!.Next = newItem;

                _last = newItem;
            }

            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var value = _first!.Value;

            if (Count == 1)
            {
                Clear();
            }
            else 
            {
                _first = _first.Next;
                _first!.Previous = null;
                Count--;
            }

            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            
            return _first!.Value;
        }

        public void Clear()
        {
            Count = 0;
            _first = null;
            _last = null;
        }
    }
}
