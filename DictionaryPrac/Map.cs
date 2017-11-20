using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPrac
{
    public interface Map<K, V>
    {
        int Size();

        bool IsEmpty();

        void Clear();

        V Get(K key);

        V Put(K key, V value);

        V Remove(K key);

        IEnumerator<K> Keys();

        IEnumerator<V> Values();
    }
}
