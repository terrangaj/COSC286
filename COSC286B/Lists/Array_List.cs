using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Markup;

namespace Lists
{
    /// <summary>
    /// Implementation of a list using arrays
    /// </summary>
    /// <typeparam name="T">The type the list stores</typeparam>
    public class Array_List<T> : A_List<T> where T : IComparable<T>
    {
        private T[] values = new T[0];
        public override int Count
        {
            get
            {
                return values.Length;
            }
        }

        public override void Add(T data)
        {
            T[] newValues = new T[values.Length + 1];
            for (int i = 0; i < values.Length; i++)
            {
                newValues[i] = values[i];
            }
            newValues[values.Length] = data; 
            values = newValues;
        }

        //private attribute to actually hold our array of 

        public override void Clear()
        {
            values = new T[0];
        }



        public override T ElementAt(int index)
        {
            if (index < 0 || index >= values.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return values[index];
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        public override void Insert(int index, T data)
        {
            //create new array, bigger than the old one

            //loop through the new values in the old array
            //keep track of the position in both the old array and the new one
            // if at the insertion point insert the new data

            //after copying everything and inserting the new data
            //make sure to set values = the new array
            if (index < 0 || index >= values.Length)
            {
                throw new IndexOutOfRangeException();
            }
            T[] temp = new T[values.Length+1];

            for (int i = 0; i< index;i++)
            {
                temp[i] = values[i];
            }
            temp[index] = data;

            for (int j = index; j < values.Length; j++)
            {
                temp[j+1] = values[j];
            }
            values = temp;

        }

        public override int IndexOf(T data)
        {
            for (int i = 0;i< values.Length;i ++)
            {
                if (data.Equals(values[i]))
                {
                    return i;
                }

            }
            throw new ApplicationException("Could not find item " + data + " in list.");
        }


        public override bool Remove(T data)
        {
            try
            {
                int indexOfItemToRemove = IndexOf(data);
                RemoveAt(indexOfItemToRemove);
                return true;
            }
            catch (ApplicationException e)
            {
                return false;
            }
            
        }

        public override T RemoveAt(int index)
        {
            if (index < 0 || index > values.Length)
            {
                throw new IndexOutOfRangeException();
            }

            T[] temp = new T[values.Length - 1];
            
            for (int i = 0; i< values.Length-1; i++)
            {
                if (i < index)
                {
                    temp[i] = values[i];
                }
                else
                {
                    temp[i] = values[i + 1];
                }
            }
            T value = values[index];
            values = temp;
            return value;
            //keep track of the item removed
            //create an array one shorter than the last one
            //loop throught the old array copying every value excepti the one being replaced
            //when youre done remember to 
            // replace the values attribute with the shorter one
            // return the item that was removed
        }

        public override T ReplaceAt(int index, T data)
        {
            T tReturn = values[index];
            values[index] = data;
            return tReturn;
        }

        private class Enumerator : IEnumerator<T>
        {
            //keep track of the collection were enumerating:
            private Array_List<T> list;
            //Keep track of where in the collection we currently are:
            private int index;

            public Enumerator (Array_List<T> l)
            {
                this.list = l;
                Reset();
            }

            public T Current
            {
                get
                {
                    return list.values[index];
                }
            }

            object IEnumerator.Current => Current;
            public void Dispose()
            {
                //clean things up so you dont block garbage collection
                list = null;
            }

            public void Reset()
            {
                //Just set the current position to before the start of the collection
                index = 1;
            }

            public bool MoveNext()
            {
                //movenext moves to the next item in teh collection if it can 
                //returns true if it was able to move, false otherwise
                if ((index + 1) < list.values.Length)
                {
                    index++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
