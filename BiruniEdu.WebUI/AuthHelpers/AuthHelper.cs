using System.Security.Claims;
using BiruniEdu.WebUI.DataAccess.Dal.Abstract;
using BiruniEdu.WebUI.Entities.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BiruniEdu.WebUI.AuthHelpers
{
    public class AuthHelper
    {
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;
        IUserDal _userDal;

        public AuthHelper(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUserDal userDal)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _userDal = userDal;
        }

        private ICollection<Claim> GetUserClaims(User user)
        {

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.FirstName + " " + user.LastName));



            var userClaims = _userDal.GetUserOperationClaims(user.Id);

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
            var userExists = _userDal.CheckUserToLogin(email, password);

            if (!userExists)
            {
                return false;
            }
            var user = _userDal.GetUserByEmail(email, password);

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
