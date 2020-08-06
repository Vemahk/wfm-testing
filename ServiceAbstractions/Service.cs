using ServiceAbstractions.Interfaces;

namespace ServiceAbstractions
{
    public class Service
    {
        private readonly ILogger _logger;

        protected Service(ILogger logger)
        {

        }
    }
}