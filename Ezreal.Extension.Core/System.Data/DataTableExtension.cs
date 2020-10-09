
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Ezreal.Extension.Core
{
    public static class DataTableExtension
    {
        /// <summary>
        /// 指示指定的<see cref="DataTable"/>对象是 <see langword="null"/> 还是没有<see cref="DataRow"/>的空集合
        /// <para>
        /// 等同于dt == <see langword="null"/> || dt.Rows.Count &lt;= 0
        /// </para>
        /// </summary>
        /// <param name="dt">将被校验的<see cref="DataTable"/>实例</param>
        /// <returns>如果<paramref name="dt"/> 参数为 <see langword="null"/> 或没有<see cref="DataRow"/>的空集合，则为 <see langword="true"/>；否则为 <see langword="false"/>。</returns>
        public static bool IsNullOrNoRows(this DataTable dt)
        {
            return dt == null || dt.Rows.Count <= 0;
        }
    }
}

