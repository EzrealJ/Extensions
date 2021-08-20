using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Ezreal.Extension.Core;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = typeof(List<string>).GetMethod(nameof(List<string>.Add)).GetFullName();
            Console.WriteLine(x);

            var q = BitConverter.GetBytes(65535u);
            var a = "123";
            Console.WriteLine(a.IsArabicNumber());
        }

    }
}
