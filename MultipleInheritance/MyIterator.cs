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
        public virtual MyIterator<T> GetEnumerator() => this;

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => data;
        public virtual bool MoveNext()
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
            this.data = ((IEnumerable<T>)_data).GetEnumerator();
        }

        public MyIterator()
        {
            this.data = Enumerable.Empty<T>().GetEnumerator();
        }
    }

    public class MyWhereIterator<T> : MyIterator<T>
    {
        MyIterator<T> data;
        Func<T, bool> predicate;
        public new T Current => data.Current;
        public MyWhereIterator<T> GetEnumerator()
        {
            return this;
        }
        public override bool MoveNext()
        {
           //while (predicate.Invoke(Current))
           //     data.MoveNext();
           // return data.MoveNext();
           while (data.MoveNext())
            {
                if (predicate(data.Current))
                {
                    return true;
                }
            }
            return false;
        }
        public MyWhereIterator(IEnumerator<T> source,  Func<T, bool> predicate)
        {
            this.data = (MyIterator<T>)source;
            this.predicate = predicate;
        }
    }

    public class MyTakeIterator<T> : MyIterator<T>
    {
        MyIterator<T> data;
        int count;
        int amount = 0;
        public new T Current => data.Current;
        public MyTakeIterator<T> GetEnumerator() => this;

        public override bool MoveNext()
        {
            while (count > amount)
            {
                data.MoveNext();
                amount++;
                return true;
            }
            return false;
        }
        public MyTakeIterator(IEnumerator<T> source, int count)
        {
            data = (MyIterator<T>)source;
            this.count = count;
        }
    }
}
