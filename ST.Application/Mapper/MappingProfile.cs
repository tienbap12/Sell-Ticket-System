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
            /// <summary>
            /// Creates a mapping between the Ticket entity and the TicketResponse DTO.
            /// </summary>
            CreateMap<Ticket, TicketResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();
            /// <summary>
            /// Creates a mapping between the TicketRequest DTO and the Ticket entity.
            /// Also configures the reverse mapping.
            /// </summary>
            CreateMap<TicketRequest, Ticket>().ReverseMap();

            /// <summary>
            /// Creates a mapping between the Category entity and the CategoryResponse DTO.
            /// Also configures the reverse mapping.
            /// </summary>
            CreateMap<Category, CategoryResponse>().ReverseMap();

            /// <summary>
            /// Creates a mapping between the CategoryRequest DTO and the Category entity.
            /// Also configures the reverse mapping.
            /// </summary>
            CreateMap<CategoryRequest, Category>().ReverseMap();


        }
    }
}
