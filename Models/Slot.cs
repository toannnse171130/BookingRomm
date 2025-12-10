using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class Slot
{
    public int SlotId { get; set; }

    public string SlotName { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
