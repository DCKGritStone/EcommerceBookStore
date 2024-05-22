using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Interface;
using ECommerceBookStore.Infrastructure.Data;

namespace ECommerceBookStore.Infrastructure.Queries
{
    public class GetOrderQuery : IGetOrderQuery
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;

        public GetOrderQuery(ECommerceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IList<OrderDto> GetAllOrders()
        {
            return mapper.Map<IList<OrderDto>>(dbContext.Orders.ToList());
        }

        public OrderDto GetOrderById(int id)
        {
            return mapper.Map<OrderDto>(dbContext.Orders.FirstOrDefault(x => x.Id == id));
        }
    }
}
