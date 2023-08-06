using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TO
{
    public partial class HotelTO
    {
        public int HotelId { get; set; }
        public int IdentificationId { get; set; }

        public int NumberIdentification { get; set; }

        public string HotelName { get; set; } = null!;

        public string Country { get; set; }

        public string Ubication { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
