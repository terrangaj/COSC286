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
    }
}
