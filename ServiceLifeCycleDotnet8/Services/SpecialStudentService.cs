using Microsoft.Extensions.Logging; 
using System;

namespace ServiceLifeCycleWebApp.Services
{
    internal class SpecialStudentService : IStudentService
    {
        private readonly ILogger<SpecialStudentService> _logger;

        public SpecialStudentService(ILogger<SpecialStudentService> logger)
        {
            _logger = logger;
            _logger.LogWarning("SpecialStudentService constructor'ına girildi.");
        }

        public Guid GetStudentId { get; } = Guid.NewGuid();
    }
}