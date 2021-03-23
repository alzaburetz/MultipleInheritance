﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using MultipleInheritance;

namespace System.Linq
{ 
    public static class LinqExtention
    {
        public static MyIterator<T> MyTake<T>(this MyIterator<T> col, int count)
        {
            var result = new MyIterator<T>();
            int i = 0;
            var collection = col.GetEnumerator();
            while(i < count)
            {
                if (collection.MoveNext())
                {
                    result = result.Append(collection.Current);
                    i++;
                }
            }

            return result;
        }

        public static MyIterator<T> MyWhere<T>(this MyIterator<T> collection, Predicate<T> condition)
        {
            var result = new MyIterator<T>();
            int i = 0;
            foreach(var item in collection)
            {
                if (condition.Invoke(item))
                {
                    result = result.Append(item);
                }
            }
            return result;
        }
    }
}
