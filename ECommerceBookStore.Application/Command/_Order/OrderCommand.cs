using ECommerceBookStore.Domain.Dto;
using MediatR;

namespace ECommerceBookStore.Application.Command._Order
{
    public class OrderCommand : IRequest<OrderDto>
    {
        public OrderCommand(Operation operation, OrderDto orderDto)
        {
            Operation = operation;
            OrderDto = orderDto;
        }

        public Operation Operation { get; set; }
        public OrderDto OrderDto { get; set; }
    }
}
