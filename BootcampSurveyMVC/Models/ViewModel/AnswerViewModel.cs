namespace BootcampSurveyMVC.Models.ViewModel
{
    public class AnswerViewModel
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; } = false;
        public short AnswerLocation { get; set; }
    }
}
