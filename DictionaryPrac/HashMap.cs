using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPrac
{
    public class HashMap<K, V> : Map<K, V>
    {
        private int _size;
        private double _loadFactor;
        private int _threshold;
        private Entry<K, V>[] _table;
        private Entry<K, V> _available;
        private const int DEFAULT_CAPACITY = 11;
        private const double DEFAULT_LOADFACTOR = 0.75;

        public HashMap()
        {
            this._table = new Entry<K, V>[DEFAULT_CAPACITY];
            this._loadFactor = DEFAULT_LOADFACTOR;
        }

        public HashMap(int initialCapacity)
        {
            this._table = new Entry<K, V>[initialCapacity];
            this._loadFactor = DEFAULT_LOADFACTOR;
        }

        public HashMap(int initialCapacity, double loadFactor)
        {
            if (loadFactor < 0 || loadFactor > 1)
            {
                throw new ArgumentOutOfRangeException("loadFactor must be a value between 0 and 1");
            }

            this._loadFactor = loadFactor;
            this._table = new Entry<K, V>[initialCapacity];
        }

        int Map<K, V>.Size()
        {
            return this._size;
        }

        public bool IsEmpty()
        {
            return this._size == 0;
        }

        public void Clear()
        {
            this._size = 0;
        }

        public V Get(K key)
        {
            return this._table[this.findBucket(key)].V;
        }

        public V Put(K key, V value)
        {
            if (key.Equals(null) || value.Equals(null))
            {
                throw new ArgumentException("key and value cannot be null");
            }

            int bucket = this.findBucket(key);

            V oldValue = this._table[bucket].V;

            this._table[bucket] = new Entry<K, V>(key, value);

            this._size++;

            if (this._size >= this._table.Length * this._threshold)
            {
                this.rehash();
            }

            return oldValue;
        }

        public V Remove(K key)
        {
            int bucket = this.findMatchingBucket(key);

            if (bucket == -1)
            {
                return  default(V);
            }

            V oldV = this._table[bucket].V;

            this._table[bucket] = null;

            this._size--;

            return oldV;
        }

        public IEnumerable<K> Keys()
        {
            List<K> keyList = new List<K>();

            foreach (Entry<K, V> item in this._table)
            {
                keyList.Add(item.K);
            }

            return keyList;
        }

        public IEnumerable<V> Values()
        {
            List<V> keyList = new List<V>();

            foreach (Entry<K, V> item in this._table)
            {
                keyList.Add(item.V);
            }

            return keyList;
        }

        private int findBucket(K key)
        {
            return key.GetHashCode() % this._table.Length;
        }

        private int findMatchingBucket(K key)
        {
            int bucket = key.GetHashCode() % this._table.Length;

            return (bucket >= 0 && bucket < this._table.Length) ? bucket : -1;
        }

        private void rehash()
        {
            int newSize = this.resize();

            Entry<K, V>[] oldTable = this._table;

            this._table = new Entry<K, V>[newSize];

            foreach (Entry<K, V> item in oldTable)
            {
                if (!item.Equals(null))
                {
                    int bucket = item.K.GetHashCode() % newSize;

                    this._table[bucket] = item;
                }
            }
        }

        private int resize()
        {
            int startNumber = (this._size * 2) + 1;

            while (!this.isPrimeNumber(startNumber))
            {
                startNumber += 2;
            }

            return startNumber;
        }

        private bool isPrimeNumber(int number)
        {
            bool isPrime = true;

            for (int i = 3; i <= 9; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }

        public class Entry<Key, Value>
        {
            public Key K { get; }
            public Value V { get; set; }

            public Entry(Key k, Value v)
            {
                this.K = k;
                this.V = v;
            }

            public override string ToString()
            {
                return string.Format("[{0}]: [{1}]", this.K, this.V);
            }
        }
    }
}
