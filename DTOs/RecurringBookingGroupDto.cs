namespace FPT_Booking_BE.DTOs
{
    public class RecurringBookingGroupDto
    {
        public string RecurrenceGroupId { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int FacilityId { get; set; }
        public string FacilityName { get; set; } = string.Empty;
        public int SlotId { get; set; }
        public string SlotName { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int TotalBookings { get; set; }
        public int PendingCount { get; set; }
        public int ApprovedCount { get; set; }
        public int RejectedCount { get; set; }
        public int CancelledCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
