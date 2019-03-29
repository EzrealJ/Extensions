using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Ezreal.Extension.Core;
using System.Linq;

namespace XUnitTest.Core.System
{
    public class TypeExtensionTest
    {

        public class A
        {

        }

        public class B : A
        {

        }

        public class C : B
        {

        }

        [Fact]
        void GetChildTypes()
        {
            A a = new A();
            IEnumerable<Type> types = typeof(A).GetChildTypes();
            Assert.True(types.Count() == 2 && types.Contains(typeof(B)) && types.Contains(typeof(C)));

        }
    }
}
