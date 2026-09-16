using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        public override void Insert(int index, T data)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(T data)
        {
            throw new NotImplementedException();
        }

        public override T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public override T ReplaceAt(int index, T data)
        {
            throw new NotImplementedException();
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
