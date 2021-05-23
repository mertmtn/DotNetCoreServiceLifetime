using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLifeCycleWebApp.Services
{
    public interface IStudentService
    {
        Guid GetStudentId { get; }
    }

    public interface ISingletonStudentService : IStudentService
    {
    }

    public interface IScopedStudentService : IStudentService
    {
    }

    public interface ITransientStudentService : IStudentService
    {
    }
}
