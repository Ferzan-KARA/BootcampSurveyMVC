using System;
using System.Collections.Generic;

namespace BootcampSurveyMVC.Models.Entities;

public partial class UserMadeQuestion
{
    public int UsrQuestId { get; set; }

    public string UsrQuestText { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual AppUser? User { get; set; }
}
