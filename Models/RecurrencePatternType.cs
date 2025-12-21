using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class RecurrencePatternType
{
    public int PatternTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<RecurrencePattern> RecurrencePatterns { get; set; } = new List<RecurrencePattern>();
}
