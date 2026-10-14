using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            return recFind(data, nRoot);
        }

        protected T recFind(T data, Node<T> nCurrent)
        {
            T tReturn = default(T);
            //base case: if the current node is null it means we have not found the item
            if (nCurrent == null)
            {
                throw new ApplicationException();
            }
            //and so we should throw an applicationexcpetion
            //otherwise
            else
            {
                int compare = data.CompareTo(nCurrent.Data);
                if (compare == 0)
                {
                    tReturn = nCurrent.Data;
                }
                else if (compare < 0)
                {
                    tReturn = recFind(data, nCurrent.Left);
                }
                else
                {
                    tReturn = recFind(data, nCurrent.Right);
                }
            }
                //do a compareto of the data we are looking for to the current node
                //base case: f they are equal, we found the node and we can return it
                //otherwise, if the node were looking for is on the left, 
                //return the result of searching on the left
                //if the node were looking for is on the right,
                //return the result of searching on the right


                //return whatever we found
                return tReturn;
        }

        /// <summary>
        /// Returns the node that is furthest right in the tree
        /// </summary>
        /// <returns>largest value in the tree</returns>
        public T FindLargest()
        {
            if (nRoot == null)
            {
                throw new ApplicationException("Tree is empty, no largest value");
            }
            return recFindLargest(nRoot);
        }

        protected T recFindLargest(Node<T> nCurrent)
        {
            T tReturn = default(T);

            if (nCurrent == null)
            {
                throw new ApplicationException();
            }
            if (nCurrent.Right != null)
            {
                tReturn = recFindLargest(nCurrent.Right);
            }
            else
            {
                {
                    tReturn = nCurrent.Data;
                }
            }



            return tReturn;
        }


        /// <summary>
        /// Returns the node that is furthest left in the tree
        /// </summary>
        /// <returns>smallest value</returns>
        public T FindSmallest()
        {
            if (nRoot == null)
            {
                throw new ApplicationException("Tree is empty, no smallest value");
            }
            return recFindSmallest(nRoot);
        }

        protected T recFindSmallest(Node<T> nCurrent)
        {
            T tReturn = default(T);

            if (nCurrent == null)
            {
                throw new ApplicationException();
            }
            if (nCurrent.Left != null)
            {
                tReturn = recFindSmallest(nCurrent.Left);
            }
            else
            {
                {
                    tReturn = nCurrent.Data;
                }
            }



            return tReturn;
            
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
            int iHeight = -1;
            // Almost easy - if the root has no children, return height of 0
            // If the root node has children, the height of the tree will be equal to
            // the greater of the height on the left or the height on the right PLUS 1
            //how to find out the eight of the left child
            //if it has no children it is height 0
            //if it has children, the height will be equal to the height of the 
            //tallest subtree plus 1
            //and so on
            if (nRoot != null)
            {
                iHeight = recHeight(nRoot);
            }
            return iHeight;
        }

        protected int recHeight(Node<T> nCurrent)
        {
            int iHeightLeft = 0;
            int iHeightRight = 0;
            if (nCurrent.Left != null)
            {
                iHeightLeft = 1 + recHeight(nCurrent.Left);
            }
            if (nCurrent.Right != null)
            {
                iHeightRight = 1 + recHeight(nCurrent.Right);
            }
            int iGreaterHeight = iHeightLeft > iHeightRight ? iHeightLeft : iHeightRight;
            return iGreaterHeight;

        }

        public override void Iterate(ProcessData<T> pd, TRAVERSALORDER order)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(T data)
        {
            //i need to keep track of whether or not weve removed the node
            bool bRemoved = false;
            //we need to alter the tree to remove node, so ill do that as we backtrack;
            //im doing a ref to bRemoved so our recursive function can change its original value
            nRoot = recRemove(nRoot, data, ref bRemoved);

            return bRemoved;
        }

        private Node<T> recRemove(Node<T> nCurrent, T data, ref bool bRemoved)
        {
            //if nCurrent is ever null, weve got nothing to do because it means we didnt
            //find the item to remove
            //ncurrent being ull is one base case
            if (nCurrent != null)
            {
                //if ncurrent is null, check to see if it is the item we want to remove
                //or if it is to the left or right of the current item
                int iCompare = data.CompareTo(nCurrent.Data);
                if (iCompare < 0)
                {
                    //not a match, what were looking for is to the left
                    nCurrent.Left = recRemove(nCurrent.Left, data, ref bRemoved);   

                }
                else if (iCompare > 0){
                    //not a match, recurse top the right
                    nCurrent.Right = recRemove(nCurrent.Right, data, ref bRemoved);
                    
                }
                else
                {
                    //if the comparison was zero, weve found our match
                    bRemoved = true;

                    if (nCurrent.IsLeaf())
                    {
                        nCurrent = null;
                        iCount--;
                    }
                    else if (nCurrent.Left != null && nCurrent.Right != null) {
                        //our node has 2 children
                        //we need to pull up a node fropm beneath us to take our place
                        //that can either be the biggest node on the left subtree
                        //or the smallest node on the right subtree
                        //lets do the largest on teh left we need to find it
                        T tReplacement = recFindLargest(nCurrent.Left);
                        //Replace teh current nodes data with teh replacements data
                        nCurrent.Data = tReplacement;
                        //weve currently got a duplicate In the tree, so now we 
                        //need to go and remove the original replacement node
                        nCurrent.Left = recRemove(nCurrent.Left, tReplacement, ref bRemoved);
                    }
                    else if (nCurrent.Left != null)
                    {
                        //if we only have a left child, replace the node to be removed
                        //with its left child
                        nCurrent = nCurrent.Left;
                        iCount--;
                        
                    }
                    else
                    {
                        //if we only have a right child, replace the node to be removed
                        //with its right child
                        nCurrent = nCurrent.Right;
                        iCount--;
                    }
                }

            }

            //return a reference to teh current node, whatever it may now be
            return nCurrent;
        }

        public override string ToString()
        {
            return "Tree (" + nRoot + ")";
        }

        private class DepthFirstEnumerator : IEnumerator<T>
        {

            //store a reference to the tree were enumerating

            BST<T> tree = null;
            Node<T> nCurrent = null;
            //keep track of the future nodes to visit
            //because i want to do this in a first in last out manner
            //this means we want a stack
            Stack<Node<T>> sNodes;

            public DepthFirstEnumerator(BST<T> tree)
            {
                this.tree = tree;
                Reset();
            }
            public T Current => throw new NotImplementedException();

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                sNodes = new Stack<Node<T>>();
                // Remember upon reset, an enumerator should be *before* the first item
                // Since the Stack is the list of items to visit in the future,
                // if we put the first item on the stack, that means we're before
                // the first item:
                if (tree.nRoot != null)
                {
                    sNodes.Push(tree.nRoot);
                }
                    
            }


        }
    }
}
