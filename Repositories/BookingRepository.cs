using FPT_Booking_BE.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPT_Booking_BE.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly FptFacilityBookingContext _context;

        public BookingRepository(FptFacilityBookingContext context)
        {
            _context = context;
        }

        public async Task AddBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsBookingConflict(int facilityId, DateOnly bookingDate, int slotId)
        {
            return await _context.Bookings.AnyAsync(b =>
                b.FacilityId == facilityId &&
                b.BookingDate == bookingDate && 
                b.SlotId == slotId &&
                b.Status != "Rejected" &&
                b.Status != "Cancelled"
            );
        }

        public async Task<IEnumerable<Booking>> GetBookings(int? userId, string? status)
        {
            var query = _context.Bookings
                .Include(b => b.Facility)
                .Include(b => b.Slot)
                .Include(b => b.User)
                .AsQueryable();

            if (userId.HasValue) query = query.Where(b => b.UserId == userId);
            if (!string.IsNullOrEmpty(status)) query = query.Where(b => b.Status == status);

            return await query.OrderByDescending(b => b.BookingDate).ToListAsync();
        }

        public async Task<Booking?> GetBookingById(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
    }
}