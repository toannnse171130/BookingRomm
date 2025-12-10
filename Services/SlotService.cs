using FPT_Booking_BE.Models;
using FPT_Booking_BE.Repositories;

namespace FPT_Booking_BE.Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _repo;

        public SlotService(ISlotRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Slot>> GetAllSlots()
        {
            return await _repo.GetAllSlots();
        }
    }
}