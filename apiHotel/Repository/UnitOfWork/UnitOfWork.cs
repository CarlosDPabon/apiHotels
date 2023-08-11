using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Repository;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelContext _hotelContext;
        private readonly IRepository<Hotel> _repositoryHotel;
        private readonly IRepository<Room> _repositoryRoom;
        private readonly IRepository<Booking> _repositoryBooking;
        private readonly IRepository<Person> _repositoryPerson;
        private readonly IRepository<BookingPerson> _repositoryBookingPerson;
        private readonly IRepository<UserInfo> _repositoryUserInfo;
        private readonly IRepository<HotelUser> _repositoryHotelUser;
        public UnitOfWork(HotelContext hotelContext, 
            IRepository<Hotel> repositoryHotel,
            IRepository<Room> repositoryRoom,
            IRepository<Booking> repositoryBooking,
            IRepository<Person> repositoryPerson,
            IRepository<BookingPerson> repositoryBookingPerson,
            IRepository<UserInfo> repositoryUserInfo,
            IRepository<HotelUser> repositoryHotelUser)
        {
            _hotelContext = hotelContext;
            _repositoryHotel = repositoryHotel;
            _repositoryRoom = repositoryRoom;
            _repositoryBooking = repositoryBooking;
            _repositoryPerson = repositoryPerson;
            _repositoryBookingPerson = repositoryBookingPerson;
            _repositoryUserInfo = repositoryUserInfo;
            _repositoryHotelUser = repositoryHotelUser;
        }

        public async Task<IRepository<Hotel>> repositoryHotel()
        {
            return _repositoryHotel;
        }
        public async Task<IRepository<Room>> repositoryRoom()
        {
            return _repositoryRoom;
        }
        public async Task<IRepository<Booking>> repositoryBooking()
        {
            return _repositoryBooking;
        }
        public async Task<IRepository<Person>> repositoryPerson()
        {
            return _repositoryPerson;
        }
        public async Task<IRepository<BookingPerson>> repositoryBookingPerson()
        {
            return _repositoryBookingPerson;
        }
        public async Task<IRepository<UserInfo>> repositoryUserInfo()
        {
            return _repositoryUserInfo;
        }
        public async Task<IRepository<HotelUser>> repositoryHotelUser()
        {
            return _repositoryHotelUser;
        }

        public IDbContextTransaction Transaction()
        {
            return _hotelContext.Database.BeginTransaction();
        }

        public void saveChanges() {
            _hotelContext.SaveChanges();
        }
    }
}
