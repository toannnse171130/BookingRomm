using FPT_Booking_BE.Models;
using FPT_Booking_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace FPT_Booking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilityService _service;

        public FacilitiesController(IFacilityService service)
        {
            _service = service;
        }

        // GET: api/facilities?campusId=1&typeId=2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacilities(
            [FromQuery] int? campusId,
            [FromQuery] int? typeId)
        {
            var result = await _service.GetFacilities(campusId, typeId);
            return Ok(result);
        }
    }
}