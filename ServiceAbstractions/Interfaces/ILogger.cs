using Domain.Enums.Infrastructure;
using System;

namespace ServiceAbstractions.Interfaces
{
    public interface ILogger
    {
        void LogEvent(string msg, LogSeverity severity);
        void LogError(string msg, LogSeverity severity = LogSeverity.ERROR);
        void LogException(Exception exception, string msg, LogSeverity severity = LogSeverity.ERROR);
    }
}