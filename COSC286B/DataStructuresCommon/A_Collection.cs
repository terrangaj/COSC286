using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresCommon
{
    /// <summary>
    /// Abstract partial implementation fo commen collection functionality
    /// </summary>
    /// <typeparam name="T">The type stored in the collection</typeparam>
    public abstract class A_Collection<T> : I_Collection<T> where T : IComparable<T>
    {
        //This will be an inefficient implementation - we can use a foreach loop
        //to just count the items.
        //We're marking as virtual because our children may wish to override with 
        // a more efficient method
        public virtual int Count
        {
            get
            {
                int count = 0;
                foreach (T item in this)
                {
                    count++;
                }
                return count;
            }
        }

        //we can also do contains by looping through all items looking for a match
        //for some implementations this could me more or less efficient
        public virtual bool Contains(T data)
        {
            bool found = false;

            //we can access the enum directly instead of using a foreach loop
            IEnumerator<T> myEnumerator = this.GetEnumerator();

            //call reset when i get teh enumerator
            myEnumerator.Reset();

            //loop through the items in the list until i find the data
            //Movenext returns true if the enumerator is able to advance to the 
            //next item. It'll return false when you get to the end of the collection
            while (!found && myEnumerator.MoveNext())
            {
                //The current property contains whatever object the enumerator
                //is currently "pointed" at. If it is equal to the item 
                //we're looking for, we've found the item!
                found = myEnumerator.Current.Equals(data);
            }

            //make enumerator clean up:
            myEnumerator.Dispose();
            //return whether or not you found the item:
            return found;
        }

        //we will override the tostring method
        //most data collections wont have a tostring, but it is useful
        //for us because well be learnging and debugging

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            string seperator = ", ";

            foreach (T item in this)
            {

                sb.Append(item + seperator);
            }
            //to make it cleaner, if our collection is not empty, delete the last
            //seperator
            if (Count > 0)
            {
                sb.Remove(sb.Length - seperator.Length, seperator.Length);
            }

            sb.Append("]");
            return sb.ToString();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public abstract void Add(T data);
        public abstract void Clear();
        public abstract bool Remove(T data);
        public abstract IEnumerator<T> GetEnumerator();
    }




}
