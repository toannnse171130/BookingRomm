using FPT_Booking_BE.DTOs;
using FPT_Booking_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq; 

namespace FPT_Booking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateRequest request)
        {
            var userIdClaim = User.FindFirst("UserId"); 
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "Token không hợp lệ hoặc thiếu thông tin UserID" });
            }

            int userId = int.Parse(userIdClaim.Value);

            var result = await _bookingService.CreateBooking(userId, request);

            if (result != "Success")
            {
                return BadRequest(new { message = result });
            }

            return Ok(new { message = "Gửi yêu cầu đặt phòng thành công!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory([FromQuery] string? status)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim == null) return Unauthorized();
            int userId = int.Parse(userIdClaim.Value);

            var bookings = await _bookingService.GetHistory(userId);

            if (!string.IsNullOrEmpty(status))
            {
                bookings = bookings.Where(b => b.Status.ToLower() == status.ToLower()).ToList();
            }

            return Ok(bookings);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] BookingStatusUpdate request)
        {
            var result = await _bookingService.UpdateStatus(id, request.Status);

            if (!result) return NotFound();
            return Ok(new { message = "Đã cập nhật trạng thái đơn đặt phòng" });
        }
    }
}