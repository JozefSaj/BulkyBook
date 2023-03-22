using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // action (/home/index) it is placed in Views/Home/Index.cshtml
        //IActionResult(ViewResult can be used to be more explicit) is a parrent class for many derived classes
        //IActionResult return type is appropriate when multiple ActionResult return types are possible in an action.
        public IActionResult Index()
        {
            // right click and go to the view
            return View();
        }

        // action(/home/privacy) it is placed in Views/Home/Privacy.cshtml
        public IActionResult Privacy()
        {
            // right click and go to the view
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}