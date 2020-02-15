using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Exceptions;

namespace elk_logging_demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Don't have access to appsettings here... need to figure this out
            //var telemetryConfig = TelemetryConfiguration.CreateDefault();
            //telemetryConfig.InstrumentationKey = "";
            //Log.Logger = new LoggerConfiguration()
            //        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            //        .Enrich.FromLogContext()
            //        .Enrich.WithExceptionDetails()
            //        .WriteTo.Console()
            //        .WriteTo.Http("")
            //        .WriteTo.ApplicationInsights(telemetryConfig, TelemetryConverter.Traces)
            //        .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
