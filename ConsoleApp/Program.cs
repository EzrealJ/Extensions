using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            var c = "123";
            var z = c;
            c = new string("123");
            Console.WriteLine(ReferenceEquals(c,z));
            Console.ReadKey();
        }

        public struct AAA
        {
            public int MyProperty { get; set; }

            public string MyProperty1 { get; set; }
        }
    }
}
