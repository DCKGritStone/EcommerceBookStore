using ECommerceBookStore.Domain.Dto;

namespace ECommerceBookStore.Domain.Interface
{
    public interface IGetPublisherQuery
    {
        IList<PublisherDto> GetAllPublishers();

        PublisherDto GetPublisherById(int id);
    }
}
