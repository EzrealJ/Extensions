# 1、Ezreal.Extension.AspNetCoreHttpLogging

Import

```C#
//in aspnetcore project StartUp.cs
        public void ConfigureServices(IServiceCollection services)
        {
            //...other TODO
            //Configuration is IConfiguration
        services.AddEzrealHttpLogging(Configuration.GetSection("ConfigurationSectionName"), option =>
            {
                option.ModuleName = nameof(AspNetCoreWebApp);
                option.SegmentedString = new string('-', 48);
            });
        }
```

Use

```C#
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //...other TODO
            //Please pay attention to the reasonable arrangement of the pipeline sequence
            app.UseEzrealHttpLogging();
            app.UseRouting();
            //...other TODO
        }
```

Config

```json
//for example
//in appsettings.json
{
  "Logging": {
    "LogLevel": {
      "Ezreal.Extension.AspNetCoreHttpLogging": "Information"
    }
  },
  "EzrealHttpLogging": {
    "ReadBody": true,
    "IgnoreWhenNoError": false,
    "LogLevel": "Information" //logging if Ezreal.Extension.AspNetCoreHttpLogging LogLevel Enable this node value
  }
}
```
