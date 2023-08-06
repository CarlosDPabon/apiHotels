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
        public IActionResult createHotel(HotelTO hotel)
        {
            bool result = _coreAgent.createHotel(hotel);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        [Route("hotel/updateHotel")]
        public IActionResult updateHotel(HotelTO hotelTO)
        {
            bool result = _coreAgent.updateHotel(hotelTO);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        [Route("hotel/manageStateHotel")]
        public IActionResult hotelState(int idHotel)
        {
            bool result = _coreAgent.hotelState(idHotel);
            return result ? Ok() : BadRequest();
        }

        [HttpGet]
        [Route("hotel/getHotels")]
        public IActionResult getHotels()
        {
            var x = _coreAgent.searchAllHotels();
            return Ok(x);
        }

        #endregion

        #region Admin Rooms
        [HttpPost]
        [Route("room/createRoom")]
        public IActionResult createRoom(RoomTO roomTO)
        {
            bool result = _coreAgent.createRoom(roomTO);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        [Route("room/updateRoom")]
        public IActionResult updateRoom(RoomTO roomTO)
        {
            bool result = _coreAgent.updateRoom(roomTO);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        [Route("room/manageStateRoom")]
        public IActionResult roomState(int idRoom)
        {
            bool result = _coreAgent.roomState(idRoom);
            return result ? Ok() : BadRequest();
        }
        [HttpGet]
        [Route("room/getRooms")]
        public IActionResult getRooms()
        {
            List<RoomTO> result = _coreAgent.searchAllRooms();
            return result != null ? Ok(result) : BadRequest();
        }
        #endregion
    }
}
