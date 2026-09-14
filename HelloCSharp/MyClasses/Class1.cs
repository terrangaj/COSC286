namespace MyClasses
{
    public class SayStuffClass
    {
        public static void SayGoodbye()
        {
            System.Console.WriteLine("Goodbye World");
        }

        public static void SayAnything(string thingToSay)
            {
            Console.WriteLine(thingToSay);

            }

        public static string CreateGoodbye(string personToSayGoodbyeTo)
        {
            return "Goodbye, " + personToSayGoodbyeTo;
        }

    }
}
