using System;
using System.Collections.Generic;

namespace BootcampSurveyMVC.Models.Entities;

public partial class Survey
{
    public int SurveyId { get; set; }

    public int? GuestMakerId { get; set; }

    public int? UserMakerId { get; set; }

    public int? QuestionAmount { get; set; }

    public virtual Guest? GuestMaker { get; set; }

    public virtual AppUser? UserMaker { get; set; }
}
