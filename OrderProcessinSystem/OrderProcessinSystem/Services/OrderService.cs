using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderProcessingSystem.Contracts.Http;
using OrderProcessinSystem.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace OrderProcessinSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrdersContext _context;
        private readonly IMapper _mapper;

        public OrderService(OrdersContext context, IMapper mapper)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
            _mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            _mapper.Map<IEnumerable<OrderDto>, IEnumerable<Order>>(await _context.Orders
                .Include(a => a.Articles)
                .Include(a => a.Payments)
                .ToListAsync());

        public async Task<Order> GetByIdAsync(long id) =>
            _mapper.Map<OrderDto, Order>(await _context.Orders
                .Include(a => a.Articles)
                .Include(a => a.Payments)
                .SingleAsync(x => x.OxId == id));

        public async Task<bool> Post(Orders orders)
        {
            try
            {
                _context.AddRange(_mapper.Map<IEnumerable<Order>, List<OrderDto>>(orders.Order));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SetNumberAsync(long id, int number)
        {
            var orderDto = await _context.Orders.SingleOrDefaultAsync(x => x.OxId == id);
            if (orderDto != null)
            {
                orderDto.InvoiceNumber = number;
                _context.Orders.Update(orderDto);
                var updatedRows = await _context.SaveChangesAsync();
                return updatedRows >= 1;
            }
            return false;
        }

        public async Task<bool> SetStatusAsync(long id, OrderStatus status)
        {
            var orderDto = await _context.Orders.SingleOrDefaultAsync(x => x.OxId == id);
            var orderStatusDto = await _context.OrderStatuses.SingleAsync(x => x.Name == status.ToString());
            if (orderDto != null && orderStatusDto != null)
            {
                orderDto.OrderStatus = orderStatusDto.Id;
                _context.Orders.Update(orderDto);
                var updatedRows = await _context.SaveChangesAsync();
                return updatedRows >= 1;
            }
            return false;
        }
    }
}
