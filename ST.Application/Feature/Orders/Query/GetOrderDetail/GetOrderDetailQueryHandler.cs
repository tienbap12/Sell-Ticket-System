using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Constracts.Order;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Orders.Query.GetOrderDetail
{
    public class GetOrderDetailQueryHandler : IQueryHandler<GetOrderDetailQuery, List<DetailsResponse>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, ITicketRepository ticketRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<Response<List<DetailsResponse>>> Handle(GetOrderDetailQuery response, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderDetailRepository.GetAllOrderDetail(response.Id);
            if (orderDetails == null)
            {
                return Response<List<DetailsResponse>>.Failure("Fail to get data");
            }
            var detailsResponses = new List<DetailsResponse>();
            foreach (var orderDetail in orderDetails)
            {
                var ticket = await _ticketRepository.GetByIdAsync(orderDetail.TicketId);
                var detailsResponse = _mapper.Map<DetailsResponse>(orderDetail);
                detailsResponse.TicketName = ticket.Name;
                detailsResponses.Add(detailsResponse);
            }

            return Response<List<DetailsResponse>>.Success("Get data successfully!!!", detailsResponses);
        }
    }
}