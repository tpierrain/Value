
namespace Value.Shared
{
    using System.Collections.Generic;

    /// <summary>
    /// Determines two collections are equal by values, i.e. ignoring the order of an elements,
    /// but the exact elements contained.
    /// </summary>
    public class EqualByValues<T>  
    {
        private IEnumerable<T> _first;
        private IEnumerable<T> _second;

        public EqualByValues(IEnumerable<T> first, IEnumerable<T> second)
        {
            _first = first;
            _second = second;
        }

        public bool Value()
        {
            bool ret = true;
            HashSet<T> set = new HashSet<T>(_first);
            foreach (var item in _second)
            {
                if (!set.Contains(item))
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }

        public static implicit operator bool(EqualByValues<T> equalByValues)
        {
            return equalByValues.Value();
        }
    }
}
