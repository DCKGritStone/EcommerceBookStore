using ECommerceBookStore.Application.Command._Order;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiController
    {
        private readonly IGetOrderQuery getOrderQuery;

        public OrderController(IGetOrderQuery getOrderQuery)
        {
            this.getOrderQuery = getOrderQuery;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var order = getOrderQuery.GetAllOrders();
            return Ok(order);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var order = getOrderQuery.GetOrderById(id);
            return Ok(order);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
        {
            var command = new OrderCommand(Operation.Create, orderDto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDto orderDto)
        {
            if (id == orderDto.Id)
            {
                var command = new OrderCommand(Operation.Update, orderDto);
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = new OrderDto { Id = id };
            var command = new OrderCommand(Operation.Delete, book);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
