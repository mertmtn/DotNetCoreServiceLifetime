# DotNetCoreServiceLifetime

This repo consists of two repositories whose different are .NET Versions

### ServiceLifeCycleWebApp
This an Net Core Web Application that includes service lifetimes representation using services. 

There are three lifetimes

- Singleton
- Scoped
- Transient

#### Program.cs
```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IStudentService, JuniorService>();
builder.Services.AddTransient<IStudentService, SeniorService>();
builder.Services.AddTransient<IStudentService, SophomoreService>();
```
#### Controller Implementation #1
```csharp
    public class HomeController(IEnumerable<IStudentService> services) : Controller
    {
        private readonly IEnumerable<IStudentService> _services = services;
        public IActionResult Index([FromServices] IEnumerable<IStudentService> serviceList)
        {
            ViewBag.TransientId1 = serviceList.Where(x => x is SeniorService).FirstOrDefault().GetStudentId;
            ViewBag.TransientId2 = serviceList.Where(x => x is SeniorService).FirstOrDefault().GetStudentId;
            return View();
        }
    }
```

#### Controller Implementation #2
```csharp
    public class HomeController(IStudentService studentService) : Controller
    {
        private readonly IStudentService _studentService = studentService;

        public IActionResult Index([FromServices] IStudentService studentService)
        {
            ViewBag.TransientId1 = _studentService.GetStudentId;
            ViewBag.TransientId2 = studentService.GetStudentId;
            return View();
        }
    }
```
### ServiceLifeCycleDotnet8
Implementation of Keyed Services which comes from .NET 8 on above project

#### Program.cs

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedTransient<IStudentService, JuniorService>(nameof(StudentType.Junior));
builder.Services.AddKeyedTransient<IStudentService, SeniorService>(nameof(StudentType.Senior));
builder.Services.AddKeyedTransient<IStudentService, SpecialStudentService>(nameof(StudentType.Special));
builder.Services.AddKeyedTransient<IStudentService, SophomoreService>(nameof(StudentType.Sophomore));
```

#### Controller Implementation 
```csharp
    public class StudentController(IServiceProvider serviceProvider) : Controller
    { 
        public IActionResult IndexServiceProvider()
        {
            var freshmanStudent = serviceProvider.GetKeyedService<IStudentService>(nameof(StudentType.Freshman));
            var seniorStudent = serviceProvider.GetRequiredKeyedService<IStudentService>(nameof(StudentType.Senior));


            ViewBag.Service1 = seniorStudent.GetStudentId.ToString();
            ViewBag.Service2 = freshmanStudent?.GetStudentId.ToString();
            return View();
        }

        public IActionResult IndexFromKeyed([FromKeyedServices(nameof(StudentType.Special))] IStudentService _specialStudentService,
                                            [FromKeyedServices(nameof(StudentType.Sophomore))] IStudentService _sophomoreStudentService)
        {
 
            ViewBag.Service1 = _specialStudentService.GetStudentId.ToString();
            ViewBag.Service2 = _sophomoreStudentService.GetStudentId.ToString();

            return View();
        }
    }
```

Keywords
- FromKeyedServices
- GetKeyedService
- GetRequiredKeyedService
