using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MultipleInheritance
{
    public class MyWhereIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        IEnumerator<T> data;
        Func<T, bool> predicate;
        public T Current => data.Current;

        object IEnumerator.Current => Current;

        public IEnumerator<T> GetEnumerator() => this;
        public bool MoveNext()
        {
           while (data.MoveNext())
            {
                if (predicate(data.Current))
                {
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            data.Reset();
        }

        public void Dispose()
        {
            data.Dispose();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)data;
        }

        public MyWhereIterator(IEnumerable<T> source,  Func<T, bool> predicate)
        {
            this.data = source.GetEnumerator();
            this.predicate = predicate;
        }
    }

    public class MyTakeIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        IEnumerator<T> data;
        int count;
        int amount = 0;

        public T Current => data.Current;

        object IEnumerator.Current => Current;

        public IEnumerator<T> GetEnumerator() => this;

        public bool MoveNext()
        {
            while (count > amount)
            {
                data.MoveNext();
                amount++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            data.Reset();
        }

        public void Dispose()
        {
            data.Dispose();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)data;
        }

        public MyTakeIterator(IEnumerable<T> source, int count)
        {
            data = source.GetEnumerator();
            this.count = count;
        }
    }
}
