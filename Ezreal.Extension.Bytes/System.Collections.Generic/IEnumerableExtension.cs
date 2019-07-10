using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ezreal.Extension.Bytes.System.Collections.Generic
{
    public static class IEnumerableExtension
    {

        public static string ToHexString(this IEnumerable<byte> bytes)
        {
            if (bytes == null)
            {
                return string.Empty;
            }
            byte[] sourceArray = bytes as byte[];//尝试解析为byte[]来避免不必要的转换
            return BitConverter.ToString(sourceArray ?? bytes.ToArray()).Replace("-", string.Empty);
        }


        /// <summary>
        /// 将<paramref name="bytes"/>转为16进制表示的字符串,并用指定分隔符<paramref name="separator"/>分割每个字节
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexStringWithSeparator(this IEnumerable<byte> bytes, string separator)
        {
            if (bytes == null)
            {
                return string.Empty;
            }
            byte[] sourceArray = bytes as byte[];//尝试解析为byte[]来避免不必要的转换
            return BitConverter.ToString(sourceArray ?? bytes.ToArray()).Replace("-", separator ?? string.Empty);
        }
    }
}
