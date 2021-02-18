using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Data.UserCollections
{
    public class UserQueue<T> : IEnumerable<T>
    {
        private T[] _queueArray;
        private const int STANDART_SIZE = 16;
        private int _head;
        private int _tail;
        private int _size;
        public int Count => _size;
        private void DoubleArraySize()
        {
            Array.Resize(ref _queueArray, _queueArray.Length * 2);
        }
        public UserQueue()
        {
            _queueArray = new T[STANDART_SIZE];
        }
        public UserQueue(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("Count should not be lower than zero!", nameof(count));
            }
            _queueArray = new T[count];
        }
        public UserQueue(IEnumerable<T> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source data should not be null!");
            }
            _queueArray = source.ToArray();
            _size = _queueArray.Length;
            _tail = _size;
        }

        public void Enqueue(T data)
        {
            if (_head == _size)
            {
                DoubleArraySize();
            }
            _queueArray[_tail] = data;
            MoveNext(ref _tail);
            _size++;
        }

        public bool Contains(T data) => _queueArray.Contains(data);
        public void Clear()
        {
            if (_size != 0)
            {
                Array.Clear(_queueArray, 0, _queueArray.Length);
            }
        }
        public T Dequeue()
        {
            T removed = _queueArray[_head];
            _queueArray[_head] = default;
            MoveNext(ref _head);
            _size--;
            return removed;
        }

        private void MoveNext(ref int index)
        {
            var tmp = index + 1;
            if (tmp == _queueArray.Length)
            {
                tmp = 0;
            }
            index = tmp;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() 
        {
            var tail = _tail;
            var head = _head;
            while (tail != head)
            {
                yield return _queueArray[head++];
            }
        }

    }
}
