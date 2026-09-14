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
        public enum SortDirection { Ascending, Descending };

        public static void BubbleSort(string[] strings, SortDirection direction)
        {
            int end = strings.Length;
            for (int i = 0; i < end; i++)
            {
                for (int j = 0; j < end - i - 1; j++)
                {
                    if (ShouldSwap(strings[j], strings[j + 1], direction))
                    {
                        SwapItems(ref strings[j], ref strings[j + 1]);
                    }
                }
            }
        }
        public static bool ShouldSwap (string left, string right, SortDirection direction)
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
    
        public static void SwapItems (ref string left, ref string right)
        {
            string tmp = left;
            left = right;
            right = tmp;
        }
    }
}
