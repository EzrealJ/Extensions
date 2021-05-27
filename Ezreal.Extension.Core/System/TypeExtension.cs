using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using System.Linq.Expressions;

namespace Ezreal.Extension.Core
{
    /// <summary>
    /// <see cref="Type"/>类型的扩展
    /// </summary>
    public static class TypeExtension
    {

        /// <summary>
        /// 类型的默认值缓存
        /// </summary>
        private static readonly ConcurrentCache<Type, object> typeDefaultValueCache = new ConcurrentCache<Type, object>();


        /// <summary>
        /// 返回类型的名称（不含namespace）
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string GetName(this Type type)
        {
            if (type.GetTypeInfo().IsGenericType == false)
            {
                return type.Name;
            }

            var builder = new StringBuilder();
            foreach (var argType in type.GetGenericArguments())
            {
                if (builder.Length > 0)
                {
                    builder.Append(",");
                }
                builder.Append(argType.GetName());
            }

            return builder.Insert(0, $"{type.Name}<").Append(">").ToString();
        }

        /// <summary>
        /// 返回类型的默认值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DefaultValue(this Type type)
        {
            if (type == null)
            {
                return null;
            }

            return typeDefaultValueCache.GetOrAdd(type, t =>
            {
                var value = Expression.Convert(Expression.Default(t), typeof(object));
                return Expression.Lambda<Func<object>>(value).Compile().Invoke();
            });
        }

        /// <summary>
        /// 是否可以从<typeparamref name="TBase"/>类型派生
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsInheritFrom<TBase>(this Type type)
        {
            return typeof(TBase).IsAssignableFrom(type);
        }
        /// <summary>
        /// 获取类型所在<see cref="Assembly"/>中定义的子类
        /// </summary>
        /// <param name="type">需要查找子类的类型实例</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetChildTypes(this Type type) => type.GetChildTypes(type.Assembly);
        /// <summary>
        /// 获取类型在指定<see cref="Assembly"/>中定义的子类
        /// </summary>
        /// <param name="type">需要查找子类的类型实例</param>
        /// <param name="assembly">需要查找的程序集</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetChildTypes(this Type type, Assembly assembly) => assembly.GetTypes().Where(t => t != type && type.IsAssignableFrom(t));
    }
}
