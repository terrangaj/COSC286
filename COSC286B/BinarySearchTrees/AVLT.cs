using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    public class AVLT<T>: BST<T> where T: IComparable<T>
    {

        /// <summary>
        /// Balances a subtree
        /// </summary>
        /// <param name="nCurrent">root of a subtree to balance</param>
        /// <returns>the root node of the newly balanced subtree</returns>
        internal override Node<T> Balance(Node<T> nCurrent)
        {
            //store a reference to the new root of the tree, which ill
            //start off assuming is going to be nCurrent
            Node<T> nNew = nCurrent;

            //check that ncurrent isnt null - if it is, nothing will change
            if (nCurrent != null)
            {
             
            
            // we need to compute the balance factor of the current node
            //we only need to balance if the current has a balance factor of less than -1 
            //or greater than +1

                if (GetHeightDifference(nCurrent) > 1)
                {
                    if (GetHeightDifference(nCurrent.Right) < 0)
                    {
                        nNew = DoubleLeft(nCurrent);
                    }
                    else
                    {
                        nNew = SingleLeft(nCurrent);
                    }
                }
                else if (GetHeightDifference(nCurrent) < -1)
                {
                    if (GetHeightDifference(nCurrent.Left) > 0)
                    {
                        nNew = DoubleRight(nCurrent);
                    }
                    else
                    {
                        nNew = SingleRight(nCurrent);
                    }
                }
            }

            return nNew;
            //if were unbalanced to the right (balance factor > 1)
                //we know if we are unbalanced to the right, well need to do a left rotation
                //but which one, we need to find out the balance facotor of the right subtree
                //if the right child is left heavy
                //perform a double left of the currnet node
                //otherwise, perform a single left ont he current node
            //if it is unbalanced to the left (balance factor < -1)
            //we need the balance factor fo the left subtree
            //if the left child is right heavy
            //perform a double right on the current node
            //otherwise perform a single right on the current node
            //if it is not unbalanced we dont need to change anything


            //return the new root of the tree
        }
        //normally id want a method to calculate the balance factor to be private
        //but im going to make it public and static for testing reasons


        /// <summary>
        /// Determines the height difference of the subtrees
        /// //we calculate this as right height minus left height
        /// positive means were right heavy
        /// negative means were left heavy
        /// </summary>
        /// <param name="nCurrent">the root of the subtree to analyze</param>
        /// <returns>the balance factor</returns>
        public static int GetHeightDifference(Node<T> nCurrent)
        {
            //check the current node isnt null
            if (nCurrent == null)
            {
                return 0;
            }
            //use recheight to get childrens height

            //calculate the height on the right subtree ( if right node is null,
            //the height on the right is 0
            int nRight = 0;
            if (nCurrent.Right != null)
            {
                nRight = 1 + recHeight(nCurrent.Right);
            }

            //calculate the height on the left subtree(if your left node is null,
            //the height on the left is 0)
            int nLeft = 0;
            if (nCurrent.Left != null)
            {
                nLeft = 1 + recHeight(nCurrent.Left);
            }
            //return the eight on the right minus the height on the left
            return nRight - nLeft;
        }



        //Normally id write my rotations as private methods,
        //but ill write them as public statics to make them easier to test
        //and for us to experiment with if we want

        /// <summary>
        /// performs a single left rotation
        /// </summary>
        /// <param name="nOldRoot">The original root of the tree</param>
        /// <returns>The new root of the tree</returns>
        public static Node<T> SingleLeft (Node<T> nOldRoot)
        {
            //The new root will be the old root's right child
            Node<T> newRoot = nOldRoot.Right;
            //we need to clear space on the left of the new root to put the old root.
            //so well assign the new roots left child to pointed at the old root's right child
            nOldRoot.Right = newRoot.Left;

            //the new root's left child will point at the old root
            newRoot.Left = nOldRoot;
            //return the new root of the tree
            return newRoot;
        }
        public static Node<T> SingleRight (Node<T> nOldRoot)
        {
            Node<T> newRoot = nOldRoot.Left;
            nOldRoot.Left = newRoot.Right;
            newRoot.Right = nOldRoot;
            return newRoot;
        }

        public static Node<T> DoubleLeft(Node<T> nOldRoot)
        {
            //first we do a single right on the right subtree
            nOldRoot.Right = SingleRight(nOldRoot.Right);
            //then we do a left rotation on the whole subtree
            return SingleLeft(nOldRoot);

        }
        public static Node<T> DoubleRight(Node<T> nOldRoot)
        {
            //first we do a single left on the left subtree
            nOldRoot.Left = SingleLeft(nOldRoot.Left);
            //then we do a right rotation on the whole subtree
            return SingleRight(nOldRoot);
        }

        /// <summary>
        /// Adds a new item to the tree without using recursion, then balances
        /// every node on the path back up to the root
        /// </summary>
        /// <param name="data">The item to add</param>
        public override void Add(T data)
        {
            iCount++;
            Stack<Node<T>> path = new Stack<Node<T>>();
            Node<T> nCurrent = nRoot;

            while (nCurrent != null)
            {
                path.Push(nCurrent);
                nCurrent = data.CompareTo(nCurrent.Data) < 0 ? nCurrent.Left : nCurrent.Right;
            }

            Node<T> nChild = new Node<T>(data);

            while (path.Count > 0)
            {
                Node<T> nNode = path.Pop();

                if (data.CompareTo(nNode.Data) < 0)
                {
                    nNode.Left = nChild;
                }
                else
                {
                    nNode.Right = nChild;
                }

                nChild = Balance(nNode);
            }

            nRoot = nChild;
        }

        /// <summary>
        /// Visits every node in the tree in the given order without using recursion,
        /// running the given method on each node's data
        /// </summary>
        /// <param name="pd">The method to run on each data item</param>
        /// <param name="order">The traversal order: pre-order, in-order or post-order</param>
        public override void Iterate(ProcessData<T> pd, TRAVERSALORDER order)
        {
            if (nRoot != null)
            {
                if (order == TRAVERSALORDER.PRE_ORDER)
                {
                    Stack<Node<T>> sNodes = new Stack<Node<T>>();
                    sNodes.Push(nRoot);
                    while (sNodes.Count > 0)
                    {
                        Node<T> nCurrent = sNodes.Pop();
                        pd(nCurrent.Data);
                        if (nCurrent.Right != null)
                        {
                            sNodes.Push(nCurrent.Right);
                        }
                        if (nCurrent.Left != null)
                        {
                            sNodes.Push(nCurrent.Left);
                        }
                    }
                }
                else if (order == TRAVERSALORDER.IN_ORDER)
                {
                    Stack<Node<T>> sNodes = new Stack<Node<T>>();
                    Node<T> nCurrent = nRoot;
                    while (nCurrent != null || sNodes.Count > 0)
                    {
                        while (nCurrent != null)
                        {
                            sNodes.Push(nCurrent);
                            nCurrent = nCurrent.Left;
                        }
                        nCurrent = sNodes.Pop();
                        pd(nCurrent.Data);
                        nCurrent = nCurrent.Right;
                    }
                }
                else if (order == TRAVERSALORDER.POST_ORDER)
                {
                    Stack<Node<T>> sNodes = new Stack<Node<T>>();
                    Stack<Node<T>> sOutput = new Stack<Node<T>>();
                    sNodes.Push(nRoot);
                    while (sNodes.Count > 0)
                    {
                        Node<T> nCurrent = sNodes.Pop();
                        sOutput.Push(nCurrent);
                        if (nCurrent.Left != null)
                        {
                            sNodes.Push(nCurrent.Left);
                        }
                        if (nCurrent.Right != null)
                        {
                            sNodes.Push(nCurrent.Right);
                        }
                    }
                    while (sOutput.Count > 0)
                    {
                        pd(sOutput.Pop().Data);
                    }
                }
            }
        }

    }
}
