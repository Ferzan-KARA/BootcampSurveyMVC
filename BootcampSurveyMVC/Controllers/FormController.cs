using AutoMapper;
using BootcampSurveyMVC.Models;
using BootcampSurveyMVC.Models.DTOs;
using BootcampSurveyMVC.Models.Entities;
using BootcampSurveyMVC.Models.Repositories;
using BootcampSurveyMVC.Models.ViewModel;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BootcampSurveyMVC.Controllers
{
    public class FormController : Controller
    {
        private readonly IMapper _mapper;
        //private readonly IFormRepository _formRepository;
        SurveyerContext _surveyerContext = new SurveyerContext();

        public FormController(IMapper mapper)
        {
            _mapper = mapper;
           // _formRepository = formRepository;
        }

        [HttpGet]
        public IActionResult CreateSurvey(int guestId)
        {

            var guest = _surveyerContext.Guests.FirstOrDefault(g => g.GuestId == guestId);
            if (guest == null) 
            {
                return NotFound();
            }

            //int questionAmount = 4;
            ViewBag.GuestName = guest.GuestName;

            var guestMadeSurvey = _mapper.Map<Survey>(guest);
            //guestMadeSurvey.QuestionAmount = questionAmount;

            return View(guestMadeSurvey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSurvey(Survey survey)
        {
            if (ModelState.IsValid)
            {
                survey.QuestionAmount = 4;
                _surveyerContext.Add(survey);
                await _surveyerContext.SaveChangesAsync();
                return RedirectToAction("CreateForm"/*, new { questionAmount = survey.QuestionAmount}*/);
            }

            return View();
        }



        [HttpGet]
        public IActionResult CreateForm(int questionAmount)
        {

            var questions = _surveyerContext.QuestionPools.ToList();

            var questionViewModels = _mapper.Map<List<QuestionViewModel>>(questions);

            ViewBag.Questions = questionViewModels;

            return View();
        }

        [HttpPost]
        public IActionResult CreateForm(CreateFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var forms = viewModel.Questions.SelectMany(q =>
                    q.Answers.Select(a =>
                    {
                        var form = _mapper.Map<Form>(a);
                        form.SurveyId = null; 
                        form.AnswerLocation = a.AnswerLocation; 
                        return form;
                    })
                ).ToList();

                foreach (var form in forms)
                {
                    _surveyerContext.Forms.Add(form);
                    _surveyerContext.SaveChanges();

                }

                return RedirectToAction("Main", "Home");
            }

            return View(viewModel);
        }
        
    }
}
