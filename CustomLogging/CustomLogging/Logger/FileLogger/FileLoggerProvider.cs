using CustomLogging.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace CustomLogging.Logger
{
   public class FileLoggerProvider : ILoggerProvider
    {
        public readonly FileLoggerModel Options;

        public SemaphoreSlim WriteFileLock;
        public  FileLoggerProvider(IOptions<FileLoggerModel> _options)
        {
            WriteFileLock = new SemaphoreSlim(1, 1);
            Options = _options.Value;

            if (!Directory.Exists(Options.FolderPath))
            {
                Directory.CreateDirectory(Options.FolderPath);
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new  FileLogger(this);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
