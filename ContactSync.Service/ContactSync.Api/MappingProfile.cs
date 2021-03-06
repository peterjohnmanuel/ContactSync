﻿using AutoMapper;
using ContactSync.Dto;
using ContactSync.Entities;

namespace ContactSync.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactGroupDto, ContactGroup>()
                .ReverseMap();

            CreateMap<ContactDto, Contact>()
                .ReverseMap();
        }
    }
}
