namespace FPT_Booking_BE.DTOs
{
    public class BookingConflictDto
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public int FacilityId { get; set; }
        public string FacilityName { get; set; } = string.Empty;
        public DateOnly BookingDate { get; set; }
        public int SlotId { get; set; }
        public string SlotName { get; set; } = string.Empty;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Purpose { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool CanOverride { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
