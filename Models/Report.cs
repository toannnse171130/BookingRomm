using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public int UserId { get; set; }

    public int? FacilityId { get; set; }

    public int? BookingId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? ReportType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Facility? Facility { get; set; }

    public virtual User User { get; set; } = null!;
}
