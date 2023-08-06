using AutoMapper;
using Common.TO;
using DataAccess.Models;
using Repository.IRepository;

namespace Repository.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext _context;
        private readonly IMapper _mapper;

        public HotelRepository(HotelContext hotelContext, IMapper mapper)
        {
            _context = hotelContext;
            _mapper = mapper;
        }
        public bool create(HotelTO hotelTO)
        {
            bool result;
            try
            {
                _context.Hotels.Add(_mapper.Map<Hotel>(hotelTO));
                _context.SaveChanges();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public HotelTO getById(int id)
        { 
            try
            {
                return  _mapper.Map<HotelTO>(_context.Hotels.Where(h => h.HotelId.Equals(id)).FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HotelTO> get()
        {
            try
            {
                return _mapper.Map<List<HotelTO>>(_context.Hotels.ToList());

            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public bool update(HotelTO hotelTO)
        {
            bool result;
            try
            {
                Hotel hotel = _context.Hotels.Where(r => r.HotelId.Equals(hotelTO.HotelId)).FirstOrDefault();
                if (hotel != null)
                {
                    hotel.IdentificationId = hotelTO.IdentificationId;
                    hotel.NumberIdentification = hotelTO.NumberIdentification;
                    hotel.HotelName = hotelTO.HotelName;
                    hotel.Ubication = hotelTO.Ubication;
                    hotel.PhoneNumber = hotelTO.PhoneNumber;
                    hotel.Email = hotelTO.Email;
                    hotel.Active = hotelTO.Active;

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
        public bool deleteById(int id)
        {
            return true;
        }
    }
}
