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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Value
{
    /// <summary>
    /// Support a by-Value Equality and Unicity.
    /// </summary>
    /// <remarks>This latest implementation has been inspired from Scott Millett's book (Patterns, Principles, and Practices of Domain-Driven Design).</remarks>
    /// <typeparam name="T">Type of the elements.</typeparam>
    public abstract class EquatableByValue<T> : IEquatable<T>
    {
        protected const int Undefined = -1;

        protected volatile int HashCode = Undefined;

        protected void ResetHashCode()
        {
            HashCode = Undefined;
        }

        public static bool operator ==(EquatableByValue<T> x, EquatableByValue<T> y)
        {
            if (x is null && y is null)
            {
                return true;
            }

            if (x is null || y is null)
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
            var otherEquatable = other as EquatableByValue<T>;
            if (otherEquatable == null)
            {
                return false;
            }

            return EqualsImpl(otherEquatable);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is T other) return Equals(other);
            return false;
        }

        protected abstract IEnumerable<object> GetAllAttributesToBeUsedForEquality();

        protected virtual bool EqualsImpl(EquatableByValue<T> otherEquatable)
        {
            // Implementation where orders of the elements matters.
            return GetAllAttributesToBeUsedForEquality().SequenceEqual(otherEquatable.GetAllAttributesToBeUsedForEquality());
        }

        public override int GetHashCode()
        {
            // Implementation where orders of the elements matters.
            if (HashCode == Undefined)
            {
                var code = 0;

                foreach (var attribute in GetAllAttributesToBeUsedForEquality())
                {
                    code = (code * 397) ^ (attribute == null ? 0 : attribute.GetHashCode());
                }

                HashCode = code;
            }

            return HashCode;
        }

    }
}