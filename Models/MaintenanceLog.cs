using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class MaintenanceLog
{
    public int LogId { get; set; }

    public int FacilityId { get; set; }

    public int ReportedBy { get; set; }

    public string IssueDescription { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? FixedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Facility Facility { get; set; } = null!;

    public virtual User ReportedByNavigation { get; set; } = null!;
}
