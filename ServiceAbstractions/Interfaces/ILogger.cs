using Domain.Enums.Infrastructure;
using System;

namespace ServiceAbstractions.Interfaces
{
    public interface ILogger
    {
        void Log(string msg, LogSeverity severity);
        void LogTrace(string msg);
        void LogDebug(string msg);
        void LogEvent(string msg);
        void LogWarning(string msg);
        void LogError(string msg, bool fatal = false);
        void LogException(Exception exception, string msg, bool fatal = false);
    }
}