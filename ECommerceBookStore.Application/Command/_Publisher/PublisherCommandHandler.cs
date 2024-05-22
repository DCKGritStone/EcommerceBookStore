using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Entity;
using ECommerceBookStore.Domain.Interface;
using MediatR;

namespace ECommerceBookStore.Application.Command._Publisher
{
    public class PublisherCommandHandler : IRequestHandler<PublisherCommand, PublisherDto>
    {
        private readonly IBaseRepository baseRepository;
        private readonly IMapper mapper;

        public PublisherCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<PublisherDto> Handle(PublisherCommand request, CancellationToken cancellationToken)
        {
            Publisher publisher;

            switch (request.Operation)
            {
                case Operation.Create:
                    publisher = new Publisher
                    {
                        Name = request.PublisherDto.Name,
                        BookId = request.PublisherDto.BookId,
                        Price = request.PublisherDto.Price,
                        Stock = request.PublisherDto.Stock,
                        Payment = request.PublisherDto.Payment

                    };
                    var createdPublisher = await baseRepository.CreatePublisherAsync(publisher);
                    return mapper.Map<PublisherDto>(createdPublisher);

                case Operation.Update:
                    var updatePublisher = new Publisher
                    {
                        Id = request.PublisherDto.Id,
                        Name = request.PublisherDto.Name,
                        BookId = request.PublisherDto.BookId,
                        Price = request.PublisherDto.Price,
                        Stock = request.PublisherDto.Stock,
                        Payment = request.PublisherDto.Payment
                    };

                    await baseRepository.UpdatePublisherAsync(request.PublisherDto.Id, updatePublisher);

                    return mapper.Map<PublisherDto>(updatePublisher);

                case Operation.Delete:

                    await baseRepository.DeletePublisherAsync(request.PublisherDto.Id);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
