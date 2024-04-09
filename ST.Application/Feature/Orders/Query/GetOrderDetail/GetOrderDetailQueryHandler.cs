using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Constracts.Order;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Orders.Query.GetOrderDetail
{
    public class GetOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, ITicketRepository ticketRepository, IMapper mapper) : IQueryHandler<GetOrderDetailQuery, List<DetailsResponse>>
    {
        public async Task<Response<List<DetailsResponse>>> Handle(GetOrderDetailQuery response, CancellationToken cancellationToken)
        {
            var orderDetails = await orderDetailRepository.GetAllOrderDetail(response.Id);
            if (orderDetails == null)
            {
                return Response<List<DetailsResponse>>.Failure("Fail to get data");
            }
            var detailsResponses = new List<DetailsResponse>();
            foreach (var orderDetail in orderDetails)
            {
                var ticket = await ticketRepository.GetByIdAsync(orderDetail.TicketId);
                var detailsResponse = mapper.Map<DetailsResponse>(orderDetail);
                detailsResponse.TicketName = ticket.Name;
                detailsResponses.Add(detailsResponse);
            }

            return Response<List<DetailsResponse>>.Success("Get data successfully!!!", detailsResponses);
        }
    }
}