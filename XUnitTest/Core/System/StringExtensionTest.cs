using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Ezreal.Extension.Core;
using Shouldly;

namespace XUnitTest.Core.System
{
    public class StringExtensionTest
    {

        [Theory]
        [InlineData(@"123", true)]
        [InlineData(@"12.3", false)]
        [InlineData(@"123 ", false)]
        void IsArabicNumber(string value, bool result)
        {
            Assert.True(value.IsArabicNumber() == result);
        }
        [Fact]
        void ToNumber()
        {
            string str = "12";
            Assert.True(str.ToNumber<byte>() == 12);
            Assert.True(str.ToNumber<sbyte>() == 12);
            Assert.True(str.ToNumber<short>() == 12);
            Assert.True(str.ToNumber<ushort>() == 12);
            Assert.True(str.ToNumber<int>() == 12);
            Assert.True(str.ToNumber<uint>() == 12);
            Assert.True(str.ToNumber<long>() == 12);
            Assert.True(str.ToNumber<ulong>() == 12);
            str = "12.3";
            Assert.True(str.ToNumber<float>() == 12.3f);
            Assert.True(str.ToNumber<double>() == 12.3d);
            Assert.True(str.ToNumber<decimal>() == 12.3m);
        }
        [Fact]
        void TryParseGuid()
        {
            Guid g1 = Guid.NewGuid();
            string guidStr = g1.ToString();
            guidStr.TryParseGuid(out Guid g2).ShouldBe(true);
            g1.ShouldBe(g2);

        }

    }
}
