using CustomLogging.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogging.Logger.DatabaseLogger
{
    public static class DatabaseLoggerExtensions
    {
        public static ILoggingBuilder AddDatabaseLogger(this ILoggingBuilder builder, Action<DatabaseLoggerModel> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, DatabaseLoggerProvider>();

            builder.Services.Configure(configure);
            return builder;
        }
    }
}
