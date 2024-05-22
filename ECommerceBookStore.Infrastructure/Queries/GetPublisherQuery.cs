using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Interface;
using ECommerceBookStore.Infrastructure.Data;

namespace ECommerceBookStore.Infrastructure.Queries
{
    public class GetPublisherQuery : IGetPublisherQuery
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;

        public GetPublisherQuery(ECommerceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IList<PublisherDto> GetAllPublishers()
        {
            return mapper.Map<IList<PublisherDto>>(dbContext.Publishers.ToList());
        }

        public PublisherDto GetPublisherById(int id)
        {
            return mapper.Map<PublisherDto>(dbContext.Publishers.FirstOrDefault(x => x.Id == id));
        }
    }
}
