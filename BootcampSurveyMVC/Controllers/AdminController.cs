using Microsoft.AspNetCore.Mvc;

namespace BootcampSurveyMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
