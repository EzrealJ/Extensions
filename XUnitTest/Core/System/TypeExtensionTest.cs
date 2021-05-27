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

        public class D<T>where T:B
        {

        }

        [Fact]
      public  void GetChildTypes()
        {
            A a = new A();
            IEnumerable<Type> types = typeof(A).GetChildTypes();
            Assert.True(types.Count() == 2 && types.Contains(typeof(B)) && types.Contains(typeof(C)));

        }
        [Fact]
        public void GetName()
        {
            Assert.Equal("D`1<C>", typeof(D<C>).GetName());
        }
    }
}
