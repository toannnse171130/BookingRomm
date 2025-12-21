using System;
using System.Collections.Generic;

namespace FPT_Booking_BE.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public int RoleId { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Booking> BookingApprovers { get; set; } = new List<Booking>();

    public virtual ICollection<Booking> BookingUpdatedByNavigations { get; set; } = new List<Booking>();

    public virtual ICollection<Booking> BookingUsers { get; set; } = new List<Booking>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SecurityTask> SecurityTaskAssignedToUsers { get; set; } = new List<SecurityTask>();

    public virtual ICollection<SecurityTask> SecurityTaskCreatedByNavigations { get; set; } = new List<SecurityTask>();
}
