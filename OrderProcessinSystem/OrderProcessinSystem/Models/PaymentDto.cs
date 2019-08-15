namespace OrderProcessinSystem.Models
{
    public partial class PaymentDto
    {
        public int Id { get; set; }
        public string MethodName { get; set; }
        public decimal Amount { get; set; }
        public long OrderOxId { get; set; }

        public virtual OrderDto OrderOx { get; set; }
    }
}
