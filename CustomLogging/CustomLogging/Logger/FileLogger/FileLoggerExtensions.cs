using CustomLogging.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogging.Logger
{
    public static class LoggerExtensions
    {
        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, Action<FileLoggerModel> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>();           
            builder.Services.Configure(configure);
            return builder;
        }
    }
}
