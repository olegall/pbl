using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PblUi
{
    public class Program
    {
        public const string RunAsServiceArg = "--win-service";

        public static void Main(string[] args)
        {
            var isService = args.Contains(RunAsServiceArg);
            var builder = CreateWebHostBuilder(args.Where(a => a != RunAsServiceArg).ToArray());
            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                var pathToContentRoot = Path.GetDirectoryName(pathToExe);
                builder.UseContentRoot(pathToContentRoot);
            }

            var host = builder.Build();

            if (isService)
            {
                host.RunAsService();
            }
            else
            {
                host.Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => 
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) =>
                {
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseStartup<Startup>();
    }
}
