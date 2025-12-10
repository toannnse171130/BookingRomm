using FPT_Booking_BE.Models;
using FPT_Booking_BE.Repositories;

namespace FPT_Booking_BE.Services
{
    public class CampusService : ICampusService
    {
        private readonly ICampusRepository _repo;

        public CampusService(ICampusRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Campus>> GetAllCampuses()
        {
            return await _repo.GetAllCampuses();
        }
    }
}