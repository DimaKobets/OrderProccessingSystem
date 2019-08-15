using System;
using System.Collections.Generic;

namespace OrderProcessinSystem.Models
{
    public partial class OrderDto
    {
        public OrderDto()
        {
            Articles = new HashSet<ArticleDto>();
            Payments = new HashSet<PaymentDto>();
        }

        public long OxId { get; set; }
        public DateTime OrderDatetime { get; set; }
        public byte? OrderStatus { get; set; }
        public int? InvoiceNumber { get; set; }

        public virtual OrderStatuseDto OrderStatusNavigation { get; set; }
        public virtual BillingAddressDto BillingAddresses { get; set; }
        public virtual ICollection<ArticleDto> Articles { get; set; }
        public virtual ICollection<PaymentDto> Payments { get; set; }
    }
}
