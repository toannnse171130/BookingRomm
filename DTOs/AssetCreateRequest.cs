namespace FPT_Booking_BE.DTOs
{
    public class AssetCreateRequest
    {
        public string AssetName { get; set; } = string.Empty;
        public string? AssetType { get; set; }
        public string? Description { get; set; }
    }
}
