using System;
using Domain.Enums.Infrastructure;
using Repository.Abstractions;

namespace Repository.Concrete
{
    public class FileLoggingRepository : ILoggingRepository
    {
        public void LogEvent(string message, LogSeverity severity)
        {
            
        }

        public void LogException(Exception e, string message, LogSeverity severity)
        {
            throw new NotImplementedException();
        }
    }
}