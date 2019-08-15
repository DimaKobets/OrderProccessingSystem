using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrderProcessingSystem.Contracts.Http;
using OrderProcessinSystem.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderProcessinSystem.Controllers
{
    [Route("orders")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new NullReferenceException(nameof(orderService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll() =>
            Ok(await _orderService.GetAllAsync()) ?? (ActionResult)NotFound();

        [HttpGet("{id:long}")]
        public async Task<ActionResult<Order>> GetById(long id) =>
            Ok(await _orderService.GetByIdAsync(id)) ?? (ActionResult)NotFound();

        [HttpPost]
        public async Task<ActionResult> Post([BindRequired][FromBody] Orders orders) =>
          await _orderService.Post(orders) ? Ok() : (ActionResult)BadRequest();

        [HttpPatch("{id:long}/status")]
        public async Task<ActionResult> SetStatus(long id, [BindRequired][FromBody] OrderStatus status) =>
            await _orderService.SetStatusAsync(id, status) ? Ok() : (ActionResult)BadRequest();

        [HttpPatch("{id:int}/number")]
        public async Task<ActionResult> SetNumber(long id, [BindRequired][FromBody] int number) =>
            await _orderService.SetNumberAsync(id, number) ? Ok() : (ActionResult)BadRequest();
    }
}