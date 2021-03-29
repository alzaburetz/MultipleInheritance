using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using MultipleInheritance;

namespace System.Linq
{ 
    public static class LinqExtention
    {
        public static IEnumerable<T> MyTake<T>(this IEnumerable<T> col, int count)
        {
            return new MyTakeIterator<T>(col, count);
        }

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> collection, Func<T, bool> condition)
        {
            return new MyWhereIterator<T>(collection, condition);
        }
    }
}
