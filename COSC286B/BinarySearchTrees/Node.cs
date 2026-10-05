using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    public class Node<T> where T: IComparable<T>
    {
        //well store the data the node contains
        private T tData;
        //references to teh two children
        private Node<T> nLeft;
        private Node<T> nRight;

        public T Data {  get => tData; set => tData = value;}
        public Node<T> Left {  get => nLeft; set => nLeft = value; }
        public Node<T> Right { get => nRight; set => nRight = value; }

        public Node(): this(default(T), null, null) { }
        public Node(T tData, Node<T> nLeft, Node<T> nRight)
        {
            this.tData = tData;
            this.nLeft = nLeft;
            this.nRight = nRight;
        }

        public Node(T tData) : this(tData, null, null) { }


        /// <summary>
        /// whether or not the node is a leaf
        /// </summary>
        /// <returns>true if leaf, false if otherwise</returns>
        public bool IsLeaf()
        {
            return (Left == null) && (Right == null);
        }

        public override string ToString()
        {
            string sLeft = "";
            string sRight = "";
            if (Left != null)
            {
                sLeft = "L(" + Left + ")";
            }
            if (Right != null)
            {
                sRight = "R(" + Right + ")";
            }

            return Data + sLeft + sRight;
        }

    }
}
