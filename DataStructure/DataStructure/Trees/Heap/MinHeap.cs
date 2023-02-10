using System;

namespace DataStructure.Trees.Heap
{
    public class MinHeap<T> where T : IKey
    {
        private T[] _nodes;

        public int Count { get; private set; }

        public MinHeap(int count)
        {
            Count = 0;
            _nodes = new T[count];
        }

        public MinHeap(T[] values)
        {
            Count = values.Length;
            _nodes = new T[values.Length * 2];
            Array.Copy(values, _nodes, Count);
            ConvertToValidHeap(_nodes);
        }

        /// <summary>
        /// O(log n)
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Insert(T value)
        {
            if (Count >= _nodes.Length)
            {
                throw new InvalidOperationException(nameof(Insert));
            }

            _nodes[Count] = value;

            var i = Count;
            while ((i - 1) / 2 >= 0 && _nodes[i].Key < _nodes[(i - 1) / 2].Key)
            {
                var aux = _nodes[(i - 1) / 2];
                _nodes[(i - 1) / 2] = _nodes[i];
                _nodes[i] = aux;

                i = (i - 1) / 2;
            }

            Count++;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T GetMin()
        {
            if (Count > 0)
                return _nodes[0];

            throw new InvalidOperationException(nameof(GetMin));
        }

        /// <summary>
        /// O(log n)
        /// </summary>
        /// <returns>Returns the min item and delete it from the heap</returns>
        public T ExtractMin()
        {
            var min = _nodes[0];

            _nodes[0] = _nodes[Count - 1];
            Count--;

            Heapify(_nodes, 0, Count);
            return min;
        }

        /// <summary>
        /// O(nlogn)
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private void ConvertToValidHeap(T[] values)
        {
            var lastNoLeafNode = values.Length / 2 - 1;

            for (var i = lastNoLeafNode; i >= 0; i--)
            {
                Heapify(values, i, values.Length);
            }
        }

        /// <summary>
        /// O(logn)
        /// </summary>
        /// <param name="values"></param>
        /// <param name="index"></param>
        private void Heapify(T[] values, int index, int count)
        {
            var minValue = values[index];
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;

            if (count - 1 >= leftChildIndex)
            {
                int? minIndex = null;
                if (minValue.Key > values[leftChildIndex].Key)
                {
                    minValue = values[leftChildIndex];
                    minIndex = leftChildIndex;
                }

                if (count - 1 >= rightChildIndex && minValue.Key > values[rightChildIndex].Key)
                {
                    minValue = values[rightChildIndex];
                    minIndex = rightChildIndex;
                }

                if (minIndex.HasValue)
                {
                    values[minIndex.Value] = values[index];
                    values[index] = minValue;
                    Heapify(values, minIndex.Value, count);
                }
            }
        }
    }

    public interface IKey
    {
        int Key { get; }
    }
}
