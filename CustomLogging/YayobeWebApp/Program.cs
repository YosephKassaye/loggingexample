using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CustomLogging.Logger;
using CustomLogging.Logger.DatabaseLogger;

namespace YayobeWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                   .ConfigureLogging((context, logging) =>
                   {
                       logging.AddDatabaseLogger(options =>
                       {
                           context.Configuration.GetSection("Logging").GetSection("YaYoBEDatabaseLogger").GetSection("Options").Bind(options);
                       });
                       //.ConfigureLogging((context, logging) =>
                       //{
                       //    logging.AddFileLogger(options =>
                       //    {
                       //        context.Configuration.GetSection("Logging").GetSection("YaYoBEFileLogger").GetSection("Options").Bind(options);
                       //    });
                   });
    }
}
