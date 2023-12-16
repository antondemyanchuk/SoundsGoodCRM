using SoundsGoodCRM.Core.Models.Customer;
using SoundsGoodCRM.DAO.InstrumentModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundsGoodCRM.DAO.OrderModels
{
	public class Order : EntityWithId
	{
		public int CustomerId { get; set; }
		public int InstrumentId { get; set; }
		public Customer Customer { get; set; }
		public Instrument Instrument { get; set; }
		public string? DateBeginning { get; set; }
		public string? DateEnding { get; set; }
		public bool IsActive { get; set; }
		public List<OrderTask> OrderTasks { get; set; }
		public List<OrderStatus> OrderStatuses { get; set; }
		public List<OrderStatusTimeLog> OrderStatusTimeLogs { get; set; }
		public List<OrderTaskJoinClass> TaskJoinClasses { get; set; }
		public string Description { get; set; }

		[NotMapped]
		public decimal TotalAmount { get; set; }
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
