using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public static class StrangeMath
    {
        public static int GetMagicNumber()
        {
            return 3;
        }
        public static long AddInts(int left, int right)
        {
            return (long)left + (long)right;
        }

        public static void SwapInts(int left, int right)
        {
            int temp = left;
            left = right;
            right = temp;
            Console.WriteLine("SwapInts: Left is {0}, right is {1}", left, right);
        }

        public static void SwapIntsByRef(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
            Console.WriteLine("SwapIntsByRef: Left is {0}, right is {1}", left, right);
        }
    }
}
