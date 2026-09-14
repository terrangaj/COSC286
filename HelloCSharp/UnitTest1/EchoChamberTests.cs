using MyClasses;

namespace TestHello
{
    public class EchoChamberTests
    {
        EchoChamber chamber;
        [SetUp]
        public void Setup()
        {
            chamber = new EchoChamber(4);
            chamber.Echo("test!");
        }

        [Test]
        public void TestRepeatProperty()
        {
            EchoChamber echo2 = new EchoChamber(2);
            Assert.AreEqual(2, echo2.Repeat);
            echo2.Repeat = 22;
            Assert.AreEqual(22, echo2.Repeat);
        }

        [Test]
        public void TestLastProperty()
        {
            Assert.AreEqual("test!", chamber.Last);
            chamber.Echo("bye");
            Assert.AreEqual("bye", chamber.Last);
        }

        [Test]
        public void TestEcho()
        {
            Console.WriteLine("About to echo Echo!");
            string echoedText = chamber.Echo("Echo!");
            Console.WriteLine("Echoing echo! returned:");
            Console.WriteLine(echoedText);
            Assert.AreEqual("Echo!Echo!Echo!Echo!", echoedText);
        }
    }
}