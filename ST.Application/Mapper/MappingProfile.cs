using AutoMapper;
using ST.Contracts.Category;
using ST.Contracts.Ticket;
using ST.Domain.Entities;

namespace ST.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ticket, TicketResponse>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).ReverseMap();
            CreateMap<Category, CategoryResponse>().ReverseMap();
        }
    }
}
