using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Logging;
using Modbus;
using PblDAL.Models;
using PblService.BLL;
using Microsoft.Extensions.Configuration;

namespace PblService
{
    public class Program
    {
        private static ApplicationContext _context;

        public const string RunAsServiceArg = "--win-service";
        
        private static ConcurrentDictionary<long, IControllerAdapter> _controllers;
        private static readonly int receiveTimeout = 5000;
        private static readonly int sendTimeout = 5000;

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
 
            _context = new ApplicationContext();
            InitControllers();
            LightsService.Init();
            ModbusControllerAdapter.InvokePollingFinished();
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

        private static void InitControllers()
        {
            if (!_context.Database.CanConnect()) return;

            _controllers = new ConcurrentDictionary<long, IControllerAdapter>();
            foreach (var c in _context.Controllers)
            {
                try
                {
                    var controller = new ModbusControllerAdapter(c.Id, c.SlaveAddress, c.Address, c.Port);
                    controller.Init(receiveTimeout, sendTimeout);
                    if (!_controllers.TryAdd(c.Id, controller))
                    {
                        throw new Exception("Could not add controller to collection");
                    }
                }
                catch
                {
                }
            }
        }

        public static ConcurrentDictionary<long, IControllerAdapter> GetControllers()
        {
            return _controllers;
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
