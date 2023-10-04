using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BootcampSurveyMVC.Models.ViewModel;

namespace BootcampSurveyMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Main", viewModel);
                }

                string encryptedPwd = viewModel.Password;
                var userPassword = Convert.ToString(ConfigurationManager.AppSettings["config:Password"]);
                var userName = Convert.ToString(ConfigurationManager.AppSettings["config:Username"]);
                if (encryptedPwd.Equals(userPassword) && viewModel.Email.Equals(userName)) 
                {
                    var roles = new string[] { "SuperAdmin", "Admin" };
                    var jwtSecurityToken = Authentication.CreateJwtSecurityToken(userName, roles.ToList());
                    return RedirectToAction("Main","Home",new {token = jwtSecurityToken});
                }

                ModelState.AddModelError("", "Hatalı Bilgiler");
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Hatalı Bilgiler");
            }

            return View("Main", viewModel);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult SignOut() 
        {
            return View();
        }
    }
}
