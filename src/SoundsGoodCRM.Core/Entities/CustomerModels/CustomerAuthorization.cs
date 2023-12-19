namespace SoundsGoodCRM.Core.Entities.Customers
{
    public class CustomerAuthorization : EntityWithId
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Customer Customer { get; set; }
    }
}
