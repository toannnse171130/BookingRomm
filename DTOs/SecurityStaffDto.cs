namespace FPT_Booking_BE.DTOs
{
    public class SecurityStaffDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PendingTaskCount { get; set; }
        public bool IsActive { get; set; }
    }
}
