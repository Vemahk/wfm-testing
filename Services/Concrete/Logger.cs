using System;
using Domain.Enums.Infrastructure;
using Repository.Abstractions;
using ServiceAbstractions.Interfaces;

namespace Services.Concrete
{
    public class Logger : ILogger
    {
        private readonly string _appName;
        private readonly ILoggingRepository _loggingRepository;

        public Logger(string appName, ILoggingRepository loggingRepository)
        {
            _appName = appName;
            _loggingRepository = loggingRepository;
        }

        public void Log(string msg, LogSeverity severity)
        {
            _loggingRepository.LogEvent(msg, severity);
        }

        public void LogTrace(string msg)
        {
            Log(msg, LogSeverity.TRACE);
        }

        public void LogDebug(string msg)
        {
            Log(msg, LogSeverity.DEBUG);
        }

        public void LogEvent(string msg)
        {
            Log(msg, LogSeverity.EVENT);
        }

        public void LogWarning(string msg)
        {
            Log(msg, LogSeverity.WARNING);
        }

        public void LogError(string msg, bool fatal = false)
        {
            Log(msg, fatal ? LogSeverity.FATAL : LogSeverity.ERROR);
        }

        public void LogException(Exception exception, string msg, bool fatal = false)
        {
            var severity = fatal ? LogSeverity.FATAL : LogSeverity.ERROR;
            _loggingRepository.LogException(exception, msg, severity);
        }
    }
}