using AutoMapper;
using Common.TO;
using DataAccess.Models;
using Domain.Core.ICore;
using Repository.Repository;
using Repository.UnitOfWork;

namespace Domain.Core.Core
{
    public class CoreAgent : ICoreAgent
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CoreAgent(
            IRepository<Hotel> repository,
            IMapper mapper,
            IUnitOfWork unitOfWork) { 
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #region Admin Hotels
        public async Task<HotelTO> createHotel(HotelTO hotelTO)
        {
            var hotel = await _unitOfWork.repositoryHotel().Result.CreateAsync(_mapper.Map<Hotel>(hotelTO));
            _unitOfWork.saveChanges();
            return _mapper.Map<HotelTO>(hotel);

        }
        public async Task updateHotel(HotelTO hotelTO)
        {
            var actualEntity = _unitOfWork.repositoryHotel().Result.GetAsync(hotelTO.HotelId).Result;
            await _unitOfWork.repositoryHotel().Result.UpdateAsync(actualEntity, _mapper.Map<Hotel>(hotelTO));
            _unitOfWork.saveChanges();
        }
        public async Task<IEnumerable<HotelTO>> searchAllHotels()
        {
            var result = await _unitOfWork.repositoryHotel().Result.GetAllAsync();
            return _mapper.Map<List<HotelTO>>(result); 
        }
        public async Task hotelState(int IdHotel)
        {
            var result = _unitOfWork.repositoryHotel().Result.GetAsync(IdHotel).Result;
            result.Active = result.Active ? false : true;
            await updateHotel(_mapper.Map<HotelTO>(result));
        }
        #endregion

        #region Admin Rooms
        public async Task<RoomTO> createRoom(RoomTO roomTO)
        {
            var room = await _unitOfWork.repositoryRoom().Result.CreateAsync(_mapper.Map<Room>(roomTO));
            _unitOfWork.saveChanges();
            return _mapper.Map<RoomTO>(room);
        }
        public async Task updateRoom(RoomTO roomTO)
        {
            var actualEntity = _unitOfWork.repositoryRoom().Result.GetAsync(roomTO.RoomId).Result;
            await _unitOfWork.repositoryRoom().Result.UpdateAsync(actualEntity, _mapper.Map<Room>(roomTO));
            _unitOfWork.saveChanges();
        }
        public async Task<IEnumerable<RoomTO>> searchAllRooms()
        {
            var result = await _unitOfWork.repositoryRoom().Result.GetAllAsync();
            return _mapper.Map<List<RoomTO>>(result);
        }
        public async Task roomState(int IdRoom) {
            var result = _unitOfWork.repositoryRoom().Result.GetAsync(IdRoom).Result;
            result.Active = result.Active ? false : true;
            await updateRoom(_mapper.Map<RoomTO>(result));
        }
        #endregion

        #region Bookings
        public async Task<List<BookingTO>> getBookingsHotels (string userName)
        {
            var agent = await _unitOfWork.repositoryUserInfo().Result.Query(u => u.UserName.Equals(userName));
            var hotels = _unitOfWork.repositoryHotelUser().Result.GetAllAsync().Result.Where(hr => hr.UserId.Equals(agent.UserId));
            var bookings = await _unitOfWork.repositoryBooking().Result.GetAllAsync();
            return _mapper.Map<List<BookingTO>>((from h in hotels join b in bookings on h.HotelId equals b.HotelId select b).ToList());
        }
        #endregion
    }
}
