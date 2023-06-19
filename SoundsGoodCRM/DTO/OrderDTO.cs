namespace SoundsGoodCRM.DTO
{
    public record OrderDto
    {
        public int Id { get; }
        public string SerialNumber { get; }
        public string Model { get; }
        public string Type { get; }
        public string Brand { get; }
        public string CustomerName { get; }
        public string Status { get; }

        public OrderDto(int id, string serialNumber, string model, string type, string brand, string customerName, string status)
        {
            Id = id;
            SerialNumber = serialNumber;
            Model = model;
            Type = type;
            Brand = brand;
            CustomerName = customerName;
            Status = status;
        }
    }
}

