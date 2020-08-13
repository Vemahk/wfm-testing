using System;
using Domain.Enums.Infrastructure;
using Repository.Abstractions;

namespace Repository.Concrete
{
    public class FileLoggingRepository : ILoggingRepository
    {
        public void LogEvent(string message, LogSeverity severity)
        {
            Console.WriteLine($"[{DateTime.UtcNow:T}][{severity}] {message}");
        }

        public void LogException(Exception e, string message, LogSeverity severity)
        {
            Console.WriteLine($"An exception has been logged: {e.Message}");
            Console.WriteLine($"[{DateTime.UtcNow:T}][{severity}] {message}");
        }
    }
}