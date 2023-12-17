namespace SoundsGoodCRM.Core.Models.OrderModels
{
    public class OrderStatusTimeLog
    {
        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public Order Order { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string DateTimeStatusSet { get; set; }

    }
}
