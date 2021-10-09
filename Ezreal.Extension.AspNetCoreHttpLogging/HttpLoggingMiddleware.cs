using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Ezreal.Extension.AspNetCoreHttpLogging
{
    internal class HttpLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IOptionsMonitor<HttpLoggingOptions> _optionsMonitor;
        private HttpLoggingOptions options => _optionsMonitor.CurrentValue;
        public HttpLoggingMiddleware(RequestDelegate next, ILogger<HttpLoggingMiddleware> logger, IOptionsMonitor<HttpLoggingOptions> options)
        {
            _next = next;
            _logger = logger;
            _optionsMonitor = options;
        }

        /// <summary>
        /// Invokes the <see cref="HttpLoggingMiddleware" />.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>HttpResponseLog.cs
        public Task Invoke(HttpContext context)
        {
            if (!_logger.IsEnabled(options.LogLevel))
            {
                // Logger isn't enabled.
                return _next(context);
            }

            return InvokeInternal(context);
        }

        private async Task InvokeInternal(HttpContext context)
        {
            using MemoryStream canReadResponseStream = new MemoryStream();
            HttpResponse response = context.Response;
            Stream originalResponseBody = ReplaceResponseBody(canReadResponseStream, response);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Exception ex = null;
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                ex = e;
            }
            finally
            {
                stopwatch.Stop();
            }
            if (options.IgnoreWhenNoError && ex is null)
            {
                await ReductionResponseBody(response, originalResponseBody);
                return;
            }
            HttpRequest request = context.Request;
            PathString path = request.Path;
            if (!options.IsMatch(path))
            {
                await ReductionResponseBody(response, originalResponseBody);
                return;
            }
            string method = request.Method;
            HostString host = request.Host;
            QueryString queryString = request.QueryString;
            IPAddress remoteAddress = context.Connection.RemoteIpAddress;
            int remotePort = context.Connection.RemotePort;
            int statusCode = response.StatusCode;
            //var referrerPolicy=httpContext.
            StringBuilder stringBuilder = new StringBuilder();
            /************************************************************************************************/
            stringBuilder.AppendLine(options.ModuleName);
            stringBuilder.AppendLine(options.SegmentedString);
            stringBuilder.AppendLine($"A request occurred on {DateTime.Now}");
            /************************************************************************************************/
            stringBuilder.AppendLine(options.SegmentedString);
            stringBuilder.AppendLine("▼-General")
                .AppendLine($"Request Url:{host}{path}{queryString}")
                .AppendLine($"Request Method:{method}")
                .AppendLine($"Status Code: {statusCode} {(HttpStatusCode)statusCode}")
                .AppendLine($"Remote Address:{remoteAddress}:{remotePort}");
            //.AppendLine($"Referrer Policy:{null}");
            /************************************************************************************************/
            stringBuilder.AppendLine(options.SegmentedString);
            stringBuilder.AppendLine("▼-Request Headers");
            foreach (KeyValuePair<string, StringValues> header in request.Headers)
            {
                stringBuilder.AppendLine($"{header.Key} :{header.Value}");
            }
            /************************************************************************************************/
            stringBuilder.AppendLine(options.SegmentedString);
            stringBuilder.AppendLine("▼-Query String Parameters");
            foreach (KeyValuePair<string, StringValues> query in request.Query)
            {
                stringBuilder.AppendLine($"{query.Key} :{query.Value}");
            }
            /************************************************************************************************/
            stringBuilder.AppendLine(options.SegmentedString);
            stringBuilder.AppendLine("▼-Request Payload");
            if (options.ReadBody)
            {                
                request.EnableBuffering();
                using (StreamReader reader = new(request.Body))
                {
                    request.Body.Seek(0, SeekOrigin.Begin);
                    string body = await reader.ReadToEndAsync();
                    request.Body.Seek(0, SeekOrigin.Begin);
                    stringBuilder.AppendLine(body);
                }
            }
            /************************************************************************************************/
            stringBuilder.AppendLine(options.SegmentedString);
            stringBuilder.AppendLine("▼-Response Headers");
            foreach (KeyValuePair<string, StringValues> header in response.Headers)
            {
                stringBuilder.AppendLine($"{header.Key} :{header.Value}");
            }
            /************************************************************************************************/
            if (options.ReadBody)
            {
                stringBuilder.AppendLine(options.SegmentedString);
                stringBuilder.AppendLine("▼-Response Payload");
                using StreamReader reader = new(canReadResponseStream);
                canReadResponseStream.Seek(0, SeekOrigin.Begin);
                string body = await reader.ReadToEndAsync();
                stringBuilder.AppendLine(body);
                await ReductionResponseBody(response, originalResponseBody);
            }
            /************************************************************************************************/
            if (ex is not null)
            {
                stringBuilder.AppendLine(options.SegmentedString);
                stringBuilder.AppendLine("▼-Exception");
                stringBuilder.AppendLine(ex.ToString());
            }
            /************************************************************************************************/
            stringBuilder.AppendLine(options.SegmentedString);
            stringBuilder.AppendLine($"It takes {stopwatch.Elapsed} to respond to this request.");
            stringBuilder.AppendLine(options.SegmentedString);
            var level = ex is not null ? LogLevel.Error : options.LogLevel;

            _logger.Log(level, ex, stringBuilder.ToString());
            if (ex is not null)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 替换HttpResponse的Body
        /// </summary>
        /// <param name="canReadResponseStream">可重读的流</param>
        /// <param name="response">响应</param>
        /// <param name="originalResponseBody">原本的流</param>
        /// <returns></returns>
        private Stream ReplaceResponseBody(MemoryStream canReadResponseStream, HttpResponse response)
        {
            Stream originalResponseBody = null;
            if (options.ReadBody)
            {
                originalResponseBody = response.Body;
                response.Body = canReadResponseStream;
            }

            return originalResponseBody;
        }
        /// <summary>
        /// 还原HttpResponse的Body
        /// </summary>
        /// <param name="canReadResponseStream">可重读的流</param>
        /// <param name="response">响应</param>
        /// <param name="originalResponseBody">原本的流</param>
        /// <returns></returns>
        private async Task ReductionResponseBody(HttpResponse response, Stream originalResponseBody)
        {
            if (options.ReadBody)
            {
                response.Body.Seek(0, SeekOrigin.Begin);
                await response.Body.CopyToAsync(originalResponseBody);
                response.Body = originalResponseBody;
            }
        }
    }
}
