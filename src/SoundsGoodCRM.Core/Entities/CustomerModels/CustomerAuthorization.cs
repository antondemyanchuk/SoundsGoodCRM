namespace SoundsGoodCRM.Core.Entities.Customers
{
    public class CustomerAuthorization : EntityWithId
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public Customer Customer { get; set; }
    }
}
