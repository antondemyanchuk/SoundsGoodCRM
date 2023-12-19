namespace SoundsGoodCRM.Core.Entities.Orders
{
    public class OrderStatusTimeLog
    {
        public DateTime DateTime { get; set; }
        public int OrderStatusId { get; set; }
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Order Order { get; set; }

    }
}
