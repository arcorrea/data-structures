using DataStructure.Common;

namespace DataStructure.Stack
{
    public class LinkedStack<T>
    {
        private SingleLinkedEntry<T>? _top = null;

        public long Count { get; private set; }

        public bool IsEmpty()
        {
            return (Count == 0);
        }

        public void Push(T value)
        {
            _top = new SingleLinkedEntry<T>(value, next: _top);
            Count++;
        }

        public T? Pop()
        {
            if(IsEmpty())
            {
                return default;
            }

            var aux = _top!.Value;
            _top = _top.Next;
            Count--;
            return aux;
        }

        public T? Peek()
        {
            return IsEmpty() ? default : _top!.Value;
        }

        public void Clear()
        {
            Count = 0;
            _top = null;
        }
    }
}
