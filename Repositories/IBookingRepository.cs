using FPT_Booking_BE.Models;

namespace FPT_Booking_BE.Repositories
{
    public interface IBookingRepository
    {
        Task<bool> IsBookingConflict(int facilityId, DateOnly bookingDate, int slotId);
        Task AddBooking(Booking booking);
        Task<IEnumerable<Booking>> GetBookings(int? userId, string? status);
        Task<Booking?> GetBookingById(int id);
        Task UpdateBooking(Booking booking);
    }
}