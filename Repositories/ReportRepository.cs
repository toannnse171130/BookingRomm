using FPT_Booking_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FPT_Booking_BE.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly FptFacilityBookingContext _context;
        public ReportRepository(FptFacilityBookingContext context) { _context = context; }

        public async Task AddReport(Report report)
        {
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Report>> GetReports(int? userId, string? status)
        {
            var query = _context.Reports
                .Include(r => r.Facility) 
                .Include(r => r.User)    
                .AsQueryable();

            if (userId.HasValue) query = query.Where(r => r.UserId == userId);
            if (!string.IsNullOrEmpty(status)) query = query.Where(r => r.Status == status);

            return await query.OrderByDescending(r => r.CreatedAt).ToListAsync();
        }

        public async Task<Report?> GetReportById(int id)
        {
            return await _context.Reports.FindAsync(id);
        }

        public async Task UpdateReport(Report report)
        {
            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
        }
    }
}