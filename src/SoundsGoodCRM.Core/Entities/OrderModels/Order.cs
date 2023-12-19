using SoundsGoodCRM.Core.Entities.Customers;
using SoundsGoodCRM.Core.Entities.Instruments;
using SoundsGoodCRM.Entities.Employees;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundsGoodCRM.Core.Entities.Orders
{
	public class Order : EntityWithId
	{
		public int CustomerId { get; set; }
		public int InstrumentId { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ComplitedAt { get; set; }
		public int OrderStatusId { get; set; }
		public string Description { get; set; }
		public decimal TotalAmount { get; set; }
		public int OrderTaskId { get; set; }
		public int EmployeeId { get; set; }

		public Customer Customer { get; set; }
		public Instrument Instrument { get; set; }
		public List<OrderStatus> OrderStatuses { get; set; }
		public List<OrderTask> OrderTasks { get; set; }
		public Employee Employee { get; set; }
		public List<OrderStatusTimeLog> OrderStatusTimeLogs { get; set; }
	}
}
