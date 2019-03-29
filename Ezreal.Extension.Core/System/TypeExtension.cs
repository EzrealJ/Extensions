using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ezreal.Extension.Core
{
    public static class TypeExtension
    {
        /// <summary>
        /// 获取类型所在<see cref="Assembly"/>中定义的子类
        /// </summary>
        /// <param name="type">需要查找子类的类型实例</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetChildTypes(this Type type)
        {
            return type.GetChildTypes(type.Assembly);
        }
        /// <summary>
        /// 获取类型在指定<see cref="Assembly"/>中定义的子类
        /// </summary>
        /// <param name="type">需要查找子类的类型实例</param>
        /// <param name="assembly">需要查找的程序集</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetChildTypes(this Type type,Assembly assembly)
        {
            return assembly.GetTypes().Where(t =>t.IsSubclassOf(type));
        }
    }
}
