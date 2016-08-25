namespace Value.Tests
{
    using System.Collections.Generic;
    using NFluent;
    using NUnit.Framework;

    [TestFixture]
    public class HashSetByValueTests
    {
        [Test]
        public void Should_consider_two_sets_with_same_items_equals()
        {
            var first = "Achille";
            var second = "Anton";
            var third = "Maxime";

            var set1 = new HashSetByValue<string> { first, second, third };
            var set2 = new HashSetByValue<string> { first, second, third };

            Check.That(set2).IsEqualTo(set1);
        }

        [Test]
        public void Should_not_consider_a_classic_hashSet_and_a_HashSetByValue_Equals()
        {
            var set1 = new HashSet<string>() { "Achille", "Anton", "Maxime" };
            var set2 = new HashSetByValue<string> { "Achille", "Anton", "Maxime" };

            Check.That(set2).IsNotEqualTo(set1);
        }

        [Test]
        public void Should_consider_two_sets_with_same_items_in_different_order_equals()
        {
            var set1 = new HashSetByValue<string> { "Achille", "Anton", "Maxime" };
            var set2 = new HashSetByValue<string> { "Maxime", "Anton", "Achille" };

            Check.That(set2).IsEqualTo(set1);
        }

        [Test]
        public void Should_provide_same_GetHashCode_from_two_sets_with_same_values()
        {
            var set1 = new HashSetByValue<string> { "Achille", "Anton", "Maxime" };
            var set2 = new HashSetByValue<string> { "Achille", "Anton", "Maxime" };

            Check.That(set2.GetHashCode()).IsEqualTo(set1.GetHashCode());
        }

        [Test]
        public void Should_provide_different_GetHashCode_for_two_different_sets()
        {
            var set1 = new HashSetByValue<string> { "Achille", "Anton", "Maxime" };
            var set2 = new HashSetByValue<string> { "Hendrix", "De Lucia", "Reinhart" };

            Check.That(set2.GetHashCode()).IsNotEqualTo(set1.GetHashCode());
        }

        [Test]
        public void Should_provide_same_GetHashCode_from_two_sets_with_same_values_in_different_order()
        {
            var set1 = new HashSetByValue<string> { "Achille", "Anton", "Maxime" };
            var set2 = new HashSetByValue<string> { "Maxime", "Achille", "Anton"  };

            Check.That(set2.GetHashCode()).IsEqualTo(set1.GetHashCode());
        }
    }
}