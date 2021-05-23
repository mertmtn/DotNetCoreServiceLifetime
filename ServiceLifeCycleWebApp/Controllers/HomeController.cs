using Microsoft.AspNetCore.Mvc; 
using ServiceLifeCycleWebApp.Services; 

namespace ServiceLifeCycleWebApp.Controllers
{
    public class HomeController : Controller
    {
        //Singleton için bu kodu aç diğerlerini kapat

        //private readonly ISingletonStudentService _singletonStudentService;
        //public HomeController(ISingletonStudentService singletonStudentService)
        //{
        //    _singletonStudentService = singletonStudentService;
        //}


        //Scoped için bu kodu aç diğerlerini kapat

        //private readonly IScopedStudentService _scopedStudentService;
        //public HomeController(IScopedStudentService scopedStudentService)
        //{
        //    _scopedStudentService = scopedStudentService;
        //}

        //Transient için bu kodu aç diğerlerini kapat

        private readonly ITransientStudentService _transientStudentService;

        public HomeController(ITransientStudentService transientStudentService)
        {
            _transientStudentService = transientStudentService;
        }

        public IActionResult Index([FromServices] ITransientStudentService transientStudentService)
        {
            //Transient için bu kodu aç diğerlerini kapat
            ViewBag.TransientId1 = _transientStudentService.GetStudentId.ToString();
            ViewBag.TransientId2 = transientStudentService.GetStudentId.ToString();

            //Singleton için bu kodu aç diğerlerini kapat
            //ViewBag.SingletonId1 = _singletonStudentService.GetStudentId.ToString();
            //ViewBag.SingletonId2 = singletonStudentService.GetStudentId.ToString();

            //Scoped için bu kodu aç diğerlerini kapat
            //ViewBag.ScopedId1 = _scopedStudentService.GetStudentId.ToString();
            //ViewBag.ScopedId2 = scopedStudentService.GetStudentId.ToString();

            return View();
        }

       
    }
}
