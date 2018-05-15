using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodes
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }
    public class LinkedList
    {
        public LinkedList First { get; set; }
        public LinkedList Last { get; set; }

    }
}
