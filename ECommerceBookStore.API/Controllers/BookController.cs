using ECommerceBookStore.Application.Command._Book;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ApiController
    {
        private readonly IGetBookQuery getBookQuery;

        public BookController(IGetBookQuery getBookQuery)
        {
            this.getBookQuery = getBookQuery;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var book = getBookQuery.GetAllBooks();
            return Ok(book);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var book = getBookQuery.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Book2Dto book2Dto)
        {

            var command = new BookCommand(Operation.Create, book2Dto: book2Dto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookDto bookDto)
        {
            if (id == bookDto.Id)
            {
                var command = new BookCommand(Operation.Update, bookDto);
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = new BookDto { Id = id };
            var command = new BookCommand(Operation.Delete, book);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
