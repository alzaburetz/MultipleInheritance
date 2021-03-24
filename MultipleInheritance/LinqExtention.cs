using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using MultipleInheritance;

namespace System.Linq
{ 
    public static class LinqExtention
    {
        public static MyTakeIterator<T> MyTake<T>(this MyIterator<T> col, int count)
        {
            return new MyTakeIterator<T>(col, count);
        }

        public static MyWhereIterator<T> MyWhere<T>(this MyIterator<T> collection, Func<T, bool> condition)
        {
            return new MyWhereIterator<T>(collection, condition);
        }
    }
}
