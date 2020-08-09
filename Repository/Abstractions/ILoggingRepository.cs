using System;
using Domain.Enums.Infrastructure;

namespace Repository.Abstractions
{
    public interface ILoggingRepository
    {
        void LogEvent(string message, LogSeverity severity);
        void LogException(Exception e, string message, LogSeverity severity);
    }
}