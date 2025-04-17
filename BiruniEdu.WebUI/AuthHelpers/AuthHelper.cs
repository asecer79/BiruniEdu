using BiruniEdu.Business.Abstract;
using BiruniEdu.Entities.Concrete.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BiruniEdu.WebUI.AuthHelpers
{
    public class AuthHelper
    {
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;
        IUserService _userService;

        public AuthHelper(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        private ICollection<Claim> GetUserClaims(User user)
        {

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.FirstName + " " + user.LastName));



            var userClaims = _userService.GetUserOperationClaims(user.Id);

            if (userClaims!=null)
            {
                foreach (var userClaim in userClaims)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userClaim.Name));

                }
            }
           

            return claims;
        }

        public async Task<bool> SignIn(string email, string password)
        {
            var userExists = _userService.CheckUserToLogin(email, password);

            if (!userExists)
            {
                return false;
            }
            var user = _userService.GetUserByEmail(email, password);

            var claims = GetUserClaims(user);

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return true;
        }

        public async Task<bool> SignOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();

            return true;
        }
    }
}
