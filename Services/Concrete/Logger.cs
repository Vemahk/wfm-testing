using System;
using System.Runtime.InteropServices;
using Domain.Enums.Infrastructure;
using Repository.Abstractions;
using ServiceAbstractions.Interfaces;

namespace Services.Concrete
{
    public class Logger : ILogger
    {
        private readonly ILoggingRepository _loggingRepository;

        public Logger(string appName, ILoggingRepository loggingRepository)
        {
            _loggingRepository = loggingRepository;
        }

        public void LogEvent(string msg, LogSeverity severity)
        {
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