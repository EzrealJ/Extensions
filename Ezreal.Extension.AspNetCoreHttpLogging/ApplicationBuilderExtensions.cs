using System;
using Ezreal.Extension.AspNetCoreHttpLogging;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds a middleware that can log HTTP requests and responses.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
        /// <returns>The <see cref="IApplicationBuilder"/>.</returns>
        public static IApplicationBuilder UseEzrealHttpLogging(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            app.UseMiddleware<HttpLoggingMiddleware>();
            return app;
        }
    }
}
