using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace Lists
{
    /// <summary>
    /// Partial implementation of list features
    /// </summary>
    /// <typeparam name="T">The type this list is storing</typeparam>
    public abstract class A_List<T>: A_Collection<T>, I_List<T> where T: IComparable<T>
    {
        public virtual T ElementAT(int index)
        {

            //The defualt operator in C# returns a default of the type
            // If you call default (int( it'll give 0, if you call default(bool),
            //itll give false, etc. If you call it on a reference type youll get null.
            T tReturn = default(T);

            if (index < 0 | index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid index (" + index + ")");

            }
            int count = 0;
            //Grab an enumerator
            IEnumerator<T> myEnum = this.GetEnumerator();
            myEnum.Reset();
            //keep looking while there are more data items and i havent reached
            //the position im looking for:
            while (myEnum.MoveNext() && count != index)
            {
                count++;
            }

            //once the count equals the index, we know were at the right index
            tReturn = myEnum.Current;

            return tReturn;
        }

        public abstract T ElementAt(int index);

        //Frequently people will create method body and just throw an exception
        //when they havent coded it yet
        public virtual int IndexOf(T data)
        {
            throw new NotImplementedException();
        }

        public abstract void Insert(int index, T data);
        public abstract T RemoveAt(int index);
        public abstract T ReplaceAt(int index, T data);
    }
}
