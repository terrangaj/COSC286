using System;
using DataStructuresCommon;

namespace BinarySearchTrees
{
    //define a delegate type that will point to a method
    //that will perform some action on a data member of type T
    public delegate void ProcessData<T>(T data);
    public enum TRAVERSALORDER {  PRE_ORDER, IN_ORDER, POST_ORDER };

    /// <summary>
    /// Interface for common functionality for binary search trees
    /// </summary>
    /// <typeparam name="T">the type to be stored in the tree</typeparam>
    public interface I_BST<T>: I_Collection<T> where T : IComparable<T>
    {
        /// <summary>
        /// Given a data element, find teh corresponding element of equal value
        /// </summary>
        /// <param name="data">An item equal to the item to be found</param>
        /// <returns>a reference to the item found</returns>
        T Find(T data);

        /// <summary>
        /// Returns the height of the tree
        /// </summary>
        /// <returns>the number of edges from the root to the deepest leaf</returns>
        /// //we could do a property, instead of a method. But a height can protentially
        /// //be computationally expensive so illl leave it as a method
        int Height();

        /// <summary>
        /// similar to an enumerator but instead of getting the items, 
        /// well run a method on each item
        /// </summary>
        /// <param name="pd">method to run on each item</param>
        /// <param name="order">the order to visit the nodes</param>
        void Iterate(ProcessData<T> pd, TRAVERSALORDER order);
    }
}
