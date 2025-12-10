using FPT_Booking_BE.DTOs;
using FPT_Booking_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FPT_Booking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportsController(IReportService service) { _service = service; }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportCreateRequest request)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim == null) return Unauthorized();
            int userId = int.Parse(userIdClaim.Value);

            await _service.CreateReport(userId, request);
            return Ok(new { message = "Báo cáo đã được gửi!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetReports([FromQuery] string? status)
        {
            return Ok(await _service.GetAllReports(status));
        }

        [HttpPut("{id}/resolve")]
        public async Task<IActionResult> ResolveReport(int id, [FromBody] string status)
        {
            var result = await _service.ResolveReport(id, status);
            if (!result) return NotFound();
            return Ok(new { message = "Cập nhật trạng thái thành công" });
        }
    }
}