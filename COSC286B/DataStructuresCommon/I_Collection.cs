using System;
using System.Collections.Generic;

namespace DataStructuresCommon;


/// <summary>
/// Common interface for all collections
/// </summary>
/// <typeparam name="T">The data type the collection stores</typeparam>
public interface I_Collection<T>: IEnumerable<T> where T: IComparable<T>
{
    // The things pretty much every collection will need to be able to do:

    /// <summary>
    /// Adds an item to the collection
    /// </summary>
    /// <param name="data">The item to add</param>
    void Add(T data);

    /// <summary>
    /// Remove all items from the collection
    /// </summary>
    void Clear();

    /// <summary>
    /// Determine if a given data item is in the collection
    /// </summary>
    /// <param name="data">The data item to look for</param>
    /// <returns>True if the item is present, false otherwise</returns>

    bool Contains(T data);

    /// <summary>
    /// Removes the first instance of a value, if it exists
    /// </summary>
    /// <param name="data">The data item to remove</param>
    /// <returns>True if successfully removed, false otherwise</returns>
    bool Remove(T data);

    /// <summary>
    /// The number of items in the collection
    /// </summary>
    int Count
    {
        get;
    }
}
