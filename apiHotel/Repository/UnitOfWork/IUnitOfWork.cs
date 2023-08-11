using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task<IRepository<Hotel>> repositoryHotel();
        public Task<IRepository<Room>> repositoryRoom();
        public Task<IRepository<Booking>> repositoryBooking();
        public Task<IRepository<Person>> repositoryPerson();
        public Task<IRepository<BookingPerson>> repositoryBookingPerson();
        public Task<IRepository<UserInfo>> repositoryUserInfo();
        public Task<IRepository<HotelUser>> repositoryHotelUser();
        public IDbContextTransaction Transaction ();
        public void saveChanges();
    }
}
