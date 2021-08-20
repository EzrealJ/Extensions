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
        [Obsolete("除非C#的版本低，否则不要使用，建议改用is关键字")]
        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }
        /// <summary>
        /// <para>在C#9可用时，建议使用<see langword="is"/> <see langword="not"/> <see langword="null"/></para>
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
