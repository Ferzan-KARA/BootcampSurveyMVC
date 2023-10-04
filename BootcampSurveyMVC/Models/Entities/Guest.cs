using System;
using System.Collections.Generic;

namespace BootcampSurveyMVC.Models.Entities;

public partial class Guest
{
    public int GuestId { get; set; }

    public string? GuestName { get; set; }

    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
