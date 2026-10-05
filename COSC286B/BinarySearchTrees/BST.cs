using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    public class BST<T> : A_BST<T>, ICloneable where T : IComparable<T>
    {

        public BST()
        {
            //initialize the root:
            nRoot = null;
            //set the count to 0
            iCount = 0;
        }
        public override void Add(T data)
        {
            //where do we add new nodes to the tree? Where they belong of course!
            //the really easy case is when the tree is empty
            if (nRoot == null)
            {
                nRoot = new Node<T>(data);
            }
            else
            {
                //otherwise use recursion to solve this:
                recAdd(data, nRoot);
                nRoot = Balance(nRoot);
            }
        }

        public void recAdd(T data, Node<T> nCurrent)
        {
            //does the data item belong to the left or right of the current node?
            int iCompare = data.CompareTo(nCurrent.Data);
            // If iCompare < 0, the data item belongs on the left
            // Base case: Item belongs on the left and the left child is null:
            // Add new node with the data item as the Left child of the current node
            //recursuve case: if left child is not null
            //call recursiveley on the left child
            //otherwise, the data item will go on the right
            // Base case: Item belongs on the right and the right child is null:
            // Add new node with the data item as the right child of the current node
            //recursuve case: if right child is not null
            //call recursiveley on the right child

            if (iCompare < 0)
            {
                if (nCurrent.Left == null)
                {
                    nCurrent.Left = new Node<T>(data);
                }
                else
                {
                    recAdd(data, nCurrent.Left);
                    nCurrent.Left = Balance(nCurrent.Left);
                }
            }
            else
            {
                if (nCurrent.Right == null)
                {
                    nCurrent.Right = new Node<T>(data);
                }
                else
                {
                    recAdd(data, nCurrent.Right);
                    nCurrent.Right = Balance(nCurrent.Right);
                }
            }
            
            

        }


        //A virtual balance method our children can override if they wish
        // to implement balancing on add
        internal virtual Node<T> Balance(Node<T> nCurrent)
        {
            return nCurrent;
        }

        public override void Clear()
        {
            nRoot = null;
            iCount = 0;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public override T Find(T data)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }


        /*
         * The height of the tree is the number of edges from the deepest leaf node
         * to the root node
         * if there is only a root node and no children, the height is 0
         * if there is no root node, a completely empty tree height will be -1
         */
        public override int Height()
        {
            // Easy case - no nodes, return height of -1
            // Almost easy - if the root has no children, return height of @
            // If the root node has children, the height of the tree will be equal to
            // the greater of the height on the left or the height on the right PLUS 1
            //how to find out the eight of the left child
            //if it has no children it is height 0
            //if it has children, the height will be equal to the height of the 
            //tallest subtree plus 1
            //and so on

        }

        public override void Iterate(ProcessData<T> pd, TRAVERSALORDER order)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(T data)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Tree (" + nRoot + ")";
        }
    }
}
