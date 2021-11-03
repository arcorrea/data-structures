using DataStructure.Trees;
using System;
using System.Collections.Generic;

namespace DataStructure.Tests.Utils
{
    public static class LeafTreeHelper
    {
        public static bool AreInternalNoteWithoutValues<TKey, TValue>(this LeafTree<TKey, TValue> tree) where TKey : IComparable
        {
            if (tree.IsEmpty())
                return true;

            var nodes = new Queue<LeafTree<TKey, TValue>>();
            nodes.Enqueue(tree);

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();

                if (!node.IsLeaf())
                {
                    if (node.Value != null && !node.Value.Equals(tree.EmptyValue))
                        return false;

                    if (node.Left != null)
                        nodes.Enqueue(node.Left);

                    if (node.Right != null)
                        nodes.Enqueue(node.Right);
                }
            }

            return true;
        }

        public static bool DoLeavesNodeHasValues<TKey, TValue>(this LeafTree<TKey, TValue> tree) where TKey : IComparable
        {
            if (tree.IsEmpty())
                return true;

            var nodes = new Queue<LeafTree<TKey, TValue>>();
            nodes.Enqueue(tree);

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();

                if (node.IsLeaf() && (node.Value == null || node.Value.Equals(tree.EmptyValue)))
                {
                     return false;
                }

                if (node.Left != null)
                    nodes.Enqueue(node.Left);

                if (node.Right != null)
                    nodes.Enqueue(node.Right);
            }

            return true;
        }

        public static bool HasSortedNodes<TKey, TValue>(this LeafTree<TKey, TValue> tree) where TKey : IComparable
        {
            if (tree.IsEmpty() || tree.IsLeaf())
                return true;

            if (tree.Left != null && tree.Left.Key.CompareTo(tree.Key) >= 0)
                return false;
            if (tree.Right != null && tree.Right.Key.CompareTo(tree.Key) < 0)
                return false;

            return (tree.Left?.HasSortedNodes() ?? true) && (tree.Right?.HasSortedNodes() ?? true);
        }

        public static bool IsLeaf<TKey, TValue>(this LeafTree<TKey, TValue> node) where TKey : IComparable
        {
            return node.Left == null && node.Right == null;
        }
    }
}
