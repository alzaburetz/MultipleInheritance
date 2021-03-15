using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using MultipleInheritance;

namespace System.Linq
{ 
    public static class LinqExtention
    {
        public static MyIterator<T> MyTake<T>(this MyIterator<T> collection, int count)
        {
            if (collection.Count() < count)
            {
                throw new IndexOutOfRangeException();
            }
            var result = new T[count];
            int i = 0;
            while(i < count)
            {
                if (collection.MoveNext())
                {
                    result[i] = collection.Current;
                    i++;
                }
            }
            return new MyIterator<T>(result);
        }

        public static MyIterator<T> MyWhere<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            var result = new T[1];
            int i = 0;
            foreach(var item in collection)
            {
                if (condition.Invoke(item))
                {
                    result[i] = item;
                    i++;
                    var temp = new T[i + 1];
                    result.CopyTo(temp, 0);
                    result = temp;
                }
            }
            return new MyIterator<T>(result);
        }
    }
}
