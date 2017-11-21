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
    }
}