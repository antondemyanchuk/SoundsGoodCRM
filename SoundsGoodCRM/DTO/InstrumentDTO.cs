using SoundsGoodCRM.DAO.CustomerModels;
using SoundsGoodCRM.DAO.InstrumentModels;
using SoundsGoodCRM.DAO.OrderModels;
using System.ComponentModel.DataAnnotations;

namespace SoundsGoodCRM.DTO
{
    public sealed record InstrumentDTO
    {
        [Required(ErrorMessage = "Serial number is required")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public CustomerDtoMin Customer { get; set; }

        [Required(ErrorMessage = "Choose tuning, please")]
        public string Tuning { get; set; }

        [Required(ErrorMessage = "Choose type, please")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Choose brand, please")]
        public InstrumentBrand Brand { get; set; }

        public InstrumentDTO() { }

        public InstrumentDTO(CustomerDtoMin customer, string type, InstrumentBrand brand, string model, string tuning, string serialNumber)
        {
            Customer = customer;
            Tuning = tuning;
            SerialNumber = serialNumber;
            Model = model;
            Tuning = tuning;
            Brand = brand;
        }
    }
}
