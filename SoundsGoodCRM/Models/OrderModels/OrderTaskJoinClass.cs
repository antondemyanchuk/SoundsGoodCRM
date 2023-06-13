using SoundsGoodCRM.Models.OrderModels;

namespace DataBaseContext.Models.OrderModels
{
    public class OrderTaskJoinClass
    {
        public int OrderId { get; set; }
        public int OrderTaskId { get; set; }
        public Order Order { get; set; }
        public OrderTask OrderTask { get; set; }
    }
}
