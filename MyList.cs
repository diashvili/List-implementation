using System;
using System.Collections;


namespace chemifroeach
{
        class MyList : IList, IEnumerator
        {
            
            private object[] _items = new object[4];
            private int _count = 0;
            private int _index;
            public MyList(object[] array, int count)
            {
                _items = array;
                _index = -1;
                _count = count;
            }
            public MyList()
            {

            }
            public object Current
            {
                get
                {
                    return _items[_index];
                }
            }
            public bool MoveNext()
            {
                if (_index + 1 < _count)
                {
                    _index++;

                    return true;
                }
                return false;

            }
            public void Reset()
            {
                _index = -1;
            }
            public IEnumerator GetEnumerator()
            {
                return new MyList(_items, Count);
            }

            private static void ArrayResize(ref object[] array, int newSize)
            {
                object[] temp = new object[newSize];
                int size = Math.Min(array.Length, newSize);

                for (int i = 0; i < size; i++)
                {
                    temp[i] = array[i];
                }

                array = temp;
            }

            public int Add(object value)
            {
                if (Count == _items.Length)
                {
                    ArrayResize(ref _items, _items.Length * 2);
                }

                Count++;
                _items[Count - 1] = value;

                return Count - 1;
            }

            public void AddRange(object[] values)
            {

                for (int i = 0; i < values.Length; i++)
                {
                    Add(values[i]);
                }

            }


            public void Insert(int index, object value)
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                if (Count == _items.Length)
                {
                    ArrayResize(ref _items, _items.Length * 2);
                }

                Count++;
                for (int i = Count - 1; i > index; i--)
                {
                    _items[i] = _items[i - 1];
                }
                _items[index] = value;
            }

            public void InsertRange(int index, object[] values)
            {

                for (int i = 0; i < values.Length; i++)
                {
                    Insert(index, values[i]);
                    index++;
                }

            }

            public void Remove(object value)
            {
                int index = IndexOf(value);
                if (index != -1)
                {
                    RemoveAt(index);
                }
            }

            public void RemoveAll(object value)
            {

                for (int i = Count - 1; i > -1; i--)
                {
                    if (_items[i] == value)
                    {
                        Remove(value);
                        Count--;
                    }
                }

            }

            public void RemoveAt(int index)
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                for (int i = index; i < _items.Length - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }
                ArrayResize(ref _items, _items.Length - 1);
            }


            public void Clear()
            {
                _items = new object[4];
                Count = 0;
            }

            public bool Contains(object value)
            {
                if (IndexOf(value) != -1)
                {
                    return true;
                }
                return false;
            }

            public int IndexOf(object value)
            {
                return IndexOf(value, 0);
            }

            public int IndexOf(object value, int startIndex)
            {
                for (int i = startIndex; i < _items.Length; i++)
                {
                    if (_items[i] == value)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public int[] IndexesOf(object value)
            {
                return IndexesOf(value, 0);
            }
            private static void ArrayResize(ref int[] array, int newSize)
            {
                int[] temp = new int[newSize];
                int size = Math.Min(array.Length, newSize);

                for (int i = 0; i < size; i++)
                {
                    temp[i] = array[i];
                }

                array = temp;
            }

            public int[] IndexesOf(object value, int startIndex)
            {
                int[] obj = new int[0];
                int y = 0;
                for (int i = startIndex; i < _items.Length; i++)
                {
                    if (_items[i] == value)
                    {
                        ArrayResize(ref obj, obj.Length + 1);
                        obj[y] = i;
                        y++;

                    }
                }
                return obj;
            }

            public void TrimToSize()
            {
                ArrayResize(ref _items, Count);
            }

            public int Count
            {
                get
                {
                    return _count;
                }
                private set
                {
                    _count = value;
                }
            }

            public int Capacity
            {
                get
                {
                    return _items.Length;
                }
                set
                {
                    if (value < Count)
                    {
                        value = Count;
                    }
                    ArrayResize(ref _items, value);
                }
            }

            public object this[int index]
            {
                get
                {
                    if (index >= Count)
                    {
                        throw new ArgumentOutOfRangeException("index");
                    }
                    return _items[index];
                }
                set
                {
                    if (index >= Count)
                    {
                        throw new ArgumentOutOfRangeException("index");
                    }
                    _items[index] = value;
                }
            }

            //----- ქვედები ჯერ არ გვაინტერესებს.

            public bool IsFixedSize
            {
                get
                {
                    return false;
                }
            }

            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            public bool IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            public object SyncRoot
            {
                get
                {
                    return this;
                }
            }

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }


        }
    }


