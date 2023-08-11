using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TO
{
    public class RoomTO
    {
        public int RoomId { get; set; }

        public int HotelId { get; set; }

        public int NumberRoom { get; set; }

        public int Capacity { get; set; }

        public string Type { get; set; } = null!;

        public string Ubication { get; set; } = null!;

        public int Price { get; set; }

        public bool Active { get; set; }

    }
}
