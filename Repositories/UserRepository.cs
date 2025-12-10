using FPT_Booking_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FPT_Booking_BE.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FptFacilityBookingContext _context;

        public UserRepository(FptFacilityBookingContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}