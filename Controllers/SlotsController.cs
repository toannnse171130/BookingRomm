using FPT_Booking_BE.Models;
using FPT_Booking_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace FPT_Booking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly ISlotService _service;

        public SlotsController(ISlotService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slot>>> GetSlots()
        {
            return Ok(await _service.GetAllSlots());
        }
    }
}