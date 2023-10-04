using System;
using System.Collections.Generic;

namespace BootcampSurveyMVC.Models.Entities;

public partial class QuestionPool
{
    public int QuestionId { get; set; }

    public string QuestionText { get; set; } = null!;
}
