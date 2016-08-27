// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="EquatableByValue.cs">
// //     Copyright 2016
// //           Thomas PIERRAIN (@tpierrain)    
// //     Licensed under the Apache License, Version 2.0 (the "License");
// //     you may not use this file except in compliance with the License.
// //     You may obtain a copy of the License at
// //         http://www.apache.org/licenses/LICENSE-2.0
// //     Unless required by applicable law or agreed to in writing, software
// //     distributed under the License is distributed on an "AS IS" BASIS,
// //     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //     See the License for the specific language governing permissions and
// //     limitations under the License.b 
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------
namespace Value
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Support a by-Value Equality and Unicity.
    /// </summary>
    /// <remarks>This latest implementation has been inspired from Scott Millett's book (Patterns, Principles, and Practices of Domain-Driven Design).</remarks>
    /// <typeparam name="T"></typeparam>
    public abstract class EquatableByValue<T> : IEquatable<T> where T : EquatableByValue<T>
    {
        private const int undefined = -1;

        private volatile int hashCode = undefined;

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

        public bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            return this.GetAllAttributesToBeUsedForEquality().SequenceEqual(other.GetAllAttributesToBeUsedForEquality());
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

            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.GetHashCodeImpl();
        }

        protected abstract IEnumerable<object> GetAllAttributesToBeUsedForEquality();

        protected virtual void ResetHashCode()
        {
            this.hashCode = undefined;
        }

        private int GetHashCodeImpl()
        {
            if (this.hashCode == undefined)
            {
                var code = 0;

                foreach (var attribute in this.GetAllAttributesToBeUsedForEquality())
                {
                    code = (code * 397) ^ (attribute == null ? 0 : attribute.GetHashCode());
                }

                this.hashCode = code;
            }

            return this.hashCode;
        }
    }
}