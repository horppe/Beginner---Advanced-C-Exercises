using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_trees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(2);
            bst.Insert(4);
            bst.Insert(3);
            bst.Insert(9);
            bst.Insert(8);
            bst.Insert(7);
            bst.Insert(6);
            bst.Insert(1);
            bst.Insert(-5);
            bst.Insert(-7);
            bst.Insert(-4);
            bst.Insert(-3);
            bst.Insert(2);
            bst.Insert(15);
            bst.Insert(23);
            bst.Insert(14);
            bst.TraverseDFS();

            bst.Remove(6);
            bst.TraverseDFS();
            bst.Remove(3);
            bst.TraverseDFS();
            bst.Remove(2);
            bst.TraverseDFS();
            bst.Remove(4);
            bst.TraverseDFS();
            bst.Remove(-4);
            bst.TraverseDFS();
            bst.Remove(-3);
            bst.TraverseDFS();
            Console.ReadKey();
        }
    }

    public class BinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Represents a binary tree node
        /// </summary>
        /// <typeparam name="T">The type of the nodes</typeparam>
        internal class BinaryTreeNode<T> :
        IComparable<BinaryTreeNode<T>> where T : IComparable<T>
        {
            // Contains the value of the node
            internal T value;
            // Contains the parent of the node
            internal BinaryTreeNode<T> parent;
            // Contains the left child of the node
            internal BinaryTreeNode<T> leftChild;
            // Contains the right child of the node
            internal BinaryTreeNode<T> rightChild;
            /// <summary>Constructs the tree node</summary>
            /// <param name="value">The value of the tree node</param>
            public BinaryTreeNode(T value)
            {
                if (value == null)
                {
                    // Null values cannot be compared -> do not allow them
                    throw new ArgumentNullException(
                    "Cannot insert null value!");
                }
                this.value = value;
                this.parent = null;
                this.leftChild = null;
                this.rightChild = null;
            }
            public override string ToString()
            {
                return this.value.ToString();
            }
            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                BinaryTreeNode<T> other = (BinaryTreeNode<T>)obj;
                return this.CompareTo(other) == 0;
            }
            public int CompareTo(BinaryTreeNode<T> other)
            {
                return this.value.CompareTo(other.value);
            }
        }
        /// <summary>
        /// The root of the tree
        /// </summary>
        private BinaryTreeNode<T> root;
        /// <summary>
        /// Constructs the tree
        /// </summary>
        public BinarySearchTree()
        {
            this.root = null;
        }
        // …
        // … The implementation of tree operations come here!!! …
        // …
        /// <summary>Inserts new value in the binary search tree
        /// </summary>
        /// <param name="value">the value to be inserted</param>
        public void Insert(T value)
        {
            this.root = Insert(value, null, root);
        }
        /// <summary>
        /// Inserts node in the binary search tree by given value
        /// </summary>
        /// <param name="value">the new value</param>
        /// <param name="parentNode">the parent of the new node</param>
        /// <param name="node">current node</param>
        /// <returns>the inserted node</returns>
        private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                node = new BinaryTreeNode<T>(value);
                node.parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.value);
                if (compareTo < 0)
                {
                    node.leftChild =
                    Insert(value, node, node.leftChild);
                }
                else if (compareTo > 0)
                {
                    node.rightChild =
                    Insert(value, node, node.rightChild);
                }
            }
            return node;
        }

        /// <summary>Finds a given value in the tree and
        /// return the node which contains it if such exsists
        /// </summary>
        /// <param name="value">the value to be found</param>
        /// <returns>the found node or null if not found</returns>
        private BinaryTreeNode<T> Find(T value)
        {
            BinaryTreeNode<T> node = this.root;
            while (node != null)
            {
                int compareTo = value.CompareTo(node.value);
                if (compareTo < 0)
                {
                    node = node.leftChild;
                }
                else if (compareTo > 0)
                {
                    node = node.rightChild;
                }
                else
                {
                    break;
                }
            }
            return node;
        }
        /// <summary>Returns whether given value exists in the tree
        /// </summary>
        /// <param name="value">the value to be checked</param>
        /// <returns>true if the value is found in the tree</returns>
        public bool Contains(T value)
        {
            bool found = this.Find(value) != null;
            return found;
        }

        /// <summary>Removes an element from the tree if exists
        /// </summary>
        /// <param name="value">the value to be deleted</param>
        public void Remove(T value)
        {
            BinaryTreeNode<T> nodeToDelete = Find(value);
            if (nodeToDelete != null)
            {
                Remove(nodeToDelete);
            }
        }
        private void Remove(BinaryTreeNode<T> node)
        {
            // Case 3: If the node has two children.
            // Note that if we get here at the end
            // the node will be with at most one child
            if (node.leftChild != null && node.rightChild != null)
            {
                BinaryTreeNode<T> replacement = node.rightChild;
                while (replacement.leftChild != null)
                {
                    replacement = replacement.leftChild;
                }
                node.value = replacement.value;
                node = replacement;
            }
            // Case 1 and 2: If the node has at most one child
            BinaryTreeNode<T> theChild = node.leftChild != null ? node.leftChild : node.rightChild;
            // If the element to be deleted has one child
            if (theChild != null)
            {
                theChild.parent = node.parent;
                // Handle the case when the element is the root
                if (node.parent == null)
                {
                    root = theChild;
                }
                else
                {
                    // Replace the element with its child sub-tree
                    if (node.parent.leftChild == node)
                    {
                        node.parent.leftChild = theChild;
                    }
                    else
                    {
                        node.parent.rightChild = theChild;
                    }
                }
            }
            else
            {
                // Handle the case when the element is the root
                if (node.parent == null)
                {
                    root = null;
                }
                else
                {
                    // Remove the element - it is a leaf
                    if (node.parent.leftChild == node)
                    {
                        node.parent.leftChild = null;
                    }
                    else
                    {
                        node.parent.rightChild = null;
                    }
                }
            }
        }

        /// <summary>Traverses and prints the ordered binary search tree
        /// tree starting from given root node.</summary>
        /// <param name="node">the starting node</param>
        private void PrintTreeDFS(BinaryTreeNode<T> node)
        {   //Print In-order
            if (node != null)
            {
                PrintTreeDFS(node.leftChild);
                Console.Write(node.value + " ");
                PrintTreeDFS(node.rightChild);
            }
        }
        public void PrintTree(T value)
        {
            if (value != null)
            {
                BinaryTreeNode<T> found = Find(value);
                PrintTreeDFS(found);
            }
            else
            {
                throw new ArgumentException("The Tree cannot have a null value.");
            }
        }

        private void PrintDFS(BinaryTreeNode<T> root, string spaces)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(spaces + root.value);
            BinaryTreeNode<T> child = null;
            Stack<BinaryTreeNode<T>> stk = new Stack<BinaryTreeNode<T>>();
            stk.Push(root.leftChild);
            stk.Push(root.rightChild);
            while (stk.Count > 0)
            {
                child = stk.Pop();
                PrintDFS(child, spaces + "  ");
            }
        }
        public void TraverseDFS()
        {
            this.PrintDFS(this.root, string.Empty);
        }
    }
}
