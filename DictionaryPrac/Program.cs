using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPrac
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"ItemData.txt");

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5);

            foreach (string line in lines)
            {
                string[] lineString = line.Split(',');

                StringKey newStringKey = new StringKey(lineString[0]);

                Item newItem = new Item(lineString[0], int.Parse(lineString[1]), double.Parse(lineString[2]));

                hashMap.Put(newStringKey, newItem);
            }

            IEnumerable list = hashMap.Keys();

            foreach (StringKey key in list)
            {
                Item i = hashMap.Get(key);

                if (i.GoldPeices == 0)
                {
                    hashMap.Remove(key);
                }
                else
                {
                    Console.WriteLine(i.ToString());
                }
            }

            Console.ReadLine();
        }
    }
}
