
using Microsoft.Extensions.Logging;
using System;

namespace ServiceLifeCycleWebApp.Services
{
    public class SophomoreService: IStudentService
    {
        private readonly ILogger<SophomoreService> _logger;

        public SophomoreService(ILogger<SophomoreService> logger)
        {
            _logger = logger;
            _logger.LogWarning("SophomoreService constructor'ına girildi.");
        }

        public Guid GetStudentId { get; } = Guid.NewGuid();
    }
}

