using System;
using System.Collections.Generic;

namespace BootcampSurveyMVC.Models.Entities;

public partial class Scoreboard
{
    public int SurveyId { get; set; }

    public int? UserId { get; set; }

    public int? GuestId { get; set; }

    public int CorrectAmount { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual Survey Survey { get; set; } = null!;

    public virtual AppUser? User { get; set; }
}
