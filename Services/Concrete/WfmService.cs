using ServiceAbstractions;
using ServiceAbstractions.Interfaces;

namespace Services.Concrete
{
    public class WfmService : Service, IWfmService
    {
        protected WfmService(ILogger logger) : base(logger)
        {

        }

    }
}