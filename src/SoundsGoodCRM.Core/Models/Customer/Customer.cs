using SoundsGoodCRM.DAO.CustomerModels;
using SoundsGoodCRM.DAO.OrderModels;
using System.Diagnostics.Metrics;


namespace SoundsGoodCRM.Core.Models.Customer
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
        public Customer() { }
        public Customer(int id, string firstName, string lastName, int customerContactId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CustomerContactsId = customerContactId;
        }
    }
}
