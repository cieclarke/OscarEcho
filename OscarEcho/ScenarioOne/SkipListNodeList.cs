using System;
namespace OscarEcho
{
    public class SkipListNodeList<T> : NodeList<T>
    {
        public SkipListNodeList(int height) : base(height) { }

        internal void IncrementHeight()
        {
            // add a dummy entry
            base.Items.Add(default(Node<T>));
        }

        internal void DecrementHeight()
        {
            // delete the last entry
            base.Items.RemoveAt(base.Items.Count - 1);
        }
    }
}
