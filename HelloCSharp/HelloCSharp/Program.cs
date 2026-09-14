using System;
using System.Security.Cryptography.X509Certificates;
using MyClasses;
class HelloCSharp
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello Nib");

        int i = 3;
        Console.WriteLine("i is {0}", i);

        i++;
        int j = i * 3;
        Console.WriteLine("I is {0} and j is {1}", i, j);

        //Console.WriteLine("What is your name");
        //string name;
        //name = Console.ReadLine();

        //if (name == "wade")
        //{
        //    Console.WriteLine("Hello Instructor");
        //}
        //else
        //{
        //    Console.WriteLine("Hello, {0}", name);
        //}


        //Console.WriteLine(StrangeMath.GetMagicNumber());

        //int a = 9;
        //int b = 21;
        //Console.WriteLine("Before swap a is {0} and b is {1}", a, b);
        //StrangeMath.SwapInts(a, b);
        //Console.WriteLine("After swap a is {0} and b is {1}", a, b);

        //Console.WriteLine("Before swapbyref a is {0} and b is {1}", a, b);
        //StrangeMath.SwapIntsByRef(ref a, ref b);
        //Console.WriteLine("After swapbyref a is {0} and b is {1}", a, b);

        //MyString ms = new MyString("This is a string");
        //MyString ms3 = new MyString("3");
        //Console.WriteLine("ms is {0} and ms3 is {1}", ms, ms3);

        //Console.WriteLine("Before swapmystrings ms is {0} and ms3 is {1}", ms, ms3);
        //SwapMyStrings(ms, ms3);
        //Console.WriteLine("After swapmystrings ms is {0} and ms3 is {1}", ms, ms3);

        //Console.WriteLine("Before swapmystringsproperties ms is {0} and ms3 is {1}", ms, ms3);
        //SwapMyStringsProperties(ms, ms3);
        //Console.WriteLine("After swapmystringsproperties ms is {0} and ms3 is {1}", ms, ms3);


        //MyString first = new MyString("One");
        //MyString second = new MyString("Two");
        //MyString third = new MyString("Three");
        //Console.WriteLine("first compared to second: {0}", first.CompareTo(second));
        //Console.WriteLine("third compared to second: {0}", third.CompareTo(second));


        EchoChamber echo4 = new EchoChamber(4);
        // This should print "HiHiHiHi"
        Console.WriteLine(echo4.Echo("Hi"));
        // This should print "Hi"
        Console.WriteLine(echo4.Last);
        EchoChamber echo3 = new EchoChamber();
        // This should print "ByeByeBye"
        Console.WriteLine(echo4.Echo("Bye"));
        // This should throw an exception:
        EchoChamber echoNegative = new EchoChamber(-7);




    }
    public static void SwapMyStrings(MyString left, MyString right)
    {
        MyString temp = left;
        left = right;
        right = temp;
        Console.WriteLine("SwapMyStrings: left is {0}, right is {1}", left, right);
    }
    public static void SwapMyStringsProperties(MyString left, MyString right)
    {
        string temp = left.StringField;
        left.StringField = right.StringField;
        right.StringField = temp;
        Console.WriteLine("SwapMyStringsProperties: left is {0}, right is {1}", left, right);
    }


}