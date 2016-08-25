namespace Value
{
    using System.Collections;
    using System.Collections.Generic;

    public class HashSetByValue<T> : ISet<T>
    {
        private readonly ISet<T> hashSet;

        private int? hashCode;

        public HashSetByValue(ISet<T> hashSet)
        {
            this.hashSet = hashSet;
        }

        public HashSetByValue() : this(new HashSet<T>())
        {
        }

        public override bool Equals(object obj)
        {
            var other = obj as HashSetByValue<T>;
            if (other == null)
            {
                return false;
            }

            return this.hashSet.SetEquals(other);
        }

        public override int GetHashCode()
        {
            if (this.hashCode == null)
            {
                int code = 0;

                // Two instances with same elements added in different order must return the same hashcode
                // Let's compute and sort hashcodes of all elements (always in the same order)
                var sortedHashs = new SortedSet<int>();
                foreach (var element in this.hashSet)
                {
                    sortedHashs.Add(element.GetHashCode());
                }

                foreach (var element in sortedHashs)
                {
                    code = (code * 397) ^ element.GetHashCode();
                }

                this.hashCode = code;
            }

            return this.hashCode.Value;
        }

        public int Count => this.hashSet.Count;

        public bool IsReadOnly => this.hashSet.IsReadOnly;

        public void Add(T item)
        {
            this.hashSet.Add(item);
        }

        public void Clear()
        {
            this.hashSet.Clear();
        }

        public bool Contains(T item)
        {
            return this.hashSet.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.hashSet.CopyTo(array, arrayIndex);
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            this.hashSet.ExceptWith(other);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.hashSet.GetEnumerator();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            this.hashSet.IntersectWith(other);
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return this.hashSet.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return this.hashSet.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return this.hashSet.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return this.hashSet.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            return this.hashSet.Overlaps(other);
        }

        public bool Remove(T item)
        {
            return this.hashSet.Remove(item);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return this.hashSet.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            this.hashSet.SymmetricExceptWith(other);
        }

        public void UnionWith(IEnumerable<T> other)
        {
            this.hashSet.UnionWith(other);
        }

        bool ISet<T>.Add(T item)
        {
            return this.hashSet.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.hashSet).GetEnumerator();
        }
    }
}