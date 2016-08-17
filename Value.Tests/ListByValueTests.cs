// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListByValueTests.cs">
//     Copyright 2016
//           Thomas PIERRAIN (@tpierrain)    
//     Licensed under the Apache License, Version 2.0 (the "License");
//     you may not use this file except in compliance with the License.
//     You may obtain a copy of the License at
//         http://www.apache.org/licenses/LICENSE-2.0
//     Unless required by applicable law or agreed to in writing, software
//     distributed under the License is distributed on an "AS IS" BASIS,
//     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//     See the License for the specific language governing permissions and
//     limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Value.Tests
{
    using System;
    using NFluent;
    using NUnit.Framework;
    using Value.Tests.Samples;

    [TestFixture()]
    public class ListByValueTests
    {
        [Test]
        public void Should_be_a_Value_Type()
        {
            var listA = new ListByValue<Card>() { Card.Parse("QC"), Card.Parse("TS") };
            var listB = new ListByValue<Card>() { Card.Parse("QC"), Card.Parse("TS") };

            Check.That(listA).IsEqualTo(listB).And.ContainsExactly(Card.Parse("QC"), Card.Parse("TS"));
        }

        [Test]
        public void Should_change_its_hashcode_everytime_the_list_is_updated()
        {
            var list = new ListByValue<Card>() { Card.Parse("QC"), Card.Parse("TS") };
            var firstHashCode = list.GetHashCode();

            list.Add(Card.Parse("3H")); // ---update the list ---
            var afterAddHash = list.GetHashCode();
            Check.That(firstHashCode).IsNotEqualTo(afterAddHash);

            list.Remove(Card.Parse("QC")); // ---update the list ---
            var afterRemoveHash = list.GetHashCode();
            Check.That(afterRemoveHash).IsNotEqualTo(afterAddHash);

            list.Clear(); // ---update the list ---
            var afterClearHash = list.GetHashCode();
            Check.That(afterClearHash).IsNotEqualTo(afterRemoveHash);
            Check.That(list.Count).IsZero();

            list.Insert(0, Card.Parse("AS")); // ---update the list ---
            Check.That(list.Count).IsEqualTo(1);
            var afterInsertHash = list.GetHashCode();
            Check.That(afterInsertHash).IsNotEqualTo(afterClearHash);

            list[0] = Card.Parse("QH");
            var afterIndexerHash = list.GetHashCode();
            Check.That(afterIndexerHash).IsNotEqualTo(afterInsertHash);

            list.RemoveAt(0);
            var afterRemoveAtHash = list.GetHashCode();
            Check.That(afterRemoveAtHash).IsNotEqualTo(afterIndexerHash);
        }

        [Test]
        public void Should_properly_expose_IndexOf()
        {
            var list = new ListByValue<Card>() { Card.Parse("QC"), Card.Parse("TS") };
            Check.That(list.IndexOf(Card.Parse("QC"))).IsEqualTo(0);
            Check.That(list.IndexOf(Card.Parse("TS"))).IsEqualTo(1);
        }

        [Test]
        public void Should_properly_expose_indexer()
        {
            var list = new ListByValue<Card>() { Card.Parse("QC"), Card.Parse("TS") };
            Check.That(list[0]).IsEqualTo(Card.Parse("QC"));
            Check.That(list[1]).IsEqualTo(Card.Parse("TS"));
        }

        [Test]
        public void Should_properly_expose_Contains()
        {
            var list = new ListByValue<Card>() { Card.Parse("QC"), Card.Parse("TS") };
            Check.That(list.Contains(Card.Parse("TS"))).IsTrue();
            Check.That(list.Contains(Card.Parse("4D"))).IsFalse();
        }

        [Test]
        public void Should_properly_expose_CopyTo()
        {
            var list = new ListByValue<Card>() { Card.Parse("QC"), Card.Parse("TS") };
            var cards = new Card[5];
            list.CopyTo(cards, 2);

            Check.That(cards).ContainsExactly(null, null, Card.Parse("QC"), Card.Parse("TS"), null);
        }

        [Test]
        public void Should_raise_NotImplementedException_when_calling_IsReadOnly_property()
        {
            var list = new ListByValue<int>() { 0, 1, 2 };
            
            Check.ThatCode(() => list.IsReadOnly).Throws<NotImplementedException>();
        }
    }
}