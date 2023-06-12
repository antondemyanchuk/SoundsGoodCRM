using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoundsGoodCRM.Models.CustomerModels
{
    public class CustomerContact : EntityWithId
    {
        public string PhoneNumber { get; set; }
        public string? PhoneNumberAlternative { get; set; }
        public string Email { get; set; }
        public string? EmailAlternative { get; set; }
        public Customer Customer { get; set; }
    }
}
