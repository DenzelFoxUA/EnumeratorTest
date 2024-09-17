using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorTest
{
    public class SomeCustomWordCollection : IEnumerable
    {
        private string[] _words;

        public SomeCustomWordCollection(string[] words)
        {
            _words = words;
        }

        public IEnumerator GetEnumerator()
        {
            var enumerator = new SomeCustomCollectionEnumerator(_words);
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }


    public class SomeCustomCollectionEnumerator : IEnumerator
    {
        private object[] _collection;
        private int _currentIndex;
        private int _startingPoint = -1;
        private int _size;

        private SomeCustomCollectionEnumerator()
        {
            _size = 0;
            _collection = new object[_size];
        }

        public SomeCustomCollectionEnumerator(object [] collection)
        {
            _currentIndex = _startingPoint;
            _size = collection.Length;
            _collection = collection;
        }

        public int Size { get => _collection.Length; private set => _size = value; }

        public object Current => GetObject(_currentIndex);

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < Size;
        }

        public void Reset()
        {
            _currentIndex = _startingPoint;
        }

        private object GetObject(int index)
        {

            try
            {
                return _collection[index];
            }
            catch(IndexOutOfRangeException ex)
            {
                string msg = ex.Message;
                throw new IndexOutOfRangeException(msg);
            }
            catch(Exception ex)
            {
               string msg = ex.Message;
               throw new Exception(msg);
            }
        }

    }
}
