using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CBTree
{
    class BTreeNode<T>
    {
        private const int HALF_NUM_KEYS = 2;
        private const int KEYS_PER_NODE = 2 * HALF_NUM_KEYS;
        private const int CHILDREN_PER_NODE = KEYS_PER_NODE + 1;
        public int NumKeysUsed = 0;
        public string[] Keys = new string[KEYS_PER_NODE];
        public T[] Values = new T[KEYS_PER_NODE];
        public BTreeNode<T>[] Children = new BTreeNode<T>[CHILDREN_PER_NODE];

        // Find an item in this subtree.
        public T FindItem(string target_key)
        {
            // Find the key after the spot where this item goes.
            int spot = 0;
            while (spot < NumKeysUsed)
            {
                // See if this key comes after the new value.
                if (String.Compare(Keys[spot], target_key) >= 0) break;
                spot++;
            }

            // If we found the item, return it.
            if ((spot < NumKeysUsed) && (Keys[spot] == target_key)) return Values[spot];

            // If there's no link to follow, we're at a leaf
            // and didn't find it so return null.
            if (Children[spot] == null) return default(T);

            // Look in the proper subtree.
            return Children[spot].FindItem(target_key);
        }

        // Add a value to this subtree.
        public void AddItem(string new_key, T new_value, ref string up_key, ref T up_value, ref BTreeNode<T> up_node)
        {
            // Find the key after the spot where this item goes.
            int spot = 0;
            while (spot < NumKeysUsed)
            {
                // See if this key comes after the new value.
                if (String.Compare(Keys[spot], new_key) >= 0) break;
                spot++;
            }

            // See if we found it.
            if ((spot < NumKeysUsed) && (Keys[spot] == new_key))
            {
                // The item is already here.
                throw new Exception("Insert error. Cannot insert item with duplicate key value '" + new_key + "'");
            }

            // See if we are in a leaf node.
            if (Children[0] == null)
            {
                // This is a leaf.
                AddItemToNode(spot, new_key, new_value, null, ref up_key, ref up_value, ref up_node);
            } else {
                // This is not a leaf. Move into the proper subtree.
                Children[spot].AddItem(new_key, new_value, ref up_key, ref up_value, ref up_node);

                // See if we had a bucket split.
                if (up_node != null)
                {
                    // We had a bucket split. Add the new bucket here.
                    AddItemToNode(spot, up_key, up_value, up_node, ref up_key, ref up_value, ref up_node);
                }
            }
        }

        // Add the new item to this node, if it fits.
        private void AddItemToNode(int spot,
            string new_key, T new_value, BTreeNode<T> new_child,
            ref string up_key, ref T up_value, ref BTreeNode<T> up_child)
        {
            // See if we have room.
            if (NumKeysUsed < KEYS_PER_NODE)
            {
                // There is room here.
                AddItemInNodeWithRoom(spot, new_key, new_value, new_child);
                up_key = null;
                up_value = default(T);
                up_child = null;
            } else {
                // There is no room here.
                SplitNode(spot, new_key, new_value, new_child, ref up_key, ref up_value, ref up_child);
            }
        }

        // Add a new item in a leaf node that has room.
        private void AddItemInNodeWithRoom(int spot, string new_key, T new_value, BTreeNode<T> new_child)
        {
            // Move the existing items over to make an empty spot at Children[after].
            Array.Copy(this.Keys, spot, this.Keys, spot + 1, NumKeysUsed - spot);
            Array.Copy(this.Values, spot, this.Values, spot + 1, NumKeysUsed - spot);
            Array.Copy(this.Children, spot + 1, this.Children, spot + 2, NumKeysUsed - spot);

            // Insert the new item.
            this.Keys[spot] = new_key;
            this.Values[spot] = new_value;
            this.Children[spot + 1] = new_child;

            NumKeysUsed++;
        }

        // We don't have room. Split the node.
        private void SplitNode(int spot, string new_key, T new_value, BTreeNode<T> new_child, ref string up_key, ref T up_value, ref BTreeNode<T> up_child)
        {
            // Make arrays holding all of the keys, values, and children.
            string[] new_keys = new string[KEYS_PER_NODE + 1];
            Array.Copy(this.Keys, 0, new_keys, 0, spot);
            new_keys[spot] = new_key;
            Array.Copy(this.Keys, spot, new_keys, spot + 1, KEYS_PER_NODE - spot);

            T[] new_values = new T[KEYS_PER_NODE + 1];
            Array.Copy(this.Values, 0, new_values, 0, spot);
            new_values[spot] = new_value;
            Array.Copy(this.Values, spot, new_values, spot + 1, KEYS_PER_NODE - spot);

            BTreeNode<T>[] new_children = new BTreeNode<T>[CHILDREN_PER_NODE + 1];
            Array.Copy(this.Children, 0, new_children, 0, spot + 1);
            new_children[spot + 1] = new_child;
            Array.Copy(this.Children, spot + 1, new_children, spot + 2, KEYS_PER_NODE - spot);

            // Copy the first half of the items into this node.
            Array.Copy(new_keys, 0, this.Keys, 0, HALF_NUM_KEYS);
            Array.Copy(new_values, 0, this.Values, 0, HALF_NUM_KEYS);
            Array.Copy(new_children, 0, this.Children, 0, HALF_NUM_KEYS + 1);
            Array.Clear(this.Keys, HALF_NUM_KEYS, HALF_NUM_KEYS);
            Array.Clear(this.Values, HALF_NUM_KEYS, HALF_NUM_KEYS);
            Array.Clear(this.Children, HALF_NUM_KEYS + 1, HALF_NUM_KEYS);
            this.NumKeysUsed = HALF_NUM_KEYS;

            // Set the up key and value.
            up_key = new_keys[HALF_NUM_KEYS];
            up_value = new_values[HALF_NUM_KEYS];

            // Make the new node to pass up.
            up_child = new BTreeNode<T>();
            Array.Copy(new_keys, HALF_NUM_KEYS + 1, up_child.Keys, 0, HALF_NUM_KEYS);
            Array.Copy(new_values, HALF_NUM_KEYS + 1, up_child.Values, 0, HALF_NUM_KEYS);
            Array.Copy(new_children, HALF_NUM_KEYS + 1, up_child.Children, 0, HALF_NUM_KEYS + 1);
            up_child.NumKeysUsed = HALF_NUM_KEYS;
        }

        // Add this item's subtree to a ListBox.
        public void AddToListBox(ListBox lst, int indent)
        {
            for (int i = 0; i < NumKeysUsed; i++)
            {
                if (Children[i] != null)
                {
                    Children[i].AddToListBox(lst, indent + 4);
                }
                lst.Items.Add(new string(' ', indent) + Values[i].ToString());
            }
            if (NumKeysUsed > 0)
            {
                if (Children[NumKeysUsed] != null)
                {
                    Children[NumKeysUsed].AddToListBox(lst, indent + 4);
                }
            }
        }

        // Remove this item.
        public void RemoveItem(string target_key)
        {
            // Find the key after the spot where this item goes.
            int spot = 0;
            while (spot < NumKeysUsed)
            {
                // See if this key comes after the new value.
                if (String.Compare(Keys[spot], target_key) >= 0) break;
                spot++;
            }

            // See if we found it.
            if ((spot < NumKeysUsed) && (Keys[spot] == target_key))
            {
                // The item is here.
                // See if we are a leaf node.
                if (Children[0] == null)
                {
                    // We're a leaf node. Remove the item.
                    RemoveItemFromNode(spot);
                } else {
                    // We're not a leaf node.
                    // Find the rightmost item to the item's left.
                    string rightmost_key = "";
                    T rightmost_value = default(T);
                    Children[spot].SwapRightmost(target_key, ref rightmost_key, ref rightmost_value);

                    // Save the rightmost values.
                    Keys[spot] = rightmost_key;
                    Values[spot] = rightmost_value;

                    // Delete the rightmost item.
                    Children[spot].RemoveItem(target_key);
                }
            } else {
                // The item is not here.
                // See if we are a leaf node.
                if (Children[0] == null)
                {
                    // We didn't find the target key.
                    throw new Exception("Delete error. Cannot find item with key value '" + target_key + "'");
                }

                // Search deeper.
                Children[spot].RemoveItem(target_key);
            }

            // See if we are a leaf node.
            if (Children[0] != null)
            {
                // We're not a leaf.
                // See if our child got too small.
                if (Children[spot].NumKeysUsed < HALF_NUM_KEYS)
                {
                    // The child is too small.
                    // Try to redistribute.
                    if ((spot > 0) && (Children[spot - 1].NumKeysUsed > HALF_NUM_KEYS))
                    {
                        // Redistribute with the left sibling.
                        RebalanceSiblings(Children[spot - 1], Children[spot], ref Keys[spot - 1], ref Values[spot - 1]);
                    } else if ((spot < HALF_NUM_KEYS - 1) && (Children[spot + 1].NumKeysUsed > HALF_NUM_KEYS))
                    {
                        // Redistribute with the right sibling.
                        RebalanceSiblings(Children[spot], Children[spot + 1], ref Keys[spot], ref Values[spot]);
                    } else {
                        // We cannot redistribute. Merge.
                        if (spot > 0)
                        {
                            // Merge with the left sibling.
                            MergeSiblings(spot - 1, spot, Keys[spot - 1], Values[spot - 1]);
                        } else {
                            // Merge with the right sibling.
                            MergeSiblings(spot, spot + 1, Keys[spot], Values[spot]);
                        }
                    }
                }
            }
        }

        // Remove the item from the given spot.
        private void RemoveItemFromNode(int spot)
        {
            Array.Copy(this.Keys, spot + 1, this.Keys, spot, NumKeysUsed - spot - 1);
            Array.Copy(this.Values, spot + 1, this.Values, spot, NumKeysUsed - spot - 1);
            Array.Copy(this.Children, spot + 2, this.Children, spot + 1, NumKeysUsed - spot - 1);
            this.NumKeysUsed--;
            this.Keys[this.NumKeysUsed] = null;
            this.Values[this.NumKeysUsed] = default(T);
            this.Children[this.NumKeysUsed + 1] = null;
        }

        // Find the rightmost item in this node's subtree.
        private void SwapRightmost(string target_key, ref string rightmost_key, ref T rightmost_value)
        {
            // See if we are a leaf node.
            if (Children[0] == null)
            {
                // We're a leaf.
                // Get our rightmost item's data for return.
                rightmost_key = Keys[NumKeysUsed - 1];
                rightmost_value = Values[NumKeysUsed - 1];

                // Save the target key in this item.
                Keys[NumKeysUsed - 1] = target_key;
            } else {
                // We're not a leaf. Follow our rightmost link.
                Children[NumKeysUsed].SwapRightmost(target_key, ref rightmost_key, ref rightmost_value);
            }
        }

        // Move items between the two nodes to balance them.
        private static void RebalanceSiblings(BTreeNode<T> left_node, BTreeNode<T> right_node, ref string middle_key, ref T middle_value)
        {
            // Make arrays holding all of the keys, values, and children.
            int num_keys = left_node.NumKeysUsed + right_node.NumKeysUsed + 1;
            int mid = left_node.NumKeysUsed;
            string[] new_keys = new string[num_keys];
            Array.Copy(left_node.Keys, 0, new_keys, 0, left_node.NumKeysUsed);
            new_keys[mid] = middle_key;
            Array.Copy(right_node.Keys, 0, new_keys, mid + 1, right_node.NumKeysUsed);

            T[] new_values = new T[num_keys];
            Array.Copy(left_node.Values, 0, new_values, 0, left_node.NumKeysUsed);
            new_values[mid] = middle_value;
            Array.Copy(right_node.Values, 0, new_values, mid + 1, right_node.NumKeysUsed);

            BTreeNode<T>[] new_children = new BTreeNode<T>[num_keys + 1];
            Array.Copy(left_node.Children, 0, new_children, 0, left_node.NumKeysUsed + 1);
            Array.Copy(right_node.Children, 0, new_children, mid + 1, right_node.NumKeysUsed + 1);

            // Copy the first half of the items into the left node.
            int num_left = (int)((num_keys - 1) / 2);
            Array.Copy(new_keys, 0, left_node.Keys, 0, num_left);
            Array.Copy(new_values, 0, left_node.Values, 0, num_left);
            Array.Copy(new_children, 0, left_node.Children, 0, num_left + 1);
            Array.Clear(left_node.Keys, num_left, KEYS_PER_NODE - num_left);
            Array.Clear(left_node.Values, num_left, KEYS_PER_NODE - num_left);
            Array.Clear(left_node.Children, num_left + 1, KEYS_PER_NODE - num_left);
            left_node.NumKeysUsed = num_left;

            // Set the up key and value.
            middle_key = new_keys[num_left];
            middle_value = new_values[num_left];

            // Copy the remaining items into the right node.
            int num_right = num_keys - 1 - num_left;
            Array.Copy(new_keys, num_left + 1, right_node.Keys, 0, num_right);
            Array.Copy(new_values, num_left + 1, right_node.Values, 0, num_right);
            Array.Copy(new_children, num_left + 1, right_node.Children, 0, num_right + 1);
            right_node.NumKeysUsed = num_right;
        }

        // Merge these siblings.
        private void MergeSiblings(int left_spot, int right_spot, string middle_key, T middle_value)
        {
            // Join the two children.
            int mid = Children[left_spot].NumKeysUsed;
            Children[left_spot].Keys[mid] = middle_key;
            Children[left_spot].Values[mid] = middle_value;

            Array.Copy(Children[right_spot].Keys, 0, Children[left_spot].Keys, mid + 1, Children[right_spot].NumKeysUsed);
            Array.Copy(Children[right_spot].Values, 0, Children[left_spot].Values, mid + 1, Children[right_spot].NumKeysUsed);
            Array.Copy(Children[right_spot].Children, 0, Children[left_spot].Children, mid + 1, Children[right_spot].NumKeysUsed + 1);
            Children[left_spot].NumKeysUsed += Children[right_spot].NumKeysUsed + 1;

            // Remove the right child's entry from our Children array.
            Array.Copy(this.Keys, left_spot + 1, this.Keys, left_spot, this.NumKeysUsed - left_spot - 1);
            Array.Copy(this.Values, left_spot + 1, this.Values, left_spot, this.NumKeysUsed - left_spot - 1);
            Array.Copy(this.Children, right_spot + 1, this.Children, right_spot, this.NumKeysUsed - right_spot);
            this.NumKeysUsed--;
            this.Keys[this.NumKeysUsed] = null;
            this.Values[this.NumKeysUsed] = default(T);
            this.Children[this.NumKeysUsed + 1] = null;
        }
    }
}
