namespace SoundsGoodCRM.Core.Models.OrderModels
{
    public class OrderTaskJoinClass
    {
        public int OrderId { get; set; }
        public int OrderTaskId { get; set; }
        public Order Order { get; set; }
        public OrderTask OrderTask { get; set; }
    }
}
