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
        public int Count => _index;

        public T Current => _head.Data;

        object IEnumerator.Current => _head.Data;

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

            T output = _head.Data;
            _head = _head.Next;
            _index--;
            _version++;
            return output;
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
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = _tail;
            _tail = node;
            if (_index == 0)
                _head = _tail;
            else
                tempNode.Next = _tail;
            _version++;
            _index++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            _enumeration_verion = _version;
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public bool MoveNext()
        {
            if (_version != _enumeration_verion)
            {
                throw new InvalidOperationException();
            }
            return true;
        }
        public void Reset()
        {
            _index = 0;
            _version = 0;
            _enumeration_verion = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            _enumeration_verion = _version;
            return this.GetEnumerator();
        }

        public MyQueue()
        {
        }


        Node<T> _head;
        Node<T> _tail;
        int _index;
        int _version;
        int _enumeration_verion = -1;
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T data)
        {
            Data = data;
        }
    }
}
