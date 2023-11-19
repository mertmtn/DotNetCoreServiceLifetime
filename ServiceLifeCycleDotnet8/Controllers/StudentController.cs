using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ServiceLifeCycleWebApp.Models.Enums;
using ServiceLifeCycleWebApp.Services;
using System;

namespace ServiceLifeCycleWebApp.Controllers
{
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
}
