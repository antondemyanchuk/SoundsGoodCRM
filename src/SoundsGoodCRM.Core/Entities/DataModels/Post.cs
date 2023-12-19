using SoundsGoodCRM.Core.Entities.Customers;

namespace SoundsGoodCRM.Core.Entities.DataModels
{
    public class Post : EntityWithId
    {
        public string PostProvider { get; set; }
        public string City { get; set; }
        public int PostCentreId { get; set; }
        public Customer Customer { get; set; }
    }
}
