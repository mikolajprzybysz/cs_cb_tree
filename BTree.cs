using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CBTree
{
    class BTree<T>
    {
        private BTreeNode<T> Root = new BTreeNode<T>();

        // Add a new item to the tree.
        public void AddItem(string new_key, T new_value)
        {
            string up_key = "";
            T up_value = default(T);
            BTreeNode<T> up_node = null;
            Root.AddItem(new_key, new_value, ref up_key, ref up_value, ref up_node);

            // See if there was a root bucket split.
            if (up_node != null)
            {
                BTreeNode<T> new_root = new BTreeNode<T>();
                new_root.Keys[0] = up_key;
                new_root.Values[0] = up_value;
                new_root.Children[0] = Root;
                new_root.Children[1] = up_node;
                new_root.NumKeysUsed = 1;

                Root = new_root;
            }
        }

        // Find this item.
        public T FindItem(string target_key)
        {
            return Root.FindItem(target_key);
        }

        // Remove this item.
        public void RemoveItem(string target_key)
        {
            Root.RemoveItem(target_key);

            // See if the root now has no keys.
            if (Root.NumKeysUsed < 1)
            {
                if (Root.Children[0] != null) Root = Root.Children[0];
            }
        }

        // return a string representation of the tree.
        public override string ToString()
        {
            return Root.ToString();
        }

        // Add a representation of the tree to a ListBox.
        public void AddToListBox(ListBox lst)
        {
            Root.AddToListBox(lst, 0);
        }
    }
}
