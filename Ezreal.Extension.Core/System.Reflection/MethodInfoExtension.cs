using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ezreal.Extension.Core
{
    /// <summary>
    /// <see cref="MethodInfo"/>类型的扩展
    /// </summary>
    public static class MethodInfoExtension
    {
        /// <summary>
        /// 返回方法的完整名称
        /// </summary>
        /// <param name="method">方法</param>
        /// <returns></returns>
        public static string GetFullName(this MethodInfo method)
        {
            var builder = new StringBuilder();
            foreach (var p in method.GetParameters())
            {
                if (builder.Length > 0)
                {
                    builder.Append(",");
                }
                builder.Append(p.ParameterType.GetName());
            }

            var insert = $"{method.ReturnType.GetName()} {method.Name}(";
            return builder.Insert(0, insert).Append(")").ToString();
        }
    }
}
