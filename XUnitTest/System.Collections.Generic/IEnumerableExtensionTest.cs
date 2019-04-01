using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.Extension.Core;
using Xunit;

namespace XUnitTest.System.Collections.Generic
{
   public class IEnumerableExtensionTest
    {
        [Fact]
        void GetChildTypes()
        {
            List<string> a = new List<string>();
            Assert.True(a.IsNullOrNoItems());
        }
    }
}
