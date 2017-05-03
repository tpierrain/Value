using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using NUnit.Framework;
using Value.Shared;

namespace Value.Tests
{
    [TestFixture]
    public class DictionaryByValueTests
    {
        [Test]
        public void Should_consider_Equals_two_instances_with_same_reference_types_elements_in_same_order()
        {
            var dico1 = new Dictionary<int, string>() { {1, "uno" }, { 4, "quatro" }, { 3, "tres" } };
            var dico2 = new Dictionary<int, string>() { { 1, "uno" }, { 3, "tres" }, { 4, "quatro" } };

            var byValue1 = new DictionaryByValue<int, string>(dico1);
            var byValue2 = new DictionaryByValue<int, string>(dico2);

            Check.That(byValue1).IsEqualTo(byValue2);
        }
    }
}
