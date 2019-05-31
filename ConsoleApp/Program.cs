using System;
using System.IO;
using System.Threading;
using Ezreal.Extension.Core;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = "123";
            Console.WriteLine(a.IsArabicNumber());
        }
    }
}
