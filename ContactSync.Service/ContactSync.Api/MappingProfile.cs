using AutoMapper;
using ContactSync.Dto;
using ContactSync.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactSync.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PhoneBookDto, PhoneBook>()
                .ReverseMap();
        }
    }
}
