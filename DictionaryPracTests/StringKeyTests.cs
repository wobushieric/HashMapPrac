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
    public class StringKeyTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            string expected = "Unit Test";

            StringKey stringKey = new StringKey(expected);

            Assert.AreEqual(expected, stringKey.ToString());
        }

        [TestMethod()]
        public void EqualsTestWithNull()
        {
            StringKey stringKey = new StringKey("Test");

            Assert.AreEqual(false, stringKey.Equals(null));
        }

        [TestMethod()]
        public void EqualsTestWithOtherType()
        {
            StringKey stringKey = new StringKey("Test");

            Assert.AreEqual(false, stringKey.Equals(new Item("A", 1, 1.5)));
        }

        [TestMethod()]
        public void EqualsTestWithSameMemoryReference()
        {
            StringKey stringKey = new StringKey("Test");

            Assert.AreEqual(true, stringKey.Equals(stringKey));
        }

        [TestMethod()]
        public void EqualsTestWithSameKeyName()
        {
            string key = "Test Key";

            StringKey stringKey = new StringKey(key);

            StringKey otherStringKey = new StringKey(key);

            Assert.AreEqual(true, stringKey.Equals(otherStringKey));
        }

        [TestMethod()]
        public void EqualsTestWithDiffKeyName()
        {
            StringKey stringKey = new StringKey("Unit");

            StringKey otherStringKey = new StringKey("Test");

            Assert.AreEqual(false, stringKey.Equals(otherStringKey));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            double coe = 31;

            StringKey stringKey = new StringKey("and");

            int expected = (int)(('a' - '0') * 1 + ('n' - '0') * coe + ('d' - '0') * coe * coe);

            Assert.AreEqual(expected, stringKey.GetHashCode());
        }
    }
}