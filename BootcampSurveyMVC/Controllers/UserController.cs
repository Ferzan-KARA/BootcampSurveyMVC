using AutoMapper;
using BootcampSurveyMVC.Models;
using BootcampSurveyMVC.Models.DTOs;
using BootcampSurveyMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BootcampSurveyMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        SurveyerContext _surveyerContext = new SurveyerContext();

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateAppUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAppUser(UserSignUpDTO userSignUpDTO)
        {
            var appUser = _mapper.Map<AppUser>(userSignUpDTO);
            return View(appUser);
        }

        public IActionResult SignIn() 
        {
            return View();
        }

    }
}
