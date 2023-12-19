namespace SoundsGoodCRM.Core.Entities.Orders
{
    public class OrderTask : EntityWithId
    {
        public string TaskName { get; set; }
        public decimal Value { get; set; }
        public List<Order> Orders { get; set; }
    }
}
