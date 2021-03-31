using System;
using System.Collections;
using System.Collections.Generic;

namespace MultipleInheritance
{
    public interface IQueue<T> : IEnumerable<T>
    {
        void Enqueue(T data);
        T Dequeue();
        int Count { get; }
    }
    public class MyQueue<T> : IQueue<T>
    {
        public int Count => _size;

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }
            var output = _head.Data;
            _head = _head.Next;
            _size--;
            _version++;
            return output;
        }

        public void Enqueue(T data)
        {
            var node = new Node<T>(data);
            var temp = _tail;
            _tail = node;
            if (_size == 0)
            {
                _head = _tail;
            }
            else
            {
                temp.Next = _tail;
            }
            _size++;
            _version++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyQueueEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> _head;
        private Node<T> _tail;
        private int _size;
        private int _version;

        private class MyQueueEnumerator<T> : IEnumerator<T>
        {
            public T Current => _currentElement;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            public bool MoveNext()
            {
                if (_version != _q._version)
                {
                    throw new InvalidOperationException();
                }
                if (_head != null)
                {
                    _currentElement = _head.Data;
                    _head = _head.Next;
                    return true;
                }
                else
                {
                    _currentElement = _tail.Data;
                    _head = _tail;
                    return false;
                }
            }

            public void Reset()
            {
                _head = _q._head;
            }

            public MyQueueEnumerator(MyQueue<T> queue)
            {
                _q = queue;
                _version = _q._version;
                _head = _q._head;
                _tail = _q._tail;
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                {
                    return;
                }

                _disposed = true;
            }

            private MyQueue<T> _q;
            private Node<T> _head;
            private Node<T> _tail;
            private T _currentElement;
            private int _version;
            private bool _disposed;
        }
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
