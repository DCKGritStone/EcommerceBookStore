using ECommerceBookStore.Domain.Dto;
using MediatR;

namespace ECommerceBookStore.Application.Command._Publisher
{
    public class PublisherCommand : IRequest<PublisherDto>
    {
        public PublisherCommand(Operation operation, PublisherDto publisherDto)
        {
            Operation = operation;
            PublisherDto = publisherDto;
        }

        public Operation Operation { get; set; }
        public PublisherDto PublisherDto { get; set; }
    }
}
