using ECommerceBookStore.Domain.Dto;

namespace ECommerceBookStore.Domain.Interface
{
    public interface IGetBookQuery
    {
        IList<BookDto> GetAllBooks();

        BookDto GetBookById(int id);
    }
}
