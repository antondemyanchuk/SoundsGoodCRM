using SoundsGoodCRM.DAO.CustomerModels;
using SoundsGoodCRM.DAO.OrderModels;

namespace SoundsGoodCRM.DAO.InstrumentModels
{
    public class Instrument : EntityWithId
    {
        public int CustomerId { get; set; }
        public int ModelId { get; set; }
        public int TuneId { get; set; }
        public string SerialNumber { get; set; }
        public InstrumentModel Model { get; set; }
        public Customer Customer { get; set; }
        public InstrumentTuning Tuning { get; set; }
        public List<Order> Orders { get; set; }

        public Instrument(int id, int customerId, int modelId, int tuneId,string serialNumber)
        {
            Id = id;
            CustomerId = customerId;
            ModelId = modelId;  
            TuneId = tuneId;
            SerialNumber = serialNumber;
        }
    }
}
