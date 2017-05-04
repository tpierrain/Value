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
        public void Should_consider_two_instances_with_same_elements_inserted_in_same_order_Equals()
        {
            var dico1 = new Dictionary<int, string>() { {1, "uno" }, { 4, "quatro" }, { 3, "tres" } };
            var dico2 = new Dictionary<int, string>() { { 1, "uno" }, { 4, "quatro" }, { 3, "tres" } };

            var byValue1 = new DictionaryByValue<int, string>(dico1);
            var byValue2 = new DictionaryByValue<int, string>(dico2);

            Check.That(dico1).IsNotEqualTo(dico2);
            Check.That(byValue1).IsEqualTo(byValue2);
        }

        [Test]
        public void Should_consider_two_instances_with_same_elements_inserted_in_different_order_Equals()
        {
            var dico1 = new Dictionary<int, string>() { {1, "uno" }, { 4, "quatro" }, { 3, "tres" } };
            var dico2 = new Dictionary<int, string>() { { 1, "uno" }, { 3, "tres" }, { 4, "quatro" } };

            var byValue1 = new DictionaryByValue<int, string>(dico1);
            var byValue2 = new DictionaryByValue<int, string>(dico2);

            Check.That(dico1).IsNotEqualTo(dico2);
            Check.That(byValue1).IsEqualTo(byValue2);
        }

        [Test]
        public void Should_consider_two_instances_with_different_elements_nott_Equals()
        {
            var dico1 = new Dictionary<int, string>() { { 1, "uno" }, { 4, "quatro" }, { 3, "tres" } };
            var dico2 = new Dictionary<int, string>() { { 1, "uno" }, { 79, "setenta y nueve" }, { 4, "quatro" } };

            var byValue1 = new DictionaryByValue<int, string>(dico1);
            var byValue2 = new DictionaryByValue<int, string>(dico2);

            Check.That(byValue1).IsNotEqualTo(byValue2);
        }

        [Test]
        public void Should_consider_an_instance_not_equals_with_SetByValue_instance()
        {
            var dico = new DictionaryByValue<int, string>(new Dictionary<int, string>() { { 1, "uno" }, { 4, "quatro" }, { 3, "tres" } });
            var set = new SetByValue<KeyValuePair<int, string>>() { new KeyValuePair<int, string>(1, "uno"), new KeyValuePair<int, string>(4, "quatro"), new KeyValuePair<int, string>(3, "tres") };

            Check.That(dico).IsNotEqualTo(set);
        }

        [Test]
        public void Should_change_its_hashcode_everytime_the_dictionary_is_updated()
        {
            var dico = new DictionaryByValue<int, string>(new Dictionary<int, string>() { { 1, "uno" }, { 4, "quatro" }, { 3, "tres" } });

            var previousHashcode = dico.GetHashCode();
            dico.Add(79, "Setenta y nueve");
            var currentHashcode = dico.GetHashCode();
            Check.That(currentHashcode).IsNotEqualTo(previousHashcode);

            previousHashcode = dico.GetHashCode();
            dico.Remove(79);
            currentHashcode = dico.GetHashCode();
            Check.That(currentHashcode).IsNotEqualTo(previousHashcode);

            previousHashcode = dico.GetHashCode();
            var keyValuePair = new KeyValuePair<int, string>(42, "quarenta y dos");
            dico.Add(keyValuePair);
            currentHashcode = dico.GetHashCode();
            Check.That(currentHashcode).IsNotEqualTo(previousHashcode);

            previousHashcode = dico.GetHashCode();
            dico.Remove(keyValuePair);
            currentHashcode = dico.GetHashCode();
            Check.That(currentHashcode).IsNotEqualTo(previousHashcode);

            previousHashcode = dico.GetHashCode();
            dico[33] = "trenta y tres";
            currentHashcode = dico.GetHashCode();
            Check.That(currentHashcode).IsNotEqualTo(previousHashcode);

            previousHashcode = dico.GetHashCode();
            dico.Clear();
            currentHashcode = dico.GetHashCode();
            Check.That(currentHashcode).IsNotEqualTo(previousHashcode);
        }
    }
}
