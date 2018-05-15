using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binTree = new BinaryTree<int>();
            binTree.Add(10);
            binTree.Add(5);
            binTree.Add(20);
            binTree.Add(3);
            binTree.Add(6);
            binTree.Add(2);
            binTree.Add(1);
            binTree.Add(15);
            binTree.Add(25);
            binTree.Add(13);
            binTree.Add(18);
            binTree.Add(19);
            binTree.Add(12);
            binTree.Add(14);
            binTree.Add(23);
            binTree.Add(30);
            Console.ReadKey();
        }
    }
    
    public class BinaryTree<T> where T: IComparable<T>
    {
        public BinaryTreeNode<T> root;
        private int nodeCount;
        public class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T: IComparable<T>
        {
            public BinaryTreeNode<T> parent;
            public T value;
            public BinaryTreeNode<T> rightChild;
            public BinaryTreeNode<T> leftChild;
            public BinaryTreeNode(T value)
            {
                this.value = value;
                rightChild = null;
                leftChild = null;
            }
            public BinaryTreeNode(T value, BinaryTreeNode<T> parent): this(value)
            {
                this.parent = parent;
            }

            public override int GetHashCode()
            {
                return value.GetHashCode();
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
            public override string ToString()
            {
                return base.ToString();
            }
        }

        public BinaryTree()
        {
            root = null;
            nodeCount = 0;
        }

        public void Add(T value)
        {
            root = Add(value, null, root);
        }

        public BinaryTreeNode<T> Add(T value, BinaryTreeNode<T> parent, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                node = new BinaryTreeNode<T>(value);
                node.parent = parent;
                nodeCount++;
            }
            else
            {
                if (value.CompareTo(node.value) < 0)
                {
                    node.leftChild = Add(value, node, node.leftChild);
                }
                else if (value.CompareTo(node.value) > 0)
                {
                    node.rightChild = Add(value, node, node.rightChild);
                }

            }
            return node;
        }

        public List<int> GetLevelSums()
        {   
            int[] depths = new int[20];
            GetSums(root, 0, depths);
            List<int> result = new List<int>();
            foreach (int i in depths)
            {
                if (i != 0)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        private void GetSums(BinaryTreeNode<T> root, int depth, int[] depths)
        {
            if (root == null)
            {
                return;
            }
            depths[depth] += int.Parse(root.value.ToString());
            GetSums(root.leftChild, depth + 1, depths);
            GetSums(root.rightChild, depth + 1, depths);
        }

        public void PrintSecondToLastDepth()
        {
            PrintLeafsSuccessors(root);
        }
        private void PrintLeafsSuccessors(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            if (HasOnlyLeafs(root))
            {
                Console.Write(root.value.ToString() + " ");
            }

            PrintLeafsSuccessors(root.leftChild);
            PrintLeafsSuccessors(root.rightChild);
        }

        private bool HasOnlyLeafs(BinaryTreeNode<T> root)
        {
            if (root.leftChild == null && root.rightChild == null)
            {
                return false;
            }
            
            int swt = 0;    //switch variable to control the state of the result
            BinaryTreeNode<T> tmp = root;
            if (tmp.leftChild != null)
            {
                tmp = tmp.leftChild;
                if (tmp.leftChild == null)
                {
                    if (tmp.rightChild == null)
                    {   //if the successor has neither right or left child, change the state of swt
                        swt++;
                    }
                }
                else
                {
                    swt--;
                }
            }
            
            tmp = root;
            if (tmp.rightChild != null)
            {
                tmp = tmp.rightChild;
                if (tmp.rightChild == null)
                {
                    if (tmp.leftChild == null)
                    {   //if the successor has neither right or left child, change the state of swt
                        swt++;
                    }
                }
                else
                {
                    swt--;
                }
            }
            
            if (swt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsBalanced()
        {
            List<int> depths = new List<int>();
            CheckDepths(root,depths, 0);
            for (int i = 0; i < depths.Count; i++)
            {
                for (int j = 0; j < depths.Count; j++)
                {
                    if (depths[i] != depths[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void CheckDepths(BinaryTreeNode<T> root,List<int> depths, int depth)
        {
            if (root == null)
            {
                depths.Add(depth - 1);
                return;
            }
            else
            {
                CheckDepths(root.leftChild, depths, depth + 1);
                CheckDepths(root.rightChild, depths, depth + 1);
            }
        }
    }
}
