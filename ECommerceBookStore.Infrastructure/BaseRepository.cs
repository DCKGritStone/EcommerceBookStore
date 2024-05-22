using ECommerceBookStore.Domain.Entity;
using ECommerceBookStore.Domain.Interface;
using ECommerceBookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBookStore.Infrastructure
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ECommerceDbContext dbContext;

        public BaseRepository(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Author> CreateAuthorAsync(Author author)
        {
            await dbContext.Authors.AddAsync(author);
            await dbContext.SaveChangesAsync();
            return author;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Publisher> CreatePublisherAsync(Publisher publisher)
        {
            await dbContext.Publishers.AddAsync(publisher);
            await dbContext.SaveChangesAsync();
            return publisher;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<int> DeleteAuthorAsync(int id)
        {
            return await dbContext.Authors.Where(x => x.Id == id).ExecuteDeleteAsync();

        }

        public async Task<int> DeleteBookAsync(int id)
        {
            return await dbContext.Books.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<int> DeleteOrderAsync(int id)
        {
            return await dbContext.Orders.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<int> DeletePublisherAsync(int id)
        {
            return await dbContext.Publishers.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            return await dbContext.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<int> UpdateAuthorAsync(int id, Author author)
        {
            return await dbContext.Authors.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(x => x.Name, author.Name)
                                                                                                        .SetProperty(x => x.DOB, author.DOB)
                                                                                                        .SetProperty(x => x.Nationality, author.Nationality));
        }

        public async Task<int> UpdateBookAsync(int id, Book book)
        {
            return await dbContext.Books.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(x => x.Title, book.Title)
                                                                                                         .SetProperty(x => x.AuthorId, book.AuthorId)
                                                                                                         .SetProperty(x => x.Price, book.Price)
                                                                                                         .SetProperty(x => x.Description, book.Description));
        }

        public async Task<int> UpdateOrderAsync(int id, Order order)
        {
            return await dbContext.Orders.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(x => x.LoginId, order.LoginId)
                                                                                                        .SetProperty(x => x.Date, order.Date)
                                                                                                        .SetProperty(x => x.BookId, order.BookId)
                                                                                                        .SetProperty(x => x.Quantity, order.Quantity)
                                                                                                        .SetProperty(x => x.TotalPrice, order.TotalPrice));
        }

        public async Task<int> UpdatePublisherAsync(int id, Publisher publisher)
        {
            return await dbContext.Publishers.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(x => x.Name, publisher.Name)
                                                                                                        .SetProperty(x => x.BookId, publisher.BookId)
                                                                                                        .SetProperty(x => x.Price, publisher.Price)
                                                                                                        .SetProperty(x => x.Stock, publisher.Stock)
                                                                                                        .SetProperty(x => x.Payment, publisher.Payment));
        }

        public async Task<int> UpdateUserAsync(int id, User user)
        {
            return await dbContext.Users.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(x => x.UserName, user.UserName)
                                                                                                        .SetProperty(x => x.Password, user.Password)
                                                                                                        .SetProperty(x => x.Email, user.Email)
                                                                                                        .SetProperty(x => x.FirstName, user.FirstName)
                                                                                                        .SetProperty(x => x.LastName, user.LastName)
                                                                                                        .SetProperty(x => x.Address, user.Address)
                                                                                                        .SetProperty(x => x.Pincode, user.Pincode)
                                                                                                        .SetProperty(x => x.PhoneNumber, user.PhoneNumber)
                                                                                                        .SetProperty(x => x.IsCustomer, user.IsCustomer));
        }

    }

}