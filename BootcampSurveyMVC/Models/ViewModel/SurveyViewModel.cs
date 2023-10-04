using BootcampSurveyMVC.Models.Entities;

namespace BootcampSurveyMVC.Models.ViewModel
{
    public class SurveyViewModel
    {
        public int SurveyId { get; set; }

        public int? GuestMakerId { get; set; }

        public byte? QuestionAmount { get; set; }

        public virtual Guest? GuestMaker { get; set; }

    }
}
