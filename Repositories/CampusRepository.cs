using FPT_Booking_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FPT_Booking_BE.Repositories
{
    public class CampusRepository : ICampusRepository
    {
        private readonly FptFacilityBookingContext _context;

        public CampusRepository(FptFacilityBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Campus>> GetAllCampuses()
        {
            return await _context.Campuses.ToListAsync();
        }
    }
}