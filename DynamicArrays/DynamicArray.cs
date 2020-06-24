using System;

namespace Task2
{
    public class DynamicArray<T> where T : new()
    {
        // fields
        private T[] elements;

        private const int defaultCapacity = 8;

        // props
        public int Capacity
        {
            get
            {
                return elements.Length;
            }
        }

        public int Length { get; private set; }

        // constructors
        public DynamicArray()
        {
            elements = new T[defaultCapacity];
        }

        public DynamicArray(int size)
        {
            elements = new T[size];
        }

        public DynamicArray(T[] arr)
        {
            elements = new T[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                elements[i] = arr[i];
            }
        }
        // indexer
        public T this[int i]
        {
            get { return elements[i]; }
            set
            {
                if ((i < Capacity) || (i > 0))
                {
                    elements[i] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        } // end of internal stuff
        // ----------------------------

        public void IncreaseCapacity(int c)
        {
            if (c != Length)
            {
                if (c > 0)
                {
                    T[] newItems = new T[c];
                    if (Length > 0)
                    {
                        Array.Copy(elements, 0, newItems, 0, Length);
                    }
                    elements = newItems;
                }
                else
                {
                    elements = new T[defaultCapacity];
                }
            }
        }
        
        public void Add(T item)
        {
            if (Length == Capacity) IncreaseCapacity(Capacity * 2);
            elements[Length++] = item;
        }
       
        public void AddRange(T[] arr)
        {
            if (Capacity - Length < arr.Length)
            {
                IncreaseCapacity(Capacity + arr.Length);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                elements[Length] = arr[i];
                Length++;
            }
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(elements, item, 0, Length); ;
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            Length--;
            if (index < Length)
            {
                Array.Copy(elements, index + 1, elements, index, Length - index);
            }
            elements[Length] = default(T);
        }

        public void Insert(T element, int index)
        {
            if ((index > Capacity) || (index < 0)) throw new ArgumentOutOfRangeException();
            if (Capacity == Length)
            {
                IncreaseCapacity(Capacity * 2);
            }

            for (int i = 0; i < Length - index; i++)
            {
                elements[Length - i] = elements[Length - i - 1];
            }
            elements[index] = element;
        }

        
        public void Filter(Func<T, bool> func)
        {
            for (int i = 0; i < Length; i++)
            {
                if (!func(elements[i]))
                {
                    RemoveAt(i--);
                }
            }
        }

        public delegate bool d1(T t1);

        // same as filter but with delegates
        public void FilterD(d1 d)
        {
            for (int i = 0; i < Length; i++)
            {
                if (!d(elements[i]))
                {
                    RemoveAt(i--);
                }
            }
        }

        public void Sort(Func<T, T, int> func)
        {
            T temp;

            for (int i = 0; i < elements.Length - 1; i++)
            {
                for (int j = 0; j < elements.Length - 1; j++)
                {
                    if (func(elements[j], elements[j + 1]) == 1)
                    {
                        temp = elements[j + 1];
                        elements[j + 1] = elements[j];
                        elements[j] = temp;
                    }
                }
            }
        }

        static public int Comparator(T t1, T t2)
        {
            if (int.TryParse(t1.ToString(), out int i1) == false)
                i1 = int.MaxValue;
            int.TryParse(t2.ToString(), out int i2);
            if (Double.TryParse(t1.ToString(), out double d1) == false)
                d1 = double.MaxValue;
            Double.TryParse(t2.ToString(), out double d2);
            string s1 = t1.ToString();
            string s2 = t2.ToString();
            if (i1 != int.MaxValue)
            {
                if (i1 == i2)
                    return 0;
                else if (i1 > i2)
                    return 1;
                else
                    return -1;
            }
            else if (d1 != Double.MaxValue)
            {
                if (d1 == d2)
                    return 0;
                else if (d1 > d2)
                    return 1;
                else
                    return -1;
            }
            else
            {
                if (s1.Length == s2.Length)
                    return 0;
                else if (s1.Length > s2.Length)
                    return 1;
                else
                    return -1;
            }
        }

        
    }
}