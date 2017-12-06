using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPrac
{
    public class StringKey : IComparable<StringKey>
    {
        public string KeyName { get; }
        private const double Coefficient = 31;

        public StringKey(string keyName)
        {
            this.KeyName = keyName;
        }

        public int CompareTo(StringKey otherStringKey)
        {
            return this.KeyName.CompareTo(otherStringKey.KeyName);
        }

        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < KeyName.Length; i++)
            {
                hash += (int)(KeyName[i] * Math.Pow(StringKey.Coefficient, i));
            }

            return Math.Abs(hash);
        }

        public override bool Equals(Object o)
        {
            if (o == null)
            {
                return false;
            }

            if (o.GetType() != typeof(StringKey))
            {
                return false;
            }

            if (object.ReferenceEquals(this, o))
            {
                return true;
            }

            StringKey newO = (StringKey)o;

            return newO.KeyName == this.KeyName;
        }

        public override string ToString()
        {
            return this.KeyName;
        }
    }
}
