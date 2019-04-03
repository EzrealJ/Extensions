using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xunit;
using Ezreal.Extension.Core;
using Shouldly;

namespace XUnitTest.Core.System
{
    public class EnumExtensionTest
    {
        public enum Enum1
        {
            [Description("A1")]
            A = 1,
            [Description("B2")]
            B = 2,
            C = 3,
        }

        public enum Enum2:byte
        {
            [Description("A1")]
            A = 1,
            [Description("B2")]
            B = 2,
            [Description("C3")]
            C = 3,
        }
        [Fact]
        void GetUnderlyingValue()
        {
            Enum1 enum1 = Enum1.B;
            enum1.GetUnderlyingValue<int>().ShouldBe(2);
            Enum2 enum2 = Enum2.C;
            enum2.GetUnderlyingValue<byte>().ShouldBe((byte)3);
        }
        [Fact]
        void GetDescription()
        {
            Enum1 enum1 = Enum1.B;
            enum1.GetDescription().ShouldBe("B2");
            Enum1 enum2 = Enum1.C;
            enum2.GetDescription(false).ShouldBeNull();
        }
    }
}
