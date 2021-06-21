using CustomLogging.Logger.DatabaseLogger.Data;
using CustomLogging.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace CustomLogging.Logger.DatabaseLogger
{
    class DatabaseLoggerProvider : ILoggerProvider
    {
        public readonly DatabaseLoggerModel Options;
       
        public DatabaseLoggerProvider(IOptions<DatabaseLoggerModel> _options )
        {
            //WriteFileLock = new SemaphoreSlim(1, 1);
            Options = _options.Value;
            

             
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(this);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
       
    }
}
