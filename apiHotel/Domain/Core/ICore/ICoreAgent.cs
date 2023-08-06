using Common.TO;

namespace Domain.Core.ICore
{
    public interface ICoreAgent
    {
        //Admin Hotels
        public bool createHotel(HotelTO hotelTO);
        public bool updateHotel(HotelTO roomTO);
        public List<HotelTO> searchAllHotels();
        public bool hotelState(int IdHotel);

        
        //Admin Rooms

        public bool createRoom(RoomTO roomTO);
        public bool updateRoom(RoomTO roomTO);
        public List<RoomTO> searchAllRooms();
        public bool roomState(int IdRoom);

    }
}
