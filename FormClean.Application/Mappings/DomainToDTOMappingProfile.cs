using AutoMapper;
using FormClean.Application.DTOs;
using FormClean.Domain.Entities;

namespace FormClean.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Demanded, DemandedDTO>().ReverseMap();
        }
    }
}
