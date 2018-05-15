using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMultiSet
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeMultiSet<string> set = new TreeMultiSet<string>();
            set.Add("Hello");
            set.Add("hello");
            set.Add("hello");
            set.Add("hello");
            int occur1 = set.FindOccurence("hello");

            TreeMultiSet<int> set2 = new TreeMultiSet<int>();
            set2.Add(4);
            set2.Add(2);
            set2.Add(8);
            set2.Add(7);
            set2.Add(3);
            set2.Add(1);
            set2.Add(6);
            set2.Add(5);
            set2.Add(7);
            int min = set2.FindMinElement();
            int max = set2.FindMaxElement();
            set2.RemoveMin();
            set2.RemoveMax();
            Console.ReadKey();
        }
    }

    //public class Comparer : IComparer
    //{
    //    public int Compare(object mainObject, object otherObject)
    //    {
    //        return -1;/*mainObject.CompareTo(otherObject);*/
    //    }
    //}

    class TreeMultiSet<T> : IEnumerable<T>
    {
        public SortedDictionary<int, List<T>> dict;
        public TreeMultiSet()
        {
            dict = new SortedDictionary<int, List<T>>();
            Count = 0;
        }

        public TreeMultiSet(IComparer<int> comparer)
        {
            dict = new SortedDictionary<int, List<T>>(comparer);
        }

        public int Count { get; set; }

        public List<T> Elements
        {
            get
            {
                List<T> result = new List<T>();
                foreach (KeyValuePair<int, List<T>> i in dict)
                {
                    if (i.Value != null)
                    {
                        result.Add(i.Value[0]);
                    }
                }
                return result;
            }
        }

        public void Add(T element)
        {
            int key = GetKey(element);
            if (dict.ContainsKey(key))
            {   //Adding of duplicates
                dict[key].Add(element);
                Count++;
                return;
            }
            dict.Add(key, new List<T>());
            dict[key].Add(element);
            Count++;
        }
        
        private int GetKey(T element)
        {
            int key = element.GetHashCode();
            key = key & 0x7FFFFFFF;
            return key;
        }

        public int FindOccurence(T element)
        {
            int key = GetKey(element);
            if (dict.ContainsKey(key))
            {
                return dict[key].Count;
            }
            return -1;
        }

        public bool Remove(T element)
        {
            int key = GetKey(element);
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
                Count--;
                return true;
            }
            return false;
        }

        public T FindMinElement()
        {
            T min = this.Elements[0];
            return min;
        }

        public T FindMaxElement()
        {
            T max = this.Elements[Elements.Count - 1];
            return max;
        }

        public void RemoveMin()
        {
            if (Count > 1)
            {
                dict.Remove(GetKey(Elements[0]));
                Count--;
            }
        }

        public void RemoveMax()
        {
            if (Count > 1)
            {
                dict.Remove(GetKey(Elements[Elements.Count - 1]));
                Count--;
            }
        }

        // IEnumerable Code
        public IEnumerator<T> GetEnumerator()
        {
            foreach (KeyValuePair<int, List<T>> pair in dict)
            {
                if (pair.Value != null)
                {
                    foreach (T item in pair.Value)
                    {
                        yield return item;
                    }
                }
                
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
