using Microsoft.AspNetCore.Mvc;
using ServiceLifeCycleWebApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLifeCycleWebApp.Controllers
{
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

    //public class HomeController(IStudentService transientStudentService) : Controller
    //{
    //    private readonly IStudentService _transientStudentService = transientStudentService;

    //    public IActionResult Index([FromServices] IStudentService transientStudentService)
    //    {
    //        ViewBag.TransientId1 = _transientStudentService.GetStudentId;
    //        ViewBag.TransientId2 = transientStudentService.GetStudentId;
    //        return View();
    //    }
    //}
}


