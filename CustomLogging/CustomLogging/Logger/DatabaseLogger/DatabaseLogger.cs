using CustomLogging.Logger.DatabaseLogger.Data;
using CustomLogging.Model;
using Microsoft.Extensions.Logging;
using System;

namespace CustomLogging.Logger.DatabaseLogger
{
    internal class DatabaseLogger : ILogger
    {
        protected readonly DatabaseLoggerProvider _dbProvider;
        protected readonly DatabaseRepository _repo = new DatabaseRepository();
        public DatabaseLogger(DatabaseLoggerProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (logLevel == LogLevel.Critical || logLevel == LogLevel.Error || logLevel == LogLevel.Warning || logLevel == LogLevel.Information)
                RecordMsg(logLevel, eventId, state, exception, formatter);
        }
        private void RecordMsg<TState>(LogLevel logLevel, EventId eventId, 
            TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _repo.Log(new Log
            {
 
                Message=formatter(state, exception),
                MessageTemplate="",
                Level=logLevel.ToString(),
                TimeStamp= DateTime.Now,
                Exception= null,
                Properties=""
            }, _dbProvider);
        }
    }
}