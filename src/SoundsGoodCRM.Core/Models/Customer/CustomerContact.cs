using SoundsGoodCRM.Core.Models;
using SoundsGoodCRM.Core.Models.Customer;


namespace SoundsGoodCRM.DAO.CustomerModels
{
    public class CustomerContact : EntityWithId
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customer Customer { get; set; }

        public CustomerContact() { }
        public CustomerContact(int id,string phoneNumber, string email)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
