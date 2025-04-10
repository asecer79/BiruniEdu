using BiruniEdu.WebUI.DataAccess.Dal.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BiruniEdu.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private IUserDal _userDal;

        public AuthController(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var userExists = _userDal.CheckUserToLogin(email, password);

            ViewBag.message = null;

            if (userExists)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.message = "User cannot be found! Check username and password!";
            ViewBag.email = email;
            ViewBag.password = password;

            return View();
        }
    }
}
