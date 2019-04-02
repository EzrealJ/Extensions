using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.Extension.Core
{
   internal class CommonFields
    {
        /// <summary>
        /// 整数型类型
        /// <para>
        /// 包含<see cref="Byte"/>、<see cref="SByte"/>、<see cref="Int16"/>、<see cref="UInt16"/>、<see cref="Int32"/>、<see cref="UInt32"/>、<see cref="Int64"/>、<see cref="UInt64"/>
        /// </para>
        /// </summary>
        public static Type[] IntegerTypes { get; } = { typeof(byte), typeof(sbyte), typeof(short), typeof(ushort), typeof(int), typeof(uint),  typeof(long), typeof(ulong) };
        /// <summary>
        /// 浮点型类型
        /// <para>
        /// 包含<see cref="Single"/>、<see cref="Double"/>、<see cref="Decimal"/>
        /// </para>
        /// </summary>
        public static Type[] FloatingPointTypes { get; } = { typeof(float), typeof(double), typeof(decimal) };
    }
}
 