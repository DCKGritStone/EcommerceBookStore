using ECommerceBookStore.Domain.Dto;

namespace ECommerceBookStore.Domain.Interface
{
    public interface IGetAuthorQuery
    {
        IList<AuthorDto> GetAllAuthors();

        AuthorDto GetAuthorById(int id);
    }
}
