using System;
using System.Collections.Generic;

namespace BootcampSurveyMVC.Models.Entities;

public partial class Form
{
    public int? SurveyId { get; set; }

    public int? QuestionId { get; set; }

    public int? UsrQid { get; set; }

    public short AnswerLocation { get; set; }

    public string Answer { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public virtual QuestionPool? Question { get; set; }

    public virtual Survey? Survey { get; set; }

    public virtual UserMadeQuestion? UsrQ { get; set; }
}
