using AutoMapper;
using ContactSync.Dto;
using ContactSync.Entities;

namespace ContactSync.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PhoneBookDto, PhoneBook>()
                .ReverseMap();

            CreateMap<PhoneBookEntryDto, PhoneBookEntry>()
                .ReverseMap();
        }
    }
}
