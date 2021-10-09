using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreWebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEzrealHttpLogging(Configuration.GetSection("EzrealHttpLogging"), option =>
            {
                option.ModuleName = nameof(AspNetCoreWebApp);
                option.SegmentedString = new string('-', 48);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#if NET461 || NETCOREAPP2_1 || NETCOREAPP2_2
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseEzrealHttpLogging();
            app.Run(async (context) =>
            {
                await SetResponseAsync(context);

            });
        }

#else

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseEzrealHttpLogging();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await SetResponseAsync(context);
                });
            });
        }
#endif


        private async Task SetResponseAsync(HttpContext context)
        {
            context.Response.Headers.Add("test", "testValue");
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Hello World!");
        }
    }
}
