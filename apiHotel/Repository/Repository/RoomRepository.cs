using AutoMapper;
using Common.TO;
using DataAccess.Models;
using Repository.IRepository;

namespace Repository.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _context;
        private readonly IMapper _mapper;
        public RoomRepository(HotelContext hotelContext, IMapper mapper)
        {
            _context = hotelContext;
            _mapper = mapper;
        }
        public bool create(RoomTO roomTO)
        {
            bool result;
            try
            {
                Room room = _mapper.Map<Room>(roomTO);
                _context.Rooms.Add(room);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                throw;
            };
            return result;
        }

        public bool deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoomTO> get()
        {
            
            try
            {
                List<RoomTO> rooms;
                return rooms = _mapper.Map<List<RoomTO>>(_context.Rooms.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RoomTO getById(int id)
        {
            try
            {
                return _mapper.Map<RoomTO>(_context.Rooms.Where(r => r.RoomId.Equals(id)).FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool update(RoomTO roomTO)
        {
            bool result;
            try
            {
                Room room = _context.Rooms.Where(r => r.RoomId.Equals(roomTO.RoomId)).FirstOrDefault();
                if (room != null) 
                {
                    room.NumberRoom = roomTO.NumberRoom;
                    room.Capacity = roomTO.Capacity;
                    room.Type = roomTO.Type;
                    room.Price = roomTO.Price;
                    room.Active = roomTO.Active;
                    
                    _context.SaveChanges();
                    result = true;
                }
                else
                    result = false;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
