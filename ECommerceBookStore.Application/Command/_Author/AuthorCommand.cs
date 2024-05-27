using ECommerceBookStore.Domain.Dto;
using MediatR;

namespace ECommerceBookStore.Application.Command._Author
{
    public class AuthorCommand : IRequest<AuthorDto>
    {


        public AuthorCommand(Operation operation, AuthorDto authorDto = null, Author2Dto author2Dto = null)
        {
            Operation = operation;
            AuthorDto = authorDto;
            Author2Dto = author2Dto;
        }

        public Operation Operation { get; set; }
        public AuthorDto? AuthorDto { get; set; }
        public Author2Dto? Author2Dto { get; set; }

    }
}
