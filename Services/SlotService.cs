using FPT_Booking_BE.DTOs;
using FPT_Booking_BE.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPT_Booking_BE.Services
{
    public class SlotService : ISlotService
    {
        private readonly FptFacilityBookingContext _context;

        public SlotService(FptFacilityBookingContext context)
        {
            _context = context;
        }

       public async Task<List<SlotDto>> GetAllSlots(int? facilityId, DateOnly? date)
        {
            var query = _context.Slots.AsQueryable();

            if (facilityId.HasValue && date.HasValue)
            {
                query = query.Where(s => !_context.Bookings.Any(b =>
                    b.SlotId == s.SlotId &&
                    b.FacilityId == facilityId &&
                    b.BookingDate == date &&
                    b.Status == "Approved" 
                ));
            }

            return await query.Select(s => new SlotDto
            {
                SlotId = s.SlotId,
                SlotName = s.SlotName,
                StartTime = s.StartTime,
                EndTime = s.EndTime
            }).ToListAsync();
        }
    }
}