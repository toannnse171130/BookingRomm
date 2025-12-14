using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class FacilityAsset
{
    public int Id { get; set; }

    public int FacilityId { get; set; }

    public int AssetId { get; set; }

    public int? Quantity { get; set; }

    public string? Condition { get; set; }

    public virtual Asset Asset { get; set; } = null!;

    public virtual Facility Facility { get; set; } = null!;
}
