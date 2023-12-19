namespace SoundsGoodCRM.Core.Entities.Orders
{
    public class OrderStatus : EntityWithId
    {
        public string StatusName { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderStatusTimeLog> OrderStatusTimeLogs { get; set; }
    }
}
