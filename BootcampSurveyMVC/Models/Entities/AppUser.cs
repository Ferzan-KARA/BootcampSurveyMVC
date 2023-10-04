using System;
using System.Collections.Generic;

namespace BootcampSurveyMVC.Models.Entities;

public partial class AppUser
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserMail { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();

    public virtual ICollection<UserMadeQuestion> UserMadeQuestions { get; set; } = new List<UserMadeQuestion>();
}
