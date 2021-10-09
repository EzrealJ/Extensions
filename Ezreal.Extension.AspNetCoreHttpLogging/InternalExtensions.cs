#if NET461_OR_GREATER ||NETCOREAPP2_1 ||NETCOREAPP2_2
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ezreal.Extension.AspNetCoreHttpLogging
{
    internal static class InternalExtensions
    {

        public static void EnableBuffering(this HttpRequest request) => request.EnableRewind();


    }
}
#endif
