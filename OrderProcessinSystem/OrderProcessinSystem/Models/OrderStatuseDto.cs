using System.Collections.Generic;

namespace OrderProcessinSystem.Models
{
    public partial class OrderStatuseDto
    {
        public OrderStatuseDto()
        {
            Orders = new HashSet<OrderDto>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrderDto> Orders { get; set; }
    }
}
