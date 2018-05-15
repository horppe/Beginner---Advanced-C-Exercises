using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tress_and_Graphs_Exercises
{
    public class TreeTest
    {
        static void Main()
        {
            Tree tree = new Tree(5, new Tree(8, new Tree(3, new Tree(4), new Tree(8))),
                new Tree(3, new Tree(1, new Tree(10, new Tree(8), new Tree(8), new Tree(6)))),
                new Tree(8));
            int result = tree.OccurenceOf(8);
            tree.PrintRootDChild(3);
            int noOfLeafs = tree.NumberOfLeafs();
            int noOfInVertices = tree.NumberInternalVertices();
            Console.ReadKey();
        }
    }
    public class Tree
    {
        int value;
        List<Tree> children;
        public Tree(int value)
        {
            this.value = value;
            children = new List<Tree>();
        }
        public Tree(int value, params Tree[] childNodes)
            : this(value)
        {
            foreach (Tree child in childNodes)
            {
                children.Add(child);
            }
        }
        public int OccurenceOf(int value)
        {
            int count = 0;
            Queue<Tree> que = new Queue<Tree>();
            que.Enqueue(this);
            while (que.Count > 0)
            {
                Tree currentTree = que.Dequeue();
                if (currentTree.value == value)
                {
                    count++;
                }
                foreach (Tree child in currentTree.children)
                {
                    que.Enqueue(child);
                }
            }
            return count;
        }
        public void PrintRootDChild(int children)
        {
            Queue<Tree> que = new Queue<Tree>();
            que.Enqueue(this);
            while (que.Count > 0)
            {
                Tree currentTree = que.Dequeue();
                if (currentTree.children.Count == children)
                {
                    Console.Write(currentTree.value + " ");
                }
                foreach (Tree child in currentTree.children)
                {
                    que.Enqueue(child);
                }
            }
        }
        public int NumberOfLeafs()
        {
            int count = 0;
            Queue<Tree> que = new Queue<Tree>();
            que.Enqueue(this);
            while (que.Count > 0)
            {
                Tree currentTree = que.Dequeue();
                if (currentTree.children.Count == 0)
                {
                    count++;
                }
                foreach (Tree child in currentTree.children)
                {
                    que.Enqueue(child);
                }
            }
            return count;
        }
        public int NumberInternalVertices()
        {
            int count = -1;
            Stack<Tree> que = new Stack<Tree>();
            que.Push(this);
            while (que.Count > 0)
            {
                Tree currentTree = que.Pop();
                if (currentTree.children.Count != 0)
                {
                    count++;
                }
                foreach (Tree child in currentTree.children)
                {
                    que.Push(child);
                }
            }
            return count;
        }
    }

}
