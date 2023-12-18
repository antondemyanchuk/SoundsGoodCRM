using SoundsGoodCRM.Core.Entities.DataModels;
using SoundsGoodCRM.Core.Entities.Instruments;
using SoundsGoodCRM.Core.Entities.Orders;

namespace SoundsGoodCRM.Core.Entities.Customers
{
    public class Customer : EntityWithId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactId { get; set; }
        public int PostId { get; set; }
        public string CustomerAuthorizationId { get; set; }

        public Contact Contact { get; set; }
        public Post Post { get; set; }
        public CustomerAuthorization CustomerAuthorization { get; set; }
        public List<Instrument> Instruments { get; set; }
        public List<Order> Orders { get; set; }
        public Customer() { }
        public Customer(string firstName, string lastName, int contactId)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactId = contactId;
        }
    }
}
