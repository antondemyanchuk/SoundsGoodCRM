using SoundsGoodCRM.Core.Models;
using SoundsGoodCRM.Core.Models.Customer;

namespace SoundsGoodCRM.DAO.CustomerModels
{
    public class CustomerPostInfo : EntityWithId
    {
        public string PostProvider { get; set; }
        public string City { get; set; }
        public int PostCentreId { get; set; }
        public Customer Customer { get; set; }
    }
}
