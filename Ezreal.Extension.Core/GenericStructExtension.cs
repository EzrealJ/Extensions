using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.Extension.Core
{
   public static class GenericStructExtension
    {
        /// <summary>
        /// 指示指定的值类型是否是它的默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="struct"></param>
        /// <returns></returns>
        public static bool IsDefault<T>(this T @struct) where T : struct
        {
            return @struct.Equals(default(T));
        }
        /// <summary>
        /// 指示指定的可空值类型对象是否为<see langword="null"/>
        /// </summary>
        /// <param name="nullableStruct"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this Nullable<T> nullableStruct) where T : struct
        {
            return nullableStruct == null;
        }
        /// <summary>
        /// 指示指定的可空值类型对象是否为<see langword="null"/>或其默认值<see langword="defalut"/>(<typeparamref name="T"/>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nullableStruct"></param>
        /// <returns></returns>
        public static bool IsNullOrDefault<T>(this Nullable<T> nullableStruct) where T : struct
        {
            return nullableStruct.IsNull() || nullableStruct.Value.IsDefault();
        }
    }
}
