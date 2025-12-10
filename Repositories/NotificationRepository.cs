using FPT_Booking_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FPT_Booking_BE.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly FptFacilityBookingContext _context;
        public NotificationRepository(FptFacilityBookingContext context) { _context = context; }

        public async Task AddNotification(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notification>> GetMyNotifications(int userId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task MarkAsRead(int notificationId)
        {
            var noti = await _context.Notifications.FindAsync(notificationId);
            if (noti != null)
            {
                noti.IsRead = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}