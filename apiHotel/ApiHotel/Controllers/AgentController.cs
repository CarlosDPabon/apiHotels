using Common.TO;
using Domain.Core.ICore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : Controller
    {
        public readonly ICoreAgent _coreAgent;
        public AgentController(ICoreAgent coreHotel) {
            _coreAgent = coreHotel;
        }

        #region Admin Hotels
        [HttpPost]
        [Route("hotel/createHotel")]

        public async Task<IActionResult> createHotel(HotelTO hotel)
        {
            var result = await _coreAgent.createHotel(hotel);
            return result != null ? Ok() : BadRequest();
        }
        [HttpPut]
        [Route("hotel/updateHotel")]
        public async Task<IActionResult> updateHotel(HotelTO hotelTO)
        {
            var result = _coreAgent.updateHotel(hotelTO);
            return result.IsCompleted ? Ok() : BadRequest(result.ToString());
        }
        [HttpPut]
        [Route("hotel/manageStateHotel")]
        public async Task<IActionResult> hotelState(int idHotel)
        {
            var result = _coreAgent.hotelState(idHotel);
            return result.IsCompleted ? Ok() : BadRequest(result.ToString());
        }

        [HttpGet]
        [Route("hotel/getHotels")]
        public async Task<IActionResult> getHotels()
        {
            return Ok(await _coreAgent.searchAllHotels());
        }

        #endregion

        #region Admin Rooms
        [HttpPost]
        [Route("room/createRoom")]
        public async Task<IActionResult> createRoom(RoomTO roomTO)
        {
            var result = _coreAgent.createRoom(roomTO);
            return result.IsCompletedSuccessfully ? Ok() : BadRequest();
        }
        [HttpPut]
        [Route("room/updateRoom")]
        public async Task<IActionResult> updateRoom(RoomTO roomTO)
        {
            var result = _coreAgent.updateRoom(roomTO);
            return result.IsCompletedSuccessfully ? Ok() : BadRequest();
        }
        [HttpPut]
        [Route("room/manageStateRoom")]
        public async Task<IActionResult> roomState(int idRoom)
        {
            var result = _coreAgent.roomState(idRoom);
            return result.IsCompletedSuccessfully ? Ok() : BadRequest();
        }
        [HttpGet]
        [Route("room/getRooms")]
        public async Task<IActionResult> getRooms()
        {
            var result = await _coreAgent.searchAllRooms();
            return result != null ? Ok(result) : BadRequest();
        }
        #endregion
        #region Booking
        [HttpGet]
        [Route("booking/getBookings")]
        public async Task<IActionResult> getBookingHotels(string userName)
        {
            var result = await _coreAgent.getBookingsHotels(userName);
            return result != null ? Ok(result) : BadRequest();
        }
        #endregion
    }
}
