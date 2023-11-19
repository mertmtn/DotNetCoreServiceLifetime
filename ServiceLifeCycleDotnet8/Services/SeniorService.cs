
using Microsoft.Extensions.Logging;
using System;

namespace ServiceLifeCycleWebApp.Services
{
    public class SeniorService: IStudentService
    {
        private readonly ILogger<SeniorService> _logger;

        public SeniorService(ILogger<SeniorService> logger)
        {
            _logger = logger;
            _logger.LogWarning("SeniorService constructor'ına girildi.");
        }

        public Guid GetStudentId { get; } = Guid.NewGuid();
    }
}
