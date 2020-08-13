using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domain.Enums.Infrastructure;
using Repository.Abstractions;

namespace Repository.Concrete
{
    public class FileLoggingRepository : ILoggingRepository
    {
        private const string LoggingDirectoryPath = ".\\logs";
        private const string MainLogFileName = "complete.log";

        private readonly Dictionary<LogSeverity, InfoStreamWrapper> Files = new Dictionary<LogSeverity, InfoStreamWrapper>();
        private readonly InfoStreamWrapper MainLogFile;

        private bool _disposed;

        public FileLoggingRepository()
        {
            var dirInfo = new DirectoryInfo(LoggingDirectoryPath);
            dirInfo.Create();

            foreach (var val in Enum.GetValues(typeof(LogSeverity)))
            {
                var enumVal = (LogSeverity)val;
                var filePath = Path.Combine(dirInfo.FullName, $"{enumVal.ToString().ToLowerInvariant()}.log");

                var fileInfo = new FileInfo(filePath);
                var stream = fileInfo.Open(FileMode.Append, FileAccess.Write);

                var wrapper = new InfoStreamWrapper(fileInfo, stream);
                Files.Add(enumVal, wrapper);
            }

            var mainFilePath = Path.Combine(dirInfo.FullName, MainLogFileName);
            var mainFileInfo = new FileInfo(mainFilePath);
            var mainFileStream = mainFileInfo.Open(FileMode.Append, FileAccess.Write);
            MainLogFile = new InfoStreamWrapper(mainFileInfo, mainFileStream);
        }

        public void LogEvent(string message, LogSeverity severity)
        {
            CheckDisposed();

            var bytes = Encoding.ASCII.GetBytes($"[{DateTime.UtcNow:T}][{severity}] {message}\r\n");
            Files[severity].Stream.WriteAsync(bytes, 0, bytes.Length);
            MainLogFile.Stream.WriteAsync(bytes, 0, bytes.Length);
        }

        public void LogException(Exception e, string message, LogSeverity severity)
        {
            CheckDisposed();

            var bytes = Encoding.ASCII.GetBytes($"An exception has been logged: {e.Message}\r\n[{DateTime.UtcNow:T}][{severity}] {message}\r\n");
            Files[severity].Stream.WriteAsync(bytes, 0, bytes.Length);
            MainLogFile.Stream.WriteAsync(bytes, 0, bytes.Length);
        }

        public void Dispose()
        {
            if(_disposed)
                throw new ApplicationException("Attempted disposing of ILoggingRepository FileLoggingRepository twice.");
            _disposed = true;

            foreach (var kv in Files)
            {
                kv.Value.Stream.Dispose();
            }
            MainLogFile.Stream.Dispose();
        }

        private void CheckDisposed()
        {
            if (_disposed)
                throw new ApplicationException("Cannot continue usage of FileLoggingRepository. Repository has been disposed.");
        }

        private class InfoStreamWrapper
        {
            public InfoStreamWrapper(FileInfo info, FileStream stream)
            {
                Info = info;
                Stream = stream;
            }

            public FileInfo Info { get; }
            public FileStream Stream { get; }
        }
    }
}