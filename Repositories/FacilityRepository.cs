using FPT_Booking_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FPT_Booking_BE.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly FptFacilityBookingContext _context;

        public FacilityRepository(FptFacilityBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Facility>> GetFacilities(int? campusId, int? typeId)
        {
            var query = _context.Facilities
                .Include(f => f.Campus)      
                .Include(f => f.Type)

                .Include(f => f.FacilityAssets)
                    .ThenInclude(fa => fa.Asset) 
                                                

                .AsQueryable();

            if (campusId.HasValue)
            {
                query = query.Where(f => f.CampusId == campusId.Value);
            }

            if (typeId.HasValue)
            {
                query = query.Where(f => f.TypeId == typeId.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Facility> GetFacilityById(int id)
        {
            return await _context.Facilities.FindAsync(id);
        }
    }
}