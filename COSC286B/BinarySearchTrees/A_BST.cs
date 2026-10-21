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

        public static bool operator ==(A_BST<T> tree1, A_BST<T> tree2)
        {
            if ((object)tree1 == null && (object)tree2 == null)
            {
                return true;
            }
            if ((object)tree1 == null || (object)tree2 == null)
            {
                return false;
            }
            return recEquals(tree1.nRoot, tree2.nRoot);
        }

        private static bool recEquals(Node<T> node1, Node<T> node2)
        {
            if (node1 == null && node2 == null)
            {
                return true;
            }
            if (node1 == null || node2 == null)
            {
                return false;
            }

            return node1.Data.CompareTo(node2.Data) == 0
            && recEquals(node1.Left, node2.Left)
            && recEquals(node1.Right, node2.Right);
        }

        public static bool operator !=(A_BST<T> tree1, A_BST<T> tree2)
        {
            return !(tree1 == tree2);
        }
    }
}
