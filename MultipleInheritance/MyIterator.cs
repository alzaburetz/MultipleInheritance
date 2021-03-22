using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MultipleInheritance
{
    public class MyIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        IEnumerable<T> data;

        public T Current => data.GetEnumerator().Current;

        object IEnumerator.Current => data.GetEnumerator().Current;

        public void Dispose()
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)data).GetEnumerator();
        }

        public bool MoveNext()
        {
            return data.GetEnumerator().MoveNext();
        }

        public void Reset()
        {
            data.GetEnumerator().Reset();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public MyIterator(IEnumerable<T> _data)
        {
            this.data = _data;
        }

        public MyIterator()
        {
            this.data = Enumerable.Empty<T>();
        }
    }
}
