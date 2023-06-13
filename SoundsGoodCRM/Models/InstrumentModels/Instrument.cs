using SoundsGoodCRM.Models.CustomerModels;
using SoundsGoodCRM.Models.OrderModels;

namespace SoundsGoodCRM.Models.InstrumentModels
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
    }
}
