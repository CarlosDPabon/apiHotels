using AutoMapper;
using Common.TO;
using DataAccess.Models;
using Domain.Core.ICore;
using Repository.UnitOfWork;

namespace Domain.Core.Core
{
    public class CoreTraveler : ICoreTraveler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CoreTraveler(IUnitOfWork unitOfWork, IMapper mapper) { 
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }
        public async Task<BookingTO> createBooking(BookingTO bookingTO)
        {

            using (var transaction = _unitOfWork.Transaction())
            {
                try
                {
                    List<Person> createPerson = new List<Person>();
                    foreach (var person in bookingTO.personTOs)
                    {
                        createPerson.Add(await _unitOfWork.repositoryPerson().Result.CreateAsync(_mapper.Map<Person>(person)));
                    }
                    var resultPerson = _mapper.Map<List<PersonTO>>(createPerson);
                    _unitOfWork.saveChanges();

                    var createBooking = await _unitOfWork.repositoryBooking().Result.CreateAsync(_mapper.Map<Booking>(bookingTO));
                    var resultBooking = _mapper.Map<BookingTO>(createBooking);
                    _unitOfWork.saveChanges();

                    foreach (var person in createPerson)
                    {
                        BookingPerson bookingPerson = new BookingPerson()
                        {
                            PersonId = person.PersonId,
                            BookingId = createBooking.BookingId
                        };
                        await _unitOfWork.repositoryBookingPerson().Result.CreateAsync(bookingPerson);
                    }
                    _unitOfWork.saveChanges();

                    resultBooking.personTOs = resultPerson;
                    transaction.Commit();

                    return resultBooking;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public IEnumerable<HotelTO> getHotels(FilterTO? filterTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomTO> getRoomsByHotel(int hotelId)
        {
            throw new NotImplementedException();
        }
    }
}
