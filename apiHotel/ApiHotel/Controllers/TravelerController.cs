using Common.TO;
using Domain.Core.ICore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelerController : Controller
    {
        private readonly ICoreTraveler _coreTraveler;
        public TravelerController(ICoreTraveler coreTraveler) {
            _coreTraveler = coreTraveler;
        }

        [HttpPost]
        [Route("traveler/createBooking")]
        public async Task<ActionResult> createBooking(BookingTO bookingTO)
        {
            var result = await _coreTraveler.createBooking(bookingTO);
            return result != null ? Ok() : BadRequest();
        }
    }
}
