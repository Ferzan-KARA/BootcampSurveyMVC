using BootcampSurveyMVC.Models.Entities;
using Microsoft.VisualBasic;

namespace BootcampSurveyMVC.Models.Repositories
{
    public interface ISurveyRepository
    {
        List<Survey> GetAllSurvey();
    }
}
