
using Microsoft.Extensions.Logging;
using System;

namespace ServiceLifeCycleWebApp.Services
{
    public class FreshmanService: IStudentService
    {
        private readonly ILogger<FreshmanService> _logger;

        public FreshmanService(ILogger<FreshmanService> logger)
        {
            _logger = logger;
            _logger.LogWarning("FreshmanService constructor'ına girildi.");
        }

        public Guid GetStudentId { get; } = Guid.NewGuid();
    }
}
