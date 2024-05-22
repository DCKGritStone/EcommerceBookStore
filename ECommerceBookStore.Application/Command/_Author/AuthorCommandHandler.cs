using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Entity;
using ECommerceBookStore.Domain.Interface;
using MediatR;

namespace ECommerceBookStore.Application.Command._Author
{
    public class AuthorCommandHandler : IRequestHandler<AuthorCommand, AuthorDto>
    {
        private readonly IBaseRepository baseRepository;
        private readonly IMapper mapper;

        public AuthorCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<AuthorDto> Handle(AuthorCommand request, CancellationToken cancellationToken)
        {
            Author author;

            switch (request.Operation)
            {
                case Operation.Create:
                    author = new Author
                    {
                        Name = request.AuthorDto.Name,
                        DOB = request.AuthorDto.DOB,
                        Nationality = request.AuthorDto.Nationality

                    };
                    var createdAuthor = await baseRepository.CreateAuthorAsync(author);
                    return mapper.Map<AuthorDto>(createdAuthor);

                case Operation.Update:
                    var updateAuthor = new Author
                    {
                        Id = request.AuthorDto.Id,
                        Name = request.AuthorDto.Name,
                        DOB = request.AuthorDto.DOB,
                        Nationality = request.AuthorDto.Nationality
                    };

                    await baseRepository.UpdateAuthorAsync(request.AuthorDto.Id, updateAuthor);

                    return mapper.Map<AuthorDto>(updateAuthor);

                case Operation.Delete:

                    await baseRepository.DeleteAuthorAsync(request.AuthorDto.Id);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}


