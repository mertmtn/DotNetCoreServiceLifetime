
using Microsoft.Extensions.Logging;
using System;

namespace ServiceLifeCycleWebApp.Services
{
    public class StudentService: ISingletonStudentService, ITransientStudentService, IScopedStudentService
    {
        private readonly ILogger<StudentService> _logger;

        public StudentService(ILogger<StudentService> logger)
        {
            _logger = logger;
            _logger.LogWarning("StudentService constructor'ına girildi.");
        }

        public Guid GetStudentId { get; } = Guid.NewGuid();
    }
}
