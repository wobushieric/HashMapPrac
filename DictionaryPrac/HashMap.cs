using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            
        }

        public V Get(K key)
        {
            throw new NotImplementedException();
        }

        public V Put(K key, V value)
        {
            throw new NotImplementedException();
        }

        public V Remove(K key)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<K> Keys()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<V> Values()
        {
            throw new NotImplementedException();
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
