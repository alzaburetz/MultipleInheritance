using System;
using System.Collections;
using System.Collections.Generic;

namespace MultipleInheritance
{
    public class MyWhereIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        public T Current => _data.Current;

        object IEnumerator.Current => Current;

        public IEnumerator<T> GetEnumerator() => this;
        public bool MoveNext()
        {
            while (_data.MoveNext())
            {
                if (_predicate(_data.Current))
                {
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            _data.Reset();
        }

        public void Dispose()
        {
            _data.Dispose();
        }

        IEnumerator IEnumerable.GetEnumerator() => this;

        public MyWhereIterator(IEnumerable<T> source,  Func<T, bool> predicate)
        {
            _data = source.GetEnumerator();
            _predicate = predicate;
        }

        private IEnumerator<T> _data;
        private Func<T, bool> _predicate;
    }

    public class MyTakeIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        public T Current => _data.Current;

        object IEnumerator.Current => Current;

        public IEnumerator<T> GetEnumerator() => this;

        public bool MoveNext() => _count > _amount++ && _data.MoveNext();

        public void Reset()
        {
            _amount = 0;
            _data.Reset();
        }

        public void Dispose()
        {
            _data.Dispose();
        }

        IEnumerator IEnumerable.GetEnumerator() => this;

        public MyTakeIterator(IEnumerable<T> source, int count)
        {
            _data = source.GetEnumerator();
            _count = count;
        }


        private IEnumerator<T> _data;
        private int _count;
        private int _amount = 0;
    }
}
