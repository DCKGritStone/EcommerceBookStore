using ECommerceBookStore.Domain.Dto;
using MediatR;

namespace ECommerceBookStore.Application.Command._Book
{
    public class BookCommand : IRequest<BookDto>
    {
        public BookCommand(Operation operation, BookDto bookDto)
        {
            Operation = operation;
            BookDto = bookDto;
        }

        public Operation Operation { get; set; }
        public BookDto BookDto { get; set; }
    }
}
