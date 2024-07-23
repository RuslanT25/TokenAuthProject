using AuthServer.Core.DTOs;
using AuthServer.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Business.Mappers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<AppUserDTO, AppUser>().ReverseMap();
        }
    }
}
