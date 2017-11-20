using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPrac
{
    class StringKey : IComparable<StringKey>
    {
        public string KeyName { get; }
        private const double Coefficient = 31;

        public StringKey(string keyName)
        {
            this.KeyName = keyName;
        }

        public int CompareTo(StringKey other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            char[] keyNameArray = this.KeyName.ToCharArray();

            int hash = 0;

            for (int i = 0; i < keyNameArray.Length; i++)
            {
                hash += (int)((keyNameArray[i] - '0') * Math.Pow(StringKey.Coefficient, i));
            }

            return hash;
        }

        public override bool Equals(Object o)
        {
            if (o == null)
            {
                return false;
            }

            if (o.GetType() != typeof(StringKey))
            {
                throw new ArgumentException("Cannot compare with object whice type is not StringKey");
            }

            StringKey newO = (StringKey)o;

            if (newO.KeyName == this.KeyName)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return this.KeyName;
        }
    }
}
