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

                int nDiff = GetHeightDifference(nNode);
                if (nDiff > 1)
                {
                    nNode = GetHeightDifference(nNode.Right) < 0 ? DoubleLeft(nNode) : SingleLeft(nNode);
                }
                else if (nDiff < -1)
                {
                    nNode = GetHeightDifference(nNode.Left) > 0 ? DoubleRight(nNode) : SingleRight(nNode);
                }

                nChild = nNode;
            }

            nRoot = nChild;
        }

    }
}
