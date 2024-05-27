using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Entity;
using ECommerceBookStore.Domain.Interface;
using MediatR;

namespace ECommerceBookStore.Application.Command._Order
{
    public class OrderCommandHandler : IRequestHandler<OrderCommand, OrderDto>
    {
        private readonly IBaseRepository baseRepository;
        private readonly IMapper mapper;

        public OrderCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<OrderDto> Handle(OrderCommand request, CancellationToken cancellationToken)
        {
            Order order;

            switch (request.Operation)
            {
                case Operation.Create:
                    order = new Order
                    {
                        LoginId = request.Order2Dto.LoginId,
                        Date = request.Order2Dto.Date,
                        BookId = request.Order2Dto.BookId,
                        Quantity = request.Order2Dto.Quantity,
                        TotalPrice = request.Order2Dto.TotalPrice
                    };
                    var createdBook = await baseRepository.CreateOrderAsync(order);
                    return mapper.Map<OrderDto>(createdBook);

                case Operation.Update:
                    var updateOrder = new Order
                    {
                        Id = request.OrderDto.Id,
                        LoginId = request.OrderDto.LoginId,
                        Date = request.OrderDto.Date,
                        BookId = request.OrderDto.BookId,
                        Quantity = request.OrderDto.Quantity,
                        TotalPrice = request.OrderDto.TotalPrice
                    };

                    await baseRepository.UpdateOrderAsync(request.OrderDto.Id, updateOrder);

                    return mapper.Map<OrderDto>(updateOrder);

                case Operation.Delete:

                    await baseRepository.DeleteOrderAsync(request.OrderDto.Id);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
