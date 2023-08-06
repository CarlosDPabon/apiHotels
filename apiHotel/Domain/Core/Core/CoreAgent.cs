using Common.TO;
using Domain.Core.ICore;
using Repository.IRepository;

namespace Domain.Core.Core
{
    public class CoreAgent : ICoreAgent
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomRepository _roomRepository;

        public CoreAgent(IHotelRepository hotelRepository, IRoomRepository roomRepository) { 
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
        }

        #region Admin Hotels
        public bool createHotel(HotelTO hotelTO)
        {
            return _hotelRepository.create(hotelTO);
        }
        public bool updateHotel(HotelTO hotelTO)
        {
            return _hotelRepository.update(hotelTO);
        }
        public List<HotelTO> searchAllHotels()
        {
            return _hotelRepository.get();
        }
        public bool hotelState(int IdHotel)
        {
            HotelTO hotelTO = _hotelRepository.getById(IdHotel);
            hotelTO.Active = hotelTO.Active ? false : true;
            return _hotelRepository.update(hotelTO);
        }
        #endregion

        #region Admin Rooms
        public bool createRoom(RoomTO roomTO)
        {
            return _roomRepository.create(roomTO);
        }
        public bool updateRoom(RoomTO roomTO)
        {
            return _roomRepository.update(roomTO);   
        }
        public List<RoomTO> searchAllRooms()
        {
            return _roomRepository.get(); 
        }
        public bool roomState(int IdRoom) {
            RoomTO roomTO = _roomRepository.getById(IdRoom);
            roomTO.Active = roomTO.Active ? false : true;
            return _roomRepository.update(roomTO);
        }
        #endregion
    }
}
