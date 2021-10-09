using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Ezreal.Extension.AspNetCoreHttpLogging
{
    public class HttpLoggingOptions
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 记录日志时包含Body
        /// <para>注意,读取Body会影响性能,若非必要不要记录Body</para>
        /// </summary>
        public bool ReadBody { get; set; } = false;
        /// <summary>
        /// 没有错误发生时不记录
        /// </summary>
        public bool IgnoreWhenNoError { get; set; }
        /// <summary>
        /// 匹配模式
        /// </summary>
        public EnumMatchMode MatchMode { get; set; }
        public LogLevel LogLevel { get; set; } = LogLevel.Debug;
        public HashSet<string> IgnorePathsRegexPatterns { get; set; } = new HashSet<string>();
        public HashSet<string> IncludePathRegexPatterns { get; set; } = new HashSet<string>();
        /// <summary>
        /// 日志区域分割字符串
        /// </summary>
        public string SegmentedString { get; set; } = new string('■', 48);

        public enum EnumMatchMode
        {
            /// <summary>
            /// 忽略模式
            /// </summary>
            Ignore,
            /// <summary>
            /// 包含模式
            /// </summary>
            Include
        }


        /// <summary>
        /// 当前的PathString是否匹配记录日志的规则 
        /// </summary>
        /// <param name="pathString"></param>
        /// <returns></returns>
        public bool IsMatch(PathString pathString)
        {
            return MatchMode switch
            {
                EnumMatchMode.Ignore => !IgnorePathsRegexPatterns.Any(r => Regex.IsMatch(pathString,r)),
                EnumMatchMode.Include => IncludePathRegexPatterns.Any(r => Regex.IsMatch(pathString, r)),
                _ => false,
            };
        }
    }
}
