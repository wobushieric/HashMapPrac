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
    public class HashMapTests
    {
        [TestMethod()]
        public void HashMapTestInvalidLoadFactor()
        {
            try
            {
                HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 2);
            }
            catch (ArgumentException e)
            {

            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void PutTestNullKey()
        {
            try
            {
                HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 0.75);

                hashMap.Put(null, new Item("Test", 1, 0.1));
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("key and value cannot be null", e.Message);
            }
        }

        [TestMethod()]
        public void PutTestNullValue()
        {
            try
            {
                HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 0.75);

                hashMap.Put(new StringKey("Test"), null);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("key and value cannot be null", e.Message);
            }
        }

        [TestMethod()]
        public void PutTest()
        {
            StringKey newStringKey = new StringKey("Unique");

            Item newItem = new Item("Item", 1, 0.75);

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 0.75);

            hashMap.Put(newStringKey, newItem);

            Assert.AreEqual(1, hashMap.Size());
            Assert.AreEqual(false, hashMap.IsEmpty());
            Assert.AreEqual(newItem, hashMap.Get(newStringKey));
        }

        [TestMethod()]
        public void SizeTest()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 0.75);

            Assert.AreEqual(0, hashMap.Size());

            hashMap.Put(new StringKey("Test"), new Item("Test", 1, 0.75));

            Assert.AreEqual(1, hashMap.Size());
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 0.75);

            Assert.AreEqual(true, hashMap.IsEmpty());

            hashMap.Put(new StringKey("Test"), new Item("Test", 1, 0.75));

            Assert.AreEqual(false, hashMap.IsEmpty());
        }

        [TestMethod()]
        public void ClearTest()
        {
            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 0.75);

            hashMap.Put(new StringKey("Test"), new Item("Test", 1, 0.75));

            hashMap.Clear();

            Assert.AreEqual(0, hashMap.Size());
        }

        [TestMethod()]
        public void GetTest()
        {
            StringKey newStringKey = new StringKey("Unique");

            StringKey secondStringKey = new StringKey("Second");

            Item newItem = new Item("Item", 1, 0.75);

            Item secondItem = new Item("Second", 2, 0.8);

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 0.75);

            hashMap.Put(newStringKey, newItem);
            hashMap.Put(secondStringKey, secondItem);

            Assert.AreEqual(newItem, hashMap.Get(newStringKey));
            Assert.AreEqual(secondItem, hashMap.Get(secondStringKey));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            StringKey newStringKey = new StringKey("Unique");

            StringKey secondStringKey = new StringKey("Second");

            Item newItem = new Item("Item", 1, 0.75);

            Item secondItem = new Item("Second", 2, 0.8);

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 0.75);

            hashMap.Put(newStringKey, newItem);
            hashMap.Put(secondStringKey, secondItem);

            Assert.AreEqual(2, hashMap.Size());
            Assert.AreEqual(secondItem, hashMap.Remove(secondStringKey));
            Assert.AreEqual(1, hashMap.Size());
        }

        [TestMethod()]
        public void KeysTest()
        {
            StringKey newStringKey = new StringKey("Unique");

            StringKey secondStringKey = new StringKey("Second");

            Item newItem = new Item("Item", 1, 0.75);

            Item secondItem = new Item("Second", 2, 0.8);

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 0.75);
            hashMap.Put(newStringKey, newItem);
            hashMap.Put(secondStringKey, secondItem);

            List<StringKey> expectedList = new List<StringKey>();
            expectedList.Add(secondStringKey);
            expectedList.Add(newStringKey);

            List<StringKey> actuaList = (List<StringKey>)hashMap.Keys();

            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.AreEqual(expectedList[i], actuaList[i]);
            }
        }

        [TestMethod()]
        public void ValuesTest()
        {
            StringKey newStringKey = new StringKey("Unique");

            StringKey secondStringKey = new StringKey("Second");

            Item newItem = new Item("Item", 1, 0.75);

            Item secondItem = new Item("Second", 2, 0.8);

            HashMap<StringKey, Item> hashMap = new HashMap<StringKey, Item>(5, 0.75);
            hashMap.Put(newStringKey, newItem);
            hashMap.Put(secondStringKey, secondItem);

            List<Item> expectedList = new List<Item>();
            expectedList.Add(secondItem);
            expectedList.Add(newItem);

            List<Item> actuaList = (List<Item>)hashMap.Values();

            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.AreEqual(expectedList[i], actuaList[i]);
            }
        }
    }
}