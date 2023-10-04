using BootcampSurveyMVC.Models.Entities;

namespace BootcampSurveyMVC.Models.DTOs
{
    public class GuestSurveyDTO
    {
        public int SurveyId { get; set; }

        public int? GuestMakerId { get; set; }

        public byte? QuestionAmount { get; set; }

        public virtual Guest? GuestMaker { get; set; }


    }
}
