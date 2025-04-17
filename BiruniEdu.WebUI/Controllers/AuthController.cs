using Microsoft.AspNetCore.Mvc;

namespace BiruniEdu.WebUI.Controllers
{
    public class AuthController : Controller
    {
        AuthHelpers.AuthHelper authHelper;
        public AuthController(AuthHelpers.AuthHelper authHelper)
        {
            this.authHelper = authHelper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {

           var isAuthenticated =await authHelper.SignIn(email, password);

            if (isAuthenticated)
            {
              return  RedirectToAction("Index", "Home");
            }

            ViewBag.message = "User cannot be found! Check username and password!";
            ViewBag.email = email;
            ViewBag.password = password;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {

           await authHelper.SignOut();

           return RedirectToAction("Login");
        }
    }
}
