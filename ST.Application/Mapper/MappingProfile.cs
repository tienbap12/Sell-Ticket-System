using AutoMapper;
using ST.Application.Feature.Tickets.DTOs;
using ST.Domain.Entities;

namespace ST.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ticket, TicketResponse>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).ReverseMap();
        }
    }
}
