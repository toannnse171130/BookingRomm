using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class FacilityType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public bool? RequiresApproval { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();
}
