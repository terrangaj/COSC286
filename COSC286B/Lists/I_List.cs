using System;
using System.Collections.Generic;
using DataStructuresCommon;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    /// <summary>
    /// Interface for implementation fo the List ADT
    /// </summary>
    /// <typeparam name="T">The type the list stores</typeparam>
    public interface I_List<T>: I_Collection<T> where T: IComparable<T>
    {
        
       //what operations must all lists be capable of?
       /// <summary>
       /// Fetches an item in a specific position in the list
       /// </summary>
       /// <param name="index">the location of the item to retrieve</param>
       /// <returns>The item at the index</returns>
        T ElementAt(int index);

        /// <summary>
        /// Given a data item, get its index
        /// </summary>
        /// <param name="data">The data to find</param>
        /// <returns>The index of that data</returns>
        int IndexOf(T data);

        /// <summary>
        /// 
        /// Inserts an item into the list
        /// </summary>
        /// <param name="index">Where to insert the item</param>
        /// <param name="data">The item to insert</param>
        void Insert(int index, T data);

        /// <summary>
        /// Remove an item at a certain position
        /// </summary>
        /// <param name="index">The locatio of the itemn to remove</param>
        /// <returns>the removed item</returns>
        T RemoveAt(int index);
        /// <summary>
        /// Replace an item at a specific position
        /// </summary>
        /// <param name="index">the location of the item to replace</param>
        /// <param name="data">the item to replace with</param>
        /// <returns>the replaced item</returns>
        T ReplaceAt (int index, T data);
    }
}
