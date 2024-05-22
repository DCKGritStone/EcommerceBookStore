using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Entity;
using ECommerceBookStore.Domain.Interface;
using MediatR;

namespace ECommerceBookStore.Application.Command._User
{
    public class UserCommandHandler : IRequestHandler<UserCommand, UserDto>
    {
        private readonly IBaseRepository baseRepository;
        private readonly IMapper mapper;

        public UserCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<UserDto> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            User user;

            switch (request.Operation)
            {
                case Operation.Create:
                    user = new User
                    {
                        UserName = request.UserDto.UserName,
                        Password = request.UserDto.Password,
                        Email = request.UserDto.Email,
                        FirstName = request.UserDto.FirstName,
                        LastName = request.UserDto.LastName,
                        Address = request.UserDto.Address,
                        Pincode = request.UserDto.Pincode,
                        PhoneNumber = request.UserDto.PhoneNumber,
                        IsCustomer = request.UserDto.IsCustomer
                    };
                    var createdUser = await baseRepository.CreateUserAsync(user);
                    return mapper.Map<UserDto>(createdUser);

                case Operation.Update:
                    var updateUser = new User
                    {
                        Id = request.UserDto.Id,
                        UserName = request.UserDto.UserName,
                        Password = request.UserDto.Password,
                        Email = request.UserDto.Email,
                        FirstName = request.UserDto.FirstName,
                        LastName = request.UserDto.LastName,
                        Address = request.UserDto.Address,
                        Pincode = request.UserDto.Pincode,
                        PhoneNumber = request.UserDto.PhoneNumber,
                        IsCustomer = request.UserDto.IsCustomer
                    };

                    await baseRepository.UpdateUserAsync(request.UserDto.Id, updateUser);

                    return mapper.Map<UserDto>(updateUser);

                case Operation.Delete:

                    await baseRepository.DeleteUserAsync(request.UserDto.Id);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
