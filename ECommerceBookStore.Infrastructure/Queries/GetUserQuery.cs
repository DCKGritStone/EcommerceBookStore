using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Interface;
using ECommerceBookStore.Infrastructure.Data;

namespace ECommerceBookStore.Infrastructure.Queries
{
    public class GetUserQuery : IGetUserQuery
    {
        private readonly IMapper mapper;
        private readonly ECommerceDbContext dbContext;

        public GetUserQuery(IMapper mapper, ECommerceDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public IList<UserDto> GetAllUsers()
        {
            return mapper.Map<IList<UserDto>>(dbContext.Users.ToList());
        }

        public UserDto GetUserById(int id)
        {
            return mapper.Map<UserDto>(dbContext.Users.FirstOrDefault(x => x.Id == id));
        }
    }
}
