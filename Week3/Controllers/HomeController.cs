using Microsoft.AspNetCore.Mvc;

namespace Week3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
