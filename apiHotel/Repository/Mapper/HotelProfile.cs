using AutoMapper;
using Common.TO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mapper
{
    public class HotelProfile : Profile
    {
        public HotelProfile() {
            CreateMap<Hotel, HotelTO>().ReverseMap();
        }
    }
}
