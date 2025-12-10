using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class Facility
{
    public int FacilityId { get; set; }

    public string FacilityName { get; set; } = null!;

    public int CampusId { get; set; }

    public int TypeId { get; set; }

    public int Capacity { get; set; }

    public string? Status { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Campus Campus { get; set; } = null!;

    public virtual ICollection<FacilityAsset> FacilityAssets { get; set; } = new List<FacilityAsset>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual FacilityType Type { get; set; } = null!;
}
