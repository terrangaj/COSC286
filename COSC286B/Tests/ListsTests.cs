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

        [Test]
        public void TestClear()
        {
            Array_List<string> list = new Array_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void TestReplaceAt()
        {
            Array_List<string> list = new Array_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.AreEqual("d", list.ReplaceAt(3, "Z"));
            Assert.AreEqual("Z", list.ElementAt(3));
        }

        [Test]
        public void TestInsert()
        {
            Array_List<string> list = new Array_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            list.Insert(3, "z");
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("z", list.ElementAt(3));
            Assert.AreEqual("b", list.ElementAt(1));
            Assert.AreEqual("d", list.ElementAt(4));
            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(-1, "ZZZ"));
        }

        [Test]
        public void TestIndex()
        {
            Array_List<string> list = new Array_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.AreEqual(0, list.IndexOf("a"));
            Assert.AreEqual(4, list.IndexOf("e"));
            Assert.AreEqual(2, list.IndexOf("c"));

        }

        [Test]
        public void TestRemove()
        {
            Array_List<string> list = new Array_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.IsTrue(list.Remove("b"));
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual("c", list.ElementAt(1));
            Assert.IsFalse(list.Remove("Z"));
        }

        [Test]
        public void TestRemoveAt()
        {
            Array_List<string> list = new Array_List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            Assert.AreEqual("c", list.RemoveAt(2));
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual("d", list.ElementAt(2));
        }
            


        
    }
}
