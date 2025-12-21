using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class RecurrencePattern
{
    public int RecurrencePatternId { get; set; }

    public string RecurrenceGroupId { get; set; } = null!;

    public int PatternTypeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? DaysOfWeek { get; set; } // Comma-separated: "Monday,Wednesday,Friday"

    public int? Interval { get; set; } // For custom intervals (e.g., every 2 weeks)

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual RecurrencePatternType PatternType { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
