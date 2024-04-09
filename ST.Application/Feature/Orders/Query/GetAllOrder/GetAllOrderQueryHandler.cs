using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Constracts.Order;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Orders.Query.GetAllOrder
{
    public class GetAllOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper) : IQueryHandler<GetAllOrderQuery, List<OrderResponse>>
    {
        public async Task<Response<List<OrderResponse>>> Handle(GetAllOrderQuery response, CancellationToken cancellationToken)
        {
            var res = await orderRepository.GetAllAsync();
            if (res == null)
            {
                return Response<List<OrderResponse>>.Failure("Fail to get data");
            }
            var result = mapper.Map<List<OrderResponse>>(res);
            return Response<List<OrderResponse>>.Success("Get data successfully", result.ToList());
        }
    }
}