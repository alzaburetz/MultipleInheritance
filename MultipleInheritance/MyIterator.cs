using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MultipleInheritance
{
    public class MyIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        List<T> data;
        int index;

        public T Current => data[index];

        object IEnumerator.Current => data[index];

        public void Dispose()
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public bool MoveNext()
        {
            return index++ <= data.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)data.GetEnumerator();
        }

        public MyIterator(IEnumerable<T> _data)
        {
            this.data = new List<T>();
            this.data.AddRange(_data);
        }

    }
}
