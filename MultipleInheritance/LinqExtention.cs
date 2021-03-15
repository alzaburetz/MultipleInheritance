using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using MultipleInheritance;

namespace System.Linq
{
    public class MyEnumerator<T> : IEnumerator<T>, IEnumerable<T>
    {
        public List<T> Data;
        private int index = -1;
        public T Current
        {
            get
            {
                if (index == -1)
                    MoveNext();
                return Data[index];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            int position = this.index + 1;

            if (position >= 0 && position < this.Data.Count)
            {
                this.index = position;
                return true;
            }

            else
            {
                return false;
            }
        }

        public void Reset()
        {
            this.index = 0;
        }

        public IEnumerator<T> GetEnumerator() => Data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();

        public MyEnumerator() { Data = new List<T>(); }

        public MyEnumerator(List<T> data)
        {
            Data = new List<T>();
            Data.AddRange(data);
            this.index = 0;
        }
    }
    public static class LinqExtention
    {
        public static IEnumerable<T> MyTake<T>(this IEnumerable<T> collection, int count)
        {
            if (collection.Data.Count < count)
            {
                throw new IndexOutOfRangeException();
            }
            var result = new T[count];
            int i = 0;
            while(i < count)
            {
                result.Add(collection.Current);
                if (collection.MoveNext())
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            var result = new List<T>();
            foreach(var item in collection)
            {
                if (condition.Invoke(collection.Current))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
