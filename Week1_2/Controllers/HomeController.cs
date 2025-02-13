using Microsoft.AspNetCore.Mvc;

namespace Week1_2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
