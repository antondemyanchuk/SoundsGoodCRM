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
    }
}
