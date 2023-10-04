namespace BootcampSurveyMVC.Models.ViewModel
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}
