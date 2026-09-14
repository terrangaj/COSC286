using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public static class MySort
    {

        public delegate void dMySort<A>(A[] myItems, SortDirection dir);
        public enum SortDirection { Ascending, Descending };
        public static void Sort<X>(X[] items, SortDirection dir, dMySort<X> sortMethod)
        {
            sortMethod(items, dir);
        }

        public static void BubbleSort<T>(T[] strings, SortDirection direction) where T : IComparable
        { 
            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < strings.Length - i - 1; j++)
                {
                    if (ShouldSwap(strings[j], strings[j + 1], direction))
                    {
                        SwapItems(ref strings[j], ref strings[j + 1]);
                    }
                }
            }
        }


        //Write a method called IsInOrder
        //it should return a bool
        //it should require a generic which must be IComparable
        //It should take, as its parameters, an array of the generic type and a sort direction
        //it should return true if that arrat is sorted in teh given direction
        //it should return false otherwise
        //algorithm:
        //loop through each item, compare one to the one after
        //check the sort direction and if the items are out of order return false
        //if you get throught hte whole array and none of the items are out of order, return true

        public static bool IsInOrder<B>(B[] items, SortDirection direction) where  B : IComparable
        {
            for (int i = 0; i < items.Length-1; i++)
            {
                if (direction == SortDirection.Ascending)
                {
                    if (items[i].CompareTo(items[i+1]) > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if(direction == SortDirection.Descending)
                    {
                        if(items[i].CompareTo(items[i + 1]) < 0)
                        {
                            return false;
                        }
                    }
                }

            }
            return true;

        }
        public static bool ShouldSwap<T> (T left, T right, SortDirection direction) where T: IComparable
        {
            bool result = false;
            if (direction == SortDirection.Ascending)
            {
                result = left.CompareTo(right) > 0;
            }
            else if (direction == SortDirection.Descending)
            {
                result = right.CompareTo(left) > 0;
            }
            return result;
        
        }
    
        public static void SwapItems<T> (ref T left, ref T right)
        {
            T tmp = left;
            left = right;
            right = tmp;
        }
    }
}
