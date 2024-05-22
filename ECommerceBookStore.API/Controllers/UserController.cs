using ECommerceBookStore.Application.Command._User;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IGetUserQuery getUserQuery;

        public UserController(IGetUserQuery getUserQuery)
        {
            this.getUserQuery = getUserQuery;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var user = getUserQuery.GetAllUsers();
            return Ok(user);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var user = getUserQuery.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            var command = new UserCommand(Operation.Create, userDto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDto userDto)
        {
            if (id == userDto.Id)
            {
                var command = new UserCommand(Operation.Update, userDto);
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = new UserDto { Id = id };
            var command = new UserCommand(Operation.Delete, user);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
