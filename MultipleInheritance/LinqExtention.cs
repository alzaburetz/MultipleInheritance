using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    public static class LinqExtention
    {
        public static IEnumerable<T> MyTake<T>(this IEnumerable<T> collection, int count)
        {
            if (collection.Count() < count)
            {
                throw new IndexOutOfRangeException();
            }
            var result = new List<T>();
            int i = 0;
            foreach(var item in collection)
            {
                if (i < count)
                {
                    result.Add(item);
                }
                i++;
            }
            return result;
        }

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            var result = new List<T>();
            foreach(var item in collection)
            {
                if (condition.Invoke(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
