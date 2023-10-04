using BootcampSurveyMVC.Models.Entities;

namespace BootcampSurveyMVC.Models.DTOs
{
    public class UserSignUpDTO
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string UserMail { get; set; } = null!;

        public string Pass { get; set; } = null!;
    }
}
