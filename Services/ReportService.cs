using FPT_Booking_BE.DTOs;
using FPT_Booking_BE.Models;
using FPT_Booking_BE.Repositories;

namespace FPT_Booking_BE.Services
{
    public interface IReportService
    {
        Task CreateReport(int userId, ReportCreateRequest request);
        Task<IEnumerable<Report>> GetAllReports(string? status);
        Task<bool> ResolveReport(int reportId, string status);
    }

    public class ReportService : IReportService
    {
        private readonly IReportRepository _repo;
        public ReportService(IReportRepository repo) { _repo = repo; }

        public async Task CreateReport(int userId, ReportCreateRequest request)
        {
            var report = new Report
            {
                UserId = userId,
                FacilityId = request.FacilityId,
                BookingId = request.BookingId,
                Title = request.Title,
                Description = request.Description,
                ReportType = request.ReportType,
                Status = "Pending",
                CreatedAt = DateTime.Now
            };
            await _repo.AddReport(report);
        }

        public async Task<IEnumerable<Report>> GetAllReports(string? status)
        {
            return await _repo.GetReports(null, status);
        }

        public async Task<bool> ResolveReport(int reportId, string status)
        {
            var report = await _repo.GetReportById(reportId);
            if (report == null) return false;

            report.Status = status;
            report.ResolvedAt = DateTime.Now;
            await _repo.UpdateReport(report);
            return true;
        }
    }
}