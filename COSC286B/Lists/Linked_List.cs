using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class Linked_List<T> : A_List<T> where T : IComparable<T>
    {
        private Node head;
        public override void Add(T data)
        {
            //Just call our recursive add method
            //head = recAdd(head, data);
            //we could also write the add iteratively
            //if the list is empty, thats easy, create a new node, set head to point at it
            //otherwise
            //progress through the list until you find the last node
            //youll know it is the alst because its next value is null
            //create a new node and se thte next of the old last node to point at the new node
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;

                }
                current.next = new Node(data);
            }
        }
        /// <summary>
        /// Recursive helper method for add
        /// Takes in a node and a data item to add to teh end of the list
        /// </summary>
        /// <param name="current">The current node</param>
        /// <param name="data">The item to add</param>
        /// <returns>the head of the current sublist</returns>
        private Node recAdd(Node current, T data)
        {
            if (current == null)
            {
                current = new Node(data);
            }
            else
            {
                current.next = recAdd(current.next, data);
            }
                return current;
        }

        public override void Clear()
        {
            head = null;
        }

        public override T ElementAt(int index)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator(this);
        }

        public override void Insert(int index, T data)
        {
            throw new NotImplementedException();
        }

        //public override bool Remove(T data)
        //{
        //    //bool bRemoved = false;
        //    ////if the list is empty, we know theres nothing to remove we can return false;

        //    //if (head == null)
        //    //{
        //    //    return bRemoved;
        //    //}
        //    ////otherwise check if the data is at the had of the list
        //    ////if it is make the data's neighbor the new head
        //    //// cutting around the head
        //    //if (head.data.CompareTo(data) == 0)
        //    //{
        //    //    head = head.next;
        //    //    bRemoved = true;
        //    //}
        //    //else
        //    //{
        //    //    //if it inst the head of the list, we need to loop through the list
        //    //    //to find the item to remove
        //    //    //since this list is singly linked, we need to keep track of 
        //    //    // two nodes at a time - because once we find the one were removing, 
        //    //    //well have to alter the one before it
        //    //    Node currentNode = head;
        //    //    Node scoutNode;
        //    //    //well loop as long as two things are true
        //    //    // we havent removed the item yet
        //    //    //we havent reached the end of the list
        //    //    while (bRemoved && currentNode != null)
        //    //    {
        //    //        //look ahead at teh next item in the lsit and see if we need to remove it
        //    //        scoutNode = currentNode.next;
        //    //        if (scoutNode != null && scoutNode.data.CompareTo(data) == 0)
        //    //        {
        //    //            //if we have a match, well set currents next to be the
        //    //            //couted targets next, thus cutting the target out of the list
        //    //            bRemoved = true;
        //    //            currentNode.next = scoutNode.next;
        //    //        }
        //    //        else
        //    //        {
        //    //            //if it isnt the right node, just progress down the chain
        //    //            currentNode = scoutNode;
        //    //        }
        //    //    }    
        //    //}


        //        //return bRemoved;


        //}

        //recursive version of remove
        public override bool Remove(T data)
        {
            return recRemove(ref head, data);
        }

        private bool recRemove(ref Node current, T data)
        {
            //keep track of whether or not the node was found and removed
            bool bRemoved = false;
            //weve actually got towo base cases
            //first base case: current is null hwich means the item to remove isnt present
            if (current == null)
            {
                return bRemoved;
            }
            //in this case, mark teh item as not found
            //second base case - we have found the item to remove
            if (current.data.CompareTo(data)==0)
            {
                bRemoved = true;
                current = current.next;
               
            }
            else
            {
                bRemoved = recRemove(ref current.next, data);
            }
            //record that weve found it 
            // bypass or cut out the item to remove
            //recursive case: We havent found it and we havent found null
            
            //recurse on the next item in the list

            //at the end, return whether or not the item was found and removed
            return bRemoved;
        }

        public override T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public override T ReplaceAt(int index, T data)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// a single node in a linked list which stores data of type t
        /// </summary>
        private class Node
        {
            public T data;
            public Node next;

            public Node (T data, Node next)
            {
                this.data = data;
                this.next = next;
            }

            public Node(T data) : this(data, null) { }
        }

        private class LinkedListEnumerator : IEnumerator<T>
        {
            //were going to want to keep a reference to 
            //the linked list were enumerating:
            private Linked_List<T> list;
            //reference to the node we are currently pointed at
            private Node lastVisited;
            //reference to the next node we want to visit
            private Node scout;
            public T Current
            {
                get
                {
                    return lastVisited.data;
                }
            }


            object IEnumerator.Current => Current;

            public LinkedListEnumerator(Linked_List<T> list)
            {
                this.list = list;
                Reset();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                bool bWasAbleToMove = false;
                if (scout != null)
                {
                    bWasAbleToMove = true;
                    //well advance our current to look at the next node
                    lastVisited = scout;
                    //Advance our scout to look at whats after
                    scout = lastVisited.next;
                }

                //return treu if we were able to advance to the next node, false otehrwise
                return bWasAbleToMove;
            }

            public void Reset()
            {
                //if were resetting, we arent currently visiting any nodes
                lastVisited = null;
                //the next thing were going to visit - the scout - is going to 
                //be the head of the list
                scout = list.head;
            }
        }
    }
}
