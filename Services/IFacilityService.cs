using FPT_Booking_BE.Models;

namespace FPT_Booking_BE.Services
{
    public interface IFacilityService
    {
        Task<IEnumerable<Facility>> GetFacilities(int? campusId, int? typeId);
    }
}