// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquatableByValue.cs">
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
namespace Value
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Support a by-Value Equality and Unicity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EquatableByValue<T> : IEquatable<T> where T : EquatableByValue<T>
    {
        private int? hashCode;

        public bool Equals(T other)
        {
            return this.EqualsImpl(other);
        }

        protected abstract IEnumerable<object> ProvideListOfAllAttributesToBeUsedForEquality();

        protected virtual void ResetHashCode()
        {
            this.hashCode = null;
        }

        private bool EqualsImpl(T other)
        {
            if (other == null)
            {
                return false;
            }

            return this.ProvideListOfAllAttributesToBeUsedForEquality().SequenceEqual(other.ProvideListOfAllAttributesToBeUsedForEquality());
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as T;

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return this.EqualsImpl(other);
        }

        public override int GetHashCode()
        {
            return this.GetHashCodeImpl();
        }

        private int GetHashCodeImpl()
        {
            if (this.hashCode == null)
            {
                var code = 0;

                foreach (var attribute in this.ProvideListOfAllAttributesToBeUsedForEquality())
                {
                    code = (code * 397) ^ ((attribute == null) ? 0 : attribute.GetHashCode());
                }

                this.hashCode = code;
            }

            return this.hashCode.Value;
        }

        public static bool operator ==(EquatableByValue<T> x, EquatableByValue<T> y)
        {
            if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
            {
                return true;
            }

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }

            return x.Equals(y);
        }

        public static bool operator !=(EquatableByValue<T> x, EquatableByValue<T> y)
        {
            return !(x == y);
        }
    }
}