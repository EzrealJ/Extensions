using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ezreal.Extension.Core
{
    /// <summary>
    /// stirng对象扩展
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 指示指定的字符串是 <see langword="null" /> 还是<see cref="string.Empty"/> 字符串。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果参数<paramref name="value"/>的值为<see langword="null"/>或者等同于<see cref="string.Empty"/>的空字符串,则返回<see langword="true"/>,否则返回<see langword="false"/></returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
        /// <summary>
        /// 指示指定的字符串不为<see langword="null" /> 且不为<see cref="string.Empty"/>。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasContent(this string value) => !string.IsNullOrEmpty(value);
        /// <summary>
        /// 指示指定的字符串是 <see langword="null" /> 还是<see cref="System.String.Empty"/> 字符串。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果参数<paramref name="value"/>的值为<see langword="null"/>或者等同于<see cref="string.Empty"/>的空字符串或者仅由空白字符组成,则返回<see langword="true"/>,否则返回<see langword="false"/></returns>
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// 指示指定的字符串不为<see langword="null" /> ，不为<see cref="string.Empty"/>，且不是仅由空白字符组成。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasEffectiveContent(this string value) => !string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// 指示指定的<see cref="string"/>对象是否是纯阿拉伯数字的组合
        /// </summary>
        /// <param name="text">要测试的<see cref="string"/>实例</param>
        /// <returns>如果<paramref name="text"/> 参数为是纯数字则为 <see langword="true"/>；否则为  <see langword="false"/>。</returns>
        public static bool IsArabicNumber(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("message", nameof(text));
            }
            //return System.Text.RegularExpressions.Regex.IsMatch(text.Trim(), @"^[0-9]*$");
            return text.All(t => t >= '0' && t <= '9');
        }

        /// <summary>
        /// 转换指定的字符串为目标数字类型
        /// <para>
        /// 当目标类型为<see cref="Byte"/>、<see cref="SByte"/>、<see cref="Int16"/>、<see cref="UInt16"/>、<see cref="Int32"/>、<see cref="UInt32"/>、<see cref="Int64"/>、<see cref="UInt64"/>时将要转换的字符串不应包含小数部分
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        public static T ToNumber<T>(this string text)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("message", nameof(text));
            }
            return (T)Convert.ChangeType(text, typeof(T));
        }

        /// <summary>
        /// 尝试将字符串转化成<see cref="Guid"/>
        /// </summary>
        /// <param name="text">待转换的<see cref="string"/>实例</param>
        /// <param name="guid">承载转换后值的<see cref="Guid"/>实例</param>
        /// <returns>转换成功时返回<see langword="true"/>并可从<paramref name="guid"/>获取转换后的<see cref="Guid"/>实例</returns>
        public static bool TryParseGuid(this string text,out Guid guid)
        {
            return Guid.TryParse(text, out guid);
        }
    }
}
