using lab8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("counter") == null)
            {
                HttpContext.Session.SetInt32("counter", 0);
            }

            int? counter = HttpContext.Session.GetInt32("counter");
            ViewBag.Counter = counter;
            return View();
        }

        public IActionResult Increment()
        {
            int? counter = HttpContext.Session.GetInt32("counter");
            if (counter == null)
            {
                counter = 0;
            }
            counter++;
            HttpContext.Session.SetInt32("counter", counter.Value);
            return RedirectToAction("Index");
        }
    
       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
