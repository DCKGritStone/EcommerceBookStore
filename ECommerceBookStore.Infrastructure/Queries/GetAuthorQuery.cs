using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Interface;
using ECommerceBookStore.Infrastructure.Data;

namespace ECommerceBookStore.Infrastructure.Queries
{
    public class GetAuthorQuery : IGetAuthorQuery
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;

        public GetAuthorQuery(ECommerceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public IList<AuthorDto> GetAllAuthors()
        {
            return mapper.Map<IList<AuthorDto>>(dbContext.Authors.ToList());
        }

        public AuthorDto GetAuthorById(int id)
        {
            return mapper.Map<AuthorDto>(dbContext.Authors.FirstOrDefault(x => x.Id == id));
        }
    }
}
