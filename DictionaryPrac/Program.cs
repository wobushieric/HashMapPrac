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
            const int maxCarryCapacity = 75;
            double carryCapacity = 0.0;

            string[] lines = System.IO.File.ReadAllLines(@"ItemData.txt");
            string[] adventureLoot = System.IO.File.ReadAllLines(@"adventureLoot.txt");

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5);

            foreach (string line in lines)
            {
                string[] lineString = line.Split(',');

                StringKey newStringKey = new StringKey(lineString[0]);

                Item newItem = new Item(lineString[0], int.Parse(lineString[1]), double.Parse(lineString[2]));

                hashMap.Put(newStringKey, newItem);
            }

            IEnumerable list = hashMap.Keys();

            HashMap<String, int> backPackHashMap = new HashMap<string, int>();

            List<string> backPackKeysList = new List<string>();

            foreach (string lootItem in adventureLoot)
            {
                bool isUnknow = true;

                foreach (StringKey key in list)
                {
                    if (key.KeyName.Equals(lootItem))
                    {
                        isUnknow = false;
                    }
                }

                if (isUnknow)
                {
                    Console.WriteLine(
                        "You find an unknown item that is not in your loot table, you leave it alone. Item name: " +
                        lootItem);                  
                }
                else
                {
                    carryCapacity += hashMap.Get(new StringKey(lootItem)).Weight;

                    if (carryCapacity < maxCarryCapacity)
                    {
                        backPackKeysList = (List<string>) backPackHashMap.Keys();

                        if (backPackKeysList.Contains(lootItem))
                        {
                            backPackHashMap.Put(lootItem, backPackHashMap.Get(lootItem) + 1);
                        }
                        else
                        {
                            backPackHashMap.Put(lootItem, 1);
                        }

                        Console.WriteLine("You have picke up a " + lootItem);
                    }
                    else
                    {
                        Console.WriteLine("You acnnot pick up the " + 
                                          lootItem + ", you are already carrying " + 
                                          (carryCapacity - hashMap.Get(new StringKey(lootItem)).Weight) + 
                                          " and it weights " + hashMap.Get(new StringKey(lootItem)).Weight);
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("You sell the following items:");
            Console.WriteLine();

            int total = 0;

            backPackKeysList = (List<string>)backPackHashMap.Keys();

            foreach (string backPackKey in backPackKeysList)
            {
                int subtotal = hashMap.Get(new StringKey(backPackKey)).GoldPeices * backPackHashMap.Get(backPackKey);

                total += subtotal;

                Console.WriteLine(
                    $"{backPackKey}, {hashMap.Get(new StringKey(backPackKey)).GoldPeices}GP, {hashMap.Get(new StringKey(backPackKey)).Weight} - Qty: {backPackHashMap.Get(backPackKey)} - Subtotal: {subtotal}GP");

            }

            Console.WriteLine();
            Console.WriteLine("Total value of sold loot items: " + total + "GP");

            /*foreach (StringKey key in list)
            {
                Item i = hashMap.Get(key);

                if (i.GoldPeices == 0)
                {
                    hashMap.Remove(key);
                }
                else if(key.KeyName.Equals(i.Name))
                {
                    Console.WriteLine(i.ToString());
                }
            }*/

            Console.ReadLine();
        }
    }
}
