﻿namespace OrderProcessinSystem.Models
{
    public partial class BillingAddressDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public short HomeNumber { get; set; }
        public int Zip { get; set; }
        public long OrderOxId { get; set; }

        public virtual OrderDto OrderOx { get; set; }
    }
}