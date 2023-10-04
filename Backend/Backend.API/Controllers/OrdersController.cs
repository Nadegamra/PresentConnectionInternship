using Backend.API.Data.DTOs;
using Backend.API.Data.Models;
using Backend.API.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("/api/orders/")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersHandler handler;

        public OrdersController(OrdersHandler handler)
        {
            this.handler = handler;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddOrderAsync(AddOrderRequest req)
        {
            try
            {
                var result = handler.AddOrderAsync(req);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Order>> GetOrderAsync(int id)
        {
            try
            {
                var result = handler.GetOrderAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Order>>> GetOrderListAsync()
        {
            try
            {
                var result = handler.GetOrderListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}