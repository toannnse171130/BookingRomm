using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class Campus
{
    public int CampusId { get; set; }

    public string CampusName { get; set; } = null!;

    public string? Address { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();
}
