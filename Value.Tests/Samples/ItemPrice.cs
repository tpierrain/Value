// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemPrice.cs">
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
namespace Value.Tests.Samples
{
    /// <summary>
    /// Price for an item.
    /// </summary>
    public class ItemPrice : Amount
    {
        private readonly string itemName;

        private int? hashCode;

        public ItemPrice(string itemName, decimal quantity, Currency currency) : base(quantity, currency)
        {
            this.itemName = itemName;
        }

        public string ItemName { get { return this.itemName; } }

        protected override bool EqualsImpl(Amount other)
        {
            var theOther = other as ItemPrice;
            if (theOther == null)
            {
                return false;
            }

            return base.EqualsImpl(other) && (this.ItemName == theOther.ItemName);
        }

        protected override int GetHashCodeImpl()
        {
            if (this.hashCode == null)
            {
                this.hashCode = base.GetHashCodeImpl() ^ this.ItemName.GetHashCode();
            }

            return this.hashCode.Value;
        }

        public override string ToString()
        {
            return string.Format("{0} - price: {1} {2}.", this.ItemName, this.Quantity, this.Currency);
        }
    }
}