using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.Extension.Core
{
    /// <summary>
    /// 通用对象扩展
    /// </summary>
    public static class GenericClassExtension
    {
        /// <summary>
        /// 指示指定的引用类型对象是否为<see langword="null"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }
        /// <summary>
        /// 指示指定的引用类型对象是否不为<see langword="null"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool NotNull<T>(this T obj) where T : class
        {
            return obj != null;
        }
    }
}
