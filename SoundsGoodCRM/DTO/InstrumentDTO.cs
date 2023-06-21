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
        public InstrumentModel Model { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public CustomerDtoMin Customer { get; set; }

        [Required(ErrorMessage = "Choose tuning, please")]
        public InstrumentTuning Tuning { get; set; }

        [Required(ErrorMessage = "Choose type, please")]
        public InstrumentType Type { get; set; }

        [Required(ErrorMessage = "Choose brand, please")]
        public InstrumentBrand Brand { get; set; }

        public InstrumentDTO() { }

        public InstrumentDTO(CustomerDtoMin customer, InstrumentType type, InstrumentBrand brand, InstrumentModel model, InstrumentTuning tuning, string serialNumber)
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
