using ECommerceBookStore.Domain.Dto;
using MediatR;

namespace ECommerceBookStore.Application.Command._User
{
    public class UserCommand : IRequest<UserDto>
    {
        public UserCommand(Operation operation, UserDto userDto)
        {
            Operation = operation;
            UserDto = userDto;
        }

        public Operation Operation { get; set; }
        public UserDto UserDto { get; set; }
    }
}
