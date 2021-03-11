using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
        public static MyEnumerator<T> MyTake<T>(this MyEnumerator<T> collection, int count)
        {
            if (collection.Data.Count < count)
            {
                throw new IndexOutOfRangeException();
            }
            var result = new List<T>();
            int i = 0;
            while(i < count)
            {
                result.Add(collection.Current);
                if (collection.MoveNext())
                {
                    i++;
                }
            }
            return new MyEnumerator<T>(result);
        }

        public static MyEnumerator<T> MyWhere<T>(this MyEnumerator<T> collection, Predicate<T> condition)
        {
            var result = new List<T>();
            while (collection.MoveNext())
            {
                if (condition.Invoke(collection.Current))
                {
                    result.Add(collection.Current);
                }
            }
            return new MyEnumerator<T>(result);
        }
    }
}
