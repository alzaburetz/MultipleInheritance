using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

        public Node<T> Head => _head;

        public Node<T> Tail => _tail;
        public bool CheckVersion() => _version != _enumeration_version;

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException();
            }
            var output = this._head.Data;
            this._head = _head.Next;
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
            _enumeration_version = _version;
            return new MyQueueEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        private Node<T> _head;
        private Node<T> _tail;
        private int _size;
        private int _version;
        private int _enumeration_version;
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

    public class MyQueueEnumerator<T> : IEnumerator<T>
    {
        public T Current => currentElement;

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (_q.CheckVersion())
            {
                throw new InvalidOperationException();
            }
            if (_head != null)
            {
                currentElement = _head.Data;
                _head = _head.Next;
            }
            else
            {
                currentElement = _tail.Data;
                _head = _tail;
            }
            _index--;
            return _index >= 0;
        }

        public void Reset()
        {
            _index = _q.Count;
            _head = _q.Head;
        }

        public MyQueueEnumerator(MyQueue<T> queue)
        {
            _q = queue;
            _head = _q.Head;
            _tail = _q.Tail;
            _index = _q.Count;
        }

        private readonly MyQueue<T> _q;
        private Node<T> _head;
        private Node<T> _tail;
        private int _index;
        private T currentElement;
    }
}
