using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lists;

namespace Tests
{
    public class ArrayListsTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void TestAdd()
        {
            Array_List<string> list = new Array_List<string>();
            Assert.AreEqual(0, list.Count);
            list.Add("a");
            Assert.AreEqual(1, list.Count);
            list.Add("b");
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void TestElementAt()
        {
            Array_List<int> list = new Array_List<int>();
            list.Add(99);
            list.Add(120);
            list.Add(3303);
            list.Add(100001);
            Assert.AreEqual(99, list.ElementAt(0));
            Assert.AreEqual(3303, list.ElementAt(2));
            Assert.AreEqual(10001, list.ElementAt(3));
        }
    }
}
