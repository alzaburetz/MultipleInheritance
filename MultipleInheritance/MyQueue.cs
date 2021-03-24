using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MultipleInheritance
{
    public interface IQueue<T> : IEnumerator<T>, IEnumerable<T>
    {
        void Enqueue(T data);
        T Dequeue();
        int Count { get; }
    }
    public class MyQueue<T> : IQueue<T>
    {
        public int Count => _data.Length;

        public T Current => _data[_index];

        object IEnumerator.Current => _data[_index];

        public T Dequeue()
        {
            if (_index == 0)
            {
                throw new InvalidOperationException();
            }

            if (_version == _enumeration_verion)
            {
                throw new InvalidOperationException();
            }
            var dequeue = _data[0];

            var temp = new T[--_index];
            for (int i = 1; i < _data.Length; i++)
            {
                temp[i - 1] = _data[i];
            }
            _data = temp;
            _version++;

            return dequeue;
        }

        public void Dispose()
        {
        }

        public void Enqueue(T data)
        {
            if (data == null)
            {
                throw new InvalidOperationException();
            } 
            
            if (_version == _enumeration_verion)
            {
                throw new InvalidOperationException();
            }
            var temp = new T[++_index];
            if (this._data != null)
                this._data.CopyTo(temp, 0);
            this._data = temp;
            this._data[_index - 1] = data;
            _version++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            _enumeration_verion = _version;
            return ((IReadOnlyCollection<T>)this._data).GetEnumerator();
        }

        public bool MoveNext()
        {
            return ++_index < _data.Length;
        }

        public void Reset()
        {
            _index = -1;
            _version = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._data.GetEnumerator();
        }

        public MyQueue()
        {
            this._data = new T[0];
        }


        T[] _data;
        int _index;
        int _version;
        int _enumeration_verion = -1;
    }
}
