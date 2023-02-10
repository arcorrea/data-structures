using System;

namespace DataStructure.Trees.SegmentTree
{
    public class SumSegmentTree
    {
        private long[] _nodes;
        public int Count { get; private set; }

        public SumSegmentTree(int[] arr)
        {
            var h = Math.Ceiling(Math.Log2(arr.Length));
            _nodes = new long[(int)Math.Pow(2, h + 1) - 1];
            Count = arr.Length;
            CreateFromArray(arr, 0, arr.Length - 1, 0);
        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start">0</param>
        /// <param name="end">n-1</param>
        /// <param name="index">0</param>
        /// <returns></returns>
        private long CreateFromArray(int[] arr, int start, int end, int index)
        {
            if (start == end)
            {
                _nodes[index] = arr[start];
                return arr[start];
            }

            var mid = (start + end) / 2;
            _nodes[index] = CreateFromArray(arr, start, mid, index * 2 + 1) +
                            CreateFromArray(arr, mid + 1, end, index * 2 + 2);

            return _nodes[index];
        }

        public long GetSum(int qStart, int qEnd)
        {
            return GetSum(0, Count - 1, 0, qStart, qEnd);
        }

        /// <summary>
        /// O(log n)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="index"></param>
        /// <param name="qStart"></param>
        /// <param name="qEnd"></param>
        /// <returns></returns>
        private long GetSum(int start, int end, int index, int qStart, int qEnd)
        {
            if (start > qEnd || end < qStart) // what are you looking is not in the range (The interception is empty)
            {
                return 0;
            }

            if (qStart <= start && end <= qEnd) //what are you looking is a super set of the range.
            {
                return _nodes[index];
            }

            var mid = (start + end) / 2;
            return GetSum(start, mid, index * 2 + 1, qStart, qEnd) +
                   GetSum(mid + 1, end, index * 2 + 2, qStart, qEnd);
        }

        private void Update(int start, int end, int index, int indexToUpdate, int diff)
        {
            if (indexToUpdate < start || indexToUpdate > end)
                return;

            var mid = (start + end) / 2;
            _nodes[index] = _nodes[index] + diff;
            if (start != end)
            {
                Update(start, mid, index * 2 + 1, indexToUpdate, diff);
                Update(mid + 1, end, index * 2 + 2, indexToUpdate, diff);
            }
        }

        public void Print()
        {
            foreach (var n in _nodes)
            {
                Console.Write(n + ", ");
            }
        }
    }
}
