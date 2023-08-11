using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TO
{
    public class PersonTO
    {
        public int PersonId { get; set; }

        public int IdentificationId { get; set; }

        public int NumberIdentification { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int PhoneNumber { get; set; }
    }
}
