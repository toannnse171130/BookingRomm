namespace FPT_Booking_BE.DTOs
{
    public class AssetDto
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public string? AssetType { get; set; }
        public string? Description { get; set; }
        public int AssignedToFacilitiesCount { get; set; }
    }
}
