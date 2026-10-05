using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresCommon;

namespace BinarySearchTrees
{
    public abstract class A_BST<T> : A_Collection<T>, I_BST<T> where T : IComparable<T>
    {
        public abstract T Find(T data);
        public abstract int Height();
        public abstract void Iterate(ProcessData<T> pd, TRAVERSALORDER order);

        //well want to keep a reference to the root no de of the 
        protected Node<T> nRoot;

        //Keep a counter of the number of items in the tree
        protected int iCount = 0;

        //A_Collection's count counts the items by enumerating the entire data structure
        //if we keep track of the count, we can do this faster:
        public override int Count { get => iCount; }
    }
}
