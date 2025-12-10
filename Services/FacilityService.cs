using FPT_Booking_BE.Models;
using FPT_Booking_BE.Repositories;

namespace FPT_Booking_BE.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IFacilityRepository _repo;

        public FacilityService(IFacilityRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Facility>> GetFacilities(int? campusId, int? typeId)
        {
            return await _repo.GetFacilities(campusId, typeId);
        }
    }
}