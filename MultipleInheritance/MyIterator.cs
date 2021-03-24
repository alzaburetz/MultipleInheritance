using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MultipleInheritance
{
    public class MyIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        IEnumerator<T> data;

        public T Current => data.Current;

        object IEnumerator.Current => data.Current;

        public void Dispose()
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data;
        }

        public bool MoveNext()
        {
            return data.MoveNext();
        }

        public void Reset()
        {
            data.Reset();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public MyIterator(IEnumerable<T> _data)
        {
            this.data = _data.GetEnumerator();
        }

        public MyIterator()
        {
            this.data = Enumerable.Empty<T>().GetEnumerator();
        }
    }

    public class MyWhereIterator<T> : IEnumerable<T>, IEnumerator<T>
    {
        IEnumerator<T> data;
        Func<T, bool> predicate;
        public T Current => data.Current;

        object IEnumerator.Current => data.Current;

        public void Dispose()
        {
           
        }
        public MyWhereIterator<T> GetEnumerator()
        {
            return this;
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return data;
        }
        public bool MoveNext()
        {
           while (predicate.Invoke(Current))
                data.MoveNext();
            return data.MoveNext();
        }
        bool IEnumerator.MoveNext()
        {
            return data.MoveNext();
        }

        public void Reset()
        {
            data.Reset();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)data;
        }

        public MyWhereIterator(IEnumerator<T> source,  Func<T, bool> predicate)
        {
            this.data = source;
            this.predicate = predicate;
        }
    }

    public class MyTakeIterator<T> : IEnumerable<T>, IEnumerator<T>
    {
        IEnumerator<T> data;
        int count;
        int amount = 0;
        public T Current => data.Current;

        object IEnumerator.Current => data.Current;

        public void Dispose()
        {
            
        }

        public MyTakeIterator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return data;
        }
        public bool MoveNext()
        {
            data.MoveNext();
            return count >= ++amount;
        }
        bool IEnumerator.MoveNext()
        {
            return data.MoveNext();
        }

        public void Reset()
        {
            data.Reset();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)data;
        }

        public MyTakeIterator(IEnumerator<T> source, int count)
        {
            data = source;
            this.count = count;
        }
    }
}
