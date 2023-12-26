using SoundsGoodCRM.Core.Entities.Customers;
using SoundsGoodCRM.Core.Entities.Orders;

namespace SoundsGoodCRM.Core.Entities.Instruments
{
    public class Instrument : EntityWithId
    {
        public int CustomerId { get; set; }
        public string SerialNumber { get; set; }
        public int InstrumentTuneId { get; set; }
        public int InstrumentTypeId { get; set; }
        public int InstrumentBrandId { get; set; }
        public int InstrumentModelId { get; set; }
        
        public InstrumentTune Tune { get; set; }
        public InstrumentType InstrumentType { get; set; }
        public InstrumentBrand InstrumentsBrand { get; set; }
        public InstrumentModel Model { get; set; }
        public Customer Customer { get; set; }
        public List<Order> Orders { get; set; }

    }
}
