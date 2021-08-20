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
        /// <see cref="byte"/>、
        /// <see cref="sbyte"/>、
        /// <see cref="short"/>、
        /// <see cref="ushort"/>、
        /// <see cref="int"/>、
        /// <see cref="uint"/>、
        /// <see cref="long"/>、
        /// <see cref="ulong"/>
        /// </para>
        /// </summary>
        public static Type[] IntegerTypes { get; } = {
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong)
        };
        /// <summary>
        /// 浮点型类型
        /// <para>
        /// <see cref="float"/>、
        /// <see cref="double"/>、
        /// <see cref="decimal"/>
        /// </para>
        /// </summary>
        public static Type[] FloatingPointTypes { get; } = {
            typeof(float),
            typeof(double),
            typeof(decimal)
        };
        /// <summary>
        /// 数字类型
        /// <para>
        /// <see cref="byte"/>、
        /// <see cref="sbyte"/>、
        /// <see cref="short"/>、
        /// <see cref="ushort"/>、
        /// <see cref="int"/>、
        /// <see cref="uint"/>、
        /// <see cref="long"/>、
        /// <see cref="ulong"/>、
        /// <see cref="float"/>、
        /// <see cref="double"/>、
        /// <see cref="decimal"/>
        /// </para>
        /// </summary>
        public static Type[] NumberTypes { get; } = {
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal)
        };

    }
}
