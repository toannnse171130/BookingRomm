namespace FPT_Booking_BE.DTOs
{
    public class RecurringConflictDto
    {
        public DateOnly BookingDate { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public BookingConflictDto? ConflictingBooking { get; set; }
        public bool HasConflict { get; set; }
        public bool CanProceed { get; set; }
        public string? AlternativeFacilityId { get; set; }
        public string? AlternativeFacilityName { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class RecurringConflictCheckResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int TotalDates { get; set; }
        public int ConflictCount { get; set; }
        public int CanProceedCount { get; set; }
        public int BlockedCount { get; set; }
        public List<RecurringConflictDto> Conflicts { get; set; } = new List<RecurringConflictDto>();
    }
}
