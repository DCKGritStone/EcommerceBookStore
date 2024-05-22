using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Interface;
using ECommerceBookStore.Infrastructure.Data;

namespace ECommerceBookStore.Infrastructure.Queries
{
    public class GetBookQuery : IGetBookQuery
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;

        public GetBookQuery(ECommerceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public IList<BookDto> GetAllBooks()
        {
            return mapper.Map<IList<BookDto>>(dbContext.Books.ToList());
        }

        public BookDto GetBookById(int id)
        {
            return mapper.Map<BookDto>(dbContext.Books.FirstOrDefault(x => x.Id == id));
        }
    }
}
