using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ezreal.Extension.Core;
using Shouldly;
using Xunit;

namespace XUnitTest.System.Collections.Generic
{
    public class IEnumerableExtensionTest
    {
        [Fact]
        void IsNullOrNoItems()
        {
            List<string> a = new List<string>();
            Assert.True(a.IsNullOrNoItems());
        }

        [Fact]
        void PadLeft()
        {
            List<string> a = new List<string>() { "AAA" };
            var a1 = a.PadLeft(3);
            a1.FirstOrDefault().ShouldBeNull();
            a1.LastOrDefault().ShouldBe("AAA");
            var a2 = a.PadLeft(3, "BBB");
            a2.FirstOrDefault().ShouldBe("BBB");
            a2.LastOrDefault().ShouldBe("AAA");

        }

        [Fact]
        void PadRight()
        {
            List<string> a = new List<string>() { "AAA" };
            var a1 = a.PadRight(3);
            a1.LastOrDefault().ShouldBeNull();
            a1.FirstOrDefault().ShouldBe("AAA");
            var a2 = a.PadRight(3, "BBB");
            a2.LastOrDefault().ShouldBe("BBB");
            a2.FirstOrDefault().ShouldBe("AAA");

        }

        [Fact]
        void Join()
        {
            List<string> a = new List<string>() { "AAA","BBB" };
            a.JoinAsString("'").ShouldBe("'AAA','BBB'");
        }
    }
}
