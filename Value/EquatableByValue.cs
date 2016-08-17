namespace Value
{
    using System;

    /// <summary>
    /// Support a by-Value Equality and Unicity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EquatableByValue<T> : IEquatable<T> where T : EquatableByValue<T>
    {
        public bool Equals(T other)
        {
            return this.EqualsImpl(other);
        }

        protected abstract bool EqualsImpl(T other);

        protected abstract int GetHashCodeImpl();

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