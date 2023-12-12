using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab07
{
    internal partial class CollectionType<T> 
    {
        public static CollectionType<T> operator +(T newValue, CollectionType<T> a)
        {

            a.items.Insert(0, newValue);
            return a;

        }

        public static CollectionType<T> operator --(CollectionType<T> a)
        {
            a.items.RemoveAt(0);
            return a;
        }

        public static bool operator ==(CollectionType<T> a, CollectionType<T> b)
        {
            return a.items.Equals(b.items);
        }

        public static bool operator !=(CollectionType<T> a, CollectionType<T> b)
        {
            return !(a.items.Equals(b.items));
        }

        public static CollectionType<T> operator *(CollectionType<T> a, CollectionType<T> b)
        {
            List<T> combinedItems = new List<T>(a.items);
            combinedItems.AddRange(b.items);
            return new CollectionType<T>(combinedItems);
        }

    }
}