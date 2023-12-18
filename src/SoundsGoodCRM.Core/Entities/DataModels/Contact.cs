using SoundsGoodCRM.Core.Entities.Customers;
using SoundsGoodCRM.Entities.Employees;

namespace SoundsGoodCRM.Core.Entities.DataModels
{
    public class Contact : EntityWithId
    {
        public string PhoneNumberPrimary { get; set; }
        public string? PhoneNumberSecondary { get; set; }
        public string Email { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }

        public Contact() { }
        public Contact(int id, string phoneNumber, string email)
        {
            Id = id;
            PhoneNumberPrimary = phoneNumber;
            Email = email;
        }
        public Contact(int id, string phoneNumber, string phoneNumberSecondary, string email)
        {
            Id = id;
            PhoneNumberPrimary = phoneNumber;
            PhoneNumberSecondary = phoneNumberSecondary;
            Email = email;
        }
    }
}
