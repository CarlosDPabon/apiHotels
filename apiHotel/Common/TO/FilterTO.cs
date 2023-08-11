using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TO
{
    public class FilterTO
    {
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public int quantityPerson { get; set; }
        public string city { get; set; }
    }
}
