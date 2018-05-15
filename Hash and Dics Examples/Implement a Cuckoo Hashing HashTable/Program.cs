using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement_a_Cuckoo_Hashing_HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            CuckooHashTable<string, int> hash = new CuckooHashTable<string, int>();
            hash.Add("Hello", 21);
            hash.Add("World", 25);
            hash.Add("World", 25);
            Console.ReadKey();
        }
    }

    public struct CuckooPair<K, V>
    { 
        public K key;
        public V value;

        public CuckooPair(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
        
        public override bool Equals(object obj)
        {
            CuckooPair<K, V> other = (CuckooPair<K, V>)obj;
            return this.key.Equals(other.key);
        }
        public override int GetHashCode()
        {
            return this.key.GetHashCode();
        }
    }

    public class CuckooHashTable<K, V>
    {
        private const int DefaultCapacity = 16;
        private const float DefaultLoadFactor = 0.75f;
        private CuckooPair<K, V>[] table;
        private float loadFactor;
        private int threshold;
        private int size;
        private int initialCapacity;

        public CuckooHashTable() : this(DefaultCapacity, DefaultLoadFactor)
        {}

        public CuckooHashTable(int capacity, float loadFactor)
        {
            this.initialCapacity = capacity;
            this.table = new CuckooPair<K, V>[capacity];
            this.loadFactor = loadFactor;
            this.threshold = (int)(capacity * this.loadFactor);
        }

        private CuckooPair<K, V> FindPair(K key)
        {
            int index = GetIndex(key);
            return table[index];
        }

        private int GetIndex(K key)
        {
            int index = key.GetHashCode();
            index = index & 0x7FFFFFFF; // clear the negative bit 
            index = index % this.table.Length;
            if (!table[index].Equals(default(CuckooPair<K, V>)) && !table[index].key.Equals(key))
            {
                index = key.GetHashCode();
                index = index & 0x7FFFFFFF;
                index = (index * 83 + 7) % this.table.Length;
                if (!table[index].Equals(default(CuckooPair<K, V>)) && !table[index].key.Equals(key))
                {
                    index = key.GetHashCode();
                    index = index & 0x7FFFFFFF;
                    index = (index * index + 19) % this.table.Length;
                }
            }
            return index;
        }

        public bool ContainsKey(K key)
        {
            int index = GetIndex(key);
            return table[index].key.Equals(key);
        }

        public void Add(K key, V value)
        {
            CuckooPair<K, V> add = new CuckooPair<K, V>(key, value);
            int index = GetIndex(key);
            if (table[index].Equals(default(CuckooPair<K, V>)))
            {
                table[index] = add;
            }
            else
            {
                CuckooPair<K, V> other = table[index];
                table[index] = add;
                this.Add(other.key, other.value);
            }
        }

        public bool Remove(K key)
        {
            int index = GetIndex(key);
            bool removed = !table[index].Equals(default(CuckooPair<K, V>));
            table[index] = default(CuckooPair<K, V>);
            return removed;
        }

    }
}
