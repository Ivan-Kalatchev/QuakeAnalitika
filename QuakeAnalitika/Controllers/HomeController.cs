using MakeupTok.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace QuakeAnalitika.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }

    }
}
