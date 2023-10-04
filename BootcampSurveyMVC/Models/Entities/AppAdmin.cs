using System;
using System.Collections.Generic;

namespace BootcampSurveyMVC.Models.Entities;

public partial class AppAdmin
{
    public string AdminId { get; set; } = null!;

    public string AdminName { get; set; } = null!;

    public string AdminMail { get; set; } = null!;

    public string AdminPass { get; set; } = null!;
}
