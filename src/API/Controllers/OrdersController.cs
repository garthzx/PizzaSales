using API.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService) {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders() {
            var orders = await _orderService.GetAllOrdersAsync();
            var dtos = orders.Select(o => new OrderDto {
                Id = o.Id,
                Date = o.OrderDate.ToString("yyyy-MM-dd"),
                Time = o.OrderTime.ToString(),
                OrderDetails = o.OrderDetails
            });
            return Ok(dtos);
        }

        [HttpGet("peak-time")]
        public async Task<ActionResult<IEnumerable<PeakTime>>> GetPeakTimeData() {
            return Ok(await _orderService.GetPeakTimeDataAsync());
        }

        [HttpGet("top-10")]
        public async Task<ActionResult<IEnumerable<BestSeller>>> GetTop10BestSellers() {
            return Ok(await _orderService.GetTop10BestSellersAsync());
        }
    }
}
