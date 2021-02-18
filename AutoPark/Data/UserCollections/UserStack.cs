using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Data.UserCollections
{
    /// <summary>
    /// My realization stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UserStack<T> : IEnumerable<T>
    {
        private T[] _stackArray;
        private const int STANDART_SIZE = 16;
        private int _index;
        public int Count => _index;
        private void DoubleArraySize()
        {
            Array.Resize(ref _stackArray, _stackArray.Length * 2);
        }
        public UserStack()
        {
            _stackArray = new T[STANDART_SIZE];
        }
        public UserStack(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("Count should not be lower than zero!", nameof(count));
            }
            _stackArray = new T[count];
        }
        public UserStack(IEnumerable<T> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source data should not be null!");
            }
            _stackArray = source.ToArray();
            _index = _stackArray.Length - 1;
        }

        public void Push(T data)
        {
            if (_index < _stackArray.Length)
            {
                _stackArray[_index++] = data;
            }
            else
            {
                DoubleArraySize();
                _stackArray[_index++] = data;
            }
        }
        public bool Contains(T data) => _stackArray.Contains(data);
        public T Pop()
        {
            if (_index <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(_index), "Stack is already empty!");
            }
            var item = _stackArray[_index - 1];
            _stackArray[_index - 1] = default;
            _index--;
            return item; 
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator()
        {
            var currentElementIndex = 0;
            while (currentElementIndex < _index + 1 && _stackArray[currentElementIndex] != null)
            {
                yield return _stackArray[currentElementIndex++];
            }
        }
    }
}
