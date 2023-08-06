using Common.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IRoomRepository
    {
        public RoomTO getById(int id);
        public List<RoomTO> get();
        public bool create(RoomTO roomTO);
        public bool update(RoomTO roomTO);
        public bool deleteById(int id);
    }
}
