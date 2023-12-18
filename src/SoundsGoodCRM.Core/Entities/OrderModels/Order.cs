using System.ComponentModel.DataAnnotations.Schema;

namespace SoundsGoodCRM.Core.Entities.Orders
{
	public class Order : EntityWithId
	{
		public int CustomerId { get; set; }
		public int InstrumentId { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ComplitedAt { get; set; }
		public bool IsActive { get; set; }
		public string Description { get; set; }
		public decimal TotalAmount { get; set; }

		public List<OrderTask> OrderTasks { get; set; }
		public List<OrderStatus> OrderStatuses { get; set; }
		public List<OrderStatusTimeLog> OrderStatusTimeLogs { get; set; }
		public Order() { }
		public Order(int id, int customerId, int instrumentId, string description)
		{
			Id = id;
			CustomerId = customerId;
			InstrumentId = instrumentId;
			Description = description;
		}

	}
}
