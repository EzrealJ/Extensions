using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.Extension.Core
{
    public static class StringExtension
    {
        /// <summary>
        /// 指示指定的字符串是 <see langword="null" /> 还是<see cref="System.String.Empty"/> 字符串。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果参数<paramref name="value"/>的值为<see langword="null"/>或者等同于<see cref="System.String.Empty"/>的空字符串,则返回<see langword="true"/>,否则返回<see langword="false"/></returns>
        public static bool IsNullOrEmpty(this String value) => string.IsNullOrEmpty(value);
        /// <summary>
        /// 指示指定的字符串是 <see langword="null" /> 还是<see cref="System.String.Empty"/> 字符串。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果参数<paramref name="value"/>的值为<see langword="null"/>或者等同于<see cref="System.String.Empty"/>的空字符串或者仅由空白字符组成,则返回<see langword="true"/>,否则返回<see langword="false"/></returns>
        public static bool IsNullOrWhiteSpace(this String value) => string.IsNullOrWhiteSpace(value);
    }
}
