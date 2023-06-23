using System.ComponentModel.DataAnnotations;

namespace SoundsGoodCRM.DTO
{
	public sealed record InstrumentDTO
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int TypeId { get; set; }
		public int ModelId { get; set; }
		public int TuningId { get; set; }
		public int BrandId { get; set; }

		[Required(ErrorMessage = "Serial number is required")]
		public string SerialNumber { get; set; }

		[Required(ErrorMessage = "Model is required")]
		public string Model { get; set; }

		[Required(ErrorMessage = "Customer is required")]
		public string CustomerFirstName { get; set; }

		[Required(ErrorMessage = "Customer is required")]
		public string CustomerLastName { get; set; }

		[Required(ErrorMessage = "Customer is required")]
		public string CustomerFullName { get; set; }

		[Required(ErrorMessage = "Choose tuning, please")]
		public string Tuning { get; set; }

		[Required(ErrorMessage = "Choose type, please")]
		public string Type { get; set; }

		[Required(ErrorMessage = "Choose brand, please")]
		public string Brand { get; set; }

		public InstrumentDTO() { }

		public InstrumentDTO(int id, string firstName, string lastName, string type, string brand, 
			string model, string tuning, string serialNumber)
		{
			Id = id;
			CustomerFirstName = firstName;
			CustomerLastName = lastName;
			Type = type;
			Tuning = tuning;
			SerialNumber = serialNumber;
			Model = model;
			Tuning = tuning;
			Brand = brand;
		}
		public InstrumentDTO(int id, int customerId, int typeId, int modelId, int tuningId, int brandId,
			string serialNumber, string model, string firstName, string lastName, string tuning, string type, string brand)
		{
			Id = id;
			CustomerId = customerId;
			TypeId = typeId;
			ModelId = modelId;
			TuningId = tuningId;
			BrandId = brandId;
			SerialNumber = serialNumber;
			Model = model;
			CustomerFirstName = firstName;
			CustomerLastName = lastName;
			Tuning = tuning;
			Type = type;
			Brand = brand;
		}
	}
}
