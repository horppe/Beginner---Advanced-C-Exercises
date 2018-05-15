using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Set_using_My_Custom_Hash_Table
{
    class Program
    {
        struct HashedSetCode
        {
            //HashedSet<string> set = new HashedSet<string>();
            //set.Add("Samson");
            //set.Add("Oluokun");
            //set.Add("Akinwale");
            //set.Add("Samuel");
            //HashedSet<string> otherSet = new HashedSet<string>();
            //otherSet.Add("Oluokun");
            //otherSet.Add("Opeyemi");
            //otherSet.Add("Abiodun");
            //otherSet.Add("Samuel");
            //HashedSet<string> union = set.Union(otherSet);
            //HashedSet<string> intersect = set.Intersect(otherSet);
            //set.Clear();
            //Console.ReadKey();
        }
        static List<int> bufferFucntion = new List<int>();
        static List<HashedSet<int>> intersections = new List<HashedSet<int>>();
        static List<HashedSet<int>> unions = new List<HashedSet<int>>();

        static void Main(string[] args)
        {
            List<HashedSet<int>> sets = GetFunctions();
            intersections.Add(sets[0].Intersect(sets[1]));
            intersections.Add(sets[0].Intersect(sets[2]));
            intersections.Add(sets[1].Intersect(sets[2]));
            intersections.Add(intersections[0].Intersect(sets[2]));

            unions.Add(sets[0].Union(sets[1]));
            unions.Add(sets[0].Union(sets[2]));
            unions.Add(sets[1].Union(sets[2]));
            unions.Add(unions[0].Union(sets[2]));

            Console.ReadKey();
        }

        static List<HashedSet<int>> GetFunctions()
        {
            HashedSet<int> firstSequence = new HashedSet<int>();
            for (int i = 0; i < 100000; i++)
            {
                firstSequence.Add(FunctionOne(i));
                bufferFucntion.Add(FunctionOne(i));
            }
            bufferFucntion.Clear();

            HashedSet<int> secondSequence = new HashedSet<int>();
            for (int i = 0; i < 100000; i++)
            {
                secondSequence.Add(FunctionTwo(i));
                bufferFucntion.Add(FunctionTwo(i));
            }
            bufferFucntion.Clear();

            HashedSet<int> thirdSequence = new HashedSet<int>();
            for (int i = 0; i < 100000; i++)
            {
                thirdSequence.Add(FunctionThree(i));
                bufferFucntion.Add(FunctionThree(i));
            }
            bufferFucntion.Clear();
            List<HashedSet<int>> sets = new List<HashedSet<int>>();
            sets.Add(firstSequence);
            sets.Add(secondSequence);
            sets.Add(thirdSequence);
            return sets;
        }

        static int FunctionOne(int k)
        {
            if (k == 0)
            {
                return 1;
            }
            return (2 * bufferFucntion[k - 1]) + 3;
        }

        static int FunctionTwo(int k)
        {
            if (k == 0)
            {
                return 2;
            }
            return (3 * bufferFucntion[k - 1]) + 1;
        }

        static int FunctionThree(int k)
        {
            if (k == 0)
            {
                return 2;
            }
            return (2 * bufferFucntion[k - 1]) - 1;
        }

    }

    //Seperating other codes from the Generic Hashed Set
    
    public class HashedSet<T> where T : IComparable<T>
    {
        public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
        {
            const int DefaultCapacity = 16;
            const float DefaultLoadFactor = 0.75f;
            private float loadFactor;
            private int threshold;
            private int initialCapacity;
            private int count;
            KeyValuePair<K, V>[] table;

            public HashTable() : this(DefaultCapacity, DefaultLoadFactor)
            { }

            public HashTable(int capacity) : this(capacity, DefaultLoadFactor)
            { }

            public HashTable(int capacity, float loadFactor)
            {
                table = new KeyValuePair<K, V>[capacity];
                threshold = (int)(loadFactor * capacity);
                this.loadFactor = loadFactor;
                initialCapacity = capacity;
                count = 0;
            }

            public int Count
            {
                get { return count; }
            }

            public int CurrentCapacity
            {
                get { return table.Length; }
            }

            private int GetIndex(K key)
            {
                int index = key.GetHashCode();
                index = index & 0x7FFFFFFF;
                index = index % table.Length;
                if (!table[index].Equals(default(KeyValuePair<K, V>)) && table[index].Key.Equals(key))
                {
                    return index;
                }
                if (!table[index].Equals(default(KeyValuePair<K, V>)) && !table[index].Key.Equals(key))
                {
                    int i = 0;
                    int newPosition = index;
                    while (!table[newPosition].Equals(default(KeyValuePair<K, V>)) && !table[newPosition].Key.Equals(key))
                    {   //Probe or Get new position with Quadratic Function
                        i++;
                        newPosition = (index + (5 * i) + ((int)0.5 * i * i)) % table.Length;
                    }
                    return newPosition;
                }
                return index;
            }

            public List<K> Keys
            {
                get
                {
                    List<K> keys = new List<K>();
                    foreach (var pair in table)
                    {
                        if (!pair.Equals(default(KeyValuePair<int, V>)))
                        {
                            keys.Add(pair.Key);
                        }
                    }
                    return keys;
                }
            }

            public KeyValuePair<K, V> this[K key]
            {
                get
                {
                    int index = GetIndex(key);
                    return table[index];
                }
            }

            public List<V> Values
            {
                get
                {
                    List<V> values = new List<V>();
                    foreach (var pair in table)
                    {
                        if (!pair.Equals(default(KeyValuePair<int, V>)))
                        {
                            values.Add(pair.Value);
                        }
                    }

                    return values;
                }
            }

            public void Add(K key, V value)
            {
                if (count >= threshold)
                {
                    Expand();
                }
                int index = GetIndex(key);
                if (!table[index].Equals(default(KeyValuePair<K, V>)) && table[index].Key.Equals(key))
                {
                    return;
                    //throw new ArgumentNullException(key.ToString(), "The parameter already exists in the Hash Table");
                }
                table[index] = new KeyValuePair<K, V>(key, value);
                count++;
            }

            public V Find(K key)
            {
                int index = GetIndex(key);
                return table[index].Value;
            }

            private void Expand()
            {
                int resized = 2 * table.Length;
                List<KeyValuePair<K, V>> tempTable = new List<KeyValuePair<K, V>>();
                foreach (var pair in table)
                {
                    if (!pair.Equals(default(KeyValuePair<K, V>)))
                    {
                        tempTable.Add(pair);
                    }
                }
                table = new KeyValuePair<K, V>[resized];
                threshold = (int)(loadFactor * resized);
                foreach (var pair in tempTable)
                {
                    int index = GetIndex(pair.Key);
                    index = index & 0x7FFFFFFF;
                    index = index % table.Length;
                    table[index] = pair;
                }
            }

            public bool Remove(K key)
            {
                int index = GetIndex(key);
                if (!table[index].Key.Equals(key))
                {
                    return false;
                }
                table[index] = default(KeyValuePair<K, V>);
                count--;
                return true;
            }

            public void Clear()
            {
                for (int i = 0; i < table.Length; i++)
                {
                    table[i] = default(KeyValuePair<K, V>);
                }
                count = 0;
            }

            public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
            {
                foreach (KeyValuePair<K, V> pair in table)
                {
                    if (!pair.Equals(default(KeyValuePair<K, V>)))
                    {
                        yield return pair;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        HashTable<int, T> set;
        //The HashCode of Value id being used as the Keys (K) for HashTable<K, V>
        public HashedSet()
        {
            set = new HashTable<int, T>();
        }

        public HashedSet(int capacity)
        {
            set = new HashTable<int, T>(capacity);
        }

        public int Count
        {
            get { return set.Count; }
        }

        public List<int> Keys { get { return set.Keys; } }
        public List<T> Values { get { return set.Values; } }

        private int GetKey(T element)
        {
            return element.GetHashCode();
        }

        public void Add(T element)
        {
            int key = GetKey(element);
            set.Add(key, element);
        }

        public bool Find(T element)
        {   //Faster algorithm
            int key = GetKey(element);
            //Check the List of Keys Property in the HashTable Class, for element's Key
            foreach (int keys in set.Keys)
            {
                if (keys.Equals(key))
                {
                    return true;
                }
            }
            return false;

            //Both Algorithms do the same thing
            //T found = set.Find(key);
            //if (element.Equals(found))
            //{   ////Check the hash table for the Key
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public bool Remove(T element)
        {
            int key = element.GetHashCode();
            bool removed = set.Remove(key);
            if (removed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            set.Clear();
        }

        public bool IsNotIn(int key, List<int> keys)
        {
            foreach (int otherkey in keys)
            {
                if (otherkey == key)
                {
                    return false;
                }
            }
            return true;
        }

        public HashedSet<T> Union(HashedSet<T> otherSet)
        {
            List<int> otherKeys = otherSet.Keys;
            List<int> mainKeys = this.Keys;
            HashedSet<T> tempHashedSet = new HashedSet<T>();
            foreach (int key in otherKeys)
            {   //If otherKey is not in mainKeys, Add it in mainKeys.Add()
                if (IsNotIn(key, mainKeys))
                {
                    mainKeys.Add(key);
                }
            }

            for (int i = 0; i < mainKeys.Count; i++)
            {   //Get the values from set with the Keys(Hash code of the elements)
                T element = set[mainKeys[i]].Value;
                if (element == null)
                {
                    element = otherSet.set[mainKeys[i]].Value;
                }
                if (element != null)
                {
                    tempHashedSet.Add(element);
                }
            }
            return tempHashedSet;
        }

        public HashedSet<T> Intersect(HashedSet<T> otherSet)
        {
            List<int> otherKeys = otherSet.Keys;
            List<int> mainKeys = this.Keys;
            List<int> intersects = new List<int>();
            HashedSet<T> tempHashedSet = new HashedSet<T>();
            foreach (int key in otherKeys)
            {   //If otherKey is in mainKeys, Add it to intersects List
                if (!IsNotIn(key, mainKeys))
                {
                    intersects.Add(key);
                }
            }

            for (int i = 0; i < intersects.Count; i++)
            {   //Get the values from set with the Keys(Hash code of the elements)
                T element = set[intersects[i]].Value;
                if (element == null)
                {
                    element = otherSet.set[intersects[i]].Value;
                }
                if (element != null)
                {
                    tempHashedSet.Add(element);
                }
            }
            return tempHashedSet;
        }

    }
}
