using Microsoft.AspNetCore.Mvc;

namespace Week4.Controllers
{

    //multiple route

    [Route("security")]
    public class AdminController : Controller
    {

        [HttpGet("p1/{id:int?}")]
        [HttpGet("p2")]
        [HttpGet("p3")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
