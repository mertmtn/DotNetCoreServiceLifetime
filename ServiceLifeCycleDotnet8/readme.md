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
