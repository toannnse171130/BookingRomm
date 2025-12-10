using FPT_Booking_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FPT_Booking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _service;
        public NotificationsController(INotificationService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> GetMyNotifications()
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim == null) return Unauthorized();
            int userId = int.Parse(userIdClaim.Value);

            return Ok(await _service.GetUserNotifications(userId));
        }
    }
}