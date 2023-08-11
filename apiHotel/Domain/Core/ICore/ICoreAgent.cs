using Common.TO;
using DataAccess.Models;

namespace Domain.Core.ICore
{
    public interface ICoreAgent
    {
        //Admin Hotels
        Task<HotelTO> createHotel(HotelTO hotelTO);
        Task updateHotel(HotelTO roomTO);
        Task<IEnumerable<HotelTO>> searchAllHotels();
        Task hotelState(int IdHotel);

        
        //Admin Rooms

        Task<RoomTO> createRoom(RoomTO roomTO);
        Task updateRoom(RoomTO roomTO);
        Task<IEnumerable<RoomTO>> searchAllRooms();
        Task roomState(int IdRoom);

        //Admin Bookings
        Task<List<BookingTO>> getBookingsHotels(string userName);
    }
}
