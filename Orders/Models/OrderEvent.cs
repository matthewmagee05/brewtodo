using System;
using static Orders.Models.Order;

namespace Orders.Models
{
    public class OrderEvent
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string Name { get; set; }
        public OrderStatuses Status { get; set; }
        public DateTime Timestamp { get; private set; }
        public OrderEvent(string orderId, string name, OrderStatuses status, DateTime timestamp)
        {
            this.Timestamp = timestamp;
            this.Status = status;
            this.Name = name;
            this.OrderId = orderId;
            this.Id = Guid.NewGuid().ToString();
        }
    }
}