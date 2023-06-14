using SoundsGoodCRM.DAO.InstrumentModels;
using SoundsGoodCRM.DAO.OrderModels;

namespace SoundsGoodCRM.DAO.CustomerModels
{
    public class Customer : EntityWithId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerContactsId { get; set; }
        public int CustomerPostInfoId { get; set; }
        public CustomerContact Contact { get; set; }
        public CustomerPostInfo PostInfo { get; set; }
        public List<Instrument> Instruments { get; set; }
        public List<Order> Orders { get; set; }
    }
}
