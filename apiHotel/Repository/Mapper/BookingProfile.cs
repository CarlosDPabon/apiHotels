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
    public class BookingProfile : Profile
    {
        public BookingProfile() { 
            CreateMap<Booking, BookingTO>().ReverseMap();
        }
    }
}
