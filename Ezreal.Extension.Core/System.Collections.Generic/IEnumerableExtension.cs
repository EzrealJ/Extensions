using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ezreal.Extension.Core
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// 指示指定的序列对象是 <see langword="null"/> 还是没有元素的空集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">将被校验的序列实例</param>
        /// <returns>如果<paramref name="collection"/> 参数为 <see langword="null"/> 或没有<typeparamref name="T"/>实例的空集合，则为 <see langword="true"/>；否则为 <see langword="false"/>。</returns>
        public static bool IsNullOrNoItems<T>(this IEnumerable<T> collection)
        {
            if (collection != null)
                if (collection.Count() > 0)
                    return false;
                else
                    return true;
            else
                return true;
        }


        /// <summary>
        /// 返回使用默认元素将序列向列首补齐得到的新序列
        /// </summary>
        /// <param name="collection">原有序列</param>
        /// <param name="count">新序列的元素总数</param>
        /// <param name="item">用于补齐的元素</param>
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
            return collection.PadRight(count, default(T));
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

            List<T> tempArray = new List<T>();          
            for (int i = 0; i < count - collectionCount; i++)
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
            int collectionCount = collection.Count();

            List<T> tempArray = new List<T>();
            tempArray.AddRange(collection);
            for (int i = 0; i < count - collectionCount; i++)
            {
                tempArray.Add(item);
            }           
            return tempArray;
        }
    }
}
