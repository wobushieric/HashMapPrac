using Microsoft.VisualStudio.TestTools.UnitTesting;
using DictionaryPrac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPrac.Tests
{
    [TestClass()]
    public class ItemTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Item item = new Item("Item", 5, 2.5);

            string expected = "Item, " + 5 + ", " + 2.5;

            Assert.AreEqual(expected, item.ToString());
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Item lowWeightItem = new Item("Item", 5, 2.5);

            Item highWeightItem = new Item("Item", 5, 4.5);

            Assert.AreEqual(-1, lowWeightItem.CompareTo(highWeightItem));
            Assert.AreEqual(1, highWeightItem.CompareTo(lowWeightItem));
            Assert.AreEqual(0, lowWeightItem.CompareTo(lowWeightItem));
        }
    }
}