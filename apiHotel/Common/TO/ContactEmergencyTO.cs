using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TO
{
    public class ContactEmergencyTO
    {
        public int ContactEmergencyId { get; set; }
        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public int Phone { get; set; }
    }
}
