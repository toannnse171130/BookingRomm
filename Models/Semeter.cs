using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class Semester
{
    public int SemesterId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
    public bool IsActive { get; set; }
}