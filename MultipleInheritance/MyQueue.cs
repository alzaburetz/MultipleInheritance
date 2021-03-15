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
        T[] data;
        int index;
        public int Count => data.Length;

        public T Current => data[index];

        object IEnumerator.Current => data[index];

        public T Dequeue()
        {
            if (index == 0)
            {
                throw new InvalidOperationException();
            }
            var dequeue = data[0];

            var temp = new T[--index];
            for (int i = 1; i < data.Length; i++)
            {
                temp[i - 1] = data[i];
            }
            data = temp;


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
            var temp = new T[++index];
            if (this.data != null)
                this.data.CopyTo(temp, 0);
            this.data = temp;
            this.data[index - 1] = data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this.data).GetEnumerator();
        }

        public bool MoveNext()
        {
            return ++index < data.Length;
        }

        public void Reset()
        {
            index = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        public MyQueue()
        {
            this.data = new T[0];
        }
    }
}
