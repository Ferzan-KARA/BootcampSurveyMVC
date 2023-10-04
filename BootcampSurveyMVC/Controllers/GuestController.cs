using BootcampSurveyMVC.Models;
using BootcampSurveyMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BootcampSurveyMVC.Controllers
{
    public class GuestController : Controller
    {
        SurveyerContext _surveyerContext = new SurveyerContext();


        [HttpGet]
        public IActionResult CreateGuest()
        {
            List<SelectListItem> guests = _surveyerContext.Guests.Select(g => new SelectListItem()
            {
                Text = $"{g.GuestName}",
                Value = g.GuestId.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult CreateGuest(Guest guest)
        {
            _surveyerContext.Guests.Add(guest);
            int result = _surveyerContext.SaveChanges();
            if (result == 0)
            {
                ViewBag.Message = "Hatalı İsim";
                return View();
            }
            else
            {
                return RedirectToAction("CreateSurvey", "Form", new { guestId = guest.GuestId });
            }

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
