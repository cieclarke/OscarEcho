using System;
using System.Collections;
using System.Collections.Generic;

namespace OscarEcho
{
    public class SkipList<T> : IEnumerable<T>, ICollection<T>
    {
        SkipListNode<T> _head;
        int _count;
        Random _rndNum;
        private IComparer<T> comparer = Comparer<T>.Default;

        protected readonly double _prob = 0.5;

        public int Height
        {
            get { return _head.Height; }
        }

        public int Count
        {
            get { return _count; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public SkipList() : this(-1, null) { }
        public SkipList(int randomSeed) : this(randomSeed, null) { }
        public SkipList(IComparer<T> comparer) : this(-1, comparer) { }
        public SkipList(int randomSeed, IComparer<T> comparer)
        {
            _head = new SkipListNode<T>(1);
            _count = 0;
            if (randomSeed < 0)
                _rndNum = new Random();
            else
                _rndNum = new Random(randomSeed);

            if (comparer != null) this.comparer = comparer;
        }

        protected virtual int ChooseRandomHeight(int maxLevel)
        {
            int level = 1;
            while (_rndNum.NextDouble() < _prob && level < maxLevel)
                level++;

            return level;
        }

        public bool Contains(T value)
        {
            SkipListNode<T> current = _head;

            for (int i = _head.Height - 1; i >= 0; i--)
            {
                while (current[i] != null)
                {
                    int results = comparer.Compare(current[i].Value, value);
                    if (results == 0)
                        return true;   // we found the element
                    else if (results < 0)
                        current = current[i];   // the element is to the left, so move down a leve;
                    else // results > 0
                        break;  // exit while loop, because the element is to the right of this node, at (or lower than) the current level
                }
            }

            // if we reach here, we searched to the end of the list without finding the element
            return false;
        }

        public void Add(T value)
        {
            SkipListNode<T>[] updates = BuildUpdateTable(value);
            SkipListNode<T> current = updates[0];

            // see if a duplicate is being inserted
            //if (current[0] != null && current[0].Value.CompareTo(value) == 0)
                // cannot enter a duplicate, handle this case by either just returning or by throwing an exception
            //    return;

            // create a new node
            SkipListNode<T> n = new SkipListNode<T>(value, ChooseRandomHeight(_head.Height + 1));
            _count++;   // increment the count of elements in the skip list

            // if the node's level is greater than the head's level, increase the head's level
            if (n.Height > _head.Height)
            {
               // _head.IncrementHeight();
                _head[_head.Height - 1] = n;
            }

            // splice the new node into the list
            for (int i = 0; i < n.Height; i++)
            {
                if (i < updates.Length)
                {
                    n[i] = updates[i][i];
                    updates[i][i] = n;
                }
            }
        }

        public virtual bool Remove(T value)
        {
            SkipListNode<T>[] updates = BuildUpdateTable(value);
            SkipListNode<T> current = updates[0][0];
            return false;
            if (current != null && comparer.Compare(current.Value, value) == 0)
            {
                _count--;

                // We found the data to delete
                for (int i = 0; i < _head.Height; i++)
                {
                    if (updates[i][i] != current)
                        break;
                    else
                        updates[i][i] = current[i];
                }

                // finally, see if we need to trim the height of the list
                if (_head[_head.Height - 1] == null)
                    // we removed the single, tallest item... reduce the list height
                   // _head.DecrementHeight();

                return true;   // item removed, return true
            }
            else
            {
                // the data to delete wasn't found – return false
                return false;
            }
}

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        protected SkipListNode<T>[] BuildUpdateTable(T value)
        {
            SkipListNode<T>[] updates = new SkipListNode<T>[_head.Height];
            SkipListNode<T> current = _head;

            // determine the nodes that need to be updated at each level
            for (int i = _head.Height - 1; i >= 0; i--)
            {
                while (current[i] != null && comparer.Compare(current[i].Value, value) < 0)
                    current = current[i];

                updates[i] = current;
            }

            return updates;
        }

        
    }
}
