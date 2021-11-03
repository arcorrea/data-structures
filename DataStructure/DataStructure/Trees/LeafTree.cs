using System;

namespace DataStructure.Trees
{
    public class LeafTree<TKey, TValue> where TKey: IComparable
    {
        public TKey? EmptyKey { get; }
        public TValue? EmptyValue { get; }

        public TKey? Key { get; private set; }
        public TValue? Value { get; private set; }
        public LeafTree<TKey, TValue>? Left { get; private set; }
        public LeafTree<TKey, TValue>? Right { get; private set; }


        public LeafTree(TKey? emptyKey = default, TValue? emptyValue = default)
        {
            Key = EmptyKey = emptyKey;
            Value = EmptyValue = emptyValue;
        }

        public LeafTree(TKey key, TValue? value, TKey? emptyKey = default, TValue? emptyValue = default) : this(emptyKey, emptyValue)
        {
            Key = key;
            Value = value;
        }



        public TValue? Find(TKey key)
        {
            if (IsEmpty())
                return EmptyValue;

            if (IsLeaf(this))
                return key.CompareTo(Key) == 0 ? Value : EmptyValue;

            var currentNode = key.CompareTo(Key) < 0 ? Left : Right;
            while (currentNode != null && !IsLeaf(currentNode))
            {
                currentNode = key.CompareTo(currentNode.Key) < 0 ? currentNode.Left : currentNode.Right;
            }

            if (currentNode == null)
                return EmptyValue;

            return key.CompareTo(currentNode.Key) == 0 ? currentNode.Value : EmptyValue;
        }

        /// <summary>
        /// Assumes all the keys are unique.
        /// Throw an exception if you try to insert an empty key or duplicated key.
        /// </summary>
        public void Insert(TKey key, TValue? value)
        {
            if (key == null || key.CompareTo(EmptyKey) == 0)
                throw new ArgumentNullException();

            if (IsEmpty())
            {
                Key = key;
                Value = value;
            }
            else 
            {
                var newNode = new LeafTree<TKey, TValue>(key, value, EmptyKey, EmptyValue);
                var currentNode = this;
                var added = false;

                do
                {
                    if (IsLeaf(currentNode))
                    {
                        if (key.CompareTo(currentNode.Key) == 0)
                            throw new ArgumentException($"Duplicated key {key}");

                        var oldNode = new LeafTree<TKey, TValue>(currentNode.Key!, currentNode.Value, EmptyKey, EmptyValue);

                        currentNode.Value = EmptyValue;
                        if (key.CompareTo(currentNode.Key) < 0)
                        {
                            currentNode.Left = newNode;
                            currentNode.Right = oldNode;
                        }
                        else
                        {
                            currentNode.Right = newNode;
                            currentNode.Left = oldNode;
                            currentNode.Key = key;
                        }

                        added = true;
                    }
                    else
                    {
                        if (key.CompareTo(currentNode.Key) < 0)
                        {
                            if (currentNode.Left == null)
                            {
                                currentNode.Left = newNode;
                                added = true;
                            }
                            else
                            {
                                currentNode = currentNode.Left;
                            }
                        }
                        else
                        {
                            if (currentNode.Right == null)
                            {
                                currentNode.Right = newNode;
                                added = true;
                            }
                            else
                            {
                                currentNode = currentNode.Right;
                            }
                        }
                    }
                } while (!added);
            }
        }

        /// <summary>
        /// Throw an exception if you try to delete with an empty key.
        /// </summary>
        public TValue? Delete(TKey key)
        {
            if (key == null || key.CompareTo(EmptyKey) == 0)
                throw new ArgumentNullException();

            if (IsEmpty())
                return EmptyValue;

            var deletedValue = EmptyValue;
            if (IsLeaf(this))
            {
                if (key.CompareTo(Key) == 0)
                {
                    deletedValue = Value;

                    Key = EmptyKey;
                    Value = EmptyValue;
                }

                return deletedValue;
            }

            LeafTree<TKey, TValue>? grandParentNode = null;
            var parentNode = this;
            var currentNode = key.CompareTo(parentNode.Key) < 0 ? parentNode.Left : parentNode.Right;

            while (currentNode != null && !IsLeaf(currentNode))
            {
                grandParentNode = parentNode;
                parentNode = currentNode;
                currentNode = key.CompareTo(parentNode.Key) < 0 ? parentNode.Left : parentNode.Right;
            }

            if (currentNode != null && key.CompareTo(currentNode.Key) == 0)
            {
                deletedValue = currentNode.Value;
                if (key.CompareTo(parentNode.Key) < 0)
                {
                    if(parentNode.Right != null || grandParentNode == null)
                    {
                        Copy(parentNode.Right, parentNode);
                    }
                    else
                    {
                        PruneBranchThatShouldContains(grandParentNode, key);
                    }
                }
                else
                {
                    if(parentNode.Left != null || grandParentNode == null)
                    {
                        Copy(parentNode.Left, parentNode);
                    }
                    else
                    {
                        PruneBranchThatShouldContains(grandParentNode, key);
                    }
                }
            }

            return deletedValue;
        }
        
        public bool IsEmpty()
        {
            return Key == null || Key.CompareTo(EmptyKey) == 0;
        }


        private void PruneBranchThatShouldContains(LeafTree<TKey, TValue> tree, TKey key)
        {
            if (key.CompareTo(tree.Key) < 0)
            {
                tree.Left = null;
            }
            else
            {
                tree.Right = null;
            }
        }

        private bool IsLeaf(LeafTree<TKey, TValue> node)
        {
            return (node.Left == null && node.Right == null);
        }

        private void Copy(LeafTree<TKey, TValue>? from, LeafTree<TKey, TValue> to)
        {
            if (from != null)
            {
                to.Key = from.Key;
                to.Value = from.Value;
                to.Left = from.Left;
                to.Right = from.Right;
            }
            else
            {
                to.Key = EmptyKey;
                to.Value = EmptyValue;
                to.Left = null;
                to.Right = null;
            }
        }

    }
}
