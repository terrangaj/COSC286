using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClasses;

namespace TestHello
{
    internal class MySortTests
    {
        [Test]
        public void TestSwapItems()
        {
            string[] myStrings = { "a", "b", "c", "d", "e", "f" };

            Assert.AreEqual("b", myStrings[1]);
            Assert.AreEqual("e", myStrings[4]);
            MySort.SwapItems(ref myStrings[1], ref myStrings[4]);
            Assert.AreEqual("e", myStrings[1]);
            Assert.AreEqual("b", myStrings[4]);
        }

        [Test]
        public void TestShouldSwap()
        {
            Assert.IsTrue(MySort.ShouldSwap("a", "b", MySort.SortDirection.Descending));
            Assert.IsTrue(MySort.ShouldSwap("b", "a", MySort.SortDirection.Ascending));
            Assert.IsFalse(MySort.ShouldSwap("a", "b", MySort.SortDirection.Ascending));
            Assert.IsFalse(MySort.ShouldSwap("a", "a", MySort.SortDirection.Ascending));
        }

        [Test]
        public void TestBubbleSort()
        {
            string[] strings = { "e", "a", "b", "f", "z", "g" };
            MySort.BubbleSort(strings, MySort.SortDirection.Ascending);
            // sorted, it should be: a, b, e, f, g, z
            int i = 0;
            Assert.AreEqual("a", strings[i++]);
            Assert.AreEqual("b", strings[i++]);
            Assert.AreEqual("e", strings[i++]);
            Assert.AreEqual("f", strings[i++]);
            Assert.AreEqual("g", strings[i++]);
            Assert.AreEqual("z", strings[i++]);
        }

        [Test]
        public void TestBubbleSortInts()
        {
            int[] ints = { 5, 8, 3, 3, 7, 9 };
            MySort.BubbleSort(ints, MySort.SortDirection.Ascending);
            // sorted, it should be: a, b, e, f, g, z
            int i = 0;
            Assert.AreEqual(3, ints[i++]);
            Assert.AreEqual(3, ints[i++]);
            Assert.AreEqual(5, ints[i++]);
            Assert.AreEqual(7, ints[i++]);
            Assert.AreEqual(8, ints[i++]);
            Assert.AreEqual(9, ints[i++]);
        }

        [Test]
        public void TestDelegatedSort()
        {
            string[] strings = { "e", "a", "b", "f", "z", "g" };
            MySort.Sort<string>(strings, MySort.SortDirection.Ascending, MySort.BubbleSort<string>);
        }

        [Test]
        public void TestIsInOrder()
        {
            string[] strings = { "e", "a", "b", "f", "z", "g" };
            Assert.IsFalse(MySort.IsInOrder<string>(strings, MySort.SortDirection.Ascending));
            Assert.IsFalse(MySort.IsInOrder<string>(strings, MySort.SortDirection.Descending));
            int[] orderedInts = { 2, 3, 6, 8, 100, 10001 };
            Assert.IsTrue(MySort.IsInOrder<int>(orderedInts, MySort.SortDirection.Ascending));
            Assert.IsFalse(MySort.IsInOrder<int>(orderedInts, MySort.SortDirection.Descending));
        }

        [Test]
        public void TestBozo()
        {
            string[] strings = { "e", "a", "b", "f", "z", "g" };
            MySort.Sort<string>(strings, MySort.SortDirection.Ascending, MySort.BozoSort<string>);
            Assert.IsFalse(MySort.IsInOrder<string>(strings, MySort.SortDirection.Ascending));
            Assert.IsFalse(MySort.IsInOrder<string>(strings, MySort.SortDirection.Descending));
            int[] orderedInts = { 2, 3, 6, 8, 100, 10001 };
            Assert.IsTrue(MySort.IsInOrder<int>(orderedInts, MySort.SortDirection.Ascending));
            Assert.IsFalse(MySort.IsInOrder<int>(orderedInts, MySort.SortDirection.Descending));
        }
    }
}

    

