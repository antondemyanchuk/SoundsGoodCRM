using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundsGoodCRM.DAO.CustomerModels
{
    public class CustomerContact : EntityWithId
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customer Customer { get; set; }

        public CustomerContact() { }
        public CustomerContact(int Id,string phoneNumber, string email)
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
