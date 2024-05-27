using ECommerceBookStore.Domain.Dto;
using MediatR;

namespace ECommerceBookStore.Application.Command._Book
{
    public class BookCommand : IRequest<BookDto>
    {
        public BookCommand(Operation operation, BookDto bookDto = null, Book2Dto book2Dto = null)
        {
            Operation = operation;
            BookDto = bookDto;
            Book2Dto = book2Dto;
        }

        public Operation Operation { get; set; }
        public BookDto BookDto { get; set; }
        public Book2Dto Book2Dto { get; set; }
    }
}
