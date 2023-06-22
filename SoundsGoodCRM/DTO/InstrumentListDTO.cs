namespace SoundsGoodCRM.DTO
{
    public class InstrumentListDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Tuning { get; set; }
        public string SerialNumber { get; set; }

        public InstrumentListDTO() { }
        public InstrumentListDTO(int id, string type, string brand, string model, string tuning, string serialNumber)
        {
            Id = id;
            Type = type;
            Brand = brand;
            Model = model;
            Tuning = tuning;
            SerialNumber = serialNumber;
        }
    }
}
