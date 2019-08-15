using OrderProcessingSystem.Contracts.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderProcessinSystem.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();

        Task<Order> GetByIdAsync(long id);

        Task<bool> Post(Orders order);

        Task<bool> SetStatusAsync(long id, OrderStatus status);

        Task<bool> SetNumberAsync(long id, int number);
    }
}
