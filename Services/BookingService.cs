using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FPT_Booking_BE.DTOs;
using FPT_Booking_BE.Models;
using FPT_Booking_BE.Repositories;

namespace FPT_Booking_BE.Services
{
    public class BookingService : IBookingService
    {
        private readonly FptFacilityBookingContext _context;
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo, FptFacilityBookingContext context)
        {
            _bookingRepo = bookingRepo;
            _context = context;
        }

        public async Task<string> CreateBooking(int userId, BookingCreateRequest request)
        {
            bool isConflict = await _bookingRepo.IsBookingConflict(
                request.FacilityId, request.BookingDate, request.SlotId);

            if (isConflict) return "Phòng này đã có người đặt trong Slot này rồi!";

            var newBooking = new Booking
            {
                UserId = userId,
                FacilityId = request.FacilityId,

                BookingDate = request.BookingDate,

                SlotId = request.SlotId,
                Purpose = request.Purpose,
                Status = "Pending",
                BookingType = "Individual",
                PriorityLevel = "Low",
                CreatedAt = DateTime.Now
            };

            await _bookingRepo.AddBooking(newBooking);
            return "Success";
        }

        public async Task<List<BookingHistoryDto>> GetHistory(int userId)
        {
            var rawData = await _context.Bookings
                .Where(b => b.UserId == userId)
                .Select(b => new
                {
                    b.BookingId,
                    b.UserId,
                    b.BookingDate,
                    b.Status,

                    FacilityName = b.Facility.FacilityName,
                    SlotName = b.Slot.SlotName,
                    StartTime = b.Slot.StartTime,
                    EndTime = b.Slot.EndTime
                })
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();

            var historyDtos = rawData.Select(b => new BookingHistoryDto
            {
                Id = b.BookingId,
                UserId = b.UserId,

                BookingDate = b.BookingDate,

                Status = b.Status,
                FacilityName = b.FacilityName,
                SlotName = b.SlotName,
                
                StartTime = b.StartTime,
                EndTime = b.EndTime

            }).ToList();

            return historyDtos;
        }

        public async Task<bool> UpdateStatus(int bookingId, string status)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null) return false;

            booking.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}