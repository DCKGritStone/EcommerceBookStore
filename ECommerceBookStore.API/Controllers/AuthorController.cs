using ECommerceBookStore.Application.Command._Author;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ApiController
    {
        private readonly IGetAuthorQuery getAuthorQuery;

        public AuthorController(IGetAuthorQuery getAuthorQuery)
        {
            this.getAuthorQuery = getAuthorQuery;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var author = getAuthorQuery.GetAllAuthors();
            return Ok(author);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var author = getAuthorQuery.GetAuthorById(id);
            return Ok(author);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AuthorDto authorDto)
        {
            var command = new AuthorCommand(Operation.Create, authorDto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AuthorDto authorDto)
        {
            if (id == authorDto.Id)
            {
                var command = new AuthorCommand(Operation.Update, authorDto);
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = new AuthorDto { Id = id };
            var command = new AuthorCommand(Operation.Delete, author);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
