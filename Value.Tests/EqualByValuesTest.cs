using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Value.Shared;

namespace Value.Tests
{
    [TestFixture]
    public class EqualByValuesTest
    {
        [Test]
        public void Should_be_equal_by_values()
        {
            var coll1 = new string[] { "Hello", "Apple", "C#" };
            var coll2 = new string[] { "C#", "Hello", "Apple" };
            Assert.IsTrue(new EqualByValues<string>(coll1, coll2));
        }

        [Test]
        public void Should_not_be_equal_by_values()
        {
            var coll1 = new string[] { "Hello", "Apple", "C#", "Java" };
            var coll2 = new string[] { "C#", "Hello", "Apple" };
            Assert.IsTrue(new EqualByValues<string>(coll1, coll2));
        }
    }
}
