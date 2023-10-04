using BootcampSurveyMVC.Models.Entities;
using BootcampSurveyMVC.Models.Repositories;
using Microsoft.EntityFrameworkCore.Query;

namespace BootcampSurveyMVC.Models.Services
{
    public class FormRepository : IFormRepository
    {
        private readonly SurveyerContext _surveyContext;
        public List<QuestionPool> GetAllQuestions()
        {
            return _surveyContext.QuestionPools.ToList();
        }

        public List<QuestionPool> GetQuestionsByMaxAmount(int maxAmount)
        {
            throw new NotImplementedException();
        }

        public void SaveForm(Form form)
        {
            _surveyContext.Forms.Add(form);
            Console.WriteLine(form.ToString());
            //_surveyContext.SaveChanges();
        }
    }
}
