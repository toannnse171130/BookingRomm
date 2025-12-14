using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class Asset
{
    public int AssetId { get; set; }

    public string AssetName { get; set; } = null!;

    public string? AssetType { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<FacilityAsset> FacilityAssets { get; set; } = new List<FacilityAsset>();
}
