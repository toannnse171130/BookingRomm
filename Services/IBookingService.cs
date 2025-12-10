using FPT_Booking_BE.DTOs;

namespace FPT_Booking_BE.Services
{
    public interface IBookingService
    {
        Task<string> CreateBooking(int userId, BookingCreateRequest request);

        Task<List<BookingHistoryDto>> GetHistory(int userId);

        Task<bool> UpdateStatus(int bookingId, string status);
    }
}