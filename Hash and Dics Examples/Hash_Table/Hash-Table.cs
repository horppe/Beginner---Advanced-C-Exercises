using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Hash_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> hash = new HashTable<string, int>();
            hash.Add("xqzrbn", 5);  //Strings that return the same Hash-Code
            hash.Add("krumld", 8);  //•
            hash.Add("Kush is Good", 420);
            KeyValuePair<string, int> five = hash["xqzrbn"];
            KeyValuePair<string, int> eight = hash["krumld"];
            KeyValuePair<string, int> fourTwenty = hash["Kush is Good"];
            foreach (var pair in hash)
            {
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }
            Console.ReadKey();
        }
    }

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
        {}

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

        public void Add(K key, V value)
        {
            if (count >= threshold)
            {
                Expand();
            }
            int index = GetIndex(key);
            if (!table[index].Equals(default(KeyValuePair<K, V>)) && table[index].Key.Equals(key))
            {
                throw new ArgumentNullException(key.ToString(), "The parameter already exists in the Hash Table");
            }
            table[index] = new KeyValuePair<K, V>(key, value);
            count++;
        }

        public KeyValuePair<K, V> this[K key]
        {
            get
            {
                int index = GetIndex(key);
                return table[index];
            }
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

        public List<K> Keys
        {
            get
            {
                List<K> keys = new List<K>();
                foreach (var pair in table)
                {
                    keys.Add(pair.Key);
                }
                return keys;
            }
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
}
