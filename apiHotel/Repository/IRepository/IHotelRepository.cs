using Common.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IHotelRepository
    {
        public HotelTO getById(int id);
        public List<HotelTO> get();
        public bool create(HotelTO hotel);
        public bool update(HotelTO hotel);
        public bool deleteById(int id);
    }
}
