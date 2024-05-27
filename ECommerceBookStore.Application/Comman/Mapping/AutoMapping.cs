using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Entity;

namespace ECommerceBookStore.Application.Comman.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, Author2Dto>().ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, Book2Dto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, Order2Dto>().ReverseMap();

            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Publisher, Publisher2Dto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, User2Dto>().ReverseMap();

        }
    }
}
