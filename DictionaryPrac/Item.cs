using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPrac
{
    class Item : IComparable<Item>
    {
        public string Name { get; }
        public int GoldPeices { get; }
        public double Weight { get; }

        public Item(string name, int goldPeices, double weight)
        {
            this.Name = name;
            this.GoldPeices = goldPeices;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Name, this.GoldPeices, this.Weight);
        }

        public int CompareTo(Item item)
        {
            return this.Weight.CompareTo(item.Weight);
        }
    }
}
