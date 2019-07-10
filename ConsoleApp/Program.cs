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
            var q = BitConverter.GetBytes(65535u);
            var a = "123";
            Console.WriteLine(a.IsArabicNumber());
        }
    }
}
