using BootcampSurveyMVC.Models.Entities;

namespace BootcampSurveyMVC.Models.Repositories
{
    public interface IFormRepository
    {
        List<QuestionPool> GetAllQuestions();
        List<QuestionPool> GetQuestionsByMaxAmount(int maxAmount);
        void SaveForm(Form form);
    }
}
