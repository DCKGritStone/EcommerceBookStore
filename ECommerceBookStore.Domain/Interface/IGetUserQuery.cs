using ECommerceBookStore.Domain.Dto;

namespace ECommerceBookStore.Domain.Interface
{
    public interface IGetUserQuery
    {
        IList<UserDto> GetAllUsers();

        UserDto GetUserById(int id);
    }
}
