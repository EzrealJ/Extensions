﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ezreal.Extension.Core
{
    /// <summary>
    /// 通用值类型扩展
    /// </summary>
    public static class GenericStructExtension
    {
        /// <summary>
        /// 指示指定的值类型是它的默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="struct"></param>
        /// <returns></returns>
        public static bool IsDefault<T>(this T @struct) where T : struct
        {
            return @struct.Equals(default(T));
        }

        /// <summary>
        /// 指示指定的值类型不是它的默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="struct"></param>
        /// <returns></returns>
        public static bool NotDefault<T>(this T @struct) where T : struct
        {
            return !IsDefault(@struct);
        }
        /// <summary>
        /// 指示指定的可空值类型对象为<see langword="null"/>
        /// <para>
        /// 此扩展等同于<see langword="!"/><see cref="Nullable{T}.HasValue"/>
        /// </para>
        /// </summary>
        /// <param name="nullableStruct"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T? nullableStruct) where T : struct
        {
            return nullableStruct == null;
        }
        /// <summary>
        /// 指示指定的可空值类型对象为<see langword="null"/>或其默认值<see langword="defalut"/>(<typeparamref name="T"/>)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nullableStruct"></param>
        /// <returns></returns>
        public static bool IsNullOrDefault<T>(this T? nullableStruct) where T : struct
        {
            return nullableStruct.IsNull() || nullableStruct.Value.IsDefault();
        }

        /// <summary>
        /// 指示指定的可空值类型不为空且不是其基类型的默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="struct"></param>
        /// <returns></returns>
        public static bool HasNotDefaultValue<T>(this T? @struct) where T : struct
        {
            return !IsNullOrDefault(@struct);
        }
        /// <summary>
        /// 将基础类型的值转换为指定枚举的值
        /// <para>
        /// 可转换的类型包括<see cref="Byte"/>、<see cref="SByte"/>、<see cref="Int16"/>、<see cref="UInt16"/>、<see cref="Int32"/>、<see cref="UInt32"/>、<see cref="Int64"/>、<see cref="UInt64"/>
        /// </para>
        /// </summary>
        /// <typeparam name="TUnderlyingType">参数可以是<see cref="Byte"/>、<see cref="SByte"/>、<see cref="Int16"/>、<see cref="UInt16"/>、<see cref="Int32"/>、<see cref="UInt32"/>、<see cref="Int64"/>、<see cref="UInt64"/>其中的一种</typeparam>
        /// <typeparam name="TEnum">目标枚举类型</typeparam>
        /// <param name="value">待转换的值</param>
        /// <returns></returns>
        public static TEnum ToEnum<TUnderlyingType, TEnum>(this TUnderlyingType value)
    where TEnum : Enum /*struct, IComparable, IConvertible, IFormattable*/
    where TUnderlyingType : struct, IComparable, IComparable<TUnderlyingType>, IConvertible, IEquatable<TUnderlyingType>, IFormattable
        {
            if (!CommonFields.IntegerTypes.Contains(typeof(TUnderlyingType)))
            {
                throw new Exception($"Enumeration type cannot be {typeof(TUnderlyingType).Name}");
            }

            if (Enum.GetUnderlyingType(typeof(TEnum)) == typeof(TUnderlyingType))
            {
                return (TEnum)(value as ValueType);
            }
            else
            {
                throw new Exception($"Enumeration is not based on {typeof(TUnderlyingType).Name}");
            }
        }

    }
}
