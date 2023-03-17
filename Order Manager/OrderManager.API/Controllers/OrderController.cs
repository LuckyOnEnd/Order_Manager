using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Application;
using OrderManager.Application.Services.Interfaces;
using OrderManager.Domain.Entity;
using System.Text.Json.Serialization.Metadata;

namespace OrderManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderLineService _orderLineService;
        public OrderController(IOrderService orderService, IOrderLineService orderLineService)
        {
            _orderService = orderService;
            _orderLineService = orderLineService;
        }
        [HttpGet]
        public async Task<ActionResult<Order>> GetAllOrders()
        {
            var result = _orderService.GetOrders();
            return Ok(result);
        }

        [HttpGet("{orderId:int}")]
        public async Task<ActionResult<Order>> GetOrderById(int orderId)
        {
            if(orderId == 0) return BadRequest();
            var result = _orderService.GetOrderById(orderId);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            _orderService.CreateOrder(order);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Order>> EditOrder(int id, Order order)
        {
            if (id == 0)
                return BadRequest();
            _orderService.UpdateOrder(id, order);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            if (id == 0)
                return BadRequest();
            _orderService.DeleteOrder(id);
            return Ok();
        }

        [HttpGet("details/{orderId:int}")]
        public async Task<ActionResult<OrderLine>> GetOrderLines(int orderId)
        {
            if (orderId == 0)
                return BadRequest();
            var result = _orderLineService.GetOrderLines(orderId);
            return Ok(result);
        }

        [HttpPost("orderLines/{orderId:int}")]
        public async Task<ActionResult<OrderLine>> CreateOrderLines(int orderId, List<OrderLine> model)
        {
            _orderLineService.CreateOrderLines(orderId, model);
            _orderService.UpdateOrderPrice(orderId);
            return NoContent();
        }
        [HttpDelete("orderline/{orderId:int}/{orderLineId:int}")]
        public async Task<ActionResult> DeleteOrderLine(int orderId ,int orderLineId)
        {
            if (orderLineId == 0)
                return BadRequest();
            _orderLineService.DeleteOrderLine(orderLineId);
            _orderService.UpdateOrderPrice(orderId);

            return NoContent();
        }

    }
}
