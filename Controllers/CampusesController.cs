using FPT_Booking_BE.Models;
using FPT_Booking_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace FPT_Booking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusesController : ControllerBase
    {
        private readonly ICampusService _service; 

        public CampusesController(ICampusService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campus>>> GetCampuses()
        {
            var result = await _service.GetAllCampuses();
            return Ok(result);
        }
    }
}