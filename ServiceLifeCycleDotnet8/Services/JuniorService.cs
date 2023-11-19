
using Microsoft.Extensions.Logging;
using System;

namespace ServiceLifeCycleWebApp.Services
{
    public class JuniorService: IStudentService
    {
        private readonly ILogger<JuniorService> _logger;

        public JuniorService(ILogger<JuniorService> logger)
        {
            _logger = logger;
            _logger.LogWarning("JuniorService constructor'ına girildi.");
        }

        public Guid GetStudentId { get; } = Guid.NewGuid();
    }
}
