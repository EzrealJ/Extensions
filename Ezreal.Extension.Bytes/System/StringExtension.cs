using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.Extension.Bytes.System
{
    public static class StringExtension
    {
        /// <summary>
        /// 普通文本转化为Bytes
        /// </summary>
        /// <param name="string"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static IEnumerable<byte> NormalTextToBytes(this string @string ,Encoding encoding=null)
        {
            encoding = encoding ?? Encoding.UTF8;
            return encoding.GetBytes(@string);
        }

        /// <summary>
        /// 十六进制文本转化为Bytes
        /// </summary>
        /// <param name="hexString"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static IEnumerable<byte> HexTextToBytes(this string hexString)
        {
            if (string.IsNullOrEmpty(hexString)) throw new ArgumentNullException("hexString");
            hexString = hexString.Replace(" ", "");
            int length = hexString.Length;
            if (length % 2 > 0)
            {
                hexString = hexString.PadLeft(length + 1, '0');
                length += 1;
            }
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < length / 2; i++)
            {
                bytes.Add(Convert.ToByte(hexString.Substring(2 * i, 2), 16));
            }
            return bytes;
        }

    }
}
