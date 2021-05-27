using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ezreal.Extension.Core
{
    /// <summary>
    /// <see cref="IEnumerable{T}"/>类型的扩展
    /// </summary>
    public static class IEnumerableExtension
    {
        /// <summary>
        /// 指示指定的序列对象是 <see langword="null"/> 还是没有元素的空集合
        /// <para>
        /// 等同于collection == <see langword="null"/> || !collection.Any()
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">将被校验的序列实例</param>
        /// <returns>如果<paramref name="collection"/> 参数为 <see langword="null"/> 或没有<typeparamref name="T"/>实例的空集合，则为 <see langword="true"/>；否则为 <see langword="false"/>。</returns>
        public static bool IsNullOrNoItems<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        /// <summary>
        /// 指示指定的序列对象是是否包含元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool HasItems<T>(this IEnumerable<T> collection)
        {
            return !IsNullOrNoItems(collection);
        }


        /// <summary>
        /// 返回使用默认元素将序列向列首补齐得到的新序列
        /// </summary>
        /// <param name="collection">原有序列</param>
        /// <param name="count">新序列的元素总数</param>
        /// <returns></returns>
        public static IEnumerable<T> PadLeft<T>(this IEnumerable<T> collection, int count)
        {
            return collection.PadLeft(count, default(T));
        }

        /// <summary>
        /// 返回使用默认元素将序列向列尾补齐得到的新序列
        /// </summary>
        /// <param name="collection">原有序列</param>
        /// <param name="count">新序列的元素总数</param>
        /// <param name="item">用于补齐的元素</param>
        /// <returns></returns>
        public static IEnumerable<T> PadRight<T>(this IEnumerable<T> collection, int count)
        {
            return collection.PadRight(count, default);
        }

        /// <summary>
        /// 返回使用指定元素将序列向列首补齐得到的新序列
        /// </summary>
        /// <param name="collection">原有序列</param>
        /// <param name="count">新序列的元素总数</param>
        /// <param name="item">用于补齐的元素</param>
        /// <returns></returns>
        public static IEnumerable<T> PadLeft<T>(this IEnumerable<T> collection, int count, T item)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            int collectionCount = collection.Count();
            int padLength = count - collectionCount;
            List<T> tempArray = new List<T>();
            for (int i = 0; i < padLength; i++)
            {
                tempArray.Add(item);
            }
            tempArray.AddRange(collection);
            return tempArray;
        }

        /// <summary>
        /// 返回使用指定元素将序列向列尾补齐得到的新序列
        /// </summary>
        /// <param name="collection">原有序列</param>
        /// <param name="count">新序列的元素总数</param>
        /// <param name="item">用于补齐的元素</param>
        /// <returns></returns>
        public static IEnumerable<T> PadRight<T>(this IEnumerable<T> collection, int count, T item)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            var enumerable = collection as T[] ?? collection.ToArray();
            int collectionCount = enumerable.Count();

            List<T> tempArray = new List<T>();
            tempArray.AddRange(enumerable);
            for (int i = 0; i < count - collectionCount; i++)
            {
                tempArray.Add(item);
            }
            return tempArray;
        }


        /// <summary>
        /// 将集合连接为带分隔符的字符串
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="collection">集合</param>
        /// <param name="quotes">引号，默认不带引号，范例：单引号 "'"</param>
        /// <param name="separator">分隔符，默认使用逗号分隔</param>
        public static string JoinAsString<T>(this IEnumerable<T> collection, string quotes = "", string separator = ",")
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            StringBuilder result = new StringBuilder();
            foreach (T each in collection)
            {
                result.AppendFormat("{0}{1}{0}{2}", quotes, each, separator);
            }
            return separator == "" ? result.ToString() : result.ToString().TrimEnd(separator.ToCharArray());
        }
    }
}
