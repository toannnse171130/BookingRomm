namespace FPT_Booking_BE.DTOs
{
    public class BookingHistoryDto
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateOnly BookingDate { get; set; } 
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string FacilityName { get; set; } = string.Empty;
        public string SlotName { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}