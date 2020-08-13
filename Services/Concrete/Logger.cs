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

        public void LogEvent(string msg, LogSeverity severity)
        {
            Console.WriteLine($"Logging event for {_appName}");
            _loggingRepository.LogEvent(msg, severity);
        }

        public void LogError(string msg, LogSeverity severity = LogSeverity.ERROR)
        {
            _loggingRepository.LogEvent(msg, severity);
        }

        public void LogException(Exception exception, string msg, LogSeverity severity = LogSeverity.ERROR)
        {
            _loggingRepository.LogException(exception, msg, severity);
        }
    }
}