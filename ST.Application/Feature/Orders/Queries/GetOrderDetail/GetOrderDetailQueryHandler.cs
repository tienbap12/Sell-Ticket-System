using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Constracts.Order;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryHandler : IQueryHandler<GetOrderDetailQuery, List<DetailsResponse>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task<Response<List<DetailsResponse>>> Handle(GetOrderDetailQuery response, CancellationToken cancellationToken)
        {
            var res = await _orderDetailRepository.GetAllOrderDetail(response.Id);
            if (res == null)
            {
                return Response<List<DetailsResponse>>.Failure("Fail to get data");
            }
            var result = _mapper.Map<List<DetailsResponse>>(res);
            return Response<List<DetailsResponse>>.Success("Get data successfully!!!", result.ToList());
        }
    }
}