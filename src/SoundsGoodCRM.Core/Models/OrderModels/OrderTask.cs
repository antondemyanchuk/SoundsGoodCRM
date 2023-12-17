namespace SoundsGoodCRM.Core.Models.OrderModels
{
    public class OrderTask : EntityWithId
    {
        public string TaskName { get; set; }
        public decimal Value { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderTaskJoinClass> TaskJoinClasses { get; set; }
    }
}
