using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Constracts.Order;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Orders.Query.GetAllOrder
{
    public class GetAllOrderQueryHandler : IQueryHandler<GetAllOrderQuery, List<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<Response<List<OrderResponse>>> Handle(GetAllOrderQuery response, CancellationToken cancellationToken)
        {
            var res = await _orderRepository.GetAllAsync();
            if (res == null)
            {
                return Response<List<OrderResponse>>.Failure("Fail to get data");
            }
            var result = _mapper.Map<List<OrderResponse>>(res);
            return Response<List<OrderResponse>>.Success("Get data successfully", result.ToList());
        }
    }
}