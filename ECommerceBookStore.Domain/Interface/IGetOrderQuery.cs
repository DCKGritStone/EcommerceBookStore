using ECommerceBookStore.Domain.Dto;

namespace ECommerceBookStore.Domain.Interface
{
    public interface IGetOrderQuery
    {
        IList<OrderDto> GetAllOrders();

        OrderDto GetOrderById(int id);
    }
}
