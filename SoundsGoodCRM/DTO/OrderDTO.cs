using System.ComponentModel.DataAnnotations;

namespace SoundsGoodCRM.DTO
{
	public record OrderDto
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int InstrumentId { get; set; }
		[Required(ErrorMessage = "Serial number is required.")]
		public string SerialNumber { get; set; }
		[Required(ErrorMessage = "Type is required.")]
		public string Type { get; set; }
		[Required(ErrorMessage = "Brand is required.")]
		public string Brand { get; set; }
		[Required(ErrorMessage = "Model is required.")]
		public string Model { get; set; }
		[Required(ErrorMessage = "Tuning is required.")]
		public string Tuning { get; set; }
		[Required(ErrorMessage = "Customer name is required.")]
		public string CustomerName { get; set; }
		[Required(ErrorMessage = "Phone number is required.")]
		public string CustomerPhone { get; set; }

		[Required(ErrorMessage = "Description is required.")]
		public string Description { get; set; }
		public OrderDto() { }

		public OrderDto(int id,int customerId, int instrumentId, string serialNumber, string type, string brand, string model, 
			string tuning,string customerName, string customerPhone, string description)
		{
			Id = id;
			CustomerId = customerId;
			InstrumentId = instrumentId;
			SerialNumber = serialNumber;
			Model = model;
			Type = type;
			Brand = brand;
			Tuning = tuning;
			CustomerName = customerName;
			CustomerPhone = customerPhone;
			Description = description;
		}
	}
}

