using FPT_Booking_BE.Models;

namespace FPT_Booking_BE.Services
{
    public interface ICampusService
    {
        Task<IEnumerable<Campus>> GetAllCampuses();
    }
}