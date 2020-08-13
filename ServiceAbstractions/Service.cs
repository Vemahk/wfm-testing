using System;
using ServiceAbstractions.Interfaces;

namespace ServiceAbstractions
{
    public class Service
    {
        private readonly ILogger _logger;

        protected Service(ILogger logger)
        {

        }

        protected void LogException(Exception e, string message)
        {
            _logger.LogException(e, message);
        }
    }
}