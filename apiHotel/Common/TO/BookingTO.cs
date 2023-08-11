using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TO
{
    public class BookingTO
    {
        public int BookingId { get; set; }

        public int HotelId { get; set; }
        public int UserId { get; set; }
        public int ContactEmergencyId { get; set; }
        public int RoomId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }
        public List<PersonTO> personTOs { get; set; }
    }
}
