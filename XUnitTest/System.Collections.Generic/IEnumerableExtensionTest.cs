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
        public void IsNullOrNoItems()
        {
            List<string> a = new List<string>();
            Assert.True(a.IsNullOrNoItems());
        }

        [Fact]
        public void HasItems()
        {
            List<string> a = new List<string>() { string.Empty};
            Assert.True(a.HasItems());
        }




        [Fact]
        public void JoinAsString()
        {
            List<string> a = new List<string>() { "AAA","BBB" };
            a.JoinAsString("'").ShouldBe("'AAA','BBB'");
        }
    }
}
