using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Ezreal.Extension.Core
{
    public static class DataSetExtension
    {
        /// <summary>
        /// 指示指定的<see cref="DataSet"/>对象是 <see langword="null"/> 还是没有<see cref="DataTable"/>的空集合
        /// </summary>
        /// <param name="ds">将被校验的<see cref="DataSet"/>实例</param>
        /// <returns>如果<paramref name="ds"/> 参数为 <see langword="null"/> 或没有<see cref="DataTable"/>的空集合，则为 <see langword="true"/>；否则为 <see langword="false"/>。</returns>
        public static bool IsNullOrNoTables(this DataSet ds)
        {
            if (ds != null)
                if (ds.Tables.Count > 0)
                    return false;
                else
                    return true;
            else
                return true;
        }
    }
}
