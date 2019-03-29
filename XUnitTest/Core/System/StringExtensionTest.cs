using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Ezreal.Extension.Core;

namespace XUnitTest.Core.System
{
    public class StringExtensionTest
    {
        [Theory]
        [InlineData(@"123", false)]
        [InlineData(@"", true)]
        [InlineData(@" ", false)]
        void StringIsNotNullOrEmpty(string value, bool result)
        {
            Assert.True(value.IsNullOrEmpty() == result);
        }


    }
}
