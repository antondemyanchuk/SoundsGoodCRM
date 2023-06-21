using System.ComponentModel.DataAnnotations;

namespace SoundsGoodCRM.DTO
{
	public class CustomerDtoMin
	{
		[Required(ErrorMessage = "Customer is required")]
		public int Id { get; set; }
		[Required(ErrorMessage = "Customer is required")]
		public string Name { get; set; }
		public CustomerDtoMin() { }
		public CustomerDtoMin(int id, string name)
		{
			Id = id;
			Name = name;

		}
	}
}
