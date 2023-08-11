using Common.TO;

namespace Domain.Core.ICore
{
    public interface ICoreTraveler 
    {
        public Task<BookingTO> createBooking(BookingTO booking);
        public IEnumerable<HotelTO> getHotels(FilterTO? filterTO);
        public IEnumerable<RoomTO> getRoomsByHotel(int hotelId);
    }
}
